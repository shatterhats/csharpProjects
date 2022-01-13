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

namespace ViewPackages
{
	/// <summary>
	/// Summary description for ViewPackagesDlg.
	/// </summary>
	public class ViewPackagesDlg : System.Windows.Forms.Form
	{
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItemFile;
		private System.Windows.Forms.MenuItem menuItemExit;
		private System.Windows.Forms.MenuItem menuItemHelp;
		private System.Windows.Forms.MenuItem menuItemAbout;
		private System.Windows.Forms.Label ServerUrlLBL;
		private System.Windows.Forms.Button buttonViewPackages;
        private System.Windows.Forms.GroupBox resultsDisplayWindoRTB;
        private IContainer components;
		private System.Windows.Forms.RichTextBox resultsDisplayWindowRTB;
		private System.Windows.Forms.TextBox serverUrlTB;
		private contentManagerService1 cBIServer = null;


		public ViewPackagesDlg()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewPackagesDlg));
            this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
            this.menuItemFile = new System.Windows.Forms.MenuItem();
            this.menuItemExit = new System.Windows.Forms.MenuItem();
            this.menuItemHelp = new System.Windows.Forms.MenuItem();
            this.menuItemAbout = new System.Windows.Forms.MenuItem();
            this.ServerUrlLBL = new System.Windows.Forms.Label();
            this.serverUrlTB = new System.Windows.Forms.TextBox();
            this.buttonViewPackages = new System.Windows.Forms.Button();
            this.resultsDisplayWindoRTB = new System.Windows.Forms.GroupBox();
            this.resultsDisplayWindowRTB = new System.Windows.Forms.RichTextBox();
            this.resultsDisplayWindoRTB.SuspendLayout();
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
            this.ServerUrlLBL.Size = new System.Drawing.Size(137, 16);
            this.ServerUrlLBL.TabIndex = 0;
            this.ServerUrlLBL.Text = "Server URL";
            this.ServerUrlLBL.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // serverUrlTB
            // 
            this.serverUrlTB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.serverUrlTB.BackColor = System.Drawing.SystemColors.Control;
            this.serverUrlTB.Location = new System.Drawing.Point(159, 16);
            this.serverUrlTB.Name = "serverUrlTB";
            this.serverUrlTB.Size = new System.Drawing.Size(513, 20);
            this.serverUrlTB.TabIndex = 1;
            // 
            // buttonViewPackages
            // 
            this.buttonViewPackages.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonViewPackages.Location = new System.Drawing.Point(568, 56);
            this.buttonViewPackages.Name = "buttonViewPackages";
            this.buttonViewPackages.Size = new System.Drawing.Size(104, 40);
            this.buttonViewPackages.TabIndex = 2;
            this.buttonViewPackages.Text = "View Packages";
            this.buttonViewPackages.Click += new System.EventHandler(this.buttonViewPackages_Click);
            // 
            // resultsDisplayWindoRTB
            // 
            this.resultsDisplayWindoRTB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.resultsDisplayWindoRTB.Controls.Add(this.resultsDisplayWindowRTB);
            this.resultsDisplayWindoRTB.Location = new System.Drawing.Point(16, 104);
            this.resultsDisplayWindoRTB.Name = "resultsDisplayWindoRTB";
            this.resultsDisplayWindoRTB.Size = new System.Drawing.Size(656, 296);
            this.resultsDisplayWindoRTB.TabIndex = 3;
            this.resultsDisplayWindoRTB.TabStop = false;
            this.resultsDisplayWindoRTB.Text = "Results Display Window";
            // 
            // resultsDisplayWindowRTB
            // 
            this.resultsDisplayWindowRTB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.resultsDisplayWindowRTB.BackColor = System.Drawing.SystemColors.Control;
            this.resultsDisplayWindowRTB.Location = new System.Drawing.Point(8, 16);
            this.resultsDisplayWindowRTB.Name = "resultsDisplayWindowRTB";
            this.resultsDisplayWindowRTB.Size = new System.Drawing.Size(640, 272);
            this.resultsDisplayWindowRTB.TabIndex = 0;
            this.resultsDisplayWindowRTB.Text = "";
            // 
            // ViewPackagesDlg
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(696, 417);
            this.Controls.Add(this.resultsDisplayWindoRTB);
            this.Controls.Add(this.buttonViewPackages);
            this.Controls.Add(this.serverUrlTB);
            this.Controls.Add(this.ServerUrlLBL);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Menu = this.mainMenu1;
            this.Name = "ViewPackagesDlg";
            this.Text = "ViewPackagesDlg";
            this.resultsDisplayWindoRTB.ResumeLayout(false);
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
			about.applicationName = "ViewPackages Sample";
			about.applicationVersion = "1.1";
			about.Show();
		}

		private void buttonViewPackages_Click(object sender, System.EventArgs e)
		{
			string resultMessage = "";
			clearResultsWindow();
			try
			{
				ViewPackages viewPackagesObj = new ViewPackages();
				displayMessage("Sending queries...");
				viewPackagesObj.doViewPackages(cBIServer, ref resultMessage);
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
					SamplesException.ShowExceptionMessage( ex.Message, true, "ViewPackages Sample" );					
				}
				return;
			}
		}

		public void setConnection(contentManagerService1 cBICMS, string cBIUrl)
		{
			cBIServer = cBICMS;
			serverUrlTB.Text = cBIUrl;
		}

		public void displayMessage(string message)
		{
			resultsDisplayWindowRTB.AppendText(message + "\n");
		}

		public void clearResultsWindow()
		{
			resultsDisplayWindowRTB.Clear();
		}

	}
}
