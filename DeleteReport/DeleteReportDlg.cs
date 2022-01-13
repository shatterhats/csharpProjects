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

namespace DeleteReport
{
	/// <summary>
	/// Summary description for DeleteReportDlg.
	/// </summary>
	public class DeleteReportDlg : System.Windows.Forms.Form
	{
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItemFile;
		private System.Windows.Forms.MenuItem menuItemExit;
		private System.Windows.Forms.MenuItem menuItemHelp;
		private System.Windows.Forms.MenuItem menuItemAbout;
		private System.Windows.Forms.Label ServerUrlLBL;
		private System.Windows.Forms.ComboBox reportListCB;
		private System.Windows.Forms.Label reportNameLBL;
		private System.Windows.Forms.Button buttonDeleteReport;
        private System.Windows.Forms.RichTextBox resultsDisplayWindowRTB;
        private IContainer components;
		private System.Windows.Forms.TextBox reportSearchPathTB;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox serverUrlTB;
		private static contentManagerService1 cBIServer = null;

		public DeleteReportDlg()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeleteReportDlg));
            this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
            this.menuItemFile = new System.Windows.Forms.MenuItem();
            this.menuItemExit = new System.Windows.Forms.MenuItem();
            this.menuItemHelp = new System.Windows.Forms.MenuItem();
            this.menuItemAbout = new System.Windows.Forms.MenuItem();
            this.ServerUrlLBL = new System.Windows.Forms.Label();
            this.serverUrlTB = new System.Windows.Forms.TextBox();
            this.reportListCB = new System.Windows.Forms.ComboBox();
            this.reportNameLBL = new System.Windows.Forms.Label();
            this.buttonDeleteReport = new System.Windows.Forms.Button();
            this.resultsDisplayWindowRTB = new System.Windows.Forms.RichTextBox();
            this.reportSearchPathTB = new System.Windows.Forms.TextBox();
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
            this.ServerUrlLBL.Size = new System.Drawing.Size(136, 16);
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
            this.serverUrlTB.Size = new System.Drawing.Size(584, 20);
            this.serverUrlTB.TabIndex = 1;
            // 
            // reportListCB
            // 
            this.reportListCB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.reportListCB.Location = new System.Drawing.Point(16, 88);
            this.reportListCB.Name = "reportListCB";
            this.reportListCB.Size = new System.Drawing.Size(456, 21);
            this.reportListCB.TabIndex = 3;
            this.reportListCB.SelectedIndexChanged += new System.EventHandler(this.reportListCB_SelectedIndexChanged);
            // 
            // reportNameLBL
            // 
            this.reportNameLBL.Location = new System.Drawing.Point(16, 72);
            this.reportNameLBL.Name = "reportNameLBL";
            this.reportNameLBL.Size = new System.Drawing.Size(72, 16);
            this.reportNameLBL.TabIndex = 4;
            this.reportNameLBL.Text = "Report Name";
            // 
            // buttonDeleteReport
            // 
            this.buttonDeleteReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDeleteReport.Location = new System.Drawing.Point(496, 80);
            this.buttonDeleteReport.Name = "buttonDeleteReport";
            this.buttonDeleteReport.Size = new System.Drawing.Size(104, 40);
            this.buttonDeleteReport.TabIndex = 5;
            this.buttonDeleteReport.Text = "Delete";
            this.buttonDeleteReport.Click += new System.EventHandler(this.buttonDeleteReport_Click);
            // 
            // resultsDisplayWindowRTB
            // 
            this.resultsDisplayWindowRTB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.resultsDisplayWindowRTB.BackColor = System.Drawing.SystemColors.Control;
            this.resultsDisplayWindowRTB.Location = new System.Drawing.Point(24, 208);
            this.resultsDisplayWindowRTB.Name = "resultsDisplayWindowRTB";
            this.resultsDisplayWindowRTB.Size = new System.Drawing.Size(568, 176);
            this.resultsDisplayWindowRTB.TabIndex = 6;
            this.resultsDisplayWindowRTB.Text = "";
            // 
            // reportSearchPathTB
            // 
            this.reportSearchPathTB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.reportSearchPathTB.BackColor = System.Drawing.SystemColors.Control;
            this.reportSearchPathTB.Location = new System.Drawing.Point(16, 136);
            this.reportSearchPathTB.Name = "reportSearchPathTB";
            this.reportSearchPathTB.Size = new System.Drawing.Size(584, 20);
            this.reportSearchPathTB.TabIndex = 8;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Location = new System.Drawing.Point(16, 192);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(584, 200);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Results Display Window";
            // 
            // DeleteReportDlg
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(616, 406);
            this.Controls.Add(this.reportSearchPathTB);
            this.Controls.Add(this.serverUrlTB);
            this.Controls.Add(this.resultsDisplayWindowRTB);
            this.Controls.Add(this.buttonDeleteReport);
            this.Controls.Add(this.reportNameLBL);
            this.Controls.Add(this.reportListCB);
            this.Controls.Add(this.ServerUrlLBL);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Menu = this.mainMenu1;
            this.Name = "DeleteReportDlg";
            this.Text = "Delete Report Sample";
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
			about.applicationName = "Delete Report Sample";
			about.applicationVersion = "1.1";
			about.Show();
		}

		// This function is the main driver for this sample.
		private void buttonDeleteReport_Click(object sender, System.EventArgs e)
		{
			string resultMessage = "";
			clearResultsWindow();
			BaseClassWrapper selectedObject = (BaseClassWrapper)reportListCB.SelectedItem;
			try
			{
				if (selectedObject == null)
				{
					MessageBox.Show("Please select a valid entry.");
					return;
				}
				displayMessage("Deleting report: " + selectedObject.ToString() + " ...");
				DeleteReport deleteRep = new DeleteReport();
				deleteRep.doDeleteReport(cBIServer, selectedObject, ref resultMessage);
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
					SamplesException.ShowExceptionMessage( ex.Message, true, "DeleteReport Sample" );					
				}
				return;
			}
		}

		public void setReportList(BaseClassWrapper[] reportAndQueryList)
		{
			reportListCB.Items.AddRange(reportAndQueryList);
		}

		public void setSelectedReportIndex(int value)
		{
			reportListCB.SelectedIndex = value;
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

		private void reportListCB_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			BaseClassWrapper selectedObject = (BaseClassWrapper)reportListCB.SelectedItem;
			if (selectedObject == null)
			{
				return;
			}
			reportSearchPathTB.Text = selectedObject.searchPath.value;
		}
	}
}
