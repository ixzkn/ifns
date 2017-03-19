namespace ifns_client_client
{
	partial class ClientForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClientForm));
			this.exit_button = new System.Windows.Forms.Button();
			this.close_button = new System.Windows.Forms.Button();
			this.errorText = new System.Windows.Forms.Label();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.addKeyLabel = new System.Windows.Forms.Label();
			this.delhost_button = new System.Windows.Forms.Button();
			this.addhost_button = new System.Windows.Forms.Button();
			this.addhost_text = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.keylist = new System.Windows.Forms.ListBox();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.syncedHostsLabel = new System.Windows.Forms.Label();
			this.syncedHostsList = new System.Windows.Forms.ListBox();
			this.syncRemoteCheck = new System.Windows.Forms.CheckBox();
			this.sync_button = new System.Windows.Forms.Button();
			this.update_text = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.label3 = new System.Windows.Forms.Label();
			this.apply_button = new System.Windows.Forms.Button();
			this.host_text = new System.Windows.Forms.TextBox();
			this.upload_check = new System.Windows.Forms.CheckBox();
			this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
			this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.showToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.tabPage3.SuspendLayout();
			this.contextMenuStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// exit_button
			// 
			this.exit_button.Location = new System.Drawing.Point(5, 234);
			this.exit_button.Name = "exit_button";
			this.exit_button.Size = new System.Drawing.Size(75, 23);
			this.exit_button.TabIndex = 10;
			this.exit_button.Text = "Exit";
			this.exit_button.UseVisualStyleBackColor = true;
			this.exit_button.Click += new System.EventHandler(this.exit_button_Click);
			// 
			// close_button
			// 
			this.close_button.Location = new System.Drawing.Point(318, 234);
			this.close_button.Name = "close_button";
			this.close_button.Size = new System.Drawing.Size(75, 23);
			this.close_button.TabIndex = 11;
			this.close_button.Text = "Close";
			this.close_button.UseVisualStyleBackColor = true;
			this.close_button.Visible = false;
			this.close_button.Click += new System.EventHandler(this.close_button_Click);
			// 
			// errorText
			// 
			this.errorText.AutoSize = true;
			this.errorText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.errorText.ForeColor = System.Drawing.Color.Red;
			this.errorText.Location = new System.Drawing.Point(12, 218);
			this.errorText.Name = "errorText";
			this.errorText.Size = new System.Drawing.Size(0, 13);
			this.errorText.TabIndex = 16;
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Controls.Add(this.tabPage3);
			this.tabControl1.Location = new System.Drawing.Point(1, 3);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(396, 212);
			this.tabControl1.TabIndex = 17;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.addKeyLabel);
			this.tabPage1.Controls.Add(this.delhost_button);
			this.tabPage1.Controls.Add(this.addhost_button);
			this.tabPage1.Controls.Add(this.addhost_text);
			this.tabPage1.Controls.Add(this.label1);
			this.tabPage1.Controls.Add(this.keylist);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(388, 186);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "API Key";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// addKeyLabel
			// 
			this.addKeyLabel.AutoSize = true;
			this.addKeyLabel.Location = new System.Drawing.Point(7, 136);
			this.addKeyLabel.Name = "addKeyLabel";
			this.addKeyLabel.Size = new System.Drawing.Size(50, 13);
			this.addKeyLabel.TabIndex = 10;
			this.addKeyLabel.Text = "Add Key:";
			// 
			// delhost_button
			// 
			this.delhost_button.Location = new System.Drawing.Point(287, 124);
			this.delhost_button.Name = "delhost_button";
			this.delhost_button.Size = new System.Drawing.Size(94, 23);
			this.delhost_button.TabIndex = 9;
			this.delhost_button.Text = "Delete Selected";
			this.delhost_button.UseVisualStyleBackColor = true;
			this.delhost_button.Click += new System.EventHandler(this.delhost_button_Click);
			// 
			// addhost_button
			// 
			this.addhost_button.Location = new System.Drawing.Point(333, 153);
			this.addhost_button.Name = "addhost_button";
			this.addhost_button.Size = new System.Drawing.Size(48, 23);
			this.addhost_button.TabIndex = 8;
			this.addhost_button.Text = "Add";
			this.addhost_button.UseVisualStyleBackColor = true;
			this.addhost_button.Click += new System.EventHandler(this.addhost_button_Click);
			// 
			// addhost_text
			// 
			this.addhost_text.Location = new System.Drawing.Point(6, 155);
			this.addhost_text.Name = "addhost_text";
			this.addhost_text.Size = new System.Drawing.Size(321, 20);
			this.addhost_text.TabIndex = 7;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(3, 7);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(50, 13);
			this.label1.TabIndex = 6;
			this.label1.Text = "API Keys";
			// 
			// keylist
			// 
			this.keylist.FormattingEnabled = true;
			this.keylist.Location = new System.Drawing.Point(6, 23);
			this.keylist.Name = "keylist";
			this.keylist.Size = new System.Drawing.Size(375, 95);
			this.keylist.TabIndex = 5;
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.syncedHostsLabel);
			this.tabPage2.Controls.Add(this.syncedHostsList);
			this.tabPage2.Controls.Add(this.syncRemoteCheck);
			this.tabPage2.Controls.Add(this.sync_button);
			this.tabPage2.Controls.Add(this.update_text);
			this.tabPage2.Controls.Add(this.label2);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(388, 186);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Remote Hosts";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// syncedHostsLabel
			// 
			this.syncedHostsLabel.AutoSize = true;
			this.syncedHostsLabel.Location = new System.Drawing.Point(6, 80);
			this.syncedHostsLabel.Name = "syncedHostsLabel";
			this.syncedHostsLabel.Size = new System.Drawing.Size(73, 13);
			this.syncedHostsLabel.TabIndex = 20;
			this.syncedHostsLabel.Text = "Synced Hosts";
			// 
			// syncedHostsList
			// 
			this.syncedHostsList.FormattingEnabled = true;
			this.syncedHostsList.Location = new System.Drawing.Point(6, 96);
			this.syncedHostsList.Name = "syncedHostsList";
			this.syncedHostsList.Size = new System.Drawing.Size(375, 82);
			this.syncedHostsList.TabIndex = 19;
			// 
			// syncRemoteCheck
			// 
			this.syncRemoteCheck.AutoSize = true;
			this.syncRemoteCheck.Location = new System.Drawing.Point(7, 7);
			this.syncRemoteCheck.Name = "syncRemoteCheck";
			this.syncRemoteCheck.Size = new System.Drawing.Size(153, 17);
			this.syncRemoteCheck.TabIndex = 18;
			this.syncRemoteCheck.Text = "Synchronize Remote Hosts";
			this.syncRemoteCheck.UseVisualStyleBackColor = true;
			this.syncRemoteCheck.CheckedChanged += new System.EventHandler(this.syncRemoteCheck_CheckedChanged);
			// 
			// sync_button
			// 
			this.sync_button.Location = new System.Drawing.Point(307, 56);
			this.sync_button.Name = "sync_button";
			this.sync_button.Size = new System.Drawing.Size(75, 23);
			this.sync_button.TabIndex = 17;
			this.sync_button.Text = "Sync Now";
			this.sync_button.UseVisualStyleBackColor = true;
			this.sync_button.Click += new System.EventHandler(this.sync_button_Click);
			// 
			// update_text
			// 
			this.update_text.Enabled = false;
			this.update_text.Location = new System.Drawing.Point(85, 30);
			this.update_text.Name = "update_text";
			this.update_text.Size = new System.Drawing.Size(297, 20);
			this.update_text.TabIndex = 16;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(4, 33);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(54, 13);
			this.label2.TabIndex = 15;
			this.label2.Text = "Last Sync";
			// 
			// tabPage3
			// 
			this.tabPage3.Controls.Add(this.label3);
			this.tabPage3.Controls.Add(this.apply_button);
			this.tabPage3.Controls.Add(this.host_text);
			this.tabPage3.Controls.Add(this.upload_check);
			this.tabPage3.Location = new System.Drawing.Point(4, 22);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage3.Size = new System.Drawing.Size(388, 186);
			this.tabPage3.TabIndex = 2;
			this.tabPage3.Text = "This Host";
			this.tabPage3.UseVisualStyleBackColor = true;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(4, 33);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(55, 13);
			this.label3.TabIndex = 19;
			this.label3.Text = "Hostname";
			// 
			// apply_button
			// 
			this.apply_button.Location = new System.Drawing.Point(307, 56);
			this.apply_button.Name = "apply_button";
			this.apply_button.Size = new System.Drawing.Size(75, 23);
			this.apply_button.TabIndex = 18;
			this.apply_button.Text = "Upload";
			this.apply_button.UseVisualStyleBackColor = true;
			this.apply_button.Click += new System.EventHandler(this.apply_button_Click);
			// 
			// host_text
			// 
			this.host_text.Location = new System.Drawing.Point(85, 30);
			this.host_text.Name = "host_text";
			this.host_text.Size = new System.Drawing.Size(297, 20);
			this.host_text.TabIndex = 17;
			this.host_text.TextChanged += new System.EventHandler(this.host_text_TextChanged);
			// 
			// upload_check
			// 
			this.upload_check.AutoSize = true;
			this.upload_check.Location = new System.Drawing.Point(4, 7);
			this.upload_check.Name = "upload_check";
			this.upload_check.Size = new System.Drawing.Size(107, 17);
			this.upload_check.TabIndex = 16;
			this.upload_check.Text = "Upload This Host";
			this.upload_check.UseVisualStyleBackColor = true;
			this.upload_check.CheckedChanged += new System.EventHandler(this.upload_check_CheckedChanged);
			// 
			// notifyIcon
			// 
			this.notifyIcon.BalloonTipText = "IFDNS Client";
			this.notifyIcon.ContextMenuStrip = this.contextMenuStrip;
			this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
			this.notifyIcon.Text = "notifyIcon";
			this.notifyIcon.Visible = true;
			this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
			// 
			// contextMenuStrip
			// 
			this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showToolStripMenuItem,
            this.exitToolStripMenuItem});
			this.contextMenuStrip.Name = "contextMenuStrip";
			this.contextMenuStrip.Size = new System.Drawing.Size(100, 48);
			// 
			// showToolStripMenuItem
			// 
			this.showToolStripMenuItem.Name = "showToolStripMenuItem";
			this.showToolStripMenuItem.Size = new System.Drawing.Size(99, 22);
			this.showToolStripMenuItem.Text = "Show";
			this.showToolStripMenuItem.Click += new System.EventHandler(this.showToolStripMenuItem_Click);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(99, 22);
			this.exitToolStripMenuItem.Text = "Exit";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
			// 
			// ClientForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(396, 263);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.errorText);
			this.Controls.Add(this.close_button);
			this.Controls.Add(this.exit_button);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ClientForm";
			this.Text = "IFNS Client";
			this.Resize += new System.EventHandler(this.ClientForm_Resize);
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			this.tabPage2.ResumeLayout(false);
			this.tabPage2.PerformLayout();
			this.tabPage3.ResumeLayout(false);
			this.tabPage3.PerformLayout();
			this.contextMenuStrip.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button exit_button;
		private System.Windows.Forms.Button close_button;
		private System.Windows.Forms.Label errorText;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.Label addKeyLabel;
		private System.Windows.Forms.Button delhost_button;
		private System.Windows.Forms.Button addhost_button;
		private System.Windows.Forms.TextBox addhost_text;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ListBox keylist;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.Label syncedHostsLabel;
		private System.Windows.Forms.ListBox syncedHostsList;
		private System.Windows.Forms.CheckBox syncRemoteCheck;
		private System.Windows.Forms.Button sync_button;
		private System.Windows.Forms.TextBox update_text;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TabPage tabPage3;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button apply_button;
		private System.Windows.Forms.TextBox host_text;
		private System.Windows.Forms.CheckBox upload_check;
		private System.Windows.Forms.NotifyIcon notifyIcon;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
		private System.Windows.Forms.ToolStripMenuItem showToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
	}
}

