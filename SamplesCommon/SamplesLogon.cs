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
using System.Xml;
using System.IO;
using System.Web.Services.Protocols;
using System.Text;
using cognosdotnet_10_2;

namespace SamplesCommon
{
	/// <summary>
	/// A standard logon dialog for the Samples.
	/// </summary>
	public class SamplesLogon : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox namespaceBox;
		private System.Windows.Forms.TextBox userNameText;
		private System.Windows.Forms.TextBox passwordText;
		private System.Windows.Forms.Button logonButton;
		private System.Windows.Forms.Button cancelButton;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public SamplesLogon( SamplesConnect connection )
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			// Save our contentManagerService1 service object.
			cBICMS = connection.CBICMS;

		}

		public SamplesLogon(contentManagerService1 cmService)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			// Save our contentManagerService1 object.
			cBICMS = cmService;

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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(SamplesLogon));
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.namespaceBox = new System.Windows.Forms.ComboBox();
			this.userNameText = new System.Windows.Forms.TextBox();
			this.passwordText = new System.Windows.Forms.TextBox();
			this.logonButton = new System.Windows.Forms.Button();
			this.cancelButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(64, 24);
			this.label1.TabIndex = 0;
			this.label1.Text = "User Name:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(16, 48);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(64, 23);
			this.label2.TabIndex = 1;
			this.label2.Text = "Password:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(16, 80);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(72, 24);
			this.label3.TabIndex = 2;
			this.label3.Text = "Namespace:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// namespaceBox
			// 
			this.namespaceBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.namespaceBox.BackColor = System.Drawing.SystemColors.Control;
			this.namespaceBox.Location = new System.Drawing.Point(88, 80);
			this.namespaceBox.Name = "namespaceBox";
			this.namespaceBox.Size = new System.Drawing.Size(184, 21);
			this.namespaceBox.TabIndex = 5;
			// 
			// userNameText
			// 
			this.userNameText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.userNameText.Location = new System.Drawing.Point(88, 16);
			this.userNameText.Name = "userNameText";
			this.userNameText.Size = new System.Drawing.Size(184, 20);
			this.userNameText.TabIndex = 3;
			this.userNameText.Text = "";
			// 
			// passwordText
			// 
			this.passwordText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.passwordText.Location = new System.Drawing.Point(88, 48);
			this.passwordText.Name = "passwordText";
			this.passwordText.PasswordChar = '*';
			this.passwordText.Size = new System.Drawing.Size(184, 20);
			this.passwordText.TabIndex = 4;
			this.passwordText.Text = "";
			this.passwordText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.passwordText_OnKeyPress);
			// 
			// logonButton
			// 
			this.logonButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.logonButton.Location = new System.Drawing.Point(112, 128);
			this.logonButton.Name = "logonButton";
			this.logonButton.TabIndex = 6;
			this.logonButton.Text = "Logon";
			this.logonButton.Click += new System.EventHandler(this.logonButton_Click);
			// 
			// cancelButton
			// 
			this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cancelButton.Location = new System.Drawing.Point(200, 128);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.TabIndex = 7;
			this.cancelButton.Text = "Cancel";
			this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
			// 
			// SamplesLogon
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(292, 166);
			this.Controls.Add(this.cancelButton);
			this.Controls.Add(this.logonButton);
			this.Controls.Add(this.passwordText);
			this.Controls.Add(this.userNameText);
			this.Controls.Add(this.namespaceBox);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "SamplesLogon";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Logon";
			this.Load += new System.EventHandler(this.SamplesLogon_Load);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		///  service object; we need to have one of these so we can
		/// access the logon() method.
		/// </summary>
		private contentManagerService1 cBICMS = null;

		/// <summary>
		/// Have we successfully logged on?  Note that we've got a read-only 
		/// propery if you want to look at this.
		/// </summary>
		private bool isLoggedOn = false;

		/// <summary>
		/// This is the default user name that shows up in the logon dialog box
		/// When it is re-opened.
		/// </summary>
		private string defaultUserName = "";
		private string defaultPassword = "";
		private string defaultNamespace = "";
		private bool switchUserMode = false;

		/// <summary>
		/// Have we successfully logged on?
		/// </summary>
		public bool loggedOn 
		{
			get {
				return isLoggedOn;
			}
		}

		private string[] getNamespaces()
		{
			// Initialize the return values container
			String[] namespaces = new String[] {};
			
			try
			{
				searchPathMultipleObject rootSearchPath = new searchPathMultipleObject();
				rootSearchPath.Value = "~";
				cBICMS.query(rootSearchPath, null, new sort[] {},new queryOptions());
			}
			catch (System.Web.Services.Protocols.SoapException ex)
			{
                if (ex == null) { }
				//Ignore this exception, it is expected				
			}

			if (switchUserMode)
			{
				// directly query for the namespace
				searchPathMultipleObject directorySearchPath = new searchPathMultipleObject();
				directorySearchPath.Value = "/directory/*";
				propEnum[] props =
					new propEnum[] { propEnum.searchPath, propEnum.defaultName };
				baseClass[] bcNamespaces = cBICMS.query(directorySearchPath, props, new sort[] {}, new queryOptions());
				if ( (bcNamespaces != null) && (bcNamespaces.GetLength(0) > 0) )
				{
					namespaces = new string[(bcNamespaces.GetLength(0)-1) * 2]; // skip "Cognos"
					for (int i=1; i < bcNamespaces.GetLength(0); i++)
					{
						namespaces[i-1] = bcNamespaces[i].defaultName.value;
						namespaces[i] = bcNamespaces[i].searchPath.value;
					}
				}
			}
			else
			{
				// Look in the displayObjects for namespace prompt options and capture 
				// all the namespaces defined there.
				displayObject[] dob =
					cBICMS.biBusHeaderValue.CAM.exception.promptInfo.displayObjects;

				for (int i = 0; i < dob.Length; i++)
				{
					if (dob[i].name.Equals("CAMNamespace"))
					{
						promptOption[] pop = dob[i].promptOptions;
						// Check to see how many namespaces exist.
						// If there is an array, there are many namespaces.
						// Otherwise there is only one namespace.
						if (pop != null)
						{
							namespaces = new string[pop.Length * 2];
							for (int j = 0, k = 0; k < pop.Length; j++, k++)
							{
								namespaces[j] = pop[k].value;
								namespaces[++j] = pop[k].id;
							}
						}
						else // There is only one namespace.
						{
							namespaces = new string[2];
							namespaces[0] = dob[i].value;
							namespaces[1] = dob[i].value;
						}
					}
				}
			}
			return namespaces;
		}


		/// <summary>
		/// The user has clicked on the Cancel button.  Indicate that we
		/// haven't logged on, and close the Logon dialog.
		/// </summary>
		/// <param name="sender">What object sent this event? (not used)</param>
		/// <param name="e">Event arguments (not used)</param>
		private void cancelButton_Click( object sender, System.EventArgs e ) 
		{
			isLoggedOn = false;

			this.Close();
		}

		private void passwordText_OnKeyPress(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				logonButton_Click(sender, e);
			}
		}
		
		/// <summary>
		/// Attempt to log on to the  server using the supplied
		/// credentials.
		/// </summary>
		/// <param name="sender">What object sent this event? (not used)</param>
		/// <param name="e">Event arguments (not used)</param>
		private void logonButton_Click( object sender, System.EventArgs e ) 
		{
			// scrub the incoming values

			if( namespaceBox.Text == null ) namespaceBox.Text = "";
			if( userNameText.Text == null ) userNameText.Text = "";
			if( passwordText.Text == null ) passwordText.Text = "";
			specificUserLogon(true, userNameText.Text, passwordText.Text, namespaceBox.Text);

			this.Close();
		}

		private void SamplesLogon_Load(object sender, System.EventArgs e)
		{
			string userName = getUserName();
			if ((userName != null) && (0 != userName.CompareTo("")) )
			{
				userNameText.Text = userName;
			}
			
			// Attempt to populate the namespace combobox.  In theory, the
			// user can type a namespace ID if they know one.
			namespaceBox.Items.Clear();

			string[] namespaceInfo = getNamespaces();
			if ( (namespaceInfo == null) || (namespaceInfo.GetLength(0)<=0) )
			{
				System.Windows.Forms.MessageBox.Show(
					"Unable to connect to server",
					"Connect Failed");
				this.Close();
				return;
			}

			//namespaceInfo is name/ID pairs -- always even
			string[] namespaces = new string[namespaceInfo.Length / 2];

			//for each value of j, jump to the second next value of k
			for (int j = 0, k = 0; k < namespaceInfo.Length; j++, k++)
			{
				namespaces[j] = namespaceInfo[k++];
				namespaceBox.Items.Add(namespaceInfo[k]);
			}
			namespaceBox.SelectedIndex = 0;
		}


		public void specificUserLogon(bool guiMode, string userName, string userPassword, string userNamespace)
		{
			try 
			{
				// sn_dg_prm_sdk_method_contentManagerService_logon_start_0
				System.Text.StringBuilder credentialXML = new System.Text.StringBuilder("<credential>" );
				credentialXML.AppendFormat( "<namespace>{0}</namespace>", userNamespace );
				credentialXML.AppendFormat( "<username>{0}</username>", userName );
				credentialXML.AppendFormat( "<password>{0}</password>", userPassword );
				credentialXML.Append( "</credential>" );

				//The csharp toolkit encodes the credentials
				string encodedCredentials = credentialXML.ToString ();
				xmlEncodedXML xmlEncodedCredentials = new xmlEncodedXML();
				xmlEncodedCredentials.Value = encodedCredentials;
				searchPathSingleObject[] emptyRoleSearchPathList = new searchPathSingleObject[0];	
				cBICMS.logon(xmlEncodedCredentials, null);
				// sn_dg_prm_sdk_method_contentManagerService_logon_end_0

				//hang on to the user data locally for use elsewhere
				setUserName(userName);
				setUserPassword(userPassword);
				setNamespace(userNamespace);
				isLoggedOn = true;
			}
			catch( SoapException ex ) 
			{
				isLoggedOn = false;
				SamplesException.ShowExceptionMessage( ex, guiMode, "Unable To Logon" );
			}
			catch (System.Exception ex)
			{
				isLoggedOn = false;
				SamplesException.ShowExceptionMessage( ex.Message, guiMode, "Unable To Logon" );
			}
		}

		public string getUserName()
		{
			if (defaultUserName == null)
			{
				return "";
			}
			return defaultUserName;
		}
		
		public void setUserName(string userName)
		{
			defaultUserName = userName;
		}
		
		public void setUserPassword(string password)
		{
			defaultPassword = password;
		}
		
		public string getUserPassword()
		{
			if (defaultPassword == null)
			{
				return "";
			}
			return defaultPassword;
		}

		public string getNamespace()
		{
			if (defaultNamespace == null)
			{
				return "";
			}
			return defaultNamespace;
		}

		public void setNamespace(string nmspace)
		{
			defaultNamespace = nmspace;
		}

		public void setSwitchUserMode(bool switchUser)
		{
			switchUserMode = true;
		}
	}
}
