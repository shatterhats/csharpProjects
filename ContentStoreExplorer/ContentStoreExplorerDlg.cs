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
using System.Threading;
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
	/// Summary description for Form1.
	/// </summary>
	public class ContentStoreExplorerDlg : System.Windows.Forms.Form
	{
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItemFile;
		private System.Windows.Forms.MenuItem menuItemExit;
		private System.Windows.Forms.MenuItem menuItemHelp;
		private System.Windows.Forms.MenuItem menuItemAbout;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.Panel locationPanel;
		private System.Windows.Forms.ToolBarButton rootButton;
		private System.Windows.Forms.ImageList toolBarImageList;
		private System.Windows.Forms.ToolBarButton backButton;
		private System.Windows.Forms.ToolBarButton nextButton;
		private System.Windows.Forms.Label searchPathLBL;
		private System.Windows.Forms.ComboBox searchPathCB;
		private System.Windows.Forms.Button buttonGO;
		private System.Windows.Forms.TreeView navTree;
		private System.Windows.Forms.ImageList treeViewImageList;
		private System.Windows.Forms.ListView contentListView;
		private System.Windows.Forms.ContextMenu listView_ContextMenu;
		private System.Windows.Forms.MenuItem menuItemExplore;
		private System.Windows.Forms.MenuItem menuItemProperties;
		private System.Windows.Forms.MenuItem menuItemView;
		private System.Windows.Forms.MenuItem menuItemRefresh;
		private System.Windows.Forms.MenuItem menuItemSmallIcons;
		private System.Windows.Forms.MenuItem menuItemLargeIcons;
		private System.Windows.Forms.MenuItem menuItemList;
		private System.Windows.Forms.MenuItem menuItemDetails;
		private System.Windows.Forms.ColumnHeader columnHeaderName;
		private System.Windows.Forms.ColumnHeader columnHeaderType;
		private System.Windows.Forms.ColumnHeader columnHeaderDateModified;
		private System.Windows.Forms.ColumnHeader columnHeaderSearchPath;
		private System.Windows.Forms.StatusBar statusBar1;
		private System.ComponentModel.IContainer components;

		private static contentManagerService1 cBIServer = null;
		private int navigationArrayIdx = 0;
		private ArrayList navigationArray = new ArrayList();
		private int previousNodeIdx = 0;
		private TreeNode[] previousNodeList = new TreeNode[] {new TreeNode(),
																 new TreeNode(),
																 new TreeNode(),
																 new TreeNode(),
																 new TreeNode()};
		private TreeNode currentNode = null;
		private TreeNode rootNode = null;
		private bool sitesToolBarEnabled = true;
		private static bool isConnected = false;
		private static string connectMessage = "";
		private baseClass[] cBIBCList = null;


		private System.Windows.Forms.MenuItem menuItemSeparator1;
		private System.Windows.Forms.Label accountLBL;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.Button buttonConnect;
		private System.Windows.Forms.Label labelSites;
		private System.Windows.Forms.MenuItem menuItemViewSites;
		private System.Windows.Forms.MenuItem menuItemSites;
		private System.Windows.Forms.ToolBar buttonToolBar;
		private System.Windows.Forms.ProgressBar progressBar;
		private System.Windows.Forms.ComboBox cBIUrlCB;
		private System.Windows.Forms.TextBox serverUrlTB;
		private bool doUpdate = true;

		public ContentStoreExplorerDlg()
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
				if (components != null) 
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(ContentStoreExplorerDlg));
			this.mainMenu1 = new System.Windows.Forms.MainMenu();
			this.menuItemFile = new System.Windows.Forms.MenuItem();
			this.menuItemExit = new System.Windows.Forms.MenuItem();
			this.menuItemViewSites = new System.Windows.Forms.MenuItem();
			this.menuItemSites = new System.Windows.Forms.MenuItem();
			this.menuItemHelp = new System.Windows.Forms.MenuItem();
			this.menuItemAbout = new System.Windows.Forms.MenuItem();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.serverUrlTB = new System.Windows.Forms.TextBox();
			this.searchPathLBL = new System.Windows.Forms.Label();
			this.searchPathCB = new System.Windows.Forms.ComboBox();
			this.buttonToolBar = new System.Windows.Forms.ToolBar();
			this.rootButton = new System.Windows.Forms.ToolBarButton();
			this.backButton = new System.Windows.Forms.ToolBarButton();
			this.nextButton = new System.Windows.Forms.ToolBarButton();
			this.toolBarImageList = new System.Windows.Forms.ImageList(this.components);
			this.locationPanel = new System.Windows.Forms.Panel();
			this.buttonGO = new System.Windows.Forms.Button();
			this.navTree = new System.Windows.Forms.TreeView();
			this.listView_ContextMenu = new System.Windows.Forms.ContextMenu();
			this.menuItemExplore = new System.Windows.Forms.MenuItem();
			this.menuItemProperties = new System.Windows.Forms.MenuItem();
			this.menuItemSeparator1 = new System.Windows.Forms.MenuItem();
			this.menuItemView = new System.Windows.Forms.MenuItem();
			this.menuItemSmallIcons = new System.Windows.Forms.MenuItem();
			this.menuItemLargeIcons = new System.Windows.Forms.MenuItem();
			this.menuItemList = new System.Windows.Forms.MenuItem();
			this.menuItemDetails = new System.Windows.Forms.MenuItem();
			this.menuItemRefresh = new System.Windows.Forms.MenuItem();
			this.treeViewImageList = new System.Windows.Forms.ImageList(this.components);
			this.contentListView = new System.Windows.Forms.ListView();
			this.columnHeaderName = new System.Windows.Forms.ColumnHeader();
			this.columnHeaderType = new System.Windows.Forms.ColumnHeader();
			this.columnHeaderDateModified = new System.Windows.Forms.ColumnHeader();
			this.columnHeaderSearchPath = new System.Windows.Forms.ColumnHeader();
			this.statusBar1 = new System.Windows.Forms.StatusBar();
			this.accountLBL = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.splitter1 = new System.Windows.Forms.Splitter();
			this.cBIUrlCB = new System.Windows.Forms.ComboBox();
			this.labelSites = new System.Windows.Forms.Label();
			this.buttonConnect = new System.Windows.Forms.Button();
			this.progressBar = new System.Windows.Forms.ProgressBar();
			this.locationPanel.SuspendLayout();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// mainMenu1
			// 
			this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItemFile,
																					  this.menuItemViewSites,
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
			// menuItemViewSites
			// 
			this.menuItemViewSites.Index = 1;
			this.menuItemViewSites.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																							  this.menuItemSites});
			this.menuItemViewSites.Text = "View";
			// 
			// menuItemSites
			// 
			this.menuItemSites.Checked = true;
			this.menuItemSites.Index = 0;
			this.menuItemSites.Text = "Sites";
			this.menuItemSites.Click += new System.EventHandler(this.menuItemSites_Click);
			// 
			// menuItemHelp
			// 
			this.menuItemHelp.Index = 2;
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
			// serverUrlTB
			// 
			this.serverUrlTB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.serverUrlTB.BackColor = System.Drawing.SystemColors.Control;
			this.serverUrlTB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.serverUrlTB.Location = new System.Drawing.Point(0, 0);
			this.serverUrlTB.Name = "serverUrlTB";
			this.serverUrlTB.Size = new System.Drawing.Size(728, 20);
			this.serverUrlTB.TabIndex = 103;
			this.serverUrlTB.Text = "";
			this.toolTip1.SetToolTip(this.serverUrlTB, "Server connected to");
			// 
			// searchPathLBL
			// 
			this.searchPathLBL.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.searchPathLBL.Enabled = false;
			this.searchPathLBL.Font = new System.Drawing.Font("Arial", 8.25F);
			this.searchPathLBL.Location = new System.Drawing.Point(0, 48);
			this.searchPathLBL.Name = "searchPathLBL";
			this.searchPathLBL.Size = new System.Drawing.Size(88, 21);
			this.searchPathLBL.TabIndex = 0;
			this.searchPathLBL.Text = "Search Path:";
			this.searchPathLBL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.toolTip1.SetToolTip(this.searchPathLBL, "Query for the list of children objects for the specified searchPath");
			// 
			// searchPathCB
			// 
			this.searchPathCB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.searchPathCB.BackColor = System.Drawing.SystemColors.Control;
			this.searchPathCB.Enabled = false;
			this.searchPathCB.Location = new System.Drawing.Point(88, 48);
			this.searchPathCB.Name = "searchPathCB";
			this.searchPathCB.Size = new System.Drawing.Size(616, 21);
			this.searchPathCB.TabIndex = 3;
			this.toolTip1.SetToolTip(this.searchPathCB, "Query for the list of children objects for the specified searchPath");
			this.searchPathCB.KeyDown += new System.Windows.Forms.KeyEventHandler(this.searchPathCB_OnKeyPress);
			// 
			// buttonToolBar
			// 
			this.buttonToolBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.buttonToolBar.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
																							 this.rootButton,
																							 this.backButton,
																							 this.nextButton});
			this.buttonToolBar.ButtonSize = new System.Drawing.Size(89, 22);
			this.buttonToolBar.Dock = System.Windows.Forms.DockStyle.None;
			this.buttonToolBar.DropDownArrows = true;
			this.buttonToolBar.ImageList = this.toolBarImageList;
			this.buttonToolBar.Location = new System.Drawing.Point(0, 16);
			this.buttonToolBar.Name = "buttonToolBar";
			this.buttonToolBar.ShowToolTips = true;
			this.buttonToolBar.Size = new System.Drawing.Size(735, 28);
			this.buttonToolBar.TabIndex = 2;
			this.buttonToolBar.TextAlign = System.Windows.Forms.ToolBarTextAlign.Right;
			this.buttonToolBar.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.buttonToolBar_ButtonClick);
			// 
			// rootButton
			// 
			this.rootButton.Enabled = false;
			this.rootButton.ImageIndex = 3;
			this.rootButton.Text = "All Objects";
			this.rootButton.ToolTipText = "List all objects in the Content Store";
			// 
			// backButton
			// 
			this.backButton.Enabled = false;
			this.backButton.ImageIndex = 1;
			this.backButton.Text = "Back";
			this.backButton.ToolTipText = "Previous View";
			// 
			// nextButton
			// 
			this.nextButton.Enabled = false;
			this.nextButton.ImageIndex = 2;
			this.nextButton.Text = "Forward";
			this.nextButton.ToolTipText = "Next View";
			// 
			// toolBarImageList
			// 
			this.toolBarImageList.ImageSize = new System.Drawing.Size(16, 16);
			this.toolBarImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("toolBarImageList.ImageStream")));
			this.toolBarImageList.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// locationPanel
			// 
			this.locationPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.locationPanel.Controls.Add(this.buttonGO);
			this.locationPanel.Controls.Add(this.searchPathCB);
			this.locationPanel.Controls.Add(this.searchPathLBL);
			this.locationPanel.Dock = System.Windows.Forms.DockStyle.Top;
			this.locationPanel.Location = new System.Drawing.Point(0, 0);
			this.locationPanel.Name = "locationPanel";
			this.locationPanel.Size = new System.Drawing.Size(736, 72);
			this.locationPanel.TabIndex = 2;
			// 
			// buttonGO
			// 
			this.buttonGO.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonGO.Enabled = false;
			this.buttonGO.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.buttonGO.Location = new System.Drawing.Point(704, 48);
			this.buttonGO.Name = "buttonGO";
			this.buttonGO.Size = new System.Drawing.Size(32, 21);
			this.buttonGO.TabIndex = 4;
			this.buttonGO.Text = "GO";
			this.buttonGO.Click += new System.EventHandler(this.buttonGO_Click);
			// 
			// navTree
			// 
			this.navTree.ContextMenu = this.listView_ContextMenu;
			this.navTree.Dock = System.Windows.Forms.DockStyle.Left;
			this.navTree.HideSelection = false;
			this.navTree.HotTracking = true;
			this.navTree.ImageList = this.treeViewImageList;
			this.navTree.Location = new System.Drawing.Point(0, 0);
			this.navTree.Name = "navTree";
			this.navTree.Size = new System.Drawing.Size(200, 504);
			this.navTree.TabIndex = 1;
			this.navTree.MouseDown += new System.Windows.Forms.MouseEventHandler(this.navTree_MouseDown);
			this.navTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.navTree_AfterSelect);
			// 
			// listView_ContextMenu
			// 
			this.listView_ContextMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																								 this.menuItemExplore,
																								 this.menuItemProperties,
																								 this.menuItemSeparator1,
																								 this.menuItemView,
																								 this.menuItemRefresh});
			// 
			// menuItemExplore
			// 
			this.menuItemExplore.Index = 0;
			this.menuItemExplore.Text = "Explore";
			this.menuItemExplore.Visible = false;
			this.menuItemExplore.Click += new System.EventHandler(this.menuItemExplore_Click);
			// 
			// menuItemProperties
			// 
			this.menuItemProperties.Index = 1;
			this.menuItemProperties.Text = "Properties";
			this.menuItemProperties.Visible = false;
			this.menuItemProperties.Click += new System.EventHandler(this.menuItemProperties_Click);
			// 
			// menuItemSeparator1
			// 
			this.menuItemSeparator1.Index = 2;
			this.menuItemSeparator1.Text = "-";
			// 
			// menuItemView
			// 
			this.menuItemView.Index = 3;
			this.menuItemView.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						 this.menuItemSmallIcons,
																						 this.menuItemLargeIcons,
																						 this.menuItemList,
																						 this.menuItemDetails});
			this.menuItemView.Text = "View";
			this.menuItemView.Visible = false;
			// 
			// menuItemSmallIcons
			// 
			this.menuItemSmallIcons.Index = 0;
			this.menuItemSmallIcons.Text = "Small Icons";
			this.menuItemSmallIcons.Click += new System.EventHandler(this.menuItemSmallIcons_Click);
			// 
			// menuItemLargeIcons
			// 
			this.menuItemLargeIcons.Index = 1;
			this.menuItemLargeIcons.Text = "Large Icons";
			this.menuItemLargeIcons.Click += new System.EventHandler(this.menuItemLargeIcons_Click);
			// 
			// menuItemList
			// 
			this.menuItemList.Index = 2;
			this.menuItemList.Text = "List";
			this.menuItemList.Click += new System.EventHandler(this.menuItemList_Click);
			// 
			// menuItemDetails
			// 
			this.menuItemDetails.Index = 3;
			this.menuItemDetails.Text = "Details";
			this.menuItemDetails.Click += new System.EventHandler(this.menuItemDetails_Click);
			// 
			// menuItemRefresh
			// 
			this.menuItemRefresh.Index = 4;
			this.menuItemRefresh.Text = "Refresh Tree";
			this.menuItemRefresh.Click += new System.EventHandler(this.menuItemRefresh_Click);
			// 
			// treeViewImageList
			// 
			this.treeViewImageList.ImageSize = new System.Drawing.Size(16, 16);
			this.treeViewImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("treeViewImageList.ImageStream")));
			this.treeViewImageList.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// contentListView
			// 
			this.contentListView.AllowColumnReorder = true;
			this.contentListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																							  this.columnHeaderName,
																							  this.columnHeaderType,
																							  this.columnHeaderDateModified,
																							  this.columnHeaderSearchPath});
			this.contentListView.ContextMenu = this.listView_ContextMenu;
			this.contentListView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.contentListView.Font = new System.Drawing.Font("Garamond", 12F);
			this.contentListView.HideSelection = false;
			this.contentListView.LargeImageList = this.treeViewImageList;
			this.contentListView.Location = new System.Drawing.Point(200, 0);
			this.contentListView.MultiSelect = false;
			this.contentListView.Name = "contentListView";
			this.contentListView.Size = new System.Drawing.Size(536, 504);
			this.contentListView.SmallImageList = this.treeViewImageList;
			this.contentListView.Sorting = System.Windows.Forms.SortOrder.Ascending;
			this.contentListView.TabIndex = 2;
			this.contentListView.View = System.Windows.Forms.View.Details;
			this.contentListView.DoubleClick += new System.EventHandler(this.contentListView_DoubleClick);
			this.contentListView.MouseUp += new System.Windows.Forms.MouseEventHandler(this.contentListView_MouseUp);
			this.contentListView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.contentListView_ColumnClick);
			// 
			// columnHeaderName
			// 
			this.columnHeaderName.Text = "Name";
			this.columnHeaderName.Width = 50;
			// 
			// columnHeaderType
			// 
			this.columnHeaderType.Text = "Type";
			this.columnHeaderType.Width = 44;
			// 
			// columnHeaderDateModified
			// 
			this.columnHeaderDateModified.Text = "Date Modified";
			this.columnHeaderDateModified.Width = 105;
			// 
			// columnHeaderSearchPath
			// 
			this.columnHeaderSearchPath.Text = "Search Path";
			this.columnHeaderSearchPath.Width = 400;
			// 
			// statusBar1
			// 
			this.statusBar1.Location = new System.Drawing.Point(0, 576);
			this.statusBar1.Name = "statusBar1";
			this.statusBar1.Size = new System.Drawing.Size(736, 22);
			this.statusBar1.TabIndex = 5;
			this.statusBar1.Text = "[";
			// 
			// accountLBL
			// 
			this.accountLBL.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.accountLBL.Font = new System.Drawing.Font("Garamond", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.accountLBL.Location = new System.Drawing.Point(272, 24);
			this.accountLBL.Name = "accountLBL";
			this.accountLBL.Size = new System.Drawing.Size(456, 21);
			this.accountLBL.TabIndex = 7;
			this.accountLBL.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// panel1
			// 
			this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.panel1.Controls.Add(this.splitter1);
			this.panel1.Controls.Add(this.contentListView);
			this.panel1.Controls.Add(this.navTree);
			this.panel1.Location = new System.Drawing.Point(0, 72);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(736, 504);
			this.panel1.TabIndex = 8;
			// 
			// splitter1
			// 
			this.splitter1.Location = new System.Drawing.Point(200, 0);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(3, 504);
			this.splitter1.TabIndex = 5;
			this.splitter1.TabStop = false;
			// 
			// cBIUrlCB
			// 
			this.cBIUrlCB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.cBIUrlCB.Location = new System.Drawing.Point(88, 0);
			this.cBIUrlCB.Name = "cBIUrlCB";
			this.cBIUrlCB.Size = new System.Drawing.Size(576, 21);
			this.cBIUrlCB.TabIndex = 101;
			this.cBIUrlCB.Text = "http://localhost:9300/p2pd/servlet/dispatch";
			// 
			// labelSites
			// 
			this.labelSites.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.labelSites.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.labelSites.Location = new System.Drawing.Point(0, 0);
			this.labelSites.Name = "labelSites";
			this.labelSites.Size = new System.Drawing.Size(88, 21);
			this.labelSites.TabIndex = 102;
			this.labelSites.Text = "Sites:";
			this.labelSites.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// buttonConnect
			// 
			this.buttonConnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonConnect.Location = new System.Drawing.Point(664, 0);
			this.buttonConnect.Name = "buttonConnect";
			this.buttonConnect.Size = new System.Drawing.Size(75, 21);
			this.buttonConnect.TabIndex = 0;
			this.buttonConnect.Text = "Connect";
			this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
			// 
			// progressBar
			// 
			this.progressBar.Location = new System.Drawing.Point(616, 576);
			this.progressBar.Name = "progressBar";
			this.progressBar.TabIndex = 105;
			this.progressBar.Visible = false;
			// 
			// ContentStoreExplorerDlg
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(736, 598);
			this.Controls.Add(this.buttonConnect);
			this.Controls.Add(this.labelSites);
			this.Controls.Add(this.cBIUrlCB);
			this.Controls.Add(this.accountLBL);
			this.Controls.Add(this.statusBar1);
			this.Controls.Add(this.buttonToolBar);
			this.Controls.Add(this.serverUrlTB);
			this.Controls.Add(this.locationPanel);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.progressBar);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.IsMdiContainer = true;
			this.Menu = this.mainMenu1;
			this.Name = "ContentStoreExplorerDlg";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Content Store Explorer";
			this.Load += new System.EventHandler(this.ContentStoreExplorerDlg_Load);
			this.locationPanel.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new ContentStoreExplorerDlg());
		}

		private void menuItemExit_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void menuItemAbout_Click(object sender, System.EventArgs e)
		{
			SamplesAbout about = new SamplesAbout();
			about.applicationName = "Content Store Explorer Sample";
			about.applicationVersion = "1.1";
			about.ShowDialog();
		}

		private void buttonToolBar_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
		{
			bool backButtonClicked = false;
			doUpdate = false;
			if ( e.Button == rootButton)
			{
				navTree.SelectedNode = null;
				addAllObjectInListView();
				initializeButtonToolBar(true);
			}
			else if (e.Button == backButton)
			{
				navTree.SelectedNode = (TreeNode)navigationArray[--navigationArrayIdx];
			}
			else if (e.Button == nextButton)
			{
				navTree.SelectedNode = (TreeNode)navigationArray[++navigationArrayIdx];
			}
			setNavigationState();
			doUpdate = true;
		}

		private void buttonGO_Click(object sender, System.EventArgs e)
		{
			string inputSearchPath = (string)searchPathCB.SelectedItem;
			if ( (inputSearchPath == null) || (0 == inputSearchPath.CompareTo("")) )
			{
				// if it's a user entered text:
				inputSearchPath = searchPathCB.Text;
				if ( (inputSearchPath == null) || (0 == inputSearchPath.CompareTo("")) )
				{	
					return;
				}
			}
			if ( (!inputSearchPath.StartsWith("/")) && (!inputSearchPath.StartsWith("CAMID(")) )
			{
				MessageBox.Show("Please enter a valid searchPath");
				return;
			}
			TreeNode treeNode = null;
			if (searchPathInTree(inputSearchPath, navTree.Nodes, ref treeNode))
			{
				navTree.SelectedNode = treeNode;
				addItemsInListView(treeNode);
			}
		}

		private void ContentStoreExplorerDlg_Load(object sender, System.EventArgs e)
		{
			buttonConnect.Focus();
		}

		private void menuItemExplore_Click(object sender, System.EventArgs e)
		{
			openSelectedListViewItem();
		}

		private void menuItemProperties_Click(object sender, System.EventArgs e)
		{
			PropertiesDlg propDlg = null;
			try
			{
				if ( (contentListView.SelectedItems != null) && (contentListView.SelectedItems.Count == 1) )
				{
					propDlg = new PropertiesDlg();
					ListView.SelectedListViewItemCollection selectedItems = contentListView.SelectedItems;
					propDlg.setItemSearchPath((string)contentListView.SelectedItems[0].Tag);
					propDlg.setConnection(cBIServer);
					propDlg.Show();
				}
			}
			catch(SoapException ex)
			{
				SamplesException.ShowExceptionMessage( ex, true, "IBM Cognos Error" );
				statusBar1.Text = "IBM Cognos Error: " + ex.Message;
				propDlg.Close();
				return;
			}
			catch(Exception ex)
			{
				if (0 != ex.Message.CompareTo("INPUT_CANCELLED_BY_USER"))
				{
					SamplesException.ShowExceptionMessage( ex.Message, true, "ContentStoreExplorer Error" );
					statusBar1.Text = "ContentStoreExplorer Error: " + ex.Message;
				}
				propDlg.Close();
				return;
			}
		}

		private void menuItemSmallIcons_Click(object sender, System.EventArgs e)
		{
			contentListView.View = View.SmallIcon;
		}

		private void menuItemLargeIcons_Click(object sender, System.EventArgs e)
		{
			contentListView.View = View.LargeIcon;
		}

		private void menuItemList_Click(object sender, System.EventArgs e)
		{
			contentListView.View = View.List;
		}

		private void menuItemDetails_Click(object sender, System.EventArgs e)
		{
			contentListView.View = View.Details;
		}

		private void menuItemRefresh_Click(object sender, System.EventArgs e)
		{
			loadUI(false, "", cBIServer);
		}

		private void navTree_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			if (doUpdate)
			{
				for (int i = navigationArray.Count-1; i > navigationArrayIdx; i--)
				{
					navigationArray.RemoveAt(i);
				}
				navigationArray.Add(navTree.SelectedNode);
				if (0 != navTree.SelectedNode.Text.CompareTo("/"))
				{
					navigationArrayIdx++;
				}
				setNavigationState();
			}
			updateSearchPathList(((baseClass)e.Node.Tag).searchPath.value);
			addItemsInListView(e.Node);
			e.Node.Expand();
		}

		private void addItemsInListView(TreeNode node)
		{
			ListViewItem item = null;
			if (node.Nodes == null)
			{
				return;
			}
			baseClass bcChild = null;
			contentListView.Items.Clear();
			for (int i=0; i<node.Nodes.Count; i++)
			{
				bcChild = (baseClass)node.Nodes[i].Tag;
				item = new ListViewItem(bcChild.defaultName.value, getImageIndex(bcChild));
				item.SubItems.Add(bcChild.objectClass.value.ToString());
				item.SubItems.Add(bcChild.modificationTime.value.ToShortDateString() + " " +
					bcChild.modificationTime.value.ToShortTimeString());
				item.SubItems.Add(bcChild.searchPath.value);
				item.Tag = bcChild.searchPath.value;
				contentListView.Items.AddRange(new ListViewItem[]{item});
			}

			contentListView.Columns[0].Width = -2; // autosize
			contentListView.Columns[1].Width = -2;
			contentListView.Columns[2].Width = -2;
			contentListView.Columns[3].Width = -2;
			
			statusBar1.Text = "  " + node.Nodes.Count.ToString() + " Objects";
		}

		private void addAllObjectInListView()
		{
			baseClass bcChild = null;
			ListViewItem item = null;
			contentListView.Items.Clear();

			for (int i=0; i < cBIBCList.GetLength(0); i++)
			{
				bcChild = cBIBCList[i];
				item = new ListViewItem(bcChild.defaultName.value, getImageIndex(bcChild));
				item.SubItems.Add(bcChild.objectClass.value.ToString());
				item.SubItems.Add(bcChild.modificationTime.value.ToShortDateString() + " " +
					bcChild.modificationTime.value.ToShortTimeString());
				item.SubItems.Add(bcChild.searchPath.value);
				item.Tag = bcChild.searchPath.value;
				contentListView.Items.AddRange(new ListViewItem[]{item});
			}

			contentListView.Columns[0].Width = -2; // autosize
			contentListView.Columns[1].Width = -2;
			contentListView.Columns[2].Width = -2;
			contentListView.Columns[3].Width = -2;
			
			statusBar1.Text = "  " + cBIBCList.GetLength(0).ToString() + " Objects";
		}

		private void contentListView_DoubleClick(object sender, System.EventArgs e)
		{
			openSelectedListViewItem();
		}

		private void navTree_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e) 
		{ 
			if(e.Button == MouseButtons.Right) 
			{ 
				menuItemExplore.Visible = false;
				menuItemProperties.Visible = false;
				menuItemSeparator1.Visible = false;
				menuItemView.Visible = false;
				menuItemRefresh.Visible = true;
			}
		}

		private void contentListView_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e) 
		{ 
			if(e.Button == MouseButtons.Right) 
			{ 
				if ( (contentListView.SelectedItems != null) && (contentListView.SelectedItems.Count == 1) )
				{
					menuItemExplore.Visible = true;
					menuItemProperties.Visible = true;
					menuItemSeparator1.Visible = true;
					menuItemView.Visible = true;
					menuItemRefresh.Visible = true;
				}
				else
				{
					menuItemExplore.Visible = false;
					menuItemProperties.Visible = false;
					menuItemSeparator1.Visible = false;
					menuItemView.Visible = true;
					menuItemRefresh.Visible = true;
				}
			} 
		}

		private void cBIUrlCB_OnKeyPress(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				buttonConnect_Click(null, null);
			}
		}

		private void searchPathCB_OnKeyPress(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				buttonGO_Click(null, null);
			}
		}

		//common use for column sorting
		private void contentListView_ColumnClick(object sender, ColumnClickEventArgs e)
		{
			if (contentListView.Sorting==SortOrder.Descending)
			{
				//toggle to ascending
				contentListView.Sorting = System.Windows.Forms.SortOrder.Ascending;
			}
			else
			{
				//toggle to Descending
				contentListView.Sorting = System.Windows.Forms.SortOrder.Descending;
			}
			//use the column number that the user clicked as a constructor argument
			//to tell the compare function which column to be working on.
			//ListViewItemSorter tells the listview control what custom class implements the
			//IComparer interface, and therefore the compare function it needs to be able to sort
			contentListView.ListViewItemSorter=new ColumnSort(e.Column);
			//now actually call the sort routine which uses the ColumnSort object's compare function
			contentListView.Sort();
		}

		/*********************************************************************************************
		 * 
		 * Public Functions
		 * 
		 *******************************************************************************************  */

		public void setNavigationState()
		{
			if (navigationArrayIdx >= navigationArray.Count-1)
			{
				nextButton.Enabled = false;
			}
			else
			{
				nextButton.Enabled = true;
			}

			if (navigationArrayIdx == 0)
			{
				backButton.Enabled = false;
			}
			else
			{
				backButton.Enabled = true;
			}
		}

		/*  
		 * This function is called when an Item is double clicked in the ListView 
		 *	or Right-Click->Open is selected on a ListView Item.
		 * 
		 * OutCome:
		 * The selected Item is 'opened': it becomes the selected node in the TreeView 
		 * and the ListView now shows the Item children.
		 * 
		*/
		public void openSelectedListViewItem()
		{
			try
			{
				TreeNode selectedNode = navTree.SelectedNode;
				// get the collection of items currently in the List View
				ListView.SelectedListViewItemCollection selectedItems = contentListView.SelectedItems;
				if (selectedItems == null)
				{
					return;
				}
				// We only care when 1 item is selected
				if (selectedItems.Count == 1)
				{
					TreeNode treeNode = null;
					searchPathInTree((string)selectedItems[0].Tag, 
						navTree.SelectedNode.Nodes,
						ref treeNode);
					navTree.SelectedNode = treeNode;
				}				
			}
			catch(SoapException ex)
			{
				SamplesException.ShowExceptionMessage( ex, true, "IBM Cognos Error" );
				statusBar1.Text = "IBM Cognos Error: " + ex.Message;
				return;
			}
			catch(Exception ex)
			{
				if (0 != ex.Message.CompareTo("INPUT_CANCELLED_BY_USER"))
				{
					SamplesException.ShowExceptionMessage( ex.Message, true, "ContentStoreExplorer Error" );
					statusBar1.Text = "ContentStoreExplorer Error: " + ex.Message;
				}
				return;
			}
		}

		/*  
		 * This function searches the children of a given TreeNode and returns the childNode
		 * corresponding to the given searchPath
		 * 
		 * Input
		 * (string) searchPath : searchPath of the TreeNode we're looking for
		 * (TreeNode) Parent   : the TreeNode that will be searched. 
		 *						 if null, the whole tree will be searched.
		 * 
		 *  Output:
		 * (TreeNode) ChildNode
		 * 
		*/
		public TreeNode getTreeNode(string searchPath, TreeNode parent)
		{
			TreeNode foundNode = null;
			if (parent == null)
			{
				// start from the root node
				parent = navTree.Nodes[0];
			}
			TreeNodeCollection childNodes = parent.Nodes;
			for(int i=0; i<childNodes.Count; i++)
			{
				foundNode = childNodes[i];
				if ( 0 == searchPath.CompareTo((string)foundNode.Tag) )
				{
					return foundNode;
				}
			}
			return null;
		}

		public void updateSearchPathList(string searchPath)
		{
			if (!searchPathCB.Items.Contains(searchPath))
			{
				searchPathCB.Items.Insert(0, searchPath);
				if (searchPathCB.Items.Count > 10) // maintain a max of 10 searchPaths
				{
					searchPathCB.Items.RemoveAt(10);
				}
				searchPathCB.SelectedIndex = 0;
			}
			else
			{
				searchPathCB.SelectedIndex = searchPathCB.Items.IndexOf(searchPath);
			}
		}

		public string getCurrentAccountName()
		{
			string accountName = "";
			baseClass[] bc = new baseClass[1];
			propEnum[] props =
				new propEnum[] { propEnum.searchPath, propEnum.defaultName };
			try
			{
				searchPathMultipleObject homeDir = new searchPathMultipleObject();
				homeDir.Value = "~";

				bc = cBIServer.query(homeDir, props, new sort[] {}, new queryOptions());
				if ( (bc != null) && (bc.GetLength(0) >0) )
				{
					accountName = bc[0].defaultName.value;
				}
			}
			catch(System.Exception ex)
			{
				return "";
			}
			return accountName;
		}

		private void menuItemSites_Click(object sender, System.EventArgs e)
		{
			if (sitesToolBarEnabled)
			{
				disableSitesToolBar();
			}
			else
			{
				enableSitesToolBar();
			}
		}

		/* This function is the starting point of the application.
		 * The sequence of operation is as follows:
		 * 1. Connect to the server
		 * 2. Update the User Interface: enable controls that can be used after the tree is loaded
		 * 3. Create the Root Node
		 * 4. Build the root children and grand children
		 * 5. expand the root Node and populate the listView with the rootNode's children.
		 */
		private void buttonConnect_Click(object sender, System.EventArgs e)
		{
			// 1. Connect to the server
			statusBar1.Text = "Connecting to site: " + cBIUrlCB.Text + " ...  Please wait.";

			// Add the site to the comboBox list
			if (!cBIUrlCB.Items.Contains(cBIUrlCB.Text))
			{
				cBIUrlCB.Items.Insert(0, cBIUrlCB.Text);
				if (cBIUrlCB.Items.Count > 10) // maintain a max of 10 sites
				{
					cBIUrlCB.Items.RemoveAt(10);
				}
				cBIUrlCB.SelectedIndex = 0;
			}
			serverUrlTB.Text = cBIUrlCB.Text;
			
			// Connect to the server in a separate thread to preserve UI functionality
			ConnectToCognosServer connect = new ConnectToCognosServer(cBIUrlCB.Text, 
				new ConnectionCallBack(ConnectionCallBackResult));
			Thread connectionThread = new Thread(new ThreadStart(connect.makeConnection));
			connectionThread.IsBackground = true;
			connectionThread.Name = "ConnectionThread";
			connectionThread.Start();			
		}

		/*
		 * This method is executed when the connection thread has finished executing
		 * The arguments of this method are returned values of the ConnectionThread
		 */
		public void ConnectionCallBackResult(bool connectionState, string resultMessage,
			contentManagerService1 cmService)
		{
			isConnected = connectionState;
			connectMessage = resultMessage;
			cBIServer = cmService;
			if (InvokeRequired)
			{
				// We're not in the UI thread, so we need to call BeginInvoke
				IAsyncResult aResult = BeginInvoke(new ConnectionCallBack(loadUI),
					new Object[]{connectionState,
									resultMessage,
									cmService});
				aResult.AsyncWaitHandle.WaitOne();
				EndInvoke(aResult);
				return;
			}

		}

		public void loadUI(bool connectionState, string resultMessage,
			contentManagerService1 cmService)
		{
			try
			{
				// Must be on the UI thread if we've got this far
				statusBar1.Text = connectMessage;
				if (!isConnected)
				{
					disableUI();
					// keep the sites toolbar enabled for another connection attempt
					enableSitesToolBar();
					return;
				}
				// 2. Update the User Interface: enable controls that can be used after the tree is loaded
				enableUI();
				disableSitesToolBar();
				accountLBL.Text = getCurrentAccountName();
				
				// 3. Create the Root Node
				statusBar1.Text = "Loading Objects...";
				cBIBCList = makeQuery("//*");
				//string bcsearchPathList = printBCList(cBIBCList);
				//MessageBox.Show(bcsearchPathList);
				baseClass bcRoot = getBaseClassFromList(cBIBCList, "/");
				rootNode = new TreeNode("/", 0, 0);
				rootNode.Tag = bcRoot;
				navTree.Nodes.Add(rootNode); 
				
				// 4. Query for all objects in the server and build them into the treeView
				buildTree(rootNode, cBIBCList, "/");

				// 5. expand the root Node and populate the listView with the rootNode's children.
				navTree.SelectedNode = rootNode;
				rootNode.Expand();
				navTree.Focus();
			}
			catch(SoapException ex)
			{
				SamplesException.ShowExceptionMessage( ex, true, "IBM Cognos Error" );
				statusBar1.Text = "IBM Cognos Error: " + ex.Message;
				return;
			}
			catch(Exception ex)
			{
				if (0 != ex.Message.CompareTo("INPUT_CANCELLED_BY_USER"))
				{
					SamplesException.ShowExceptionMessage( ex.Message, true, "ContentStoreExplorer Error" );
					statusBar1.Text = "ContentStoreExplorer Error: " + ex.Message;
				}
				return;
			}
		}

		public string printBCList(baseClass[] cmBCList)
		{
			string bcsearchPathList = "";
			for(int i=0; i < cmBCList.GetLength(0); i++)
			{
				bcsearchPathList += cmBCList[i].searchPath.value;
				bcsearchPathList += ",\n";
			}
			return bcsearchPathList;
		}

		public void buildTree(TreeNode parentNode, baseClass[] cmBCList, string parentSearchPath)
		{
			int imgIdx = 0;
			TreeNode childNode = null;
			baseClass childBaseClass = null;

			for (int i=0; i < cmBCList.GetLength(0); i++)
			{
				childBaseClass = cmBCList[i];
				//parent will be null for root
				if ( (childBaseClass.parent.value != null)
					&& (0 == parentSearchPath.CompareTo(childBaseClass.parent.value[0].searchPath.value)) )
				{
					imgIdx = getImageIndex(childBaseClass);
					childNode = new TreeNode(childBaseClass.defaultName.value, imgIdx, imgIdx);
					childNode.Tag = childBaseClass;
					parentNode.Nodes.Add(childNode);
					buildTree(childNode, cmBCList, childBaseClass.searchPath.value);
				}
			}
		}

		public bool searchPathInTree(string searchPath, TreeNodeCollection nodeCollection, ref TreeNode treeNode)
		{
			for (int i=0; i < nodeCollection.Count; i++)
			{
				TreeNode childNode = nodeCollection[i];
				if (0 == searchPath.CompareTo( ((baseClass)childNode.Tag).searchPath.value ))
				{
					treeNode = childNode;
					break;
				}
				else
				{
					searchPathInTree(searchPath, childNode.Nodes, ref treeNode);
				}
			}
			if (treeNode == null)
			{
				return false;
			}
			else
			{
				return true;
			}
		}

		public baseClass getBaseClassFromList(baseClass[] cmBCList, string searchPath)
		{
			baseClass bc = null;
			foreach (baseClass bcObject in cmBCList)
			{
				if (0 == searchPath.CompareTo(bcObject.searchPath.value))
				{
					bc = bcObject;
					break;
				}
			}
			return bc;
		}

		public void disableUI()
		{
			navTree.Nodes.Clear();
			navTree.Width = 200;
			contentListView.Items.Clear();
			disableSitesToolBar();
			initializeButtonToolBar(false);
			disableSearchPathToolBar();
			accountLBL.Text = "";
		}

		public void enableUI()
		{
			navTree.Nodes.Clear();
			navTree.Width = 200;
			contentListView.Items.Clear();
			enableSitesToolBar();
			initializeButtonToolBar(true);
			enableSearchPathToolBar();
		}

		public void initializeButtonToolBar(bool rootEnabled)
		{
			// reset the button toolBar
			previousNodeIdx = 0;
			previousNodeList[0].Text = "";
			previousNodeList[1].Text = "";
			previousNodeList[2].Text = "";
			previousNodeList[3].Text = "";
			previousNodeList[4].Text = "";
			rootButton.Enabled = rootEnabled;
			navigationArray.Clear();
			navigationArrayIdx = 0;
			setNavigationState();
		}

		public void disableSitesToolBar()
		{
			labelSites.Visible = false;
			cBIUrlCB.Visible = false;
			buttonConnect.Visible = false;
			menuItemSites.Checked = false;
			sitesToolBarEnabled = false;
		}

		public void enableSitesToolBar()
		{
			labelSites.Visible = true;
			cBIUrlCB.Visible = true;
			buttonConnect.Visible = true;
			menuItemSites.Checked = true;
			sitesToolBarEnabled = true;
		}

		public void enableSearchPathToolBar()
		{
			searchPathLBL.Enabled = true;
			searchPathCB.Enabled = true;
			searchPathCB.BackColor = System.Drawing.SystemColors.Window;
			buttonGO.Enabled = true;
		}

		public void disableSearchPathToolBar()
		{
			searchPathLBL.Enabled = false;
			searchPathCB.Enabled = false;
			searchPathCB.BackColor = System.Drawing.SystemColors.Control;
			buttonGO.Enabled = false;
		}

		public baseClass[] makeQuery(string searchPath)
		{
			baseClass[] bcResultArr = new baseClass[0];
			sort[] sortOptions = { new sort() };
			sortOptions[0].order = orderEnum.ascending;
			sortOptions[0].propName = propEnum.defaultName;
			propEnum[] props = new propEnum[] { propEnum.searchPath, 
												  propEnum.defaultName, 
												  propEnum.objectClass,
												  propEnum.modificationTime,
												  propEnum.hasChildren,
												  propEnum.parent};
			searchPathMultipleObject cmSearchPath = new searchPathMultipleObject();
			cmSearchPath.Value = searchPath;

			try
			{
				bcResultArr = cBIServer.query(cmSearchPath, props, sortOptions, new queryOptions());
			}
			catch(SoapException ex)
			{
				SamplesException.ShowExceptionMessage( ex, true, "IBM Cognos Error" );
				statusBar1.Text = "IBM Cognos Error: " + ex.Message;
				return null;
			}
			catch(Exception ex)
			{
				if (0 != ex.Message.CompareTo("INPUT_CANCELLED_BY_USER"))
				{
					SamplesException.ShowExceptionMessage( ex.Message, true, "ContentStoreExplorer Error" );
					statusBar1.Text = "ContentStoreExplorer Error: " + ex.Message;
				}
				return null;
			}
			return bcResultArr;
		}

		public int getImageIndex(baseClass bcObj)
		{
			switch (bcObj.objectClass.value)
			{
				case classEnum.root:
					return 0;

				case classEnum.capability:
				case classEnum.directory:
					return 1;

				case classEnum.package:
					return 2;

				case classEnum.folder:
					if (0 == bcObj.defaultName.value.CompareTo("My Folders"))
					{
						return 22;
					}
					else
					{
						return 3;
					}
				case classEnum.report:
					return 4;

				case classEnum.securedFeature:
					return 5;

				case classEnum.securedFunction:
					return 6;

				case classEnum.dispatcher:
					return 7;

				case classEnum.agentService:
				case classEnum.batchReportService:
				case classEnum.contentManagerService:
				case classEnum.dataIntegrationService:
				case classEnum.deliveryService:
				case classEnum.eventManagementService:
				case classEnum.indexDataService:
				case classEnum.indexSearchService:
				case classEnum.indexUpdateService:
//				case classEnum.jobAndScheduleMonitoringService:
				case classEnum.jobService:
				case classEnum.logService:
				case classEnum.metadataService:
				case classEnum.metricsManagerService:
				case classEnum.monitorService:
				case classEnum.planningRuntimeService:
				case classEnum.planningTaskService:
				case classEnum.presentationService:
				case classEnum.reportService:
				case classEnum.systemService:

				case classEnum.runTimeState:
					return 8;

				case classEnum.@namespace:
					return 9;
				
				case classEnum.contact:
					return 10;
				
				case classEnum.dataSource:
					return 11;
				
				case classEnum.dataSourceConnection:
					return 12;
				
				case classEnum.dataSourceSignon:
					return 13;
				
				case classEnum.printer:
					return 14;
				
				case classEnum.group:
					return 16;
				
				case classEnum.role:
					return 17;
				
				case classEnum.distributionList:
					return 18;
				case classEnum.importDeployment:
				case classEnum.exportDeployment:
					return 19;
				case classEnum.query:
					return 20;
				case classEnum.content:
					return 21;
				case classEnum.model:
					return 23;
				case classEnum.jobDefinition:
					return 24;
				case classEnum.configuration:
					return 25;
//				case classEnum.importDeploymentFolder:
//				case classEnum.exportDeploymentFolder:
//					return 26;

//				case classEnum.deploymentHistory:
				case classEnum.history:
				case classEnum.historyDetail:
				case classEnum.historyDetailAgentService:
				case classEnum.historyDetailRelatedHistory:
				case classEnum.historyDetailRelatedReports:
				case classEnum.historyDetailReportService:
				case classEnum.historyDetailRequestArguments:
					return 27;
				case classEnum.jobStepDefinition:
					return 28;
/***************************
 * classes not handled yet
 * TBD
				case classEnum.account:
				case classEnum.adminFolder:
				case classEnum.agentDefinition:
				case classEnum.agentDefinitionView:
				case classEnum.agentOutputHotList:
				case classEnum.agentState:
				case classEnum.agentTaskDefinition:
				case classEnum.agentTaskState:
				case classEnum.analysis:
				case classEnum.configuration:
				case classEnum.configurationFolder:
				case classEnum.contentTask:
				case classEnum.credential:
				case classEnum.dataSourceNameBinding:
				case classEnum.deploymentDetail:
				case classEnum.drillPath:
				case classEnum.graphic:
				case classEnum.indexUpdateTask:
				case classEnum.installedComponent:
				case classEnum.memo:
				case classEnum.metricsDataSourceETLTask:
				case classEnum.metricsExportTask:
				case classEnum.metricsFileImportTask:
				case classEnum.metricsMaintenanceTask:
				case classEnum.modelView:
				case classEnum.namespaceFolder:
				case classEnum.output:
				case classEnum.packageConfiguration:
				case classEnum.page:
				case classEnum.pageDefinition:
				case classEnum.pagelet:
				case classEnum.pageletFolder:
				case classEnum.pageletInstance:
				case classEnum.planningAdministrationConsoleService:
				case classEnum.planningApplication:
				case classEnum.planningEList:
				case classEnum.planningTask:
				case classEnum.portal:
				case classEnum.portalPackage:
				case classEnum.portalSkin:
				case classEnum.portalSkinFolder:
				case classEnum.portlet:
				case classEnum.portletFolder:
				case classEnum.portletInstance:
				case classEnum.portletProducer:
				case classEnum.powerPlayCube:
				case classEnum.powerPlayReport:
				case classEnum.reportTemplate:
				case classEnum.reportVersion:
				case classEnum.reportView:
				case classEnum.schedule:
				case classEnum.session:
				case classEnum.shortcut:
				case classEnum.shortcutRSSTask:
				case classEnum.SQL:
				case classEnum.storedProcedureTask:
				case classEnum.transientStateFolder:
				case classEnum.URL:
				case classEnum.urlRSSTask:
				case classEnum.webServiceTask:
*/
				

					/*
				case classEnum.output:
					if (0 == bcObj.outputFormat.CompareTo("HTML"))
					{
						return 29;
					}
					else if (0 == bcObj.outputFormat.CompareTo("XHTML"))
					{
						return 30;
					}
					else if (0 == bcObj.outputFormat.CompareTo("CSV"))
					{
						return 31;
					}
					else if (0 == bcObj.outputFormat.CompareTo("PDF"))
					{
						return 32;
					}
					else if (0 == bcObj.outputFormat.CompareTo("EXCEL"))
					{
						return 33;
					}
					else if (0 == bcObj.outputFormat.CompareTo("XML"))
					{
						return 34;
					}
					else
					{
						return 99;
					}
					*/
				default:
					return 99;
			}
		}

	}

	public delegate void ConnectionCallBack(bool connectionState, string resultMessage,
											contentManagerService1 cmService);
	public class ConnectToCognosServer
	{
		private static string savedUserName = "";
		private static string savedUserPassword = "";
		private static string savedNamespace = "";
		private string cBIUrl = "";
		private ConnectionCallBack callback;
		
		public ConnectToCognosServer(string cmUrl, ConnectionCallBack callbackDelegate)
		{
			cBIUrl = cmUrl;
			callback = callbackDelegate;
		}

		public void makeConnection()
		{
			contentManagerService1 cmService = new contentManagerService1();
			try
			{
				cmService.Url = cBIUrl;
				searchPathMultipleObject homeDir = new searchPathMultipleObject();
				homeDir.Value = "~";

				//Test for Anonymous Authentication
				baseClass[] bc = cmService.query ( homeDir, new propEnum[]{} , new sort[]{}, new queryOptions () );
				if (bc != null)
				{
					if (callback != null)
						callback(true, "Connected to Server: " + cBIUrl, cmService);
					return;
				}
			}
			catch(Exception ex) 
			{
				//If security is turned on, we will end up here and fall into the logon code below
			}
			// Attempt to log on.
			SamplesLogon logon = new SamplesLogon( cmService );
			logon.setUserName(savedUserName);
			logon.setUserPassword(savedUserPassword);
			logon.setNamespace(savedNamespace);
			logon.ShowDialog( );
			if( !logon.loggedOn ) 
			{
				if (callback != null)
					callback(false, "Unable to login to: \"" + cBIUrl+ "\"... ", cmService);
				return;
			} 
			else 
			{
				savedUserName = logon.getUserName();
				savedUserPassword = logon.getUserPassword();
				savedNamespace = logon.getNamespace();
			}
			
			if (callback != null)
				callback(true, "Connected to Server: " + cBIUrl, cmService);
		}

	}

	public class NodeObject : baseClass
	{
		public string outputFormat = "";
		public NodeObject()
		{
			this.defaultName = new tokenProp();
			this.searchPath = new stringProp();
			this.objectClass = new classEnumProp();
			this.modificationTime = new dateTimeProp();
		}

		public override string ToString()
		{
			return this.defaultName.value;
		}

	}

	public class FieldObject
	{
		public string fieldName = "";
		public string fieldValue = null;

		public FieldObject()
		{
			this.fieldName = "";
			this.fieldValue = "";
		}

	}

	/// class that implements IComparer interface
	/// for the purpose of sorting based on subitems,
	/// which are columns in a listview's detail/report view
	public class ColumnSort:IComparer
	{
		private int columnNum;
		public ColumnSort(int column_to_sort)
		{
			//retrieve what column it is the user is trying to sort
			columnNum=column_to_sort;
		}
		//this function must be implemented from the IComparer interface
		//the function always(?) takes in two generic object parameters
		//that must be cast to the appropriate type
		//in this case a ListViewItem

		public int Compare(object a, object b)
		{
			ListViewItem listItemA=(System.Windows.Forms.ListViewItem)a;
			ListViewItem listItemB=(System.Windows.Forms.ListViewItem)b;
			//after the objects have been cast you can retrieve the item or subitem text for
			//string comparison. you return the result so the sort funtion knows which
			//subitem is greater than the other. to switch between ascending and descending
			//is multiply the result by -1 to change the sign.

			if (listItemA.ListView.Sorting==System.Windows.Forms.SortOrder.Ascending)
				//here i grab the enum value for what type of sorting the user has	specified...i really don't know how
				//i am able to access the listView properties (the parent of the listitem)....but it works
			{
				return (String.Compare(listItemA.SubItems[columnNum].Text,listItemB.SubItems[columnNum].Text)*-1);
			}
			else
			{
				return String.Compare(listItemA.SubItems[columnNum].Text,listItemB.SubItems[columnNum].Text);

			}
		}
	}
}
