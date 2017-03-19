using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text.RegularExpressions;

namespace ifns_client_client
{
	public partial class ClientForm : Form
	{
		ChannelFactory<ifns_service_interface.IFDNSServerInterface> pipeFactory;
		ifns_service_interface.IFDNSServerInterface proxy;

		public ClientForm(bool visible)
		{
			InitializeComponent();
			pipeFactory = new ChannelFactory<ifns_service_interface.IFDNSServerInterface>(new BasicHttpBinding(), new EndpointAddress("http://localhost:8000/ifns_client_service"));
			pipeFactory.Open();
			proxy = pipeFactory.CreateChannel();
			ReadSync();
			if (!visible)
			{
				Hide();
			}
		}

		private void ErrorText(string text)
		{
			errorText.Text = text;
			errorText.ForeColor = Color.Red;
		}

		private void SuccessText(string text)
		{
			errorText.Text = text;
			errorText.ForeColor = Color.Green;
		}

		private void ReadSync()
		{
			try
			{
				keylist.Items.Clear();
				foreach (var key in proxy.GetAPIKeys())
				{
					keylist.Items.Add(key);
				}
				update_text.Text = proxy.GetLastUpdate().ToString();
				host_text.Text = proxy.GetHost();
				if (host_text.Text != "")
				{
					upload_check.Checked = true;
					apply_button.Enabled = true;
					host_text.Enabled = true;
				}
				else
				{
					upload_check.Checked = false;
					apply_button.Enabled = false;
					host_text.Enabled = false;
				}
				syncRemoteCheck.Checked = sync_button.Enabled = proxy.GetRemoteSync();
				UpdateHostList();
				SuccessText("");
			}
			catch (Exception ex)
			{
				ErrorText(ex.ToString());
			}
		}

		private void exit_button_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void close_button_Click(object sender, EventArgs e)
		{
			Hide();
		}


		private void UpdateHostList()
		{
			syncedHostsList.Items.Clear();
			var hostList = proxy.GetRemoteHosts();
			foreach (var host in hostList)
			{
				syncedHostsList.Items.Add(host);
			}
		}

		private void sync_button_Click(object sender, EventArgs e)
		{
			try
			{
				proxy.RefreshRemoteHosts();
				update_text.Text = proxy.GetLastUpdate().ToString();
				UpdateHostList();
				SuccessText("Synced");
			}
			catch (Exception ex)
			{
				ErrorText(ex.ToString());
			}
		}

		private void addhost_button_Click(object sender, EventArgs e)
		{
			try
			{
				if (addhost_text.Text != "")
				{
					proxy.AddAPIKey(addhost_text.Text);
					ReadSync();
					addhost_text.Text = "";
					SuccessText("Added");
				}
			}
			catch (Exception ex)
			{
				ErrorText(ex.ToString());
			}
		}

		private void delhost_button_Click(object sender, EventArgs e)
		{
			try
			{
				proxy.DelAPIKey((string)keylist.SelectedItem);
				ReadSync();
				SuccessText("");
			}
			catch (Exception ex)
			{
				ErrorText(ex.ToString());
			}
		}

		private bool ValidateHostText()
		{
			var r = new Regex("^[A-Za-z0-9_-]{1,255}$");
			if (!r.IsMatch(host_text.Text))
			{
				host_text.BackColor = Color.Red;
				return false;
			}
			host_text.BackColor = SystemColors.Window;
			return true;
		}

		private void upload_check_CheckedChanged(object sender, EventArgs e)
		{
			host_text.Enabled = upload_check.Checked;
			if (!upload_check.Checked)
			{
				try
				{
					apply_button.Enabled = false;
					proxy.StopHostPublish();
					SuccessText("");
					ReadSync();
				}
				catch (Exception ex)
				{
					ErrorText(ex.ToString());
				}
			}
			else
			{
				host_text.Focus();
			}
		}

		private void host_text_TextChanged(object sender, EventArgs e)
		{
			if (host_text.Text != "" && upload_check.Checked)
			{
				apply_button.Enabled = ValidateHostText();
			}
		}

		private void apply_button_Click(object sender, EventArgs e)
		{
			try
			{
				if (upload_check.Checked && ValidateHostText())
				{
					if (proxy.GetHost() != "")
					{
						proxy.StopHostPublish();
					}
					proxy.PublishHost(host_text.Text);
					ReadSync();
					SuccessText("Uploaded");
				}
			}
			catch (Exception ex)
			{
				ErrorText(ex.ToString());
			}
		}

		private void syncRemoteCheck_CheckedChanged(object sender, EventArgs e)
		{
			try
			{
				proxy.SetRemoteSync(syncRemoteCheck.Checked);
				sync_button.Enabled = syncRemoteCheck.Checked;
				SuccessText("");
			}
			catch (Exception ex)
			{
				ErrorText(ex.ToString());
			}
		}

		private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			Show();
		}

		private void ClientForm_Resize(object sender, EventArgs e)
		{
			if (WindowState == FormWindowState.Minimized)
			{
				Hide();
			}
		}

		private void showToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Show();
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Close();
		}
	}
}
