using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Runtime.InteropServices;
using System.ServiceModel.Description;

public enum ServiceState
{
	SERVICE_STOPPED = 0x00000001,
	SERVICE_START_PENDING = 0x00000002,
	SERVICE_STOP_PENDING = 0x00000003,
	SERVICE_RUNNING = 0x00000004,
	SERVICE_CONTINUE_PENDING = 0x00000005,
	SERVICE_PAUSE_PENDING = 0x00000006,
	SERVICE_PAUSED = 0x00000007,
}

[StructLayout(LayoutKind.Sequential)]
public struct ServiceStatus
{
	public long dwServiceType;
	public ServiceState dwCurrentState;
	public long dwControlsAccepted;
	public long dwWin32ExitCode;
	public long dwServiceSpecificExitCode;
	public long dwCheckPoint;
	public long dwWaitHint;
};

namespace ifns_client_service
{
	public partial class IFDNSServiceHost : ServiceBase
	{
		[DllImport("advapi32.dll", SetLastError = true)]
		private static extern bool SetServiceStatus(IntPtr handle, ref ServiceStatus serviceStatus);

		public IFDNSServiceHost()
		{
			try
			{
				InitializeComponent();
				eventLog = new System.Diagnostics.EventLog();
				const string sourceName = "ifns-client-service";
				if (!System.Diagnostics.EventLog.SourceExists(sourceName))
				{
					System.Diagnostics.EventLog.CreateEventSource(sourceName, sourceName);
				}
				eventLog.Source = sourceName;
				eventLog.Log = sourceName;
			}
			catch (Exception e)
			{
				System.Diagnostics.Debug.Print("ifns-client-service: " + e.ToString());
			}
		}

		protected override void OnStart(string[] args)
		{
			ServiceStatus serviceStatus = new ServiceStatus();
			serviceStatus.dwCurrentState = ServiceState.SERVICE_START_PENDING;
			serviceStatus.dwWaitHint = 100000;
			SetServiceStatus(this.ServiceHandle, ref serviceStatus);

			eventLog.WriteEntry("Starting...");
			try
			{

				implementer = new ifns_service_interface.IFDNSServer();
				implementer.ReadConfiguration();
				wcfinterface = new ServiceHost(implementer, new Uri("http://localhost:8000"));
				wcfinterface.AddServiceEndpoint(typeof(ifns_service_interface.IFDNSServerInterface), new BasicHttpBinding(), "ifns_client_service");
				ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
				smb.HttpGetEnabled = true;
				wcfinterface.Description.Behaviors.Add(smb);
				wcfinterface.Open();
				eventLog.WriteEntry("Server launched");
				timer = new System.Timers.Timer();
				timer.Interval = 60000 * 20; // 20 min
				timer.Elapsed += new System.Timers.ElapsedEventHandler(this.OnTimer);
				timer.Start();

				// trigger initial sync
				OnTimer(null, null);

				serviceStatus.dwCurrentState = ServiceState.SERVICE_RUNNING;
				SetServiceStatus(this.ServiceHandle, ref serviceStatus);
			}
			catch (Exception e)
			{
				System.Diagnostics.Debug.Print("ifns-client-service: " + e.ToString());
				eventLog.WriteEntry("Error: " + e.ToString());
			}
		}

		protected override void OnStop()
		{
			eventLog.WriteEntry("Service Stopped");
			wcfinterface.Close();
			timer.Stop();

			ServiceStatus serviceStatus = new ServiceStatus();
			serviceStatus.dwCurrentState = ServiceState.SERVICE_STOPPED;
			SetServiceStatus(this.ServiceHandle, ref serviceStatus);
		}

		public void OnTimer(object sender, System.Timers.ElapsedEventArgs args)
		{
			eventLog.WriteEntry("Refresh");
			try
			{
				implementer.RefreshRemoteHosts();

				// if we are publishing, update the host record
				if (implementer.GetHost() != "")
				{
					implementer.PublishHost(implementer.GetHost());
				}
			}
			catch (Exception e)
			{
				eventLog.WriteEntry("Error: " + e.ToString());
			}
		}

		ServiceHost wcfinterface;
		EventLog eventLog;
		System.Timers.Timer timer;
		ifns_service_interface.IFDNSServer implementer;
	}
}
