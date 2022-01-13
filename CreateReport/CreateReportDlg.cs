/** 
Licensed Materials - Property of IBM

IBM Cognos Products: DOCS

(C) Copyright IBM Corp. 2005

US Government Users Restricted Rights - Use, duplication or disclosure restricted by GSA ADP Schedule Contract with
IBM Corp.
*/
using System;
using System.Xml;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using SamplesCommon;
using cognosdotnet_10_2;
using System.Web.Services.Protocols;

namespace CreateReport
{
	/// <summary>
	/// Summary description for CreateReportDlg.
	/// </summary>
	public class CreateReportDlg : System.Windows.Forms.Form
	{
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.MenuItem menuItem4;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button CreateReportButton;
        private IContainer components;
		private System.Windows.Forms.RichTextBox resultsDisplayWindowRTB;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox targetLocationTB;
		private System.Windows.Forms.TextBox serverUrlTB;
		public static SamplesConnect cBIServer = null;

		public CreateReportDlg()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateReportDlg));
            this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.serverUrlTB = new System.Windows.Forms.TextBox();
            this.CreateReportButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.resultsDisplayWindowRTB = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.targetLocationTB = new System.Windows.Forms.TextBox();
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
            this.menuItem2});
            this.menuItem1.Text = "File";
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 0;
            this.menuItem2.Text = "Exit";
            this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
            // 
            // menuItem3
            // 
            this.menuItem3.Index = 1;
            this.menuItem3.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem4});
            this.menuItem3.Text = "Help";
            // 
            // menuItem4
            // 
            this.menuItem4.Index = 0;
            this.menuItem4.Text = "About";
            this.menuItem4.Click += new System.EventHandler(this.menuItem4_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(24, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Server URL";
            // 
            // serverUrlTB
            // 
            this.serverUrlTB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.serverUrlTB.BackColor = System.Drawing.SystemColors.Control;
            this.serverUrlTB.Location = new System.Drawing.Point(24, 24);
            this.serverUrlTB.Name = "serverUrlTB";
            this.serverUrlTB.Size = new System.Drawing.Size(432, 20);
            this.serverUrlTB.TabIndex = 1;
            this.serverUrlTB.Text = "http://localhost:9300/p2pd/servlet/dispatch";
            // 
            // CreateReportButton
            // 
            this.CreateReportButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CreateReportButton.Location = new System.Drawing.Point(328, 112);
            this.CreateReportButton.Name = "CreateReportButton";
            this.CreateReportButton.Size = new System.Drawing.Size(128, 23);
            this.CreateReportButton.TabIndex = 2;
            this.CreateReportButton.Text = "Create Report";
            this.CreateReportButton.Click += new System.EventHandler(this.CreateReportButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.resultsDisplayWindowRTB);
            this.groupBox1.Location = new System.Drawing.Point(8, 136);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(464, 184);
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
            this.resultsDisplayWindowRTB.Size = new System.Drawing.Size(448, 160);
            this.resultsDisplayWindowRTB.TabIndex = 0;
            this.resultsDisplayWindowRTB.Text = "";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(24, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Target Location";
            // 
            // targetLocationTB
            // 
            this.targetLocationTB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.targetLocationTB.Location = new System.Drawing.Point(24, 72);
            this.targetLocationTB.Name = "targetLocationTB";
            this.targetLocationTB.Size = new System.Drawing.Size(432, 20);
            this.targetLocationTB.TabIndex = 5;
            this.targetLocationTB.Text = "CAMID(\"::Anonymous\")/folder[@name=\'My Folders\']";
            // 
            // CreateReportDlg
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(480, 329);
            this.Controls.Add(this.targetLocationTB);
            this.Controls.Add(this.serverUrlTB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.CreateReportButton);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Menu = this.mainMenu1;
            this.Name = "CreateReportDlg";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Create Report";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void menuItem2_Click(object sender, System.EventArgs e)
		{
 			this.Close();
		}

		private void menuItem4_Click(object sender, System.EventArgs e)
		{
			SamplesAbout about = new SamplesAbout();
			about.applicationName = "CreateReport";
			about.applicationVersion = "1.1";
			about.Show();
		}

		// This function is the entry point and the main driver for this sample.
		private void CreateReportButton_Click(object sender, System.EventArgs e)
		{
			try
			{
				clearResultsWindow();
				CreateReport crObject = new CreateReport();
				
				// 1. Prompt for the Package Name
				string packageName = crObject.getPackageName(cBIServer);
				if ( (packageName == null) || (0 == packageName.CompareTo("")) )
				{
					return;
				}
				displayMessage("The package name selected is: " + packageName);


				// 2. Prompt for the name of the report to be created
				string reportName = crObject.getReportName();
				if ( (reportName == null) || (0 == reportName.CompareTo("")) )
				{
					return;
				}
				displayMessage("The new report name will be : " + reportName);

				
				// 3. Build up and Display the list of tables and Columns
				// 3.1 Get the list of table names and columns for the selected package

                string packageSearchPath = "/content/folder[@name='Samples']/folder[@name='Models']/package[@name='" + packageName + "']";
				CreateReportDlg crObjectDlg = new CreateReportDlg();
                string metaDataResponse = crObjectDlg.getPackageMetaData(packageSearchPath);
				if (0 == metaDataResponse.CompareTo(""))
				{
					return;
				}
				TableData[] tableNameColumnMap = crObjectDlg.buildUpTableData(metaDataResponse);
				if (tableNameColumnMap == null)
				{
					return;
				}

				// 3.2 Populate the UI with the table names and columns
				CreateReportTableDlg crTableDlg = new CreateReportTableDlg(tableNameColumnMap, packageName, reportName);
				crTableDlg.populateTableNameList();
				crTableDlg.selectTableIndex(0);
				crTableDlg.ShowDialog();
				if (crTableDlg.isOKed)
				{
					// 4. Create the specification XML for the new report 
					//    and add it to the content store
					reportServiceSpecification reportSpec = crObject.createReportSpec(cBIServer,
						packageName,
						targetLocationTB.Text,
						reportName, 
						crTableDlg.getSelectedTableName(), 
						crTableDlg.getSelectedColumnList());
					if (reportSpec != null)
					{
						displayMessage("...the report \"" + reportName + "\" has been successfully added to the content store.");
						displayMessage("\nExecuting report specification...");
					}
					else
					{
						displayMessage("...failed adding the report \"" + reportName + "\" to the content store.");	
						return;
					}

					// 5. Execute the specification
					bool status = crObject.executeReportSpec(cBIServer, reportSpec);
					if (status)
					{
						displayMessage("...the report \"" + reportName + "\" executed successfully.");
					}
					else
					{
						displayMessage("...failed executing the report \"" + reportName + "\".");
						return;
					}
				}
				else
				{
					return;
				}
			}
			catch(SoapException ex)
			{
				SamplesException.ShowExceptionMessage( ex, true, "Create Report Sample - CreateReportButton_Click" );
				return;
			}
			catch(System.Exception ex)
			{
				SamplesException.ShowExceptionMessage( ex.Message, true, "Create Report Sample - CreateReportButton_Click" );
				return;
			}
		}

		public void setConnection(SamplesConnect connection)
		{
			cBIServer = connection;
			serverUrlTB.Text = connection.CBIURL;
		}

		public void displayMessage(string message)
		{
			resultsDisplayWindowRTB.AppendText(message + "\n");
		}

		public void clearResultsWindow()
		{
			resultsDisplayWindowRTB.Clear();
		}

		//********************************************************
		//    * Get the metadata for the selected OR default (first)
		//    * package listed
		//********************************************************
		public string getPackageMetaData(string packageName)
		{
			try
			{
		    
				// Get the metadata for the selected OR default (second) package listed

				string metaDataRequest = "<metadataRequest connection=\""
					+ packageName
					+ "\">"
					+ "<Metadata Depth=\"\" "
					+ "no_collections=\"1\">"
					+ "<Properties>"
					+ "<Property name=\"*/@name\"/>"
					+ "<Property name=\"*/@datatype\"/>"
					+ "<Property name=\"*/@_path\"/>"
					+ "<Property name=\"*/@_ref\"/>"
					+ "<Property name=\"*/@usage\"/>"
					+ "<Property name=\"*/folder\"/>"
					+ "<Property name=\"./querySubject\"/>"
					+ "<Property name=\"./queryItem\"/>"
					+ "<Property name=\"*/measure\"/>"
					+ "<Property name=\"*/member\"/>"
					+ "<Property name=\"*/level\"/>"
					+ "<Property name=\"*/fact\"/>"
					+ "<Property name=\"*/hierarchy\"/>"
					+ "</Properties>"
					+ "</Metadata>"
					+ "</metadataRequest>";


				reportServiceMetadataSpecification mdSpec = new reportServiceMetadataSpecification();
				mdSpec.value = new specification();
				mdSpec.value.Value = metaDataRequest;

				asynchReply mdResponse = cBIServer.CBIRS.runSpecification(mdSpec,new parameterValue[] {}, new option [] {});

				asynchDetailReportMetadata reportMD = null;

				for (int i = 0; i < mdResponse.details.Length; i++)
				{
					if (mdResponse.details[i] is asynchDetailReportMetadata)
					{
						reportMD = (asynchDetailReportMetadata) mdResponse.details[i];
						break;
					}
				}
				string metaDataString = reportMD.metadata.Value;
				return metaDataString;
			}
			catch(SoapException ex)
			{
				SamplesException.ShowExceptionMessage( ex, true, "Create Report Sample - getPackageMetaData" );
				return "";
			}
			catch(System.Exception ex)
			{
				SamplesException.ShowExceptionMessage( ex.Message, true, "Create Report Sample - getPackageMetaData" );
				return "";
			}
		}

		public TableData[] buildUpTableData(string metaDataResponse)
		{
			try
			{
				string tableName = "";
				XmlNodeWrapper[] tableColumns = null;
				TableData[] tableNameColumnMap = null;

				// Load the metadata XML into a DOM
				XmlDocument metaDataDocument = new XmlDocument();
				XmlNodeList tableNodes;
				XmlNode tableNode;
				XmlNode tableAttributeNode;

				metaDataDocument.LoadXml(metaDataResponse);

				// Parse the XML and build up the table objects
				XmlElement root = metaDataDocument.DocumentElement;
				tableNodes = root.SelectNodes("//querySubject");
				if (tableNodes.Count == 0)
				{
					tableNodes = root.SelectNodes("//folder/folder");
				}
				int nbTables = tableNodes.Count;
				tableNameColumnMap = new TableData[nbTables];
				for (int i=0; i<nbTables; i++)
				{
					tableNode = tableNodes[i];
					tableAttributeNode = tableNode.Attributes.GetNamedItem("name");
					tableName = tableAttributeNode.Value;
					if (tableNode.HasChildNodes)
					{
						//XmlNodeList of report-insertable items
						XmlNodeList tableColumnList1 = tableNode.SelectNodes(".//measure");
						XmlNodeList tableColumnList2 = tableNode.SelectNodes(".//queryItem");

						tableColumns = new XmlNodeWrapper[tableColumnList1.Count + tableColumnList2.Count];

						//add first list of nodes, if any
						for (int j=0; j<tableColumnList1.Count; j++)
						{
							XmlNode tableColumnNode = tableColumnList1[j];
							XmlNodeWrapper tableColumnAttrNode = new XmlNodeWrapper(tableColumnNode);
							tableColumns[j] = tableColumnAttrNode;
						}
						//add second list of nodes, if any
						for (int j=tableColumnList1.Count;j < tableColumnList1.Count+tableColumnList2.Count; j++)
						{
							XmlNode tableColumnNode = tableColumnList2[j-tableColumnList1.Count];
							XmlNodeWrapper tableColumnAttrNode = new XmlNodeWrapper(tableColumnNode);
							tableColumns[j] = tableColumnAttrNode;
						}
					}
					tableNameColumnMap[i] = new TableData(tableName, tableColumns);				
				}
				return tableNameColumnMap;
			}
			catch(SoapException ex)
			{
				SamplesException.ShowExceptionMessage( ex, true, "Create Report Sample - buildUpTableData" );
				return null;
			}
			catch(System.Exception ex)
			{
				SamplesException.ShowExceptionMessage( ex.Message, true, "Create Report Sample - buildUpTableData" );
				return null;
			}
		}
	}

}
