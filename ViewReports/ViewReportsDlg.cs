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
using System.Web.Services.Protocols;
using SamplesCommon;
using cognosdotnet_10_2;

namespace ViewReports
{
	/// <summary>
	/// Summary description for ViewReportsDlg.
	/// </summary>
	public class ViewReportsDlg : System.Windows.Forms.Form
	{
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItemFile;
		private System.Windows.Forms.MenuItem menuItemExit;
		private System.Windows.Forms.MenuItem menuItemHelp;
		private System.Windows.Forms.MenuItem menuItemAbout;
		private System.Windows.Forms.Label BIServerURLLBL;
		private System.Windows.Forms.Button viewReportsButton;
		private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox resultsDisplayWindowRTB;
        private IContainer components;
		private System.Windows.Forms.TextBox serverUrlTB;
		private contentManagerService1 cBIServer = null;

		public ViewReportsDlg()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewReportsDlg));
            this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
            this.menuItemFile = new System.Windows.Forms.MenuItem();
            this.menuItemExit = new System.Windows.Forms.MenuItem();
            this.menuItemHelp = new System.Windows.Forms.MenuItem();
            this.menuItemAbout = new System.Windows.Forms.MenuItem();
            this.BIServerURLLBL = new System.Windows.Forms.Label();
            this.serverUrlTB = new System.Windows.Forms.TextBox();
            this.viewReportsButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.resultsDisplayWindowRTB = new System.Windows.Forms.RichTextBox();
            this.groupBox1.SuspendLayout();
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
            // BIServerURLLBL
            // 
            this.BIServerURLLBL.Location = new System.Drawing.Point(24, 16);
            this.BIServerURLLBL.Name = "BIServerURLLBL";
            this.BIServerURLLBL.Size = new System.Drawing.Size(147, 24);
            this.BIServerURLLBL.TabIndex = 0;
            this.BIServerURLLBL.Text = "Server URL";
            this.BIServerURLLBL.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // serverUrlTB
            // 
            this.serverUrlTB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.serverUrlTB.BackColor = System.Drawing.SystemColors.Control;
            this.serverUrlTB.Location = new System.Drawing.Point(177, 16);
            this.serverUrlTB.Name = "serverUrlTB";
            this.serverUrlTB.Size = new System.Drawing.Size(487, 20);
            this.serverUrlTB.TabIndex = 1;
            // 
            // viewReportsButton
            // 
            this.viewReportsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.viewReportsButton.Location = new System.Drawing.Point(576, 48);
            this.viewReportsButton.Name = "viewReportsButton";
            this.viewReportsButton.Size = new System.Drawing.Size(88, 32);
            this.viewReportsButton.TabIndex = 2;
            this.viewReportsButton.Text = "View Reports";
            this.viewReportsButton.Click += new System.EventHandler(this.viewReportsButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.resultsDisplayWindowRTB);
            this.groupBox1.Location = new System.Drawing.Point(16, 88);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(648, 304);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Results Display Window";
            // 
            // resultsDisplayWindowRTB
            // 
            this.resultsDisplayWindowRTB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.resultsDisplayWindowRTB.BackColor = System.Drawing.SystemColors.Control;
            this.resultsDisplayWindowRTB.Location = new System.Drawing.Point(8, 16);
            this.resultsDisplayWindowRTB.Name = "resultsDisplayWindowRTB";
            this.resultsDisplayWindowRTB.Size = new System.Drawing.Size(632, 280);
            this.resultsDisplayWindowRTB.TabIndex = 0;
            this.resultsDisplayWindowRTB.Text = "";
            // 
            // ViewReportsDlg
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(680, 401);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.viewReportsButton);
            this.Controls.Add(this.serverUrlTB);
            this.Controls.Add(this.BIServerURLLBL);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Menu = this.mainMenu1;
            this.Name = "ViewReportsDlg";
            this.Text = "ViewReportsDlg";
            this.groupBox1.ResumeLayout(false);
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
			about.applicationName = "ViewReports Sample";
			about.applicationVersion = "1.1";
			about.Show();
		}

		private void viewReportsButton_Click(object sender, System.EventArgs e)
		{
			string resultMessage = "";
			clearResultsWindow();
			try
			{
				ViewReports viewReportsObj = new ViewReports();
				displayMessage("Sending queries...");
				viewReportsObj.doViewReportsAndQueries(cBIServer, ref resultMessage);
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
					SamplesException.ShowExceptionMessage( ex.Message, true, "ViewReports Sample" );					
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
