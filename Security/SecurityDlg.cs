/** 
Licensed Materials - Property of IBM

IBM Cognos Products: DOCS

(C) Copyright IBM Corp. 2005, 2008

US Government Users Restricted Rights - Use, duplication or disclosure restricted by GSA ADP Schedule Contract with
IBM Corp.
*/
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using SamplesCommon;
using cognosdotnet_10_2;

namespace Security
{
	/// <summary>
	/// Summary description for SecurityDlg.
	/// </summary>
	public class SecurityDlg : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label ServerUrlLBL;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox securityOptionCB;
		private System.Windows.Forms.Button buttonRunOption;
		private System.Windows.Forms.RichTextBox resultsDisplayWindowRTB;
		private System.Windows.Forms.Label resultsDisplayWindowLBL;
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItemFile;
		private System.Windows.Forms.MenuItem menuItemExit;
		private System.Windows.Forms.MenuItem menuItemHelp;
        private System.Windows.Forms.MenuItem menuItemAbout;
        private IContainer components;
		private static SamplesConnect CBIConnection = null;
		private string savedUserName = "";
		private string savedNamespace = "";
		private System.Windows.Forms.TextBox serverUrlTB;
		private bool loggedIn = false;
			
		public SecurityDlg()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SecurityDlg));
            this.ServerUrlLBL = new System.Windows.Forms.Label();
            this.serverUrlTB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.securityOptionCB = new System.Windows.Forms.ComboBox();
            this.buttonRunOption = new System.Windows.Forms.Button();
            this.resultsDisplayWindowRTB = new System.Windows.Forms.RichTextBox();
            this.resultsDisplayWindowLBL = new System.Windows.Forms.Label();
            this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
            this.menuItemFile = new System.Windows.Forms.MenuItem();
            this.menuItemExit = new System.Windows.Forms.MenuItem();
            this.menuItemHelp = new System.Windows.Forms.MenuItem();
            this.menuItemAbout = new System.Windows.Forms.MenuItem();
            this.SuspendLayout();
            // 
            // ServerUrlLBL
            // 
            this.ServerUrlLBL.Location = new System.Drawing.Point(16, 13);
            this.ServerUrlLBL.Name = "ServerUrlLBL";
            this.ServerUrlLBL.Size = new System.Drawing.Size(144, 16);
            this.ServerUrlLBL.TabIndex = 0;
            this.ServerUrlLBL.Text = "Server URL";
            // 
            // serverUrlTB
            // 
            this.serverUrlTB.BackColor = System.Drawing.SystemColors.Control;
            this.serverUrlTB.Location = new System.Drawing.Point(16, 32);
            this.serverUrlTB.Name = "serverUrlTB";
            this.serverUrlTB.Size = new System.Drawing.Size(600, 20);
            this.serverUrlTB.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(160, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Choose Option";
            // 
            // securityOptionCB
            // 
            this.securityOptionCB.Location = new System.Drawing.Point(160, 88);
            this.securityOptionCB.Name = "securityOptionCB";
            this.securityOptionCB.Size = new System.Drawing.Size(160, 21);
            this.securityOptionCB.TabIndex = 3;
            // 
            // buttonRunOption
            // 
            this.buttonRunOption.Location = new System.Drawing.Point(336, 88);
            this.buttonRunOption.Name = "buttonRunOption";
            this.buttonRunOption.Size = new System.Drawing.Size(104, 24);
            this.buttonRunOption.TabIndex = 4;
            this.buttonRunOption.Text = "Run Option";
            this.buttonRunOption.Click += new System.EventHandler(this.buttonRunOption_Click);
            // 
            // resultsDisplayWindowRTB
            // 
            this.resultsDisplayWindowRTB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.resultsDisplayWindowRTB.BackColor = System.Drawing.SystemColors.Control;
            this.resultsDisplayWindowRTB.Location = new System.Drawing.Point(16, 136);
            this.resultsDisplayWindowRTB.Name = "resultsDisplayWindowRTB";
            this.resultsDisplayWindowRTB.Size = new System.Drawing.Size(600, 264);
            this.resultsDisplayWindowRTB.TabIndex = 5;
            this.resultsDisplayWindowRTB.Text = "";
            // 
            // resultsDisplayWindowLBL
            // 
            this.resultsDisplayWindowLBL.Location = new System.Drawing.Point(16, 120);
            this.resultsDisplayWindowLBL.Name = "resultsDisplayWindowLBL";
            this.resultsDisplayWindowLBL.Size = new System.Drawing.Size(128, 16);
            this.resultsDisplayWindowLBL.TabIndex = 6;
            this.resultsDisplayWindowLBL.Text = "Results Display Window";
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
            // SecurityDlg
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(632, 414);
            this.Controls.Add(this.resultsDisplayWindowLBL);
            this.Controls.Add(this.resultsDisplayWindowRTB);
            this.Controls.Add(this.buttonRunOption);
            this.Controls.Add(this.securityOptionCB);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.serverUrlTB);
            this.Controls.Add(this.ServerUrlLBL);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Menu = this.mainMenu1;
            this.Name = "SecurityDlg";
            this.Text = "Security Sample";
            this.Load += new System.EventHandler(this.SecurityDlg_Load);
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
			about.applicationName = "Security Sample";
			about.applicationVersion = "1.1";
			about.Show();
		}

		private void SecurityDlg_Load(object sender, System.EventArgs e)
		{
			// Check if the current user is logged in as Anonymous
			// if so, enable the check box.
			account myAccount = new account();
			baseClass[] bc = new baseClass[1];
			propEnum[] props = new propEnum[] { propEnum.searchPath, propEnum.defaultName };
			searchPathMultipleObject homeSearchPath = new searchPathMultipleObject();
			homeSearchPath.Value = "~";

			try
			{
				bc = CBIConnection.CBICMS.query(homeSearchPath, props, new sort[] {}, new queryOptions());
			}
			catch(System.Exception ex)
			{
				// Anonymous is OFF
				securityOptionCB.Items.Add("Get Logon Info");
				securityOptionCB.Items.Add("Logoff");
				securityOptionCB.SelectedIndex = 0;
				return;
			}
			if (bc != null)
			{
				// Anonymous is ON.
				securityOptionCB.Items.Add("Get Logon Info");
				securityOptionCB.Items.Add("Logon as a different user");
				securityOptionCB.Items.Add("Logoff");
				securityOptionCB.SelectedIndex = 0;
				return;
			}
		}

		// This function is the main driver for this sample.
		private void buttonRunOption_Click(object sender, System.EventArgs e)
		{
			clearDisplayWindow();
			string result = "";
			Security securityObj = new Security();
			string selectedOption = (string)securityOptionCB.SelectedItem;
			if ( (selectedOption == null) || (0 == selectedOption.CompareTo("")) )
			{
				MessageBox.Show("Please select a valid security option.");
				return;
			}

			if (0 == selectedOption.CompareTo("Get Logon Info"))
			{
				if (!isLoggedIn(CBIConnection.CBICMS))
				{
					try
					{
						if (securityObj.doLogon(CBIConnection, savedUserName, savedNamespace, ref result))
						{
							loggedIn = true;
						}
					}
					catch (System.Exception ex)
					{
						result = "logon failure: " + ex.Message + ".\n";
					}
				}
				result = "";
				securityObj.getLogonInfo(CBIConnection, ref result);
			}
			else if (0 == selectedOption.CompareTo("Logon as a different user"))
			{
				if (securityObj.doLogonAs(CBIConnection, savedUserName, savedNamespace, ref result))
				{
					loggedIn = true;
				}
			}
			else if (0 == selectedOption.CompareTo("Logoff"))
			{
				if (securityObj.doLogoff(CBIConnection, ref result))
				{
					loggedIn = false;
				}
			}
			displayMessage(result);
		}

		public bool isLoggedIn(contentManagerService1 cBICMS)
		{
			return ( isAnonymous(cBICMS) || loggedIn );
		}

		public bool isAnonymous(contentManagerService1 cBICMS)
		{
			bool doTestForAnonymous = false;
			try
			{
				searchPathMultipleObject homeSearchPath = new searchPathMultipleObject();
				homeSearchPath.Value = "~";

				baseClass[] bc =
					cBICMS.query(
					homeSearchPath,
					new propEnum[] {},
					new sort[] {},
					new queryOptions());
					if (bc != null)
					{
						doTestForAnonymous = true;
					}
					else
					{
						doTestForAnonymous = false;
					}
			}
			catch (System.Exception ex)
			{
				//Ignore this, it means that Anonymous access is denied...
			}

			return doTestForAnonymous;
		}

		public void setConnection(SamplesConnect cBIConnection, string cBIUrl, string userName, string userNamespace)
		{
			CBIConnection = cBIConnection;
			serverUrlTB.Text = cBIUrl;
			savedUserName = userName;
			savedNamespace = userNamespace;
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
