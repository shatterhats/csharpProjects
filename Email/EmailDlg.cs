/** 
Licensed Materials - Property of IBM

IBM Cognos Products: DOCS

(C) Copyright IBM Corp. 2005

US Government Users Restricted Rights - Use, duplication or disclosure restricted by GSA ADP Schedule Contract with
IBM Corp.
*/
using System;
using System.Drawing;
using System.Threading;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Web.Services.Protocols;
using SamplesCommon;
using cognosdotnet_10_2;
//using EmailContactsDlg;

namespace Email
{
	/// <summary>
	/// Summary description for EmailDlg.
	/// </summary>
	public class EmailDlg : System.Windows.Forms.Form
	{
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItemFile;
		private System.Windows.Forms.MenuItem menuItemExit;
		private System.Windows.Forms.MenuItem menuItemHelp;
		private System.Windows.Forms.MenuItem menuItemAbout;
		private System.Windows.Forms.Label ServerUrlLBL;
		private System.Windows.Forms.Label ReportNameLBL;
		private System.Windows.Forms.Button emailButton;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox reportListCB;
        private System.Windows.Forms.ComboBox emailOptionCB;
        private IContainer components;
		private System.Windows.Forms.RichTextBox resultsDisplayWindowRTB;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox reportSearchPathTB;
		private System.Windows.Forms.TextBox serverUrlTB;
		private SamplesConnect cBIConnection = null;

		public EmailDlg()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EmailDlg));
            this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
            this.menuItemFile = new System.Windows.Forms.MenuItem();
            this.menuItemExit = new System.Windows.Forms.MenuItem();
            this.menuItemHelp = new System.Windows.Forms.MenuItem();
            this.menuItemAbout = new System.Windows.Forms.MenuItem();
            this.ServerUrlLBL = new System.Windows.Forms.Label();
            this.serverUrlTB = new System.Windows.Forms.TextBox();
            this.ReportNameLBL = new System.Windows.Forms.Label();
            this.reportListCB = new System.Windows.Forms.ComboBox();
            this.resultsDisplayWindowRTB = new System.Windows.Forms.RichTextBox();
            this.emailButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.emailOptionCB = new System.Windows.Forms.ComboBox();
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
            // ServerUrlLBL
            // 
            this.ServerUrlLBL.Location = new System.Drawing.Point(16, 16);
            this.ServerUrlLBL.Name = "ServerUrlLBL";
            this.ServerUrlLBL.Size = new System.Drawing.Size(142, 16);
            this.ServerUrlLBL.TabIndex = 0;
            this.ServerUrlLBL.Text = "Server URL";
            // 
            // serverUrlTB
            // 
            this.serverUrlTB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.serverUrlTB.BackColor = System.Drawing.SystemColors.Control;
            this.serverUrlTB.Enabled = false;
            this.serverUrlTB.Location = new System.Drawing.Point(16, 32);
            this.serverUrlTB.Name = "serverUrlTB";
            this.serverUrlTB.Size = new System.Drawing.Size(496, 20);
            this.serverUrlTB.TabIndex = 1;
            this.serverUrlTB.Text = "http://localhost/crn/cgi-bin/cognos.cgi";
            // 
            // ReportNameLBL
            // 
            this.ReportNameLBL.Location = new System.Drawing.Point(232, 72);
            this.ReportNameLBL.Name = "ReportNameLBL";
            this.ReportNameLBL.Size = new System.Drawing.Size(72, 16);
            this.ReportNameLBL.TabIndex = 2;
            this.ReportNameLBL.Text = "Report Name";
            // 
            // reportListCB
            // 
            this.reportListCB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.reportListCB.Location = new System.Drawing.Point(232, 88);
            this.reportListCB.Name = "reportListCB";
            this.reportListCB.Size = new System.Drawing.Size(280, 21);
            this.reportListCB.TabIndex = 3;
            this.reportListCB.SelectedIndexChanged += new System.EventHandler(this.reportListCB_SelectedIndexChanged);
            // 
            // resultsDisplayWindowRTB
            // 
            this.resultsDisplayWindowRTB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.resultsDisplayWindowRTB.BackColor = System.Drawing.SystemColors.Control;
            this.resultsDisplayWindowRTB.Location = new System.Drawing.Point(24, 200);
            this.resultsDisplayWindowRTB.Name = "resultsDisplayWindowRTB";
            this.resultsDisplayWindowRTB.Size = new System.Drawing.Size(480, 136);
            this.resultsDisplayWindowRTB.TabIndex = 4;
            this.resultsDisplayWindowRTB.Text = "";
            // 
            // emailButton
            // 
            this.emailButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.emailButton.Location = new System.Drawing.Point(432, 144);
            this.emailButton.Name = "emailButton";
            this.emailButton.Size = new System.Drawing.Size(80, 32);
            this.emailButton.TabIndex = 6;
            this.emailButton.Text = "Email";
            this.emailButton.Click += new System.EventHandler(this.emailButton_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(16, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "Select Email Option";
            // 
            // emailOptionCB
            // 
            this.emailOptionCB.Location = new System.Drawing.Point(16, 88);
            this.emailOptionCB.Name = "emailOptionCB";
            this.emailOptionCB.Size = new System.Drawing.Size(200, 21);
            this.emailOptionCB.TabIndex = 8;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Location = new System.Drawing.Point(16, 184);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(496, 160);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Results Display Window";
            // 
            // reportSearchPathTB
            // 
            this.reportSearchPathTB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.reportSearchPathTB.BackColor = System.Drawing.SystemColors.Control;
            this.reportSearchPathTB.Location = new System.Drawing.Point(16, 120);
            this.reportSearchPathTB.Name = "reportSearchPathTB";
            this.reportSearchPathTB.Size = new System.Drawing.Size(496, 20);
            this.reportSearchPathTB.TabIndex = 10;
            // 
            // EmailDlg
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(528, 353);
            this.Controls.Add(this.reportSearchPathTB);
            this.Controls.Add(this.serverUrlTB);
            this.Controls.Add(this.resultsDisplayWindowRTB);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.emailOptionCB);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.emailButton);
            this.Controls.Add(this.reportListCB);
            this.Controls.Add(this.ReportNameLBL);
            this.Controls.Add(this.ServerUrlLBL);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Menu = this.mainMenu1;
            this.Name = "EmailDlg";
            this.Text = "Email Sample";
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
			about.applicationName = "Email Sample";
			about.applicationVersion = "1.1";
			about.Show();
		}

		private void emailButton_Click(object sender, System.EventArgs e)
		{
			string emailAddress = "";
			string emailOption = (string)emailOptionCB.SelectedItem;
			EmailContactsDlg ecObject = new EmailContactsDlg();
			Email emailObject = new Email();
			// 1. check the list of contacts in the content store
			addressSMTP[] contactList = emailObject.getContactEmails(cBIConnection.CBICMS);

			int nbContacts = contactList.Length;
			if ( (contactList != null) && (nbContacts > 0) )
			{
				// 1.1 add the list of contact to the contact list combo box.
				ecObject.setContactEmails(contactList);
			}
			else
			{
				// 1.2 notify there are no contacts in the content store
				resultsDisplayWindowRTB.Clear();
				resultsDisplayWindowRTB.AppendText("Please make sure a contact exists in the content store.");
				return;
			}
			// 2. Get the emailing option selected by the user.
			if (0 == emailOption.CompareTo("Email Selected User"))
			{
				ecObject.setAllUsersMode(false);				
				ecObject.setSelectedEmailAddress(0); // default to the first in the list
			}
			else
			{
				ecObject.setAllUsersMode(true);
			}
			resultsDisplayWindowRTB.Clear();
			ecObject.ShowDialog();
			if (ecObject.isContactInfoSet == true)
			{
				emailAddress = ecObject.emailAddress;
				BaseClassWrapper selectedObject = (BaseClassWrapper)reportListCB.SelectedItem;
				string emailSubject = ecObject.emailSubject;
				string emailBody = ecObject.emailBody;
				if ( (emailAddress == null) || (0 == emailAddress.CompareTo("")) )
				{
					displayMessage("Emailing the report : \"" + selectedObject.defaultName.value + "\" to all users...");
				}
				else
				{
					displayMessage("Emailing the report : \"" + selectedObject.defaultName.value + "\" to " + emailAddress + "...");
				}
				// create a thread to still have UI control while sending email
				EmailArgsObject emailArgsObj = new EmailArgsObject(emailObject, selectedObject, emailAddress, emailSubject, emailBody);
				ThreadPool.QueueUserWorkItem(new WaitCallback(executeEmailThread), emailArgsObj);
			}
		}

		public void setConnection(SamplesConnect connection, string cBIUrl)
		{
			cBIConnection = connection;
			serverUrlTB.Text = cBIUrl;
		}

		public void setReportList(string[] reportList)
		{
			int nbReports = reportList.GetLength(0);
			for (int i=0;i<nbReports;i++)
			{
				reportListCB.Items.Add(reportList[i]);
			}
		}

		public void addEmailOptions()
		{
			emailOptionCB.Items.Add("Email Selected User");
			emailOptionCB.Items.Add("Email All Contacts");
		}

		public void setReportList(BaseClassWrapper[] reportAndQueryList)
		{
			reportListCB.Items.AddRange(reportAndQueryList);
		}

		public void setSelectedReportIndex(int value)
		{
			reportListCB.SelectedIndex = value;
		}

		public void setSelectedEmailOption(int value)
		{
			emailOptionCB.SelectedIndex = value;
		}

		private void executeEmailThread(Object stateInfo)
		{
			try
			{
				EmailArgsObject eaObj = (EmailArgsObject) stateInfo;
				string output = eaObj.emailObject.sendEmail(cBIConnection, eaObj.reportObj, eaObj.emailAddress, eaObj.emailSubject, eaObj.emailBody);
				displayMessage(output);
			}
            catch (SoapException ex)
            {
                displayMessage("\n...the operation failed.\nThe following information was returned:");
                displayMessage(SamplesException.getExceptionMessage(ex));
                return;
            }
            catch (System.Exception ex)
			{
				SamplesException.ShowExceptionMessage( ex.Message, true, "Email Report Sample" );
                return;
			}
        }

		public void displayMessage(string message)
		{
			resultsDisplayWindowRTB.AppendText(message + "\n");
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
