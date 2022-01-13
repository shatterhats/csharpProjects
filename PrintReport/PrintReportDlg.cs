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

namespace PrintReport
{
	/// <summary>
	/// Summary description for PrintReportDlg.
	/// </summary>
	public class PrintReportDlg : System.Windows.Forms.Form
	{
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItemFile;
		private System.Windows.Forms.MenuItem menuItemExit;
		private System.Windows.Forms.MenuItem menuItemHelp;
		private System.Windows.Forms.MenuItem menuItemAbout;
		private System.Windows.Forms.Label ServerUrlLBL;
		private System.Windows.Forms.Label printOptionLBL;
		private System.Windows.Forms.ComboBox printOptionCB;
		private System.Windows.Forms.Label reportNameLBL;
		private System.Windows.Forms.Button RunOption;
		private System.Windows.Forms.ComboBox reportListCB;
        private System.Windows.Forms.RichTextBox resultsDisplayWindowRTB;
        private IContainer components;
		private System.Windows.Forms.TextBox reportSearchPathTB;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox serverUrlTB;
		
		public static SamplesConnect cBIServer = null;

		public PrintReportDlg()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PrintReportDlg));
            this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
            this.menuItemFile = new System.Windows.Forms.MenuItem();
            this.menuItemExit = new System.Windows.Forms.MenuItem();
            this.menuItemHelp = new System.Windows.Forms.MenuItem();
            this.menuItemAbout = new System.Windows.Forms.MenuItem();
            this.ServerUrlLBL = new System.Windows.Forms.Label();
            this.serverUrlTB = new System.Windows.Forms.TextBox();
            this.printOptionLBL = new System.Windows.Forms.Label();
            this.printOptionCB = new System.Windows.Forms.ComboBox();
            this.reportNameLBL = new System.Windows.Forms.Label();
            this.reportListCB = new System.Windows.Forms.ComboBox();
            this.RunOption = new System.Windows.Forms.Button();
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
            this.ServerUrlLBL.Size = new System.Drawing.Size(135, 16);
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
            this.serverUrlTB.Text = "http://localhost:9300/p2pd/servlet/dispatch";
            // 
            // printOptionLBL
            // 
            this.printOptionLBL.Location = new System.Drawing.Point(16, 72);
            this.printOptionLBL.Name = "printOptionLBL";
            this.printOptionLBL.Size = new System.Drawing.Size(100, 23);
            this.printOptionLBL.TabIndex = 2;
            this.printOptionLBL.Text = "Select Print Option";
            // 
            // printOptionCB
            // 
            this.printOptionCB.Location = new System.Drawing.Point(16, 88);
            this.printOptionCB.Name = "printOptionCB";
            this.printOptionCB.Size = new System.Drawing.Size(248, 21);
            this.printOptionCB.TabIndex = 3;
            this.printOptionCB.SelectedIndexChanged += new System.EventHandler(this.printOptionCB_SelectedIndexChanged);
            // 
            // reportNameLBL
            // 
            this.reportNameLBL.Location = new System.Drawing.Point(288, 72);
            this.reportNameLBL.Name = "reportNameLBL";
            this.reportNameLBL.Size = new System.Drawing.Size(80, 16);
            this.reportNameLBL.TabIndex = 4;
            this.reportNameLBL.Text = "Report Name";
            // 
            // reportListCB
            // 
            this.reportListCB.Location = new System.Drawing.Point(288, 88);
            this.reportListCB.Name = "reportListCB";
            this.reportListCB.Size = new System.Drawing.Size(328, 21);
            this.reportListCB.TabIndex = 5;
            this.reportListCB.SelectedIndexChanged += new System.EventHandler(this.reportListCB_SelectedIndexChanged);
            // 
            // RunOption
            // 
            this.RunOption.Location = new System.Drawing.Point(520, 160);
            this.RunOption.Name = "RunOption";
            this.RunOption.Size = new System.Drawing.Size(96, 32);
            this.RunOption.TabIndex = 6;
            this.RunOption.Text = "Print Option";
            this.RunOption.Click += new System.EventHandler(this.RunOption_Click);
            // 
            // resultsDisplayWindowRTB
            // 
            this.resultsDisplayWindowRTB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.resultsDisplayWindowRTB.BackColor = System.Drawing.SystemColors.Control;
            this.resultsDisplayWindowRTB.Location = new System.Drawing.Point(24, 216);
            this.resultsDisplayWindowRTB.Name = "resultsDisplayWindowRTB";
            this.resultsDisplayWindowRTB.Size = new System.Drawing.Size(584, 176);
            this.resultsDisplayWindowRTB.TabIndex = 8;
            this.resultsDisplayWindowRTB.Text = "";
            // 
            // reportSearchPathTB
            // 
            this.reportSearchPathTB.BackColor = System.Drawing.SystemColors.Control;
            this.reportSearchPathTB.Location = new System.Drawing.Point(16, 128);
            this.reportSearchPathTB.Name = "reportSearchPathTB";
            this.reportSearchPathTB.Size = new System.Drawing.Size(600, 20);
            this.reportSearchPathTB.TabIndex = 9;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Location = new System.Drawing.Point(16, 200);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(600, 200);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Results Display Window";
            // 
            // PrintReportDlg
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(632, 417);
            this.Controls.Add(this.reportSearchPathTB);
            this.Controls.Add(this.serverUrlTB);
            this.Controls.Add(this.resultsDisplayWindowRTB);
            this.Controls.Add(this.RunOption);
            this.Controls.Add(this.reportListCB);
            this.Controls.Add(this.reportNameLBL);
            this.Controls.Add(this.printOptionCB);
            this.Controls.Add(this.printOptionLBL);
            this.Controls.Add(this.ServerUrlLBL);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Menu = this.mainMenu1;
            this.Name = "PrintReportDlg";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Print Report Sample";
            this.Load += new System.EventHandler(this.PrintReportDlg_Load);
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
			about.applicationName = "Print Report Sample";
			about.applicationVersion = "1.1";
			about.Show();
		}

		// This function is the entry point of this sample.
		private void RunOption_Click(object sender, System.EventArgs e)
		{
			string resultMessage = "";
			clearResultsWindow();
			PrintReport prObject = new PrintReport();
			BaseClassWrapper selectedObject = (BaseClassWrapper)reportListCB.SelectedItem;
			try
			{
				// 1. Get the selected Print Option {Add Printer, Delete Printer, Start Print, etc...}
				string selectedOption = (string)printOptionCB.SelectedItem;
				if ( (selectedOption == null) || (0 == selectedOption.CompareTo("")) )
				{
					MessageBox.Show("Please choose a valid print option.");
					return;
				}
				// 2. Get the selected report name (for the 'Start Print' command only).
				if (selectedObject == null)
				{
					MessageBox.Show("Please select a valid report or query name.");
					return;
				}
				// 3. Run 
				runPrintOption(cBIServer, selectedOption, selectedObject.searchPath.value, ref resultMessage);
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
					SamplesException.ShowExceptionMessage( ex.Message, true, "Print Report Sample" );					
				}
				return;
			}
		}

		private void PrintReportDlg_Load(object sender, System.EventArgs e)
		{
			printOptionCB.Items.Add("getAvailablePrinters");
			printOptionCB.Items.Add("addPrinter");
			printOptionCB.Items.Add("deletePrinter");
			printOptionCB.Items.Add("changePrinterName");
			printOptionCB.Items.Add("changePrinterAddress");
			printOptionCB.Items.Add("startPrint");
			reportListCB.Enabled = false;
			printOptionCB.SelectedIndex = 0;
		}

		private void printOptionCB_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			string selectedItem = (string)printOptionCB.SelectedItem;
			if ( (selectedItem == null) || (0 == selectedItem.CompareTo("")) )
			{
				return;
			}
			if (0 == selectedItem.CompareTo("startPrint"))
			{
				reportListCB.Enabled = true;
			}
			else
			{
				reportListCB.Enabled = false;
			}
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

		public void setReportList(BaseClassWrapper[] reportAndQueryList)
		{
			reportListCB.Items.AddRange(reportAndQueryList);
		}

		public void setSelectedReportIndex(int value)
		{
			reportListCB.SelectedIndex = value;
		}

		public void displayMessage(string message)
		{
			resultsDisplayWindowRTB.AppendText(message + "\n");
		}

		public void clearResultsWindow()
		{
			resultsDisplayWindowRTB.Clear();
		}

		public void runPrintOption(SamplesConnect connection, string selectedPrintOption, string reportPath, ref string returnMessage)
		{
			try
			{
				string printerName = "";
				string newAddress = "";
				string printerAddress = "";
				string newPrinterName = "";
				string[] printerNameList = null;
				PrintReport pr = new PrintReport();
				SamplesInput si = new SamplesInput();
				baseClass[] bcPrinterList = new baseClass[1];
				SamplesListInput sli = new SamplesListInput();

				clearResultsWindow();
			
				switch(selectedPrintOption)
				{
					case "getAvailablePrinters":
						bcPrinterList = pr.getAvailablePrinters(connection, ref returnMessage);
						if ( (bcPrinterList != null) && (bcPrinterList.GetLength(0) > 0) )
						{
							displayMessage("List of available printers:");
							printer printerObj = new printer();
							printerObj.printerAddress = new stringProp();
							for (int i=0; i<bcPrinterList.GetLength(0); i++)
							{
								printerObj = (printer)bcPrinterList[i];
								displayMessage("\tPrinter Name: " + bcPrinterList[i].defaultName.value);
								displayMessage("\tSearch Path : " + bcPrinterList[i].searchPath.value);
								displayMessage("\tAddress     : " + printerObj.printerAddress.value + "\n");
							}
						}
						break;
					case "addPrinter": 
						printerName = si.getInput("Add Printer - Printer Name", "Please enter a name for the new printer.", "");
						printerAddress = si.getInput("Add Printer - Printer Address", "Please enter the address of the new printer", "");
						pr.addPrinter(connection, printerName, printerAddress, ref returnMessage);
						break;
					case "deletePrinter":
						bcPrinterList = pr.getAvailablePrinters(connection, ref returnMessage);
						if ( (bcPrinterList == null) || (bcPrinterList.GetLength(0) == 0) )
						{
							break;
						}
						printerNameList = getPrinterNames(connection, bcPrinterList);
						printerName = sli.getInput("Delete Printer", 
							"Please select the name of the printer to be deleted.", 
							printerNameList,
							0);
						pr.deletePrinter(connection, printerName, ref returnMessage);	
						break;
					case "changePrinterName":
						bcPrinterList = pr.getAvailablePrinters(connection, ref returnMessage);
						if ( (bcPrinterList == null) || (bcPrinterList.GetLength(0) == 0) )
						{
							break;
						}
						printerNameList = getPrinterNames(connection, bcPrinterList);
						printerName = sli.getInput("Change Printer Name", 
							"Please select the name of the printer to be modified.", 
							printerNameList,
							0);
						newPrinterName = si.getInput("Change Printer Name", "Please enter the new printer name.", "");
						pr.changePrinterName(connection, printerName, newPrinterName, ref returnMessage);
						break;
					case "changePrinterAddress":
						bcPrinterList = pr.getAvailablePrinters(connection, ref returnMessage);
						if ( (bcPrinterList == null) || (bcPrinterList.GetLength(0) == 0) )
						{
							break;
						}
						printerNameList = getPrinterNames(connection, bcPrinterList);
						printerName = sli.getInput("Change Printer Address", 
							"Please enter the name of the printer to be modified.", 
							printerNameList,
							0);
						newAddress = si.getInput("Change Printer Address", "Please enter the new printer address.", "");
						pr.changePrinterAddress(connection, printerName, newAddress, ref returnMessage);
						break;
					case "startPrint":
						bcPrinterList = pr.getAvailablePrinters(connection, ref returnMessage);
						if ( (bcPrinterList == null) || (bcPrinterList.GetLength(0) == 0) )
						{
							break;
						}
						printerNameList = getPrinterNames(connection, bcPrinterList);
						printerName = sli.getInput("Print", 
							"Please select the destination printer.", 
							printerNameList,
							0);
						displayMessage("executing...");
						pr.startPrint(connection, getPrinterSearchPath(connection, printerName), reportPath, ref returnMessage);
						break;
				}
			}
			catch(SoapException ex)
			{
				SamplesException.ShowExceptionMessage( ex, true, "Print Report Sample - runPrintOption" );
				return;
			}
			catch(System.Exception ex)
			{
				if (0 != ex.Message.CompareTo("INPUT_CANCELLED_BY_USER"))
				{
					SamplesException.ShowExceptionMessage( ex.Message, true, "Print Report Samples - runPrintOption" );
					return;
				}
			}
		}

		public bool userIsAnonymous(SamplesConnect connection)
		{
			//Test for Anonymous Authentication
			bool bTestAnonymous = false;
			try
			{
				searchPathMultipleObject homeDir = new searchPathMultipleObject();
				homeDir.Value = "~";

				baseClass[] bc = connection.CBICMS.query ( homeDir, new propEnum[]{} , new sort[]{}, new queryOptions () );
				if ( ((bc != null) && (bc.GetLength(0) > 0)) && (0 == bc[0].searchPath.value.CompareTo("CAMID(\"::Anonymous\")")) )
				{
					bTestAnonymous = true;
				}
			}
			catch(Exception ex) 
			{
				string output = ex.Message;
				return false;
			}
			return bTestAnonymous;
		}

		public string getPrinterSearchPath(SamplesConnect connection, string printerName)
		{
			string printerPath = "";
			string currentPrinterName = "";
			try 
			{
				baseClass[] bcaPrinters = new baseClass[1];
				propEnum[] props =
					new propEnum[] { propEnum.searchPath, propEnum.defaultName };

				searchPathMultipleObject printersPath = new searchPathMultipleObject();
				printersPath.Value = "CAMID(\":\")/printer";

				bcaPrinters = connection.CBICMS.query(printersPath, props, new sort[] {}, new queryOptions());

				if ( (bcaPrinters == null) || (bcaPrinters.GetLength(0) == 0) )
				{
					displayMessage("There are no printers defined.");
					return "";
				}

				for (int i=0; i<bcaPrinters.GetLength(0); i++)
				{
					currentPrinterName = bcaPrinters[i].defaultName.value.ToLower();
					printerName = printerName.ToLower();
					if (0 == currentPrinterName.CompareTo(printerName))
					{
						printerPath = bcaPrinters[i].searchPath.value +"\n";
					}
				}
			}
			catch(SoapException ex)
			{
				SamplesException.ShowExceptionMessage( ex, true, "Print Report Sample - getAvailablePrinters" );
				displayMessage("getAvailablePrinters failed with error: " + ex.Message);
				return null;
			}
			catch(System.Exception ex)
			{
				SamplesException.ShowExceptionMessage( ex.Message, true, "Print Report Sample - getAvailablePrinters" );
				displayMessage("getAvailablePrinters failed with error: " + ex.Message);
				return null;
			}
			return printerPath;
		}

		public void setConnection(SamplesConnect connection, string cBIUrl)
		{
			cBIServer = connection;
			serverUrlTB.Text = cBIUrl;
		}

		public string[] getPrinterNames(SamplesConnect connection, baseClass[] bcPrinterList)
		{
			if ( (bcPrinterList == null) || (bcPrinterList.GetLength(0) == 0) )
			{
				return null;
			}

			string[] printerNameList = new string[bcPrinterList.GetLength(0)];
			for (int i=0; i<bcPrinterList.GetLength(0); i++)
			{
				printerNameList[i] = bcPrinterList[i].defaultName.value;
			}
			return printerNameList;
		}

	}
}
