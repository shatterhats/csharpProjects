/** 
Licensed Materials - Property of IBM

IBM Cognos Products: DOCS

(C) Copyright IBM Corp. 2005

US Government Users Restricted Rights - Use, duplication or disclosure restricted by GSA ADP Schedule Contract with
IBM Corp.
*/
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Web.Services.Protocols;
using SamplesCommon;
using cognosdotnet_10_2;

namespace Permissions
{
	/// <summary>
	/// Summary description for PermissionsDlg.
	/// </summary>
	public class PermissionsDlg : System.Windows.Forms.Form
	{
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItemFile;
		private System.Windows.Forms.MenuItem menuItemExit;
		private System.Windows.Forms.MenuItem menuItemHelp;
		private System.Windows.Forms.MenuItem menuItemAbout;
		private System.Windows.Forms.Label serverUrlLBL;
		private System.Windows.Forms.TextBox serverUrlTB;
		private System.Windows.Forms.Button permissionsButton;
		private System.Windows.Forms.GroupBox resultsDisplayWindowLBL;
        private System.Windows.Forms.RichTextBox resultsDisplayWindowRTB;
        private IContainer components;
		private System.Windows.Forms.Label label1;
		public System.Windows.Forms.TextBox cBIPathTB;
		private contentManagerService1 cBICMS = null;

		public PermissionsDlg()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PermissionsDlg));
            this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
            this.menuItemFile = new System.Windows.Forms.MenuItem();
            this.menuItemExit = new System.Windows.Forms.MenuItem();
            this.menuItemHelp = new System.Windows.Forms.MenuItem();
            this.menuItemAbout = new System.Windows.Forms.MenuItem();
            this.serverUrlLBL = new System.Windows.Forms.Label();
            this.serverUrlTB = new System.Windows.Forms.TextBox();
            this.permissionsButton = new System.Windows.Forms.Button();
            this.resultsDisplayWindowLBL = new System.Windows.Forms.GroupBox();
            this.resultsDisplayWindowRTB = new System.Windows.Forms.RichTextBox();
            this.cBIPathTB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.resultsDisplayWindowLBL.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemFile,
            this.menuItemHelp});
            // 
            // menuItemFile
            // 
            this.menuItemFile.Index = 0;
            this.menuItemFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemExit});
            this.menuItemFile.Text = "File";
            // 
            // menuItemExit
            // 
            this.menuItemExit.Index = 0;
            this.menuItemExit.Text = "Exit";
            this.menuItemExit.Click += new System.EventHandler(this.menuItemExit_Click);
            // 
            // menuItemHelp
            // 
            this.menuItemHelp.Index = 1;
            this.menuItemHelp.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemAbout});
            this.menuItemHelp.Text = "Help";
            // 
            // menuItemAbout
            // 
            this.menuItemAbout.Index = 0;
            this.menuItemAbout.Text = "About";
            this.menuItemAbout.Click += new System.EventHandler(this.menuItemAbout_Click);
            // 
            // serverUrlLBL
            // 
            this.serverUrlLBL.Location = new System.Drawing.Point(16, 16);
            this.serverUrlLBL.Name = "serverUrlLBL";
            this.serverUrlLBL.Size = new System.Drawing.Size(74, 16);
            this.serverUrlLBL.TabIndex = 0;
            this.serverUrlLBL.Text = "Server URL";
            // 
            // serverUrlTB
            // 
            this.serverUrlTB.BackColor = System.Drawing.SystemColors.Control;
            this.serverUrlTB.Location = new System.Drawing.Point(96, 16);
            this.serverUrlTB.Name = "serverUrlTB";
            this.serverUrlTB.Size = new System.Drawing.Size(536, 20);
            this.serverUrlTB.TabIndex = 1;
            // 
            // permissionsButton
            // 
            this.permissionsButton.Location = new System.Drawing.Point(648, 56);
            this.permissionsButton.Name = "permissionsButton";
            this.permissionsButton.Size = new System.Drawing.Size(104, 40);
            this.permissionsButton.TabIndex = 2;
            this.permissionsButton.Text = "Set Permissions";
            this.permissionsButton.Click += new System.EventHandler(this.permissionsButton_Click);
            // 
            // resultsDisplayWindowLBL
            // 
            this.resultsDisplayWindowLBL.Controls.Add(this.resultsDisplayWindowRTB);
            this.resultsDisplayWindowLBL.Location = new System.Drawing.Point(16, 104);
            this.resultsDisplayWindowLBL.Name = "resultsDisplayWindowLBL";
            this.resultsDisplayWindowLBL.Size = new System.Drawing.Size(736, 248);
            this.resultsDisplayWindowLBL.TabIndex = 3;
            this.resultsDisplayWindowLBL.TabStop = false;
            this.resultsDisplayWindowLBL.Text = "Results Display Window";
            // 
            // resultsDisplayWindowRTB
            // 
            this.resultsDisplayWindowRTB.BackColor = System.Drawing.SystemColors.Control;
            this.resultsDisplayWindowRTB.Location = new System.Drawing.Point(8, 16);
            this.resultsDisplayWindowRTB.Name = "resultsDisplayWindowRTB";
            this.resultsDisplayWindowRTB.Size = new System.Drawing.Size(720, 224);
            this.resultsDisplayWindowRTB.TabIndex = 0;
            this.resultsDisplayWindowRTB.Text = "";
            // 
            // cBIPathTB
            // 
            this.cBIPathTB.BackColor = System.Drawing.SystemColors.Control;
            this.cBIPathTB.Location = new System.Drawing.Point(96, 64);
            this.cBIPathTB.Name = "cBIPathTB";
            this.cBIPathTB.Size = new System.Drawing.Size(536, 20);
            this.cBIPathTB.TabIndex = 4;
            this.cBIPathTB.Text = "/content/folder[@name=\'Samples\']/folder[@name=\'Models\']/package[@name=\'GO Sales (" +
                "query)\']/folder[@name=\'Report Studio Report Samples\']";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(16, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Search Path";
            // 
            // PermissionsDlg
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(776, 361);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cBIPathTB);
            this.Controls.Add(this.resultsDisplayWindowLBL);
            this.Controls.Add(this.permissionsButton);
            this.Controls.Add(this.serverUrlTB);
            this.Controls.Add(this.serverUrlLBL);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Menu = this.mainMenu1;
            this.Name = "PermissionsDlg";
            this.Text = "PermissionsDlg";
            this.resultsDisplayWindowLBL.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void menuItemExit_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void menuItemAbout_Click(object sender, System.EventArgs e)
		{
			SamplesAbout about = new SamplesAbout();
			about.applicationName = "Permissions Sample";
			about.applicationVersion = "1.1";
			about.Show();
		}

		private void permissionsButton_Click(object sender, System.EventArgs e)
		{
			string resultMessage = "";
			resultsDisplayWindowRTB.Clear();
			try
			{
				Permissions permObj = new Permissions();
				String searchPath = cBIPathTB.Text;
				permObj.setPermissions(cBICMS, ref resultMessage, searchPath);
				displayMessage(resultMessage);
			}
			catch(SoapException ex)
			{
				displayMessage("\n...the operation failed.\nThe following information was returned:");
				displayMessage(SamplesException.getExceptionMessage( ex));
				return;
			}
			catch(System.Exception ex)
			{
				if (0 != ex.Message.CompareTo("INPUT_CANCELLED_BY_USER"))
				{
					SamplesException.ShowExceptionMessage( ex.Message, true, "SetPermissions Sample" );					
				}
				return;
			}
		}

		public void setConnection(contentManagerService1 cmService, string cBIUrl)
		{
			cBICMS = cmService;
			serverUrlTB.Text = cBIUrl;
		}

		public void displayMessage(string message)
		{
			resultsDisplayWindowRTB.AppendText("\n" + message);
		}

		public void clearDisplayWindow()
		{
			resultsDisplayWindowRTB.Clear();
		}


	}
}
