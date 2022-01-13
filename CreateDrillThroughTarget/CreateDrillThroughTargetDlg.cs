/** 
Licensed Materials - Property of IBM

IBM Cognos Products: DOCS

(C) Copyright IBM Corp. 2005

US Government Users Restricted Rights - Use, duplication or disclosure restricted by GSA ADP Schedule Contract with
IBM Corp.
*/
using System;
using System.IO;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Web.Services.Protocols;
using SamplesCommon;
using cognosdotnet_10_2;

namespace CreateDrillThroughTarget
{
	/// <summary>
	/// Summary description for CreateDrillThroughTargetDlg.
	/// </summary>
	public class CreateDrillThroughTargetDlg : System.Windows.Forms.Form
	{
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItemFile;
		private System.Windows.Forms.MenuItem menuItemExit;
		private System.Windows.Forms.MenuItem menuItemHelp;
        private System.Windows.Forms.MenuItem menuItemAbout;
        private IContainer components;
		private System.Windows.Forms.Button buttonCreateDrillThroughTarget;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label reportNameLBL;
		private System.Windows.Forms.ComboBox reportListCB;
		private AxSHDocVw.AxWebBrowser outputBrowser;
		private System.Windows.Forms.TextBox reportSearchPathTB;
		private System.Windows.Forms.TextBox serverUrlTB;
		private static contentManagerService1 cBIServer = null;
		private static reportService1 cBIRS = null;
        private ComboBox packageListCB;
        private Label packageLabel;
		private static SamplesConnect cBIConnection = null;
        private CreateDrillThroughTarget dtTarget = new CreateDrillThroughTarget();

		public CreateDrillThroughTargetDlg()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateDrillThroughTargetDlg));
            this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
            this.menuItemFile = new System.Windows.Forms.MenuItem();
            this.menuItemExit = new System.Windows.Forms.MenuItem();
            this.menuItemHelp = new System.Windows.Forms.MenuItem();
            this.menuItemAbout = new System.Windows.Forms.MenuItem();
            this.buttonCreateDrillThroughTarget = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.serverUrlTB = new System.Windows.Forms.TextBox();
            this.reportNameLBL = new System.Windows.Forms.Label();
            this.reportListCB = new System.Windows.Forms.ComboBox();
            this.outputBrowser = new AxSHDocVw.AxWebBrowser();
            this.reportSearchPathTB = new System.Windows.Forms.TextBox();
            this.packageListCB = new System.Windows.Forms.ComboBox();
            this.packageLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.outputBrowser)).BeginInit();
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
            // buttonCreateDrillThroughTarget
            // 
            this.buttonCreateDrillThroughTarget.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCreateDrillThroughTarget.Location = new System.Drawing.Point(560, 136);
            this.buttonCreateDrillThroughTarget.Name = "buttonCreateDrillThroughTarget";
            this.buttonCreateDrillThroughTarget.Size = new System.Drawing.Size(125, 46);
            this.buttonCreateDrillThroughTarget.TabIndex = 0;
            this.buttonCreateDrillThroughTarget.Text = "Create Target";
            this.buttonCreateDrillThroughTarget.Click += new System.EventHandler(this.buttonCreateDrillThroughTarget_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(19, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(199, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "Server URL";
            // 
            // serverUrlTB
            // 
            this.serverUrlTB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.serverUrlTB.BackColor = System.Drawing.SystemColors.Control;
            this.serverUrlTB.Location = new System.Drawing.Point(19, 37);
            this.serverUrlTB.Name = "serverUrlTB";
            this.serverUrlTB.Size = new System.Drawing.Size(666, 22);
            this.serverUrlTB.TabIndex = 2;
            // 
            // reportNameLBL
            // 
            this.reportNameLBL.Location = new System.Drawing.Point(19, 125);
            this.reportNameLBL.Name = "reportNameLBL";
            this.reportNameLBL.Size = new System.Drawing.Size(96, 18);
            this.reportNameLBL.TabIndex = 3;
            this.reportNameLBL.Text = "Report Name";
            // 
            // reportListCB
            // 
            this.reportListCB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.reportListCB.Enabled = false;
            this.reportListCB.Location = new System.Drawing.Point(19, 155);
            this.reportListCB.Name = "reportListCB";
            this.reportListCB.Size = new System.Drawing.Size(522, 24);
            this.reportListCB.TabIndex = 4;
            this.reportListCB.SelectedIndexChanged += new System.EventHandler(this.reportListCB_SelectedIndexChanged);
            // 
            // outputBrowser
            // 
            this.outputBrowser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.outputBrowser.Enabled = true;
            this.outputBrowser.Location = new System.Drawing.Point(19, 255);
            this.outputBrowser.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("outputBrowser.OcxState")));
            this.outputBrowser.Size = new System.Drawing.Size(666, 358);
            this.outputBrowser.TabIndex = 5;
            // 
            // reportSearchPathTB
            // 
            this.reportSearchPathTB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.reportSearchPathTB.BackColor = System.Drawing.SystemColors.Control;
            this.reportSearchPathTB.Location = new System.Drawing.Point(19, 209);
            this.reportSearchPathTB.Name = "reportSearchPathTB";
            this.reportSearchPathTB.Size = new System.Drawing.Size(666, 22);
            this.reportSearchPathTB.TabIndex = 6;
            // 
            // packageListCB
            // 
            this.packageListCB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.packageListCB.Location = new System.Drawing.Point(19, 91);
            this.packageListCB.MaxDropDownItems = 32;
            this.packageListCB.Name = "packageListCB";
            this.packageListCB.Size = new System.Drawing.Size(522, 24);
            this.packageListCB.Sorted = true;
            this.packageListCB.TabIndex = 7;
            this.packageListCB.SelectedIndexChanged += new System.EventHandler(this.packageListCB_SelectedIndexChanged);
            // 
            // packageLabel
            // 
            this.packageLabel.Location = new System.Drawing.Point(19, 67);
            this.packageLabel.Name = "packageLabel";
            this.packageLabel.Size = new System.Drawing.Size(65, 21);
            this.packageLabel.TabIndex = 8;
            this.packageLabel.Text = "Package";
            // 
            // CreateDrillThroughTargetDlg
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 15);
            this.ClientSize = new System.Drawing.Size(704, 629);
            this.Controls.Add(this.packageLabel);
            this.Controls.Add(this.packageListCB);
            this.Controls.Add(this.reportSearchPathTB);
            this.Controls.Add(this.serverUrlTB);
            this.Controls.Add(this.outputBrowser);
            this.Controls.Add(this.reportListCB);
            this.Controls.Add(this.reportNameLBL);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonCreateDrillThroughTarget);
            this.Menu = this.mainMenu1;
            this.Name = "CreateDrillThroughTargetDlg";
            this.Text = "Create DrillThrough Target Sample";
            ((System.ComponentModel.ISupportInitialize)(this.outputBrowser)).EndInit();
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
			about.applicationName = "CreateDrillThroughTarget Sample";
			about.applicationVersion = "1.1";
			about.Show();
		}

		private void buttonCreateDrillThroughTarget_Click(object sender, System.EventArgs e)
		{
			string output = "";
			BaseClassWrapper selectedObject = (BaseClassWrapper)reportListCB.SelectedItem;
			try
			{
				if (selectedObject == null)
				{
					MessageBox.Show("Please select a valid entry.");
					return;
				}
				
				output = dtTarget.createDrillThrough(cBIConnection, (BaseClassWrapper)selectedObject, packageListCB.SelectedItem.ToString());
				displayPage(output);
			}
			catch(SoapException ex)
			{
				displayPage("<br>...the operation failed.<br>The following information was returned:<br><br>" +
					SamplesException.getExceptionMessage( ex));
				return;
			}
			catch(System.Exception ex)
			{
				if (0 != ex.Message.CompareTo("INPUT_CANCELLED_BY_USER"))
				{
					SamplesException.ShowExceptionMessage( ex.Message, true, "CreateDrillThroughTarget Sample" );					
					displayPage("\n...the operation failed.\nThe page could not be displayed.");
				}
				return;
			}
		}

		public void setReportList(BaseClassWrapper[] reportAndQueryList)
		{
			reportListCB.Items.AddRange(reportAndQueryList);
		}

        public void setPackageList(string[] packageNameList)
        {
            packageListCB.Items.AddRange(packageNameList);
        }

        public void setSelectedPackageIndex(int value)
        {
            packageListCB.SelectedIndex = value;
        }

		public void setSelectedReportIndex(int value)
		{
			reportListCB.SelectedIndex = value;
		}

		public void setConnection(SamplesConnect connection, string cBIUrl)
		{
			cBIConnection = connection;
			cBIServer = connection.CBICMS;
			cBIRS = connection.CBIRS;
			serverUrlTB.Text = cBIUrl;
		}

		public void displayPage(string currentPage)
		{
			string outputFile = "";
			object nullObject = null;
			CommonFunctions cf = new CommonFunctions();

			outputFile = cf.getSamplesPath();
			if (!Directory.Exists(outputFile))
			{
				// could not access the ...\webcontent\samples directory
				// use the current directory instead
				outputFile = Directory.GetCurrentDirectory();
			}
			outputFile += "createDrillThroughTargetOutput.htm";
			if (File.Exists(outputFile))
			{
				File.Delete(outputFile);
			}
			StreamWriter sw = new StreamWriter(outputFile);
			sw.WriteLine(currentPage);
			sw.Flush();
			sw.Close();
			outputBrowser.Navigate(outputFile, ref nullObject, ref nullObject, ref nullObject, ref nullObject);
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

        private void packageListCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                setReportList(dtTarget.getPromptedReports(cBIConnection, packageListCB.SelectedItem.ToString()));
                setSelectedReportIndex(0);
                reportListCB.Enabled = true;
            }
            catch (SoapException soapEx)
            {
                displayPage("<br>...the operation failed.<br>The following information was returned by The IBM Cognos Server:<br><br>" +
                    SamplesException.getExceptionMessage(soapEx));

            }
            
        }

	}
}
