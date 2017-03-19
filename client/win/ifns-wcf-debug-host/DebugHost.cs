using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Description;

// Test application for testing service outside of service process

namespace ifns_wcf_debug_host
{
	class DebugHost
	{
		static void Main(string[] args)
		{
			var implementer = new ifns_service_interface.IFDNSServer();
			implementer.ReadConfiguration();
			var wcfinterface = new ServiceHost(implementer, new Uri("http://localhost:8000"));
			wcfinterface.AddServiceEndpoint(typeof(ifns_service_interface.IFDNSServerInterface), new BasicHttpBinding(), "ifns_client_service");
			ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
			smb.HttpGetEnabled = true;
			wcfinterface.Description.Behaviors.Add(smb);
			wcfinterface.Open();
			implementer.RefreshRemoteHosts();
			Console.ReadLine();
			wcfinterface.Close();
		}
	}
}
