using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ifns_client_client
{
	static class Client
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			bool hide = false;
			if (args != null && args.Length == 1 && args[0] == "/hide")
			{
				hide = true;
			}
			Application.Run(new ClientForm(hide));
		}
	}
}
