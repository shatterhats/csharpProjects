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
using System.Threading;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Web.Services.Protocols;
using SamplesCommon;
using cognosdotnet_10_2;

namespace AddReport
{
	/// <summary>
	/// Summary description for AddReportDlg.
	/// </summary>
	public class AddReportDlg : System.Windows.Forms.Form
	{
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.MenuItem menuExit;
        private System.Windows.Forms.MenuItem menuAbout;
        private IContainer components;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button RunOptionButton;
		private System.Windows.Forms.ComboBox OptionChooserCB;
		private System.Windows.Forms.RichTextBox resultsDisplayWindowRTB;
		private System.Windows.Forms.TextBox serverUrlTB;	
	
		private reportService1 cBIRS = null;
		private systemService1 cBISS = null;
        private string accountPath= "";

		public AddReportDlg()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddReportDlg));
            this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuExit = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.menuAbout = new System.Windows.Forms.MenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.resultsDisplayWindowRTB = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.serverUrlTB = new System.Windows.Forms.TextBox();
            this.OptionChooserCB = new System.Windows.Forms.ComboBox();
            this.RunOptionButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem1,
            this.menuItem3});
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 0;
            this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuExit});
            this.menuItem1.Text = "File";
            // 
            // menuExit
            // 
            this.menuExit.Index = 0;
            this.menuExit.Text = "Exit";
            this.menuExit.Click += new System.EventHandler(this.menuExit_Click);
            // 
            // menuItem3
            // 
            this.menuItem3.Index = 1;
            this.menuItem3.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuAbout});
            this.menuItem3.Text = "Help";
            // 
            // menuAbout
            // 
            this.menuAbout.Index = 0;
            this.menuAbout.Text = "About";
            this.menuAbout.Click += new System.EventHandler(this.menuAbout_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.resultsDisplayWindowRTB);
            this.groupBox1.Location = new System.Drawing.Point(10, 111);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(568, 184);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Results Display Window";
            // 
            // resultsDisplayWindowRTB
            // 
            this.resultsDisplayWindowRTB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.resultsDisplayWindowRTB.BackColor = System.Drawing.SystemColors.Control;
            this.resultsDisplayWindowRTB.Location = new System.Drawing.Point(10, 18);
            this.resultsDisplayWindowRTB.Name = "resultsDisplayWindowRTB";
            this.resultsDisplayWindowRTB.Size = new System.Drawing.Size(549, 154);
            this.resultsDisplayWindowRTB.TabIndex = 0;
            this.resultsDisplayWindowRTB.Text = "";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(10, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 19);
            this.label1.TabIndex = 9;
            this.label1.Text = "Server URL";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // serverUrlTB
            // 
            this.serverUrlTB.BackColor = System.Drawing.SystemColors.Control;
            this.serverUrlTB.Enabled = false;
            this.serverUrlTB.Location = new System.Drawing.Point(185, 18);
            this.serverUrlTB.Name = "serverUrlTB";
            this.serverUrlTB.Size = new System.Drawing.Size(372, 22);
            this.serverUrlTB.TabIndex = 10;
            // 
            // OptionChooserCB
            // 
            this.OptionChooserCB.Location = new System.Drawing.Point(185, 65);
            this.OptionChooserCB.Name = "OptionChooserCB";
            this.OptionChooserCB.Size = new System.Drawing.Size(266, 24);
            this.OptionChooserCB.TabIndex = 11;
            // 
            // RunOptionButton
            // 
            this.RunOptionButton.Location = new System.Drawing.Point(461, 65);
            this.RunOptionButton.Name = "RunOptionButton";
            this.RunOptionButton.Size = new System.Drawing.Size(96, 26);
            this.RunOptionButton.TabIndex = 12;
            this.RunOptionButton.Text = "Run Option";
            this.RunOptionButton.Click += new System.EventHandler(this.RunOptionButton_Click);
            // 
            // AddReportDlg
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 15);
            this.ClientSize = new System.Drawing.Size(587, 305);
            this.Controls.Add(this.RunOptionButton);
            this.Controls.Add(this.OptionChooserCB);
            this.Controls.Add(this.serverUrlTB);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Menu = this.mainMenu1;
            this.Name = "AddReportDlg";
            this.Text = "Add Report Sample";
            this.Load += new System.EventHandler(this.AddReportDlg_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void menuAbout_Click(object sender, System.EventArgs e)
		{
			SamplesAbout about = new SamplesAbout();
			about.applicationName = "Add Report Sample";
			about.applicationVersion = "1.1";
			about.Show();
		}

		private void menuExit_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void AddReportDlg_Load(object sender, System.EventArgs e)
		{
			OptionChooserCB.Items.Add("Validate Specification");
			OptionChooserCB.Items.Add("Add Specification to Content Store");
			OptionChooserCB.SelectedIndex = 0;
		}
		
		private void RunOptionButton_Click(object sender, System.EventArgs e)
		{
			try
			{
				string resultMessage = "";
				Stream myStream;
				OpenFileDialog fileDialog = new OpenFileDialog();
				fileDialog.InitialDirectory = "../../" ;
				fileDialog.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*";
				if(fileDialog.ShowDialog() == DialogResult.OK)
				{
					if((myStream = fileDialog.OpenFile())!= null)
					{
						string reportspecStr = ReadReportSpecification(fileDialog.FileName);
                        specification spec = new specification();
                        spec.Value = reportspecStr;
						myStream.Close();
						AddReport addReportObject = new AddReport();
						clearResultsWindow();
						reportServiceReportSpecification reportspec = new reportServiceReportSpecification();

                        anyTypeProp reportSpecProperty = new anyTypeProp();
                        reportSpecProperty.value = reportspecStr;

                        reportspec.value = spec;

						if (0 == OptionChooserCB.Text.CompareTo("Validate Specification"))
						{
							// validate the file
							displayMessage("Validating the file specification : \"" + fileDialog.FileName + "\"...");
							addReportObject.validateReportSpec(cBIRS, reportspec, ref resultMessage);
							displayMessage(resultMessage);
						}
						else if (0 == OptionChooserCB.Text.CompareTo("Add Specification to Content Store"))
						{
							// add the specification
							SamplesInput reportNameDlg = new SamplesInput();
							string inputReportName = reportNameDlg.getInput("Please enter a name for the new Report","Name", "");
							displayMessage("Adding the file specification : \"" + fileDialog.FileName + "\"...");
							addReportObject.addReportSpec(cBISS, cBIRS, reportspec, inputReportName, accountPath, ref resultMessage);
							displayMessage(resultMessage);
						}
					}
				}
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
					SamplesException.ShowExceptionMessage( ex.Message, true, "AddReport Sample - RunOptionButton_Click()" );					
				}
				return;
			}
		}

		private string ReadReportSpecification(string fileName)
		{
			StreamReader sr = File.OpenText(fileName);
			String input;
			string reportSpecStr = "";
			while ((input=sr.ReadLine())!=null) 
			{
				reportSpecStr += input;
			}
			sr.Close();
			return reportSpecStr;
		}

		public void setConnection(reportService1 rService, string cBIUrl, string account)
		{
			cBIRS = rService;
			serverUrlTB.Text = cBIUrl;
            accountPath = account;
		}

        public string GetAccountPath()
        {
            return accountPath;
        }

		public void displayMessage(string message)
		{
			resultsDisplayWindowRTB.AppendText(message + "\n");
		}

		public void clearResultsWindow()
		{
			resultsDisplayWindowRTB.Clear();
		}

		public systemService1 CBISS
		{
			get
			{
				return cBISS;
			}
			set
			{
				cBISS = value;
			}
		}
	}
}
