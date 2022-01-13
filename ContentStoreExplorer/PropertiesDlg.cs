/** 
Licensed Materials - Property of IBM

IBM Cognos Products: DOCS

(C) Copyright IBM Corp. 2005

US Government Users Restricted Rights - Use, duplication or disclosure restricted by GSA ADP Schedule Contract with
IBM Corp.
*/
using System;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Web.Services.Protocols;
using SamplesCommon;
using cognosdotnet_10_2;

namespace ContentStoreExplorer
{
	/// <summary>
	/// Summary description for PropertiesDlg.
	/// </summary>
	public class PropertiesDlg : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button buttonCancel;
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.TabControl tabControlProperties;
		private System.Windows.Forms.TabPage tabPageTypes;
		private System.Windows.Forms.ColumnHeader typeColumnHeaderName;
		private System.Windows.Forms.ColumnHeader typeColumnHeaderType;
		private System.Windows.Forms.ColumnHeader typeColumnHeaderValue;
		private System.Windows.Forms.TabPage tabPageValues;
		private System.Windows.Forms.ColumnHeader valuesLVColumnHeaderName;
		private System.Windows.Forms.ColumnHeader valuesLVColumnHeaderValue;
		private System.Windows.Forms.ListView valuesListView;
		private System.Windows.Forms.ColumnHeader typesLVcolumnHeaderName;
		private System.Windows.Forms.ColumnHeader typesLVcolumnHeaderValue;
		private System.Windows.Forms.ColumnHeader typesLVcolumnHeaderType;
		private System.Windows.Forms.ListView typesListView;
		
		/// <summary>
		// *** User Defined Globals ***
		/// </summary>
		/// 
		private contentManagerService1 cBIServer = null;
		private string itemSearchPath = "";
		private object selectedObject = null;
		private baseClass selectedBCObject = null;
		private int IMAGE_COLLAPSED = 0;
		private int IMAGE_EXPANDED = 1;
		private int NO_IMAGE = 99;
		// ****************************

		public PropertiesDlg()
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(PropertiesDlg));
			this.buttonCancel = new System.Windows.Forms.Button();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.tabControlProperties = new System.Windows.Forms.TabControl();
			this.tabPageValues = new System.Windows.Forms.TabPage();
			this.valuesListView = new System.Windows.Forms.ListView();
			this.valuesLVColumnHeaderName = new System.Windows.Forms.ColumnHeader();
			this.valuesLVColumnHeaderValue = new System.Windows.Forms.ColumnHeader();
			this.tabPageTypes = new System.Windows.Forms.TabPage();
			this.typesListView = new System.Windows.Forms.ListView();
			this.typesLVcolumnHeaderName = new System.Windows.Forms.ColumnHeader();
			this.typesLVcolumnHeaderValue = new System.Windows.Forms.ColumnHeader();
			this.typesLVcolumnHeaderType = new System.Windows.Forms.ColumnHeader();
			this.typeColumnHeaderName = new System.Windows.Forms.ColumnHeader();
			this.typeColumnHeaderValue = new System.Windows.Forms.ColumnHeader();
			this.typeColumnHeaderType = new System.Windows.Forms.ColumnHeader();
			this.tabControlProperties.SuspendLayout();
			this.tabPageValues.SuspendLayout();
			this.tabPageTypes.SuspendLayout();
			this.SuspendLayout();
			// 
			// buttonCancel
			// 
			this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.Location = new System.Drawing.Point(400, 528);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(88, 32);
			this.buttonCancel.TabIndex = 2;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
			// 
			// imageList1
			// 
			this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// tabControlProperties
			// 
			this.tabControlProperties.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.tabControlProperties.Controls.Add(this.tabPageValues);
			this.tabControlProperties.Controls.Add(this.tabPageTypes);
			this.tabControlProperties.ImageList = this.imageList1;
			this.tabControlProperties.Location = new System.Drawing.Point(8, 8);
			this.tabControlProperties.Name = "tabControlProperties";
			this.tabControlProperties.SelectedIndex = 0;
			this.tabControlProperties.Size = new System.Drawing.Size(480, 512);
			this.tabControlProperties.TabIndex = 8;
			// 
			// tabPageValues
			// 
			this.tabPageValues.Controls.Add(this.valuesListView);
			this.tabPageValues.ImageIndex = 2;
			this.tabPageValues.Location = new System.Drawing.Point(4, 23);
			this.tabPageValues.Name = "tabPageValues";
			this.tabPageValues.Size = new System.Drawing.Size(472, 485);
			this.tabPageValues.TabIndex = 2;
			this.tabPageValues.Text = "Values";
			// 
			// valuesListView
			// 
			this.valuesListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.valuesListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																							 this.valuesLVColumnHeaderName,
																							 this.valuesLVColumnHeaderValue});
			this.valuesListView.GridLines = true;
			this.valuesListView.LabelEdit = true;
			this.valuesListView.LargeImageList = this.imageList1;
			this.valuesListView.Location = new System.Drawing.Point(8, 8);
			this.valuesListView.MultiSelect = false;
			this.valuesListView.Name = "valuesListView";
			this.valuesListView.Size = new System.Drawing.Size(456, 472);
			this.valuesListView.SmallImageList = this.imageList1;
			this.valuesListView.StateImageList = this.imageList1;
			this.valuesListView.TabIndex = 0;
			this.valuesListView.View = System.Windows.Forms.View.Details;
			this.valuesListView.Click += new System.EventHandler(this.valuesListView_Click);
			// 
			// valuesLVColumnHeaderName
			// 
			this.valuesLVColumnHeaderName.Text = "Name";
			this.valuesLVColumnHeaderName.Width = 225;
			// 
			// valuesLVColumnHeaderValue
			// 
			this.valuesLVColumnHeaderValue.Text = "Value";
			this.valuesLVColumnHeaderValue.Width = 225;
			// 
			// tabPageTypes
			// 
			this.tabPageTypes.Controls.Add(this.typesListView);
			this.tabPageTypes.ImageIndex = 3;
			this.tabPageTypes.Location = new System.Drawing.Point(4, 23);
			this.tabPageTypes.Name = "tabPageTypes";
			this.tabPageTypes.Size = new System.Drawing.Size(472, 485);
			this.tabPageTypes.TabIndex = 1;
			this.tabPageTypes.Text = "Types";
			// 
			// typesListView
			// 
			this.typesListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.typesListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																							this.typesLVcolumnHeaderName,
																							this.typesLVcolumnHeaderValue,
																							this.typesLVcolumnHeaderType});
			this.typesListView.FullRowSelect = true;
			this.typesListView.GridLines = true;
			this.typesListView.LargeImageList = this.imageList1;
			this.typesListView.Location = new System.Drawing.Point(8, 8);
			this.typesListView.Name = "typesListView";
			this.typesListView.Size = new System.Drawing.Size(456, 472);
			this.typesListView.SmallImageList = this.imageList1;
			this.typesListView.StateImageList = this.imageList1;
			this.typesListView.TabIndex = 0;
			this.typesListView.View = System.Windows.Forms.View.Details;
			this.typesListView.Click += new System.EventHandler(this.typesListView_Click);
			// 
			// typesLVcolumnHeaderName
			// 
			this.typesLVcolumnHeaderName.Text = "Name";
			this.typesLVcolumnHeaderName.Width = 150;
			// 
			// typesLVcolumnHeaderValue
			// 
			this.typesLVcolumnHeaderValue.Text = "Value";
			this.typesLVcolumnHeaderValue.Width = 150;
			// 
			// typesLVcolumnHeaderType
			// 
			this.typesLVcolumnHeaderType.Text = "Type";
			this.typesLVcolumnHeaderType.Width = 150;
			// 
			// typeColumnHeaderName
			// 
			this.typeColumnHeaderName.Text = "Name";
			this.typeColumnHeaderName.Width = 150;
			// 
			// typeColumnHeaderValue
			// 
			this.typeColumnHeaderValue.Text = "Value";
			this.typeColumnHeaderValue.Width = 150;
			// 
			// typeColumnHeaderType
			// 
			this.typeColumnHeaderType.Text = "Type";
			this.typeColumnHeaderType.Width = 150;
			// 
			// PropertiesDlg
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.buttonCancel;
			this.ClientSize = new System.Drawing.Size(500, 566);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.tabControlProperties);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "PropertiesDlg";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Properties";
			this.Load += new System.EventHandler(this.PropertiesDlg_Load);
			this.tabControlProperties.ResumeLayout(false);
			this.tabPageValues.ResumeLayout(false);
			this.tabPageTypes.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void buttonCancel_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		
		private void PropertiesDlg_Load(object sender, System.EventArgs e)
		{
			int arrIdx = 0;
			sort[] sortOptions = { new sort() };
			searchPathMultipleObject itemSP = new searchPathMultipleObject();
			itemSP.Value = itemSearchPath;

			// 1. get the object from Server
			selectedBCObject = cBIServer.query(itemSP, 
				new propEnum[] {propEnum.objectClass}, 
				new sort[] {}, 
				new queryOptions())[0];

			// 2. get the list of field names in the object use it to build the list of propEnum 
			// and query for the proper object fields.

			this.Text = selectedBCObject.objectClass.value.ToString() + " Properties"; 
			System.Type objType = selectedBCObject.GetType();
			int nbFields = objType.GetFields().GetLength(0);
			propEnum[] propEnumArr = new propEnum[nbFields];
			foreach (FieldInfo fieldInfo in objType.GetFields()) 
			{
				propEnumArr[arrIdx] = getPropEnumElement(fieldInfo.Name);
				arrIdx++;
			}

			// 3. Query for the object again to get the values
			sortOptions[0].order = orderEnum.ascending;
			sortOptions[0].propName = propEnum.defaultName;
			selectedBCObject = cBIServer.query(itemSP, 
				propEnumArr, 
				new sort[] {}, 
				new queryOptions())[0];

			// 4. Build the table and insert the name/value pairs
			typesListView.Items.Clear();
			valuesListView.Items.Clear();

			selectedObject = (object)selectedBCObject;
			populateListView(selectedObject, valuesListView);
			populateListView(selectedObject, typesListView);
			
			typesListView.Columns[0].Width = -2; // autosize
			typesListView.Columns[1].Width = 100;
			typesListView.Columns[2].Width = -2;

			valuesListView.Columns[0].Width = -2;
			valuesListView.Columns[0].Width = 200;
		}

		private void typesListView_Click(object sender, System.EventArgs e)
		{
			try
			{
				if ( (typesListView.SelectedItems != null) && (typesListView.SelectedItems.Count == 1) )
				{
					if (typesListView.SelectedItems[0].ImageIndex == IMAGE_COLLAPSED)
					{
						int itemIdx = typesListView.SelectedItems[0].Index;
						if (addChildItems(typesListView.SelectedItems[0].Tag, "", ref itemIdx, typesListView))
						{
							// has children, update the icon
							typesListView.SelectedItems[0].ImageIndex = IMAGE_EXPANDED;
						}
					}
					else if (typesListView.SelectedItems[0].ImageIndex == IMAGE_EXPANDED)
					{
						typesListView.SelectedItems[0].ImageIndex = IMAGE_COLLAPSED;
						removeChildItems(typesListView.SelectedItems[0], typesListView);
					}
				}
				typesListView.Columns[0].Width = -2; // autosize
				typesListView.Columns[1].Width = 100;
				typesListView.Columns[2].Width = -2;
			}
			catch(System.Exception ex)
			{
				if (0 != ex.Message.CompareTo("INPUT_CANCELLED_BY_USER"))
				{
					SamplesException.ShowExceptionMessage( ex.Message, true, "Client Error: " );
				}
				return;
			}
		}

		private void valuesListView_Click(object sender, System.EventArgs e)
		{
			try
			{
				if ( (valuesListView.SelectedItems != null) && (valuesListView.SelectedItems.Count == 1) )
				{
					if (valuesListView.SelectedItems[0].ImageIndex == IMAGE_COLLAPSED)
					{
						int itemIdx = valuesListView.SelectedItems[0].Index;
						if (addChildItems(valuesListView.SelectedItems[0].Tag, "", ref itemIdx, valuesListView))
						{
							// has children, update the icon
							valuesListView.SelectedItems[0].ImageIndex = IMAGE_EXPANDED;
						}
					}
					else if (valuesListView.SelectedItems[0].ImageIndex == IMAGE_EXPANDED)
					{
						valuesListView.SelectedItems[0].ImageIndex = IMAGE_COLLAPSED;
						removeChildItems(valuesListView.SelectedItems[0], valuesListView);
					}
				}
				valuesListView.Columns[0].Width = -2; // autosize
				valuesListView.Columns[1].Width = 200;
				this.Width = valuesListView.Columns[0].Width + valuesListView.Columns[1].Width + 45;
			}
			catch(System.Exception ex)
			{
				if (0 != ex.Message.CompareTo("INPUT_CANCELLED_BY_USER"))
				{
					SamplesException.ShowExceptionMessage( ex.Message, true, "Client Error: " );
				}
				return;
			}
		}

		public void setItemSearchPath(string searchPath)
		{
			itemSearchPath = searchPath;
		}

		public void setConnection(contentManagerService1 cmService)
		{
			cBIServer = cmService;
		}

		public void populateListView(object selectedObject, ListView lvObject)
		{
			object objVal = null;
			string objValType = "";
			string objValString = "";
			ListViewItem item = null;
			System.Type objType = selectedObject.GetType();
			
			foreach (FieldInfo fieldInfo in objType.GetFields()) 
			{
				objVal = fieldInfo.GetValue(selectedObject);
				if (objVal == null)
				{
					item = new ListViewItem(fieldInfo.Name, NO_IMAGE);
					item.Tag = objVal;
					item.SubItems.Add("null"); // value column
					if (0 == lvObject.Name.CompareTo("typesListView"))
					{
						item.SubItems.Add("<type inaccessible for null objects>"); // type column
					}
					lvObject.Items.AddRange(new ListViewItem[]{item});
				}
				else 
				{
					if (0 == lvObject.Name.CompareTo("valuesListView"))
					{
						objValString = "";
						if (0 == fieldInfo.Name.CompareTo("objectClass"))
						{
							objValString = selectedBCObject.objectClass.value.ToString();
						}
						else
						{
							getObjectValue(objVal, ref objValString);
						}
						
						if (0 == objValString.CompareTo("ARRAY"))
						{
							objValString = "";
							item = new ListViewItem(fieldInfo.Name, IMAGE_COLLAPSED);
						}
						else
						{
							item = new ListViewItem(fieldInfo.Name, NO_IMAGE);
						}
						item.Tag = objVal;
						item.SubItems.Add(objValString); // value column
					}
					else
					{
						item = new ListViewItem(fieldInfo.Name, IMAGE_COLLAPSED);
						item.Tag = objVal;
						item.SubItems.Add(""); // value column
						objValType = objVal.GetType().ToString();
						objValType = objValType.Substring(13, objValType.Length-13);
						item.SubItems.Add(objValType);   // type column
					}
					lvObject.Items.AddRange(new ListViewItem[]{item});
				}
			}
		}

		public void getObjectValue(object objVal, ref string result)
		{
			object childObjVal = null;
			foreach (FieldInfo valfieldInfo in objVal.GetType().GetFields()) 
			{
				childObjVal = valfieldInfo.GetValue(objVal);
				if (childObjVal != null)
				{
					if (isArrayType(childObjVal))
					{
						result = "ARRAY";
					}
					else if (!findSimpleTypeValue(childObjVal, ref result))
					{
						result = "null";
					}
					break;
				}
				else
				{
					result = "null";
				}
			}
		}

		public bool findSimpleTypeValue(object obj, ref string objValString)
		{
			if (obj == null)
			{
				return false;
			}
			int intObj = 0;
			bool boolObj = false;
			string stringObj = "";
			baseClass[] bcObj = new baseClass[1];
			System.DateTime dateObj = new DateTime();
			if (obj.GetType().Equals(stringObj.GetType()))
			{
				objValString += (string)obj;
				return true;
			}
			else if (obj.GetType().Equals(dateObj.GetType()))
			{
				objValString += ((DateTime)obj).ToLongDateString() + "; " + ((DateTime)obj).ToLongTimeString();
				return true;
			}
			else if (obj.GetType().Equals(boolObj.GetType()))
			{
				boolObj = ((bool)obj);
				if (boolObj)
				{
					objValString += "true";
				}
				else
				{
					objValString += "false";
				}
				return true;
			}
			else if (obj.GetType().Equals(intObj.GetType()))
			{
				objValString +=((int)obj).ToString();
				return true;
			}
			else
			{
				return false;
			}
		}

		public bool isArrayType(object obj)
		{
			if (0 == obj.GetType().BaseType.ToString().CompareTo("System.Array"))
			{
				return true;
			}
			return false;
		}
		public propEnum getPropEnumElement(string enumName)
		{
			switch (enumName)
			{
				case "active":
					return propEnum.active;
				case "actualCompletionTime":
					return propEnum.actualCompletionTime;
				case "actualExecutionTime":
					return propEnum.actualExecutionTime;
				case "advancedSettings":
					return propEnum.advancedSettings;
				case "ancestors":
					return propEnum.ancestors;
				case "asOfTime":
					return propEnum.asOfTime;
				case "base":
					return propEnum.@base;
				case "brsAffineConnections":
					return propEnum.brsAffineConnections;
				case "brsMaximumProcesses":
					return propEnum.brsMaximumProcesses;
				case "brsNonAffineConnections":
					return propEnum.brsNonAffineConnections;
				case "burstKey":
					return propEnum.burstKey;
				case "businessPhone":
					return propEnum.businessPhone;
				case "canBurst":
					return propEnum.canBurst;
				case "capabilities":
					return propEnum.capabilities;
				case "capacity":
					return propEnum.capacity;
//				case "configuration":
//					return propEnum.configuration;
				case "connections":
					return propEnum.connections;
				case "connectionString":
					return propEnum.connectionString;
				case "consumers":
					return propEnum.consumers;
				case "contact":
					return propEnum.contact;
				case "contactEMail":
					return propEnum.contactEMail;
				case "contentLocale":
					return propEnum.contentLocale;
				case "creationTime":
					return propEnum.creationTime;
				case "credential":
					return propEnum.credential;
				case "credentialNamespaces":
					return propEnum.credentialNamespaces;
				case "credentials":
					return propEnum.credentials;
				case "dailyPeriod":
					return propEnum.dailyPeriod;
				case "data":
					return propEnum.data;
				case "dataSize":
					return propEnum.dataSize;
				case "dataType":
					return propEnum.dataType;
				case "defaultDescription":
					return propEnum.defaultDescription;
				case "defaultName":
					return propEnum.defaultName;
				case "defaultOutputFormat":
					return propEnum.defaultOutputFormat;
				case "defaultScreenTip":
					return propEnum.defaultScreenTip;
				case "defaultTriggerDescription":
					return propEnum.defaultTriggerDescription;
				case "deployedObject":
					return propEnum.deployedObject;
				case "deployedObjectAncestorDefaultNames":
					return propEnum.deployedObjectAncestorDefaultNames;
				case "deployedObjectClass":
					return propEnum.deployedObjectClass;
				case "deployedObjectStatus":
					return propEnum.deployedObjectStatus;
				case "deployedObjectUsage":
					return propEnum.deployedObjectUsage;
				case "description":
					return propEnum.description;
				case "disabled":
					return propEnum.disabled;
				case "dispatcherID":
					return propEnum.dispatcherID;
				case "dispatcherPath":
					return propEnum.dispatcherPath;
				case "displaySequence":
					return propEnum.displaySequence;
				case "email":
					return propEnum.email;
				case "endDate":
					return propEnum.endDate;
				case "endType":
					return propEnum.endType;
				case "eventID":
					return propEnum.eventID;
				case "everyNPeriods":
					return propEnum.everyNPeriods;
//				case "executionDetails":
//					return propEnum.executionDetails;
				case "executionPageDefinition":
					return propEnum.executionPageDefinition;
				case "faxPhone":
					return propEnum.faxPhone;
				case "format":
					return propEnum.format;
				case "givenName":
					return propEnum.givenName;
				case "governors":
					return propEnum.governors;
				case "hasChildren":
					return propEnum.hasChildren;
				case "hasMessage":
					return propEnum.hasMessage;
				case "height":
					return propEnum.height;
				case "homePhone":
					return propEnum.homePhone;
				case "horizontalElementsRenderingLimit":
					return propEnum.horizontalElementsRenderingLimit;
				case "identity":
					return propEnum.identity;
				case "isolationLevel":
					return propEnum.isolationLevel;
//				case "jsmNonPeakDemandBeginHour":
//					return propEnum.jsmNonPeakDemandBeginHour;
//				case "jsmNonPeakDemandMaximumJobs":
//					return propEnum.jsmNonPeakDemandMaximumJobs;
//				case "jsmPeakDemandBeginHour":
//					return propEnum.jsmPeakDemandBeginHour;
//				case "jsmPeakDemandMaximumJobs":
//					return propEnum.jsmPeakDemandMaximumJobs;
				case "lastConfigurationModificationTime":
					return propEnum.lastConfigurationModificationTime;
				case "lastPage":
					return propEnum.lastPage;
				case "loadBalancingMode":
					return propEnum.loadBalancingMode;
				case "locale":
					return propEnum.locale;
				case "location":
					return propEnum.location;
//				case "lsAuditAdminLevel":
//					return propEnum.lsAuditAdminLevel;
//				case "lsAuditLevel":
//					return propEnum.lsAuditLevel;
//				case "lsAuditOtherLevel":
//					return propEnum.lsAuditOtherLevel;
//				case "lsAuditUsageLevel":
//					return propEnum.lsAuditUsageLevel;
				case "members":
					return propEnum.members;
				case "metadataModel":
					return propEnum.metadataModel;
				case "mobilePhone":
					return propEnum.mobilePhone;
				case "model":
					return propEnum.model;
				case "modelName":
					return propEnum.modelName;
				case "modificationTime":
					return propEnum.modificationTime;
				case "monthlyAbsoluteDay":
					return propEnum.monthlyAbsoluteDay;
				case "monthlyRelativeDay":
					return propEnum.monthlyRelativeDay;
				case "monthlyRelativeWeek":
					return propEnum.monthlyRelativeWeek;
				case "name":
					return propEnum.name;
				case "namespaceFormat":
					return propEnum.namespaceFormat;
				case "objectClass":
					return propEnum.objectClass;
				case "output":
					return propEnum.output;
				case "owner":
					return propEnum.owner;
				case "ownerPassport":
					return propEnum.ownerPassport;
				case "packageBase":
					return propEnum.packageBase;
				case "page":
					return propEnum.page;
				case "pageOrientation":
					return propEnum.pageOrientation;
				case "pagerPhone":
					return propEnum.pagerPhone;
				case "parameters":
					return propEnum.parameters;
				case "parent":
					return propEnum.parent;
				case "paths":
					return propEnum.paths;
				case "permissions":
					return propEnum.permissions;
				case "policies":
					return propEnum.policies;
				case "portalPage":
					return propEnum.portalPage;
//				case "portalPreferences":
//					return propEnum.portalPreferences;
				case "position":
					return propEnum.position;
				case "postalAddress":
					return propEnum.postalAddress;
				case "printerAddress":
					return propEnum.printerAddress;
				case "productLocale":
					return propEnum.productLocale;
				case "qualifier":
					return propEnum.qualifier;
				case "recipients":
					return propEnum.recipients;
				case "recipientsEMail":
					return propEnum.recipientsEMail;
				case "related":
					return propEnum.related;
				case "replacement":
					return propEnum.replacement;
				case "requestedExecutionTime":
					return propEnum.requestedExecutionTime;
				case "retentions":
					return propEnum.retentions;
				case "rsAffineConnections":
					return propEnum.rsAffineConnections;
				case "rsMaximumProcesses":
					return propEnum.rsMaximumProcesses;
				case "rsNonAffineConnections":
					return propEnum.rsNonAffineConnections;
				case "rsQueueLimit":
					return propEnum.rsQueueLimit;
				case "runAsOwner":
					return propEnum.runAsOwner;
				case "runningState":
					return propEnum.runningState;
				case "screenTip":
					return propEnum.screenTip;
				case "searchPath":
					return propEnum.searchPath;
				case "sequencing":
					return propEnum.sequencing;
				case "serverGroup":
					return propEnum.serverGroup;
				case "source":
					return propEnum.source;
				case "specification":
					return propEnum.specification;
				case "startAsActive":
					return propEnum.startAsActive;
				case "startDate":
					return propEnum.startDate;
				case "state":
					return propEnum.state;
				case "status":
					return propEnum.status;
				case "stepObject":
					return propEnum.stepObject;
				case "surname":
					return propEnum.surname;
				case "target":
					return propEnum.target;
				case "taskID":
					return propEnum.taskID;
				case "timeZoneID":
					return propEnum.timeZoneID;
				case "triggerDescription":
					return propEnum.triggerDescription;
				case "triggerName":
					return propEnum.triggerName;
				case "type":
					return propEnum.type;
				case "unit":
					return propEnum.unit;
				case "uri":
					return propEnum.uri;
				case "usage":
					return propEnum.usage;
				case "user":
					return propEnum.user;
				case "userCapabilities":
					return propEnum.userCapabilities;
				case "userCapability":
					return propEnum.userCapability;
				case "userName":
					return propEnum.userName;
				case "version":
					return propEnum.version;
				case "verticalElementsRenderingLimit":
					return propEnum.verticalElementsRenderingLimit;
				case "viewed":
					return propEnum.viewed;
				case "weeklyFriday":
					return propEnum.weeklyFriday;
				case "weeklyMonday":
					return propEnum.weeklyMonday;
				case "weeklySaturday":
					return propEnum.weeklySaturday;
				case "weeklySunday":
					return propEnum.weeklySunday;
				case "weeklyThursday":
					return propEnum.weeklyThursday;
				case "weeklyTuesday":
					return propEnum.weeklyTuesday;
				case "weeklyWednesday":
					return propEnum.weeklyWednesday;
				case "width":
					return propEnum.width;
				case "yearlyAbsoluteDay":
					return propEnum.yearlyAbsoluteDay;
				case "yearlyAbsoluteMonth":
					return propEnum.yearlyAbsoluteMonth;
				case "yearlyRelativeDay":
					return propEnum.yearlyRelativeDay;
				case "yearlyRelativeMonth":
					return propEnum.yearlyRelativeMonth;
				case "yearlyRelativeWeek":
					return propEnum.yearlyRelativeWeek;
				default:
					return 0;
			}
		}

		public bool addChildItems(object objVal, string indent, ref int itemIdx, ListView lvObject)
		{
			int nbFields = 0;
			string sObjType = "";
			object childObj = null;
			ListViewItem item = null;
			FieldInfo[] fieldInfo;
			System.Type objType = objVal.GetType();
			
			indent += "    ";
			fieldInfo = objType.GetFields();
			nbFields = fieldInfo.GetLength(0);
			if (nbFields == 0)
			{
				if (isArrayType(objVal))
				{
					constructArrayRows(objVal, indent, ref itemIdx, lvObject);
				}
			}
			for(int i=0; i < nbFields; i++)
			{
				childObj = fieldInfo[i].GetValue(objVal);
				if ( (childObj == null) && (0 != fieldInfo[i].Name.CompareTo("schemaInfo")) &&
					(0 == lvObject.Name.CompareTo("typesListView")) )
				{
					item = new ListViewItem(indent + "." + fieldInfo[i].Name, NO_IMAGE);
					item.Tag = childObj;
					item.SubItems.Add("null");
					item.SubItems.Add("<type inaccessible for null objects>");
					lvObject.Items.Insert(++itemIdx, item);
					continue;
				}
				else if (isValid(childObj, fieldInfo[i].Name))
				{
					item = new ListViewItem(indent + "." + fieldInfo[i].Name, NO_IMAGE);
					item.Tag = childObj; 
					if (childObj.GetType().IsEnum)
					{
						specialCaseEnum(lvObject, item, ref itemIdx);
						continue;
					}
					sObjType = childObj.GetType().ToString();
					if (sObjType.StartsWith("cognosdotnet_10_2."))
					{
						sObjType = sObjType.Substring(13, sObjType.Length-13);
						item.SubItems.Add("");
						if (0 == lvObject.Name.CompareTo("typesListView"))
						{
							item.SubItems.Add(sObjType);
						}
					}
					else
					{
						string objString = "";
						if (findSimpleTypeValue(childObj, ref objString))
						{
							item.SubItems.Add(objString); // value column
						}
						else
						{
							item.SubItems.Add(""); // value column
						}
						if (0 == lvObject.Name.CompareTo("typesListView"))
						{
							item.SubItems.Add(sObjType); // type column						
						}
					}
					lvObject.Items.Insert(++itemIdx, item);
					if (isArrayType(childObj))
					{
						indent += indent;
						constructArrayRows(childObj, indent, ref itemIdx, lvObject);
						break;
					}
					addChildItems(childObj, indent, ref itemIdx, lvObject);
				}
				else
				{
					continue;
				}
			}
			return true;
		}

		public bool isValid(object objVal, string fieldName)
		{
			int integerObj = 0;
			DateTime date_lowerBound = new DateTime();
			DateTime date_upperBound = new DateTime(9999, 12, 31, 23, 59, 59);

			if (objVal == null)
			{
				return false;
			}
			if (objVal.GetType().Equals(date_upperBound.GetType()))
			{
				if ( (0 == objVal.ToString().CompareTo(date_lowerBound.ToString())) ||
					(0 == objVal.ToString().CompareTo(date_upperBound.ToString())) )
				{
					return false;
				}
			}
			else if (objVal.GetType().Equals(integerObj.GetType()))
			{
				if ( (0 == objVal.ToString().CompareTo("2147483647")) ||
					(0 == objVal.ToString().CompareTo("-2147483648")) )
				{
					return false;
				}
			}
			else if ( 0 == objVal.ToString().CompareTo("") )
			{
				return false;
			}
			else if ( (0 == objVal.ToString().CompareTo("-3.402823E+38")) ||
				(0 == objVal.ToString().CompareTo("3.402823E+38")) ||
				(0 == objVal.ToString().CompareTo("1.401298E-45")) ||
				(0 == objVal.ToString().CompareTo("Infinity")) ||
				(0 == objVal.ToString().CompareTo("-Infinity")) ||
				(0 == objVal.ToString().CompareTo("NaN")) )
			{
				return false;
			}
			else if ( (0 == fieldName.CompareTo("Zero")) ||
				(0 == fieldName.CompareTo("One")) ||
				(0 == fieldName.CompareTo("MinusOne")) ||
				(0 == fieldName.CompareTo("MaxValue")) ||
				(0 == fieldName.CompareTo("MinValue")) )
			{
				return false;
			}
			else if ( (0 == fieldName.CompareTo("TrueString")) ||
				(0 == fieldName.CompareTo("FalseString")) )
			{
				return false;
			}
			return true;
		}

		public void constructArrayRows(object objVal, string indent, ref int itemIdx, ListView lvObject)
		{
			ListViewItem item;
			Array objArr = null;
			string sObjType = "";
			string objValString = "";

			objArr = (System.Array)objVal;
			for(int j=0; j < objArr.GetLength(0); j++)
			{
				sObjType = objArr.GetValue(j).GetType().ToString();
				if (sObjType.StartsWith("cognosdotnet_10_2."))
				{
					sObjType = sObjType.Substring(13, sObjType.Length-13);
				}
				item = new ListViewItem(indent + "[" + j + "]", NO_IMAGE);
				item.Tag = objArr.GetValue(j);
				objValString = "";
				findSimpleTypeValue(objArr.GetValue(j), ref objValString);
				item.SubItems.Add(objValString);
				if (0 == lvObject.Name.CompareTo("typesListView"))
				{
					item.SubItems.Add(sObjType);
				}
				lvObject.Items.Insert(++itemIdx, item);
				addChildItems(objArr.GetValue(j), indent, ref itemIdx, lvObject);
			}
		}

		public void removeChildItems(ListViewItem selectedItem, ListView lvObject)
		{
			int childIdx = selectedItem.Index + 1;
			ListViewItem childItem = lvObject.Items[childIdx];
			while ( (childItem != null) && (childItem.Text.StartsWith("    ")) )
			{
				lvObject.Items.RemoveAt(childIdx);
				if (childIdx < lvObject.Items.Count)
				{
					childItem = lvObject.Items[childIdx];
				}
				else
				{
					childItem = null;
				}
			}
		}

		public void specialCaseEnum(ListView lvObject, ListViewItem item, ref int itemIdx)
		{
			string sObjType = "";
			
			if (0 == lvObject.SelectedItems[0].Text.CompareTo("objectClass"))
			{
				item.SubItems.Add(selectedBCObject.objectClass.value.ToString());
			}
			else if (0 == (item.Tag).ToString().CompareTo("grant"))
			{
				item.SubItems.Add("grant");
			}

			if (0 == lvObject.Name.CompareTo("typesListView"))
			{
				sObjType = (item.Tag).GetType().ToString();
				sObjType = sObjType.Substring(13, sObjType.Length-13);
				item.SubItems.Add(sObjType);
			}
			lvObject.Items.Insert(++itemIdx, item);
		}
	}
}
