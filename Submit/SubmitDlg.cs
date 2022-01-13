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

namespace Submit
{
	/// <summary>
	/// Summary description for SubmitDlg.
	/// </summary>
	public class SubmitDlg : System.Windows.Forms.Form
	{
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItemFile;
		private System.Windows.Forms.MenuItem menuItemExit;
		private System.Windows.Forms.MenuItem menuItemHelp;
		private System.Windows.Forms.MenuItem menuItemAbout;
		private System.Windows.Forms.Label reportListLBL;
		private System.Windows.Forms.ComboBox submitOptionCB;
		private System.Windows.Forms.ComboBox reportListCB;
        private System.Windows.Forms.Button buttonRunOption;
        private IContainer components;
		private System.Windows.Forms.RichTextBox resultsDisplayWindowRTB;
		private System.Windows.Forms.Label submitOptionLBL;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox reportSearchPathTB;
		private System.Windows.Forms.Label serverUrlLBL;
		private System.Windows.Forms.TextBox serverUrlTB;
		public static contentManagerService1 cBICMS = null;
		public static SamplesConnect cBIServer;

		public SubmitDlg()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SubmitDlg));
            this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
            this.menuItemFile = new System.Windows.Forms.MenuItem();
            this.menuItemExit = new System.Windows.Forms.MenuItem();
            this.menuItemHelp = new System.Windows.Forms.MenuItem();
            this.menuItemAbout = new System.Windows.Forms.MenuItem();
            this.serverUrlLBL = new System.Windows.Forms.Label();
            this.serverUrlTB = new System.Windows.Forms.TextBox();
            this.reportListLBL = new System.Windows.Forms.Label();
            this.reportListCB = new System.Windows.Forms.ComboBox();
            this.resultsDisplayWindowRTB = new System.Windows.Forms.RichTextBox();
            this.buttonRunOption = new System.Windows.Forms.Button();
            this.submitOptionCB = new System.Windows.Forms.ComboBox();
            this.submitOptionLBL = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.reportSearchPathTB = new System.Windows.Forms.TextBox();
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
            this.serverUrlLBL.Size = new System.Drawing.Size(134, 16);
            this.serverUrlLBL.TabIndex = 0;
            this.serverUrlLBL.Text = "Server URL";
            // 
            // serverUrlTB
            // 
            this.serverUrlTB.BackColor = System.Drawing.SystemColors.Control;
            this.serverUrlTB.Location = new System.Drawing.Point(16, 32);
            this.serverUrlTB.Name = "serverUrlTB";
            this.serverUrlTB.Size = new System.Drawing.Size(600, 20);
            this.serverUrlTB.TabIndex = 1;
            // 
            // reportListLBL
            // 
            this.reportListLBL.Location = new System.Drawing.Point(288, 72);
            this.reportListLBL.Name = "reportListLBL";
            this.reportListLBL.Size = new System.Drawing.Size(72, 16);
            this.reportListLBL.TabIndex = 3;
            this.reportListLBL.Text = "Report Name";
            // 
            // reportListCB
            // 
            this.reportListCB.Location = new System.Drawing.Point(288, 88);
            this.reportListCB.Name = "reportListCB";
            this.reportListCB.Size = new System.Drawing.Size(328, 21);
            this.reportListCB.TabIndex = 5;
            this.reportListCB.SelectedIndexChanged += new System.EventHandler(this.reportListCB_SelectedIndexChanged);
            // 
            // resultsDisplayWindowRTB
            // 
            this.resultsDisplayWindowRTB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.resultsDisplayWindowRTB.BackColor = System.Drawing.SystemColors.Control;
            this.resultsDisplayWindowRTB.Location = new System.Drawing.Point(24, 208);
            this.resultsDisplayWindowRTB.Name = "resultsDisplayWindowRTB";
            this.resultsDisplayWindowRTB.Size = new System.Drawing.Size(584, 192);
            this.resultsDisplayWindowRTB.TabIndex = 6;
            this.resultsDisplayWindowRTB.Text = "";
            // 
            // buttonRunOption
            // 
            this.buttonRunOption.Location = new System.Drawing.Point(528, 152);
            this.buttonRunOption.Name = "buttonRunOption";
            this.buttonRunOption.Size = new System.Drawing.Size(88, 40);
            this.buttonRunOption.TabIndex = 7;
            this.buttonRunOption.Text = "Run Option";
            this.buttonRunOption.Click += new System.EventHandler(this.buttonRunOption_Click);
            // 
            // submitOptionCB
            // 
            this.submitOptionCB.Location = new System.Drawing.Point(16, 88);
            this.submitOptionCB.Name = "submitOptionCB";
            this.submitOptionCB.Size = new System.Drawing.Size(256, 21);
            this.submitOptionCB.TabIndex = 8;
            // 
            // submitOptionLBL
            // 
            this.submitOptionLBL.Location = new System.Drawing.Point(16, 72);
            this.submitOptionLBL.Name = "submitOptionLBL";
            this.submitOptionLBL.Size = new System.Drawing.Size(88, 16);
            this.submitOptionLBL.TabIndex = 9;
            this.submitOptionLBL.Text = "Submit Options";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Location = new System.Drawing.Point(16, 192);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(600, 216);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Results Display Window";
            // 
            // reportSearchPathTB
            // 
            this.reportSearchPathTB.BackColor = System.Drawing.SystemColors.Control;
            this.reportSearchPathTB.Location = new System.Drawing.Point(16, 120);
            this.reportSearchPathTB.Name = "reportSearchPathTB";
            this.reportSearchPathTB.Size = new System.Drawing.Size(600, 20);
            this.reportSearchPathTB.TabIndex = 11;
            // 
            // SubmitDlg
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(632, 425);
            this.Controls.Add(this.reportSearchPathTB);
            this.Controls.Add(this.serverUrlTB);
            this.Controls.Add(this.submitOptionLBL);
            this.Controls.Add(this.submitOptionCB);
            this.Controls.Add(this.buttonRunOption);
            this.Controls.Add(this.resultsDisplayWindowRTB);
            this.Controls.Add(this.reportListCB);
            this.Controls.Add(this.reportListLBL);
            this.Controls.Add(this.serverUrlLBL);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Menu = this.mainMenu1;
            this.Name = "SubmitDlg";
            this.Text = "SubmitDlg";
            this.Load += new System.EventHandler(this.SubmitDlg_Load);
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
			about.applicationName = "Submit";
			about.applicationVersion = "1.1";
			about.Show();
		}

		private void buttonRunOption_Click(object sender, System.EventArgs e)
		{
			try
			{
				string resultMessage = "";
				BaseClassWrapper selectedObject = null;
				string submitOptionSelected = "";
				bool submitAt = false;
				
				selectedObject = (BaseClassWrapper)reportListCB.SelectedItem;
				if (selectedObject == null)
				{
					MessageBox.Show("Please select a valid entry.");
					return;
				}
				submitOptionSelected = (string)submitOptionCB.SelectedItem;
				if ( (submitOptionSelected == null) || (0 == submitOptionSelected.CompareTo("")) )
				{
					MessageBox.Show("Please select a submit option from the list.");
				}
				if (0 == submitOptionSelected.CompareTo("Submit Job"))
				{
					submitAt = false;
				}
				else if (0 == submitOptionSelected.CompareTo("Submit Job At"))
				{
					submitAt = true;
				}
				Submit submitObj = new Submit();
				submitObj.doSubmit(cBIServer, selectedObject.searchPath.value, submitAt, ref resultMessage);
				displayMessage(resultMessage);
			}
			catch(SoapException ex)
			{
				displayMessage("...the operation failed.\nThe following information was returned:\n\n" +
					SamplesException.getExceptionMessage( ex));
				return;
			}
			catch(System.Exception ex)
			{
				if (0 != ex.Message.CompareTo("INPUT_CANCELLED_BY_USER"))
				{
					SamplesException.ShowExceptionMessage( ex.Message, true, "Submit Sample" );					
					displayMessage("\n...the operation failed.\nThe page could not be displayed.");
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

		public void setConnection(SamplesConnect connection, string cBIUrl)
		{
			cBIServer = connection;
			cBICMS = connection.CBICMS;
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

		private void SubmitDlg_Load(object sender, System.EventArgs e)
		{
			submitOptionCB.Items.Add("Submit Job");
			submitOptionCB.Items.Add("Submit Job At");
			submitOptionCB.SelectedIndex = 0;
		}

	}
}
