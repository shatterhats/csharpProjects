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
using cognosdotnet_10_2;

namespace Email
{
	/// <summary>
	/// Summary description for EmailContactsDlg.
	/// </summary>
	public class EmailContactsDlg : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button buttonSendEmail;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.TextBox emailSubjectTB;
		private System.Windows.Forms.RichTextBox emailBodyRTB;
		private System.Windows.Forms.Label emailAddressLBL;
		private System.Windows.Forms.Label emailSubjectLBL;
		private System.Windows.Forms.Label emailBodyLBL;
		private System.Windows.Forms.ComboBox emailAddressCB;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public EmailContactsDlg()
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(EmailContactsDlg));
			this.emailAddressLBL = new System.Windows.Forms.Label();
			this.emailSubjectLBL = new System.Windows.Forms.Label();
			this.emailBodyLBL = new System.Windows.Forms.Label();
			this.emailSubjectTB = new System.Windows.Forms.TextBox();
			this.emailBodyRTB = new System.Windows.Forms.RichTextBox();
			this.buttonSendEmail = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.emailAddressCB = new System.Windows.Forms.ComboBox();
			this.SuspendLayout();
			// 
			// emailAddressLBL
			// 
			this.emailAddressLBL.Location = new System.Drawing.Point(16, 16);
			this.emailAddressLBL.Name = "emailAddressLBL";
			this.emailAddressLBL.Size = new System.Drawing.Size(80, 23);
			this.emailAddressLBL.TabIndex = 0;
			this.emailAddressLBL.Text = "Email Address:";
			// 
			// emailSubjectLBL
			// 
			this.emailSubjectLBL.Location = new System.Drawing.Point(16, 56);
			this.emailSubjectLBL.Name = "emailSubjectLBL";
			this.emailSubjectLBL.Size = new System.Drawing.Size(80, 23);
			this.emailSubjectLBL.TabIndex = 1;
			this.emailSubjectLBL.Text = "Email Subject:";
			// 
			// emailBodyLBL
			// 
			this.emailBodyLBL.Location = new System.Drawing.Point(16, 104);
			this.emailBodyLBL.Name = "emailBodyLBL";
			this.emailBodyLBL.Size = new System.Drawing.Size(72, 16);
			this.emailBodyLBL.TabIndex = 2;
			this.emailBodyLBL.Text = "Email Body:";
			// 
			// emailSubjectTB
			// 
			this.emailSubjectTB.Location = new System.Drawing.Point(96, 56);
			this.emailSubjectTB.Name = "emailSubjectTB";
			this.emailSubjectTB.Size = new System.Drawing.Size(184, 20);
			this.emailSubjectTB.TabIndex = 4;
			this.emailSubjectTB.Text = "SDK Email Sample Report";
			// 
			// emailBodyRTB
			// 
			this.emailBodyRTB.Location = new System.Drawing.Point(96, 104);
			this.emailBodyRTB.Name = "emailBodyRTB";
			this.emailBodyRTB.Size = new System.Drawing.Size(184, 96);
			this.emailBodyRTB.TabIndex = 5;
			this.emailBodyRTB.Text = "This is an example of email body text";
			// 
			// buttonSendEmail
			// 
			this.buttonSendEmail.Location = new System.Drawing.Point(96, 216);
			this.buttonSendEmail.Name = "buttonSendEmail";
			this.buttonSendEmail.Size = new System.Drawing.Size(80, 24);
			this.buttonSendEmail.TabIndex = 6;
			this.buttonSendEmail.Text = "Send Email";
			this.buttonSendEmail.Click += new System.EventHandler(this.buttonSendEmail_Click);
			// 
			// buttonCancel
			// 
			this.buttonCancel.Location = new System.Drawing.Point(200, 216);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(80, 23);
			this.buttonCancel.TabIndex = 7;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
			// 
			// emailAddressCB
			// 
			this.emailAddressCB.Location = new System.Drawing.Point(96, 16);
			this.emailAddressCB.Name = "emailAddressCB";
			this.emailAddressCB.Size = new System.Drawing.Size(184, 21);
			this.emailAddressCB.TabIndex = 8;
			// 
			// EmailContactsDlg
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(296, 254);
			this.Controls.Add(this.emailAddressCB);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonSendEmail);
			this.Controls.Add(this.emailBodyRTB);
			this.Controls.Add(this.emailSubjectTB);
			this.Controls.Add(this.emailBodyLBL);
			this.Controls.Add(this.emailSubjectLBL);
			this.Controls.Add(this.emailAddressLBL);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "EmailContactsDlg";
			this.Text = "Email Contacts";
			this.ResumeLayout(false);

		}
		#endregion

		public string emailAddress = "";
		public string emailSubject = "";
		public string emailBody = "";
		public bool isContactInfoSet = false;

		private void buttonCancel_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void buttonSendEmail_Click(object sender, System.EventArgs e)
		{
			emailAddress = (string)emailAddressCB.SelectedItem;
			if (emailAddress == null)
			{
				emailAddress = "";
			}
			emailSubject = emailSubjectTB.Text;
			emailBody = emailBodyRTB.Text;
			isContactInfoSet = true;
			this.Close();
		}

		public void setAllUsersMode(bool isAllUsersMode)
		{
			if (isAllUsersMode)
			{
				emailAddressLBL.Visible = false;
				emailAddressCB.Visible = false;
			}
			else
			{
				emailAddressLBL.Visible = true;
				emailAddressCB.Visible = true;
			}
		}

		public void setContactEmails(addressSMTP[] contactList)
		{
			int nbContacts = contactList.GetLength(0);
			for (int i=0;i<nbContacts;i++)
			{
				emailAddressCB.Items.Add(contactList[i].Value);
			}
		}

		public void setSelectedEmailAddress(int value)
		{
			emailAddressCB.SelectedIndex = value;
		}


	}
}
