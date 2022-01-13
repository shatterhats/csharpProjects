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
using System.Xml;

using SamplesCommon;

namespace CreateReport
{
	/// <summary>
	/// Summary description for CreateReportTableDlg.
	/// </summary>
	public class CreateReportTableDlg : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button buttonOK;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.Label tablesLBL;
		private System.Windows.Forms.ComboBox tablesCB;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		public bool isOKed = false;
		private System.Windows.Forms.ListBox availableColumnsLB;
		private System.Windows.Forms.ListBox selectedColumnsLB;
		private System.Windows.Forms.Button buttonAddItem;
		private System.Windows.Forms.Button buttonRemoveItem;
		public static TableData[] m_tableNameColumnMap = null;
		public string m_packageName = "";
		public string m_reportName = "";
		public string m_tableName = "";
		public string[] m_columnList = null;

		public CreateReportTableDlg()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		public CreateReportTableDlg(TableData[] tableNameColumnMap, string packageName, string reportName)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			m_tableNameColumnMap = tableNameColumnMap;
			m_packageName = packageName;
			m_reportName = reportName;
			m_tableName = "";
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateReportTableDlg));
            this.tablesLBL = new System.Windows.Forms.Label();
            this.tablesCB = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.availableColumnsLB = new System.Windows.Forms.ListBox();
            this.buttonAddItem = new System.Windows.Forms.Button();
            this.buttonRemoveItem = new System.Windows.Forms.Button();
            this.selectedColumnsLB = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tablesLBL
            // 
            this.tablesLBL.Location = new System.Drawing.Point(16, 8);
            this.tablesLBL.Name = "tablesLBL";
            this.tablesLBL.Size = new System.Drawing.Size(48, 16);
            this.tablesLBL.TabIndex = 0;
            this.tablesLBL.Text = "Tables:";
            // 
            // tablesCB
            // 
            this.tablesCB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tablesCB.Location = new System.Drawing.Point(16, 24);
            this.tablesCB.Name = "tablesCB";
            this.tablesCB.Size = new System.Drawing.Size(184, 21);
            this.tablesCB.TabIndex = 1;
            this.tablesCB.SelectedIndexChanged += new System.EventHandler(this.tablesCB_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.Location = new System.Drawing.Point(16, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Available Columns:";
            // 
            // availableColumnsLB
            // 
            this.availableColumnsLB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.availableColumnsLB.HorizontalScrollbar = true;
            this.availableColumnsLB.Location = new System.Drawing.Point(16, 80);
            this.availableColumnsLB.Name = "availableColumnsLB";
            this.availableColumnsLB.Size = new System.Drawing.Size(184, 225);
            this.availableColumnsLB.TabIndex = 3;
            // 
            // buttonAddItem
            // 
            this.buttonAddItem.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.buttonAddItem.Location = new System.Drawing.Point(216, 152);
            this.buttonAddItem.Name = "buttonAddItem";
            this.buttonAddItem.Size = new System.Drawing.Size(72, 24);
            this.buttonAddItem.TabIndex = 4;
            this.buttonAddItem.Text = "> > >";
            this.buttonAddItem.Click += new System.EventHandler(this.buttonAddItem_Click);
            // 
            // buttonRemoveItem
            // 
            this.buttonRemoveItem.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.buttonRemoveItem.Location = new System.Drawing.Point(216, 208);
            this.buttonRemoveItem.Name = "buttonRemoveItem";
            this.buttonRemoveItem.Size = new System.Drawing.Size(75, 23);
            this.buttonRemoveItem.TabIndex = 5;
            this.buttonRemoveItem.Text = "< < <";
            this.buttonRemoveItem.Click += new System.EventHandler(this.buttonRemoveItem_Click);
            // 
            // selectedColumnsLB
            // 
            this.selectedColumnsLB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.selectedColumnsLB.HorizontalScrollbar = true;
            this.selectedColumnsLB.Location = new System.Drawing.Point(304, 80);
            this.selectedColumnsLB.Name = "selectedColumnsLB";
            this.selectedColumnsLB.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.selectedColumnsLB.Size = new System.Drawing.Size(184, 225);
            this.selectedColumnsLB.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.Location = new System.Drawing.Point(304, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "Selected Columns";
            // 
            // buttonOK
            // 
            this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOK.Location = new System.Drawing.Point(304, 320);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 8;
            this.buttonOK.Text = "OK";
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.Location = new System.Drawing.Point(408, 320);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 9;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // CreateReportTableDlg
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(512, 358);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.selectedColumnsLB);
            this.Controls.Add(this.buttonRemoveItem);
            this.Controls.Add(this.buttonAddItem);
            this.Controls.Add(this.availableColumnsLB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tablesCB);
            this.Controls.Add(this.tablesLBL);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CreateReportTableDlg";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "CreateReportTableDlg";
            this.Load += new System.EventHandler(this.CreateReportTableDlg_Load);
            this.ResumeLayout(false);

		}
		#endregion

		private void buttonCancel_Click(object sender, System.EventArgs e)
		{
			isOKed = false;
			this.Close();
		}

		private void buttonOK_Click(object sender, System.EventArgs e)
		{
			isOKed = true;
			this.Close();
		}

		private void CreateReportTableDlg_Load(object sender, System.EventArgs e)
		{
		
		}

		private void tablesCB_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			availableColumnsLB.Items.Clear();
			string selectedTableName = (string)tablesCB.SelectedItem;
			if (selectedTableName == null)
			{
				return;
			}
			for (int i=0; i<m_tableNameColumnMap.GetLength(0); i++)
			{
				string currentTableName = m_tableNameColumnMap[i].getTableName();
				if (0 == selectedTableName.CompareTo(currentTableName))
				{
					// found the selected table name in the Table/Column map
					// now retrieve the associated columns for display
					int nbColumns = m_tableNameColumnMap[i].getColumns().GetLength(0);
					XmlNodeWrapper[] columns = new XmlNodeWrapper[nbColumns];
					columns = m_tableNameColumnMap[i].getColumns();
					for (int j=0; j<nbColumns; j++)
					{
						availableColumnsLB.Items.Add(columns[j]);
					}
					break;
				}
			}
		}

		private void buttonAddItem_Click(object sender, System.EventArgs e)
		{
			string selectedText = availableColumnsLB.SelectedItem.ToString();
			if ( (selectedText != null) && (0 !=selectedText.CompareTo("")) && 
				!selectedColumnsLB.Items.Contains(availableColumnsLB.SelectedItem) )
			{
				selectedColumnsLB.Items.Add(availableColumnsLB.SelectedItem);
			}
		}

		private void buttonRemoveItem_Click(object sender, System.EventArgs e)
		{			
			int selectedIndex = selectedColumnsLB.SelectedIndex;
			if (selectedIndex >= 0)
			{
				selectedColumnsLB.Items.RemoveAt(selectedIndex);
			}
		}

		public XmlNodeWrapper[] getSelectedColumnList() 
		{
			int nbSelectedColumns = selectedColumnsLB.Items.Count;
			XmlNodeWrapper[] selectedColumns = new XmlNodeWrapper[nbSelectedColumns];
			for (int i=0; i<nbSelectedColumns; i++)
			{
				selectedColumns[i] = (XmlNodeWrapper)selectedColumnsLB.Items[i];
			}
			return selectedColumns;
		}

		public string getSelectedTableName()
		{
			string selectedTableName = (string)tablesCB.SelectedItem;
			if ( (selectedTableName == null) || (0 == selectedTableName.CompareTo("")) )
			{
				MessageBox.Show("Please select a table name.");
			}
			return selectedTableName;
		}

		public void populateTableNameList()
		{
			tablesCB.Items.Clear();
			if (m_tableNameColumnMap.GetLength(0) <= 0)
			{
				return;
			}
			int nbTables = m_tableNameColumnMap.GetLength(0);
			for (int i=0; i<nbTables; i++)
			{
				tablesCB.Items.Add(m_tableNameColumnMap[i].getTableName());
			}
		}

		public void selectTableIndex(int index)
		{
			tablesCB.SelectedIndex = index;
		}

	}
}
