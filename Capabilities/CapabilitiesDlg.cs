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

namespace Capabilities
{
	/// <summary>
	/// Summary description for CapabilitiesDlg.
	/// </summary>
	public class CapabilitiesDlg : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button buttonSetCapabilities;
		private System.Windows.Forms.RichTextBox resultsDisplayWindowRTB;
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItemFile;
		private System.Windows.Forms.MenuItem menuItemExit;
		private System.Windows.Forms.MenuItem menuItemHelp;
        private System.Windows.Forms.MenuItem menuItemAbout;
        private IContainer components;
		private System.Windows.Forms.TextBox cmServiceUrlTB;
		private System.Windows.Forms.GroupBox groupBox1;
		public static contentManagerService1 cmService = null;

		public CapabilitiesDlg()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CapabilitiesDlg));
            this.label1 = new System.Windows.Forms.Label();
            this.cmServiceUrlTB = new System.Windows.Forms.TextBox();
            this.buttonSetCapabilities = new System.Windows.Forms.Button();
            this.resultsDisplayWindowRTB = new System.Windows.Forms.RichTextBox();
            this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
            this.menuItemFile = new System.Windows.Forms.MenuItem();
            this.menuItemExit = new System.Windows.Forms.MenuItem();
            this.menuItemHelp = new System.Windows.Forms.MenuItem();
            this.menuItemAbout = new System.Windows.Forms.MenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(16, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Server URL";
            // 
            // cmServiceUrlTB
            // 
            this.cmServiceUrlTB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmServiceUrlTB.BackColor = System.Drawing.SystemColors.Control;
            this.cmServiceUrlTB.Location = new System.Drawing.Point(16, 40);
            this.cmServiceUrlTB.Name = "cmServiceUrlTB";
            this.cmServiceUrlTB.Size = new System.Drawing.Size(432, 20);
            this.cmServiceUrlTB.TabIndex = 1;
            // 
            // buttonSetCapabilities
            // 
            this.buttonSetCapabilities.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSetCapabilities.Location = new System.Drawing.Point(496, 32);
            this.buttonSetCapabilities.Name = "buttonSetCapabilities";
            this.buttonSetCapabilities.Size = new System.Drawing.Size(112, 40);
            this.buttonSetCapabilities.TabIndex = 2;
            this.buttonSetCapabilities.Text = "Set Capabilities";
            this.buttonSetCapabilities.Click += new System.EventHandler(this.buttonSetCapabilities_Click);
            // 
            // resultsDisplayWindowRTB
            // 
            this.resultsDisplayWindowRTB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.resultsDisplayWindowRTB.BackColor = System.Drawing.SystemColors.Control;
            this.resultsDisplayWindowRTB.Location = new System.Drawing.Point(24, 120);
            this.resultsDisplayWindowRTB.Name = "resultsDisplayWindowRTB";
            this.resultsDisplayWindowRTB.Size = new System.Drawing.Size(576, 136);
            this.resultsDisplayWindowRTB.TabIndex = 3;
            this.resultsDisplayWindowRTB.Text = "";
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
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Location = new System.Drawing.Point(16, 104);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(592, 168);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Results Display Window";
            // 
            // CapabilitiesDlg
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(624, 289);
            this.Controls.Add(this.resultsDisplayWindowRTB);
            this.Controls.Add(this.buttonSetCapabilities);
            this.Controls.Add(this.cmServiceUrlTB);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Menu = this.mainMenu1;
            this.Name = "CapabilitiesDlg";
            this.Text = "Capabilities Sample";
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
			about.applicationName = "Capabilities";
			about.applicationVersion = "1.0";
			about.Show();
		}

		// This function is the main driver for this sample.
		private void buttonSetCapabilities_Click(object sender, System.EventArgs e)
		{
			string resultMessage = "";
			resultsDisplayWindowRTB.Clear();
			try
			{
				Capabilities capObj = new Capabilities();
				capObj.setCapabilities(cmService, ref resultMessage);
				displayMessage(resultMessage);
			}
			catch(SoapException ex)
			{
				displayMessage("\n...the operation failed.\nThe following information was returned by cmService:");
				displayMessage(SamplesException.getExceptionMessage( ex));
				return;
			}
			catch(System.Exception ex)
			{
				if (0 != ex.Message.CompareTo("INPUT_CANCELLED_BY_USER"))
				{
					SamplesException.ShowExceptionMessage( ex.Message, true, "SetCapabilities Sample" );					
				}
				return;
			}
		}

		public void setConnection(contentManagerService1 cBICMS, string crnUrl)
		{
			cmService = cBICMS;
			cmServiceUrlTB.Text = crnUrl;
		}

		public void displayMessage(string message)
		{
			resultsDisplayWindowRTB.AppendText("\n" + message);
		}

		public void clearDisplayWindow()
		{
			resultsDisplayWindowRTB.Clear();
		}

	}
}
