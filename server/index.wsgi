#!/usr/bin/env python
import psycopg2, re, json, base64, random, hashlib, time, os, ConfigParser, datetime
from email.utils import parseaddr
from wsgiref.util import *
from cgi import parse_qs, escape

# Input validation ########

def validHost(hostname):
	return re.match(r'^[A-Za-z0-9_-]{1,255}$',hostname) and hostname != "localhost"

def validAddress(address):
	return re.match(r'^(?:[0-9]{1,3}\.){3}[0-9]{1,3}$',address)

def validAPIKey(key):
	return re.match(r'^(?:[A-Za-z0-9+_/]{4})*(?:[A-Za-z0-9_+/]{2}==|[A-Za-z0-9+_/]{3}=)?$', key)

def validUserDesc(desc):
	# currently only accept email addresses
	parsed = parseaddr(desc)
	return '@' in parsed[1]

# Database functions ########

def verifyAPIKey(conn,key):
	"""
	Verify if a given key is valid.

	Args:
		conn - database connection
		key	 - API key
	"""
	if not validAPIKey(key):
		return False

	with conn.cursor() as cur:
		cur.execute("SELECT apikey FROM users WHERE apikey=%s;",(key,))
		return cur.fetchone() is not None

def createTables(conn):
	"""
	Create tables for new install.

	Args:
		conn - database connection
	"""
	with conn.cursor() as cur:
		cur.execute("CREATE TABLE users (apikey char(28) PRIMARY KEY UNIQUE, dsc varchar(50) NOT NULL);")
		cur.execute("CREATE TABLE hosts (id SERIAL PRIMARY KEY, name varchar(50) NOT NULL, apikey char(28) REFERENCES users(apikey) NOT NULL, address inet, timestamp timestamp default current_timestamp, UNIQUE(name,apikey));")
		conn.commit()

def checkCreateTables(conn):
	"""
	Check if tables dont exist or are old and do the right thing.
	Either creates or upgrades the tables.

	Args:
		conn - database connection
	"""
	cur = conn.cursor()
	result = None
	with conn.cursor() as cur:
		try:
			cur.execute("SELECT apikey FROM users LIMIT 1;")
			result = cur.fetchone()
			conn.commit()
		except psycopg2.ProgrammingError:
			conn.rollback()
	if result is None:
		createTables(conn)

def getHosts(cur, key):
	"""
	Return host data for a given API key.

	Args:
		cur - database cursor
		key - user api key
	"""
	cur.execute("SELECT name,address,timestamp FROM hosts WHERE apikey=%s;",(key,))
	result = cur.fetchall()
	if result is not None:
		keys = ['name','address','timestamp']
		result = map(lambda x: {keys[i]:v for i,v in enumerate(x)}, result)
	return result

# Response helpers ########

def ok_response(environ, start_response, obj):
	start_response('200 OK', [('Content-Type', 'application/json')])
	return [json.dumps(obj)]

def not_found(environ, start_response):
	"""
	For 404 responses.
	"""
	start_response('404 NOT FOUND', [('Content-Type', 'text/plain')])
	return ['Not Found']

def exception(environ, start_response, exc):
	"""
	For 500 responses.
	"""
	start_response('500 INTERNAL SERVER ERROR', [('Content-Type', 'text/plain')])
	return [str(exc)]

def auth_error(environ, start_response):
	"""
	For unauthorized responses.
	"""
	start_response('401 UNAUTHORIZED', [('Content-Type', 'text/plain')])
	return ['Unauthorized']

# Input ########

def getClientAddress(environ):
	try:
		return environ['HTTP_X_FORWARDED_FOR'].split(',')[-1].strip()
	except KeyError:
		return environ['REMOTE_ADDR']

def getRequestBody(environ, size_limit=255):
	try:
		request_body_size = min(int(environ.get('CONTENT_LENGTH', 0)), size_limit)
		request_body = str(environ['wsgi.input'].read(request_body_size)).strip()
	except:
		raise Exception("Expected request data")
	return request_body

# Commands ########

def make_user(environ, start_response, conn):
	"""
	Adding users.
	"""
	desc = ""
	try:
		desc = getRequestBody(environ).strip()
		if not validUserDesc(desc):
			return auth_error(environ, start_response)
	except:
		return auth_error(environ, start_response)

	key = base64.urlsafe_b64encode(hashlib.sha1(bytes(os.urandom(24))).digest())
	with conn.cursor() as cur:
		cur.execute("INSERT INTO users (apikey,dsc) VALUES (%s,%s);",(key,desc))
		conn.commit()
	return ok_response(environ, start_response, key)

def get_hosts(environ, start_response, conn, key):
	"""
	Page handler for getting host list.
	"""
	hosts = []
	with conn.cursor() as cur:
		hosts = getHosts(cur, key)

	# have to convert timestamp because it is not json seralizable
	for i,host in enumerate(hosts):
		hosts[i]['timestamp'] = str(host['timestamp'])
	
	return ok_response(environ, start_response, hosts)

def put_host(environ, start_response, conn, key, size_limit=255, count_limit=30):
	"""
	Page handler for putting hosts.
	"""
	request_body = getRequestBody(environ, size_limit).strip().lower()
	if not validHost(request_body):
		raise Exception("Invalid hostname")

	client_address = getClientAddress(environ)
	if not validAddress(client_address):
		raise Exception("Invalid address")

	with conn.cursor() as cur:
		cur.execute("INSERT INTO hosts (name,apikey,address,timestamp) VALUES (%s,%s,%s,%s) ON CONFLICT (name,apikey) DO UPDATE SET address = EXCLUDED.address, timestamp = EXCLUDED.timestamp;",(request_body, key, client_address, datetime.datetime.now()))
		# check for row limits
		cur.execute("SELECT count(*) FROM hosts WHERE apikey=%s;",(key,))
		count = cur.fetchone()[0]
		if count > count_limit:
			cur.execute("DELETE hosts WHERE name in (SELECT name FROM hosts WHERE name=%s AND apikey=%s ORDER BY time DESC LIMIT %s);",(request_bosy, key, count-count_limit))
		conn.commit()
	return ok_response(environ, start_response, True)

def del_host(environ, start_response, conn, key, size_limit=255):
	"""
	Page handler for deleting hosts.
	"""
	host = shift_path_info(environ).strip().lower()
	if not validHost(host):
		raise Exception("Invalid hostname")

	with conn.cursor() as cur:
		cur.execute("DELETE FROM hosts WHERE apikey=%s AND name=%s;",(key, host))
		conn.commit()
	return ok_response(environ, start_response, True)

request_count = 0
request_time = 0

def application(environ, start_response):
	"""
	Main application.

	Example usage:
		Create a new user: 
			POST an email address to /new
			Returns JSON string like: "AR7wW96IeSi7_5fdsOkstTRPqfE="
			This is your API key.
		Post a host: 
			POST host contents to /<apikey>/
			If hostname does not exist will create it.
		Get hosts:
			GET /<apikey>/
			Returns hosts for API key.
	"""
	try:
		# read configuration, location can be overidden with enviroment
		configfile = "/etc/idns.conf"
		if "IDNS_CONFIGURATION" in os.environ:
			configfile = os.environ["IDNS_CONFIGURATION"]
		config = ConfigParser.SafeConfigParser()
		config.read(configfile)

		# request limiting
		global request_count
		global request_time
		request_limit = config.getint("limits","request_limit")
		request_count = min(0,request_count - (int(time.time()) - request_time) * request_limit)
		request_time = int(time.time())
		if request_count > request_limit:
			raise Exception("Too many requests in one second.")

		# Connect to DB server
		# Note that connections with psycopg2 are stateful, so there
		# should be one per request.  Don't think we can share them.
		with psycopg2.connect(host=config.get("database","host"), 
							dbname=config.get("database","name"), 
							user=config.get("database","user"), 
							password=config.get("database","password")) as conn:
			checkCreateTables(conn)

			# user validation
			try:
				user = environ['HTTP_X_API_KEY']
			except:
				return auth_error(environ, start_response)
			
			# check for the new user creation key:
			if user == config.get("server","new_user_key"):
				# create and return new user
				return make_user(environ, start_response, conn)
			else:
				# validate
				if not verifyAPIKey(conn, user):
					return auth_error(environ, start_response)

			# command
			if environ['REQUEST_METHOD'] == 'POST':
				return put_host(environ, start_response, conn, user, 
								size_limit=config.getint("limits","size_limit"), 
								count_limit=config.getint("limits","count_limit"))
			elif environ['REQUEST_METHOD'] == 'DELETE':
				return del_host(environ, start_response, conn, user,
								size_limit=config.getint("limits","size_limit"))
			else:
				return get_hosts(environ, start_response, conn, user)
	except Exception as e:
		return exception(environ, start_response, e)
