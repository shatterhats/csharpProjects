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

namespace Save
{
	/// <summary>
	/// Summary description for SaveDlg.
	/// </summary>
	public class SaveDlg : System.Windows.Forms.Form
	{
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItemFile;
		private System.Windows.Forms.MenuItem menuItemExit;
		private System.Windows.Forms.MenuItem menuItemHelp;
		private System.Windows.Forms.MenuItem menuItemAbout;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox saveOptionsCB;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox reportListCB;
		private System.Windows.Forms.Button runOption;
        private System.Windows.Forms.RichTextBox resultsDisplayWindowRTB;
        private IContainer components;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox reportSearchPathTB;
		private System.Windows.Forms.TextBox serverUrlTB;
		public static SamplesConnect cBIConnection = null;

		public SaveDlg()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SaveDlg));
            this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
            this.menuItemFile = new System.Windows.Forms.MenuItem();
            this.menuItemExit = new System.Windows.Forms.MenuItem();
            this.menuItemHelp = new System.Windows.Forms.MenuItem();
            this.menuItemAbout = new System.Windows.Forms.MenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.serverUrlTB = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.saveOptionsCB = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.reportListCB = new System.Windows.Forms.ComboBox();
            this.runOption = new System.Windows.Forms.Button();
            this.resultsDisplayWindowRTB = new System.Windows.Forms.RichTextBox();
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
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(16, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Server URL";
            // 
            // serverUrlTB
            // 
            this.serverUrlTB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.serverUrlTB.BackColor = System.Drawing.SystemColors.Control;
            this.serverUrlTB.Enabled = false;
            this.serverUrlTB.Location = new System.Drawing.Point(16, 24);
            this.serverUrlTB.Name = "serverUrlTB";
            this.serverUrlTB.Size = new System.Drawing.Size(600, 20);
            this.serverUrlTB.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(16, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Save Options";
            // 
            // saveOptionsCB
            // 
            this.saveOptionsCB.Location = new System.Drawing.Point(16, 80);
            this.saveOptionsCB.Name = "saveOptionsCB";
            this.saveOptionsCB.Size = new System.Drawing.Size(256, 21);
            this.saveOptionsCB.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(288, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Report Name";
            // 
            // reportListCB
            // 
            this.reportListCB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.reportListCB.Location = new System.Drawing.Point(288, 80);
            this.reportListCB.Name = "reportListCB";
            this.reportListCB.Size = new System.Drawing.Size(328, 21);
            this.reportListCB.TabIndex = 5;
            this.reportListCB.SelectedIndexChanged += new System.EventHandler(this.reportListCB_SelectedIndexChanged);
            // 
            // runOption
            // 
            this.runOption.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.runOption.Location = new System.Drawing.Point(528, 144);
            this.runOption.Name = "runOption";
            this.runOption.Size = new System.Drawing.Size(88, 32);
            this.runOption.TabIndex = 6;
            this.runOption.Text = "Run Option";
            this.runOption.Click += new System.EventHandler(this.runOption_Click);
            // 
            // resultsDisplayWindowRTB
            // 
            this.resultsDisplayWindowRTB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.resultsDisplayWindowRTB.BackColor = System.Drawing.SystemColors.Control;
            this.resultsDisplayWindowRTB.Location = new System.Drawing.Point(24, 200);
            this.resultsDisplayWindowRTB.Name = "resultsDisplayWindowRTB";
            this.resultsDisplayWindowRTB.Size = new System.Drawing.Size(584, 152);
            this.resultsDisplayWindowRTB.TabIndex = 7;
            this.resultsDisplayWindowRTB.Text = "";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Location = new System.Drawing.Point(16, 184);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(600, 176);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Results Display Window";
            // 
            // reportSearchPathTB
            // 
            this.reportSearchPathTB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.reportSearchPathTB.BackColor = System.Drawing.SystemColors.Control;
            this.reportSearchPathTB.Location = new System.Drawing.Point(16, 112);
            this.reportSearchPathTB.Name = "reportSearchPathTB";
            this.reportSearchPathTB.Size = new System.Drawing.Size(600, 20);
            this.reportSearchPathTB.TabIndex = 9;
            // 
            // SaveDlg
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(632, 374);
            this.Controls.Add(this.reportSearchPathTB);
            this.Controls.Add(this.serverUrlTB);
            this.Controls.Add(this.resultsDisplayWindowRTB);
            this.Controls.Add(this.runOption);
            this.Controls.Add(this.reportListCB);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.saveOptionsCB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Menu = this.mainMenu1;
            this.Name = "SaveDlg";
            this.Text = "Save Options";
            this.Load += new System.EventHandler(this.SaveDlg_Load);
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
			about.applicationName = "AddReport";
			about.applicationVersion = "1.1";
			about.Show();
		}

		private void SaveDlg_Load(object sender, System.EventArgs e)
		{
			saveOptionsCB.Items.Add("Save Report");
			saveOptionsCB.Items.Add("Save Report As");
			saveOptionsCB.SelectedIndex = 0;
		}

		// This method is the main entry point of this sample.
		private void runOption_Click(object sender, System.EventArgs e)
		{
			bool saveAsFlag = false;
			string newReportName = "";
			string resultMessage = "";
			string selectedOption = "";
			BaseClassWrapper selectedObject = null;
			clearResultsWindow();
			try
			{
				// Validate the selected report or query 
				selectedObject = (BaseClassWrapper)reportListCB.SelectedItem;
				if (selectedObject == null)
				{
					MessageBox.Show("Please select a valid entry.");
					return;
				}
				// Validate the selected save option
				selectedOption = (string)saveOptionsCB.SelectedItem;
				if ( (selectedOption == null) || (0 == selectedOption.CompareTo("")) )
				{
					MessageBox.Show("Please select a Save Option from the list.");
					return;
				}
				else if (0 == selectedOption.CompareTo("Save Report"))
				{
					displayMessage("Saving the report '" + selectedObject.defaultName.value + "'...");
					saveAsFlag = false;
				}
				else if (0 == selectedOption.CompareTo("Save Report As"))
				{
					// Get the new report name and location
					SamplesInput si = new SamplesInput();
					newReportName = si.getInput("Report Name", "Please enter a new name for the report", selectedObject.defaultName.value + "_1");
					displayMessage("Saving the report '" + selectedObject.defaultName.value + "' as " + newReportName +"...");
					saveAsFlag = true;
				}

				// Call the function that will execute the selected option
				
				Save saveOpts = new Save();
				saveOpts.runOption(cBIConnection, 
					selectedObject.searchPath.value, 
					saveAsFlag,
					newReportName,
					ref resultMessage);
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
					SamplesException.ShowExceptionMessage( ex.Message, true, "CancelReport Sample" );					
					displayMessage(ex.Message);
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
			cBIConnection = connection;
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
