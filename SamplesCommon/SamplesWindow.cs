/** 
Licensed Materials - Property of IBM

IBM Cognos Products: DOCS

(C) Copyright IBM Corp. 2005, 2008

US Government Users Restricted Rights - Use, duplication or disclosure restricted by GSA ADP Schedule Contract with
IBM Corp.
*/
//  Copyright (C) 2008 Cognos ULC, an IBM Company. All rights reserved.
//  Cognos (R) is a trademark of Cognos ULC, (formerly Cognos Incorporated).

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Reflection;
using cognosdotnet_10_2;

namespace SamplesCommon
{
	/// <summary>
	/// The main window for sample programs.
	/// 
	/// Add an event handler to Actions.Click to perform the action 
	/// demonstrated by this sample.
	/// 
	/// Add an Activated event handler to this window to set the 
	/// applicationName, applicationVersion, applicationAction, and 
	/// applicationTitle properties.
	/// </summary>
	public class SamplesWindow : System.Windows.Forms.Form
	{
		private System.Windows.Forms.MainMenu mainMenu;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.TextBox urlText;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ListBox resultsBox;
		private System.Windows.Forms.Button actionButton;
		private System.Windows.Forms.MenuItem menuExit;
        private System.Windows.Forms.MenuItem menuAbout;
        private IContainer components;

		public SamplesWindow()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			this.Activated += new EventHandler( SamplesWindow_Activated );

            System.Windows.Forms.Form.CheckForIllegalCrossThreadCalls = false;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SamplesWindow));
            this.mainMenu = new System.Windows.Forms.MainMenu(this.components);
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuExit = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.menuAbout = new System.Windows.Forms.MenuItem();
            this.urlText = new System.Windows.Forms.TextBox();
            this.actionButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.resultsBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
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
            this.menuAbout.Text = "About...";
            this.menuAbout.Click += new System.EventHandler(this.menuAbout_Click);
            // 
            // urlText
            // 
            this.urlText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.urlText.Location = new System.Drawing.Point(240, 24);
            this.urlText.Name = "urlText";
            this.urlText.Size = new System.Drawing.Size(319, 20);
            this.urlText.TabIndex = 0;
            this.urlText.Text = "http://localhost:9300/p2pd/servlet/dispatch";
            // 
            // actionButton
            // 
            this.actionButton.Location = new System.Drawing.Point(16, 16);
            this.actionButton.Name = "actionButton";
            this.actionButton.Size = new System.Drawing.Size(96, 32);
            this.actionButton.TabIndex = 2;
            this.actionButton.Text = "(Action)";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(118, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Server URL:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // resultsBox
            // 
            this.resultsBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.resultsBox.HorizontalScrollbar = true;
            this.resultsBox.Location = new System.Drawing.Point(16, 64);
            this.resultsBox.Name = "resultsBox";
            this.resultsBox.Size = new System.Drawing.Size(543, 160);
            this.resultsBox.TabIndex = 4;
            // 
            // SamplesWindow
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(575, 241);
            this.Controls.Add(this.resultsBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.actionButton);
            this.Controls.Add(this.urlText);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Menu = this.mainMenu;
            this.Name = "SamplesWindow";
            this.Text = "IBM Cognos Samples";
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private string app_name = null;
		private string app_version = null;

		/// <summary>
		/// The application's name, as shown in the About dialog box.
		/// </summary>
		public string applicationName {
			set {
				app_name = value;
			}
			get {
				return app_name;
			}
		}

		/// <summary>
		/// The application's version string, as shown in the About dialog box.
		/// </summary>
		public string applicationVersion {
			set {
				app_version = value;
			}
			get {
				return app_version;
			}
		}

		/// <summary>
		/// The application's action string, as shown on the button in the main window.
		/// </summary>
		public string applicationAction {
			set {
				actionButton.Text = value;
			}
			get {
				return actionButton.Text;
			}
		}

		/// <summary>
		/// The application's main window title bar string.
		/// </summary>
		public string applicationTitle {
			set {
				this.Text = value;
			}
			get {
				return this.Text;
			}
		}

		/// <summary>
		/// Actions launched by the Action button.
		/// 
		/// Add event handlers to the Click event of this object.
		/// </summary>
		public System.Windows.Forms.Button Actions {
			get {
				return actionButton;
			}
		}

		/// <summary>
		/// Return the Server URL.
		/// </summary>
		public string serverUrl {
			get {
				return urlText.Text;
			}
		}

		/// <summary>
		/// Add a single line of text to the output window.
		/// </summary>
		/// <param name="text">A line of text.</param>
		public void AddText( string text ) {
			resultsBox.Items.Add( text );
		}

		/// <summary>
		/// Add several lines of text to the output window.
		/// </summary>
		/// <param name="text">An array of text.</param>
		public void AddText( string[] text ) {
			foreach( string s in text ) {
				AddText( s );
			}
		}

		/// <summary>
		/// Add several lines of text (all in one string, separated by \n
		/// characters) to the output window.
		/// </summary>
		/// <param name="text">A string containing several lines of text.</param>
		public void AddTextLines( string text ) {
			string split_on = "\n";
			AddText( text.Split( split_on.ToCharArray() ) );
		}

		/// <summary>
		/// The user has chosen Exit from the File menu.
		/// </summary>
		/// <param name="sender">What object sent this event? (not used)</param>
		/// <param name="e">Event arguments (not used)</param>
		private void menuExit_Click( object sender, System.EventArgs e ) {
			this.Close();
		}

		/// <summary>
		/// The user has chosen About... from the Help menu.
		/// 
		/// Display the About dialog.
		/// </summary>
		/// <param name="sender">What object sent this event? (not used)</param>
		/// <param name="e">Event arguments (not used)</param>
		private void menuAbout_Click( object sender, System.EventArgs e ) {
			SamplesAbout about = new SamplesAbout();
			about.Activated += new EventHandler( about_Activated );

			about.Show();
		}

		/// <summary>
		/// The About window has been activated; we need to set up the strings
		/// that are displayed there.
		/// </summary>
		/// <param name="sender">Who sent this event?</param>
		/// <param name="e">Event arguments (not used)</param>
		private void about_Activated( object sender, EventArgs e ) {
			SamplesAbout about = (SamplesAbout)sender;

			about.applicationName = this.applicationName;
			about.applicationVersion = this.applicationVersion;
		}

		private static bool wasActivated = false;

		/// <summary>
		/// This window has been activated; clear out the results box.
		/// 
		/// Also gets default application name and version information
		/// from the assembly.
		/// </summary>
		/// <param name="sender">Who sent this event? (not used)</param>
		/// <param name="e">Event arguments (not used)</param>
		private void SamplesWindow_Activated( object sender, EventArgs e ) {
			if( !wasActivated ) {
				resultsBox.Items.Clear();
				wasActivated = true;
			}
		}
	}
}
