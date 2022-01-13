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
using SamplesCommon;
using cognosdotnet_10_2;

namespace CMQuery
{
	/// <summary>
	/// Summary description for CMQueryDlg.
	/// </summary>
	public class CMQueryDlg : System.Windows.Forms.Form
	{
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItemFile;
		private System.Windows.Forms.MenuItem menuItemExit;
		private System.Windows.Forms.MenuItem menuItemHelp;
		private System.Windows.Forms.MenuItem menuItemAbout;
		private System.Windows.Forms.Label ServerUrlLBL;
		private System.Windows.Forms.Button buttonExecuteQuery;
        private System.Windows.Forms.RichTextBox resultsDisplayWindowRTB;
        private IContainer components;
		private System.Windows.Forms.TextBox searchPathTB;
		private static contentManagerService1 cBIServer = null;
		private string userName = "";
		private string userPassword = "";
		private System.Windows.Forms.Label searchPathLBL;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox serverUrlTB;
		private string userNamespace = "";

		public CMQueryDlg()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CMQueryDlg));
            this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
            this.menuItemFile = new System.Windows.Forms.MenuItem();
            this.menuItemExit = new System.Windows.Forms.MenuItem();
            this.menuItemHelp = new System.Windows.Forms.MenuItem();
            this.menuItemAbout = new System.Windows.Forms.MenuItem();
            this.ServerUrlLBL = new System.Windows.Forms.Label();
            this.serverUrlTB = new System.Windows.Forms.TextBox();
            this.buttonExecuteQuery = new System.Windows.Forms.Button();
            this.resultsDisplayWindowRTB = new System.Windows.Forms.RichTextBox();
            this.searchPathTB = new System.Windows.Forms.TextBox();
            this.searchPathLBL = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
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
            // ServerUrlLBL
            // 
            this.ServerUrlLBL.Location = new System.Drawing.Point(16, 16);
            this.ServerUrlLBL.Name = "ServerUrlLBL";
            this.ServerUrlLBL.Size = new System.Drawing.Size(112, 16);
            this.ServerUrlLBL.TabIndex = 0;
            this.ServerUrlLBL.Text = "Server URL";
            // 
            // serverUrlTB
            // 
            this.serverUrlTB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.serverUrlTB.BackColor = System.Drawing.SystemColors.Control;
            this.serverUrlTB.Location = new System.Drawing.Point(16, 32);
            this.serverUrlTB.Name = "serverUrlTB";
            this.serverUrlTB.Size = new System.Drawing.Size(440, 20);
            this.serverUrlTB.TabIndex = 1;
            // 
            // buttonExecuteQuery
            // 
            this.buttonExecuteQuery.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonExecuteQuery.Location = new System.Drawing.Point(496, 24);
            this.buttonExecuteQuery.Name = "buttonExecuteQuery";
            this.buttonExecuteQuery.Size = new System.Drawing.Size(112, 40);
            this.buttonExecuteQuery.TabIndex = 2;
            this.buttonExecuteQuery.Text = "Execute";
            this.buttonExecuteQuery.Click += new System.EventHandler(this.buttonExecuteQuery_Click);
            // 
            // resultsDisplayWindowRTB
            // 
            this.resultsDisplayWindowRTB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.resultsDisplayWindowRTB.BackColor = System.Drawing.SystemColors.Control;
            this.resultsDisplayWindowRTB.Location = new System.Drawing.Point(24, 144);
            this.resultsDisplayWindowRTB.Name = "resultsDisplayWindowRTB";
            this.resultsDisplayWindowRTB.Size = new System.Drawing.Size(576, 232);
            this.resultsDisplayWindowRTB.TabIndex = 3;
            this.resultsDisplayWindowRTB.Text = "";
            // 
            // searchPathTB
            // 
            this.searchPathTB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.searchPathTB.Location = new System.Drawing.Point(16, 88);
            this.searchPathTB.Name = "searchPathTB";
            this.searchPathTB.Size = new System.Drawing.Size(592, 20);
            this.searchPathTB.TabIndex = 4;
            this.searchPathTB.Text = "/*";
            // 
            // searchPathLBL
            // 
            this.searchPathLBL.Location = new System.Drawing.Point(16, 72);
            this.searchPathLBL.Name = "searchPathLBL";
            this.searchPathLBL.Size = new System.Drawing.Size(72, 16);
            this.searchPathLBL.TabIndex = 5;
            this.searchPathLBL.Text = "Search Path";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Location = new System.Drawing.Point(16, 128);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(592, 256);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Results Display Window";
            // 
            // CMQueryDlg
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(624, 398);
            this.Controls.Add(this.resultsDisplayWindowRTB);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.searchPathLBL);
            this.Controls.Add(this.searchPathTB);
            this.Controls.Add(this.serverUrlTB);
            this.Controls.Add(this.buttonExecuteQuery);
            this.Controls.Add(this.ServerUrlLBL);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Menu = this.mainMenu1;
            this.Name = "CMQueryDlg";
            this.Text = "Content Manager Query Sample";
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
			about.applicationName = "Capabilities";
			about.applicationVersion = "1.1";
			about.Show();
		}

		private void buttonExecuteQuery_Click(object sender, System.EventArgs e)
		{
			string output = "";
			string searchPath = searchPathTB.Text;
			if ( (searchPath == null) || (0 == searchPath.CompareTo("")) )
			{
				MessageBox.Show("Please enter a valid search path");
				return;
			}
			displayMessage("Executing Query...");
			CMQuery queryObj = new CMQuery();
			output = queryObj.doQuery(cBIServer, searchPath, userName, userPassword, userNamespace, true);
			displayMessage(output);
		}

		public void setConnection(contentManagerService1 cBICMS, 
			string cBIUrl, 
			string uname, 
			string password, 
			string unamespace)
		{
			cBIServer = cBICMS;
			serverUrlTB.Text = cBIUrl;
			userName = uname;
			userPassword = password;
			userNamespace = unamespace;
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
