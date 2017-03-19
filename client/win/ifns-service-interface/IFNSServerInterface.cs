using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ifns_service_interface
{
	[ServiceContract]
	public interface IFDNSServerInterface
	{
		// Fetch host list from server and update local hosts file
		[OperationContract]
		void RefreshRemoteHosts();

		// Gets a list of remote hosts
		[OperationContract]
		IEnumerable<string> GetRemoteHosts();

		// If we sync remote hosts by default
		// sync - true means sync hosts be default
		[OperationContract]
		void SetRemoteSync(bool sync);

		// Get if we sync remote hosts be default
		[OperationContract]
		bool GetRemoteSync();

		// Last update time for host list
		[OperationContract]
		DateTime GetLastUpdate();

		// Add an API key to fetch / upload hosts (local config)
		// key - key to add
		[OperationContract]
		void AddAPIKey(string key);

		// Remove an API key (local config)
		// key - key to remove 
		[OperationContract]
		void DelAPIKey(string key);

		// Get a list of current API keys (local config)
		[OperationContract]
		IEnumerable<string> GetAPIKeys();

		// Publish this host to the server
		// name - hostname to use
		[OperationContract]
		void PublishHost(string name);

		// Remove this host from the server
		[OperationContract]
		void StopHostPublish();

		// Get the current hostname that is upload as this host
		[OperationContract]
		string GetHost();
	}
}
