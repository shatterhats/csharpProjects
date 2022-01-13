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

namespace SamplesCommon
{
	/// <summary>
	/// Summary description for SamplesConnect.
	/// </summary>
	public class SamplesConnect : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox serverUrlTB;
		private System.Windows.Forms.Button buttonOK;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.Label connectLBL;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;		

		// sn_dg_prm_smpl_connect_start_0
		private agentService cBIAS = null; 
		// sn_dg_prm_smpl_connect_end_0
		private batchReportService1 cBIBRS = null;
		private contentManagerService1 cBICMS = null;
		private dataIntegrationService1 cBIDIS = null;
		private deliveryService1 cBIDS = null;
		private eventManagementService1 cBIEMS = null;
		private jobService1 cBIJS = null;
		private monitorService1 cBIMS = null;
		private reportService1 cBIRS = null;
		private systemService1 cBISS = null;

		private string cBIUrl = "";
		private string errorText = null;
		private bool connectedToServer = false;	
		private static string savedUserName = "";
		private static string savedUserPassword = "";
		private static string savedNamespace = "";
        private static string savedAccountSearchPath = "";


		public SamplesConnect()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SamplesConnect));
            this.label1 = new System.Windows.Forms.Label();
            this.serverUrlTB = new System.Windows.Forms.TextBox();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.connectLBL = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(10, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Server URL";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // serverUrlTB
            // 
            this.serverUrlTB.Location = new System.Drawing.Point(87, 23);
            this.serverUrlTB.Name = "serverUrlTB";
            this.serverUrlTB.Size = new System.Drawing.Size(312, 20);
            this.serverUrlTB.TabIndex = 1;
            this.serverUrlTB.Text = "http://localhost:9300/p2pd/servlet/dispatch";
            this.serverUrlTB.KeyDown += new System.Windows.Forms.KeyEventHandler(this.serverUrlTB_OnKeyPress);
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(239, 55);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 2;
            this.buttonOK.Text = "OK";
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            this.buttonOK.KeyDown += new System.Windows.Forms.KeyEventHandler(this.buttonOK_OnKeyPress);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(327, 55);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 3;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            this.buttonCancel.KeyDown += new System.Windows.Forms.KeyEventHandler(this.buttonCancel_OnKeyPress);
            // 
            // connectLBL
            // 
            this.connectLBL.Location = new System.Drawing.Point(24, 55);
            this.connectLBL.Name = "connectLBL";
            this.connectLBL.Size = new System.Drawing.Size(152, 23);
            this.connectLBL.TabIndex = 4;
            // 
            // SamplesConnect
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(414, 86);
            this.Controls.Add(this.connectLBL);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.serverUrlTB);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SamplesConnect";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Connect to server";
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void buttonOK_Click(object sender, System.EventArgs e)
		{
			connectLBL.Visible = true;
			connectLBL.Text = "Connecting...";
			cBICMS = new contentManagerService1();

			if (cBICMS != null)
			{
				//Test for Anonymous Authentication
				Boolean bTestAnonymous = false;
				try
				{
					cBIUrl = serverUrlTB.Text;
					cBICMS.Url = cBIUrl;
					searchPathMultipleObject homeDirSearchPath = new searchPathMultipleObject();
					homeDirSearchPath.Value = "~";
					baseClass[] bc = CBICMS.query ( homeDirSearchPath, new propEnum[]{} , new sort[]{}, new queryOptions () );
					if (bc != null)
					{
						bTestAnonymous = true;
					}
				}
				catch(Exception ex) 
				{
                    if (ex == null) { }
					//if security is enabled, we will end up here
				}
				if (bTestAnonymous == true)
				{
					connectedToServer = true;
					connectLBL.Visible = true;
					connectLBL.Text = "Connected.";
                    savedAccountSearchPath = "CAMID(\"::Anonymous\")";
				}
				else
				{
					// Attempt to log on.
					SamplesLogon logon = new SamplesLogon( this );
					logon.setUserName(savedUserName);
					logon.setUserPassword(savedUserPassword);
					logon.setNamespace(savedNamespace);
					logon.ShowDialog( );
					if( !logon.loggedOn ) 
					{
						errorText = ( "Connection to server: Unable to log on." );
						connectedToServer = false;
						connectLBL.Visible = false;
						return;
					} 
					else 
					{
						connectedToServer = true;
						savedUserName = logon.getUserName();
						savedUserPassword = logon.getUserPassword();
						savedNamespace = logon.getNamespace();
						connectLBL.Visible = true;
						connectLBL.Text = "Connected.";
                        savedAccountSearchPath = getLogonAccount(this).searchPath.value;;
					}
				}
			}
			this.Close();
		}

		private void buttonCancel_Click(object sender, System.EventArgs e)
		{
			connectedToServer = false;
			this.Close();
		}

		public bool IsConnectedToCBI()
		{
			return connectedToServer;
		}

        public string GetAccountPath()
        {
            return savedAccountSearchPath;
        }

        public string GetErrorText()
		{
			return errorText;
		}

		public string getUserName()
		{
			return savedUserName;
		}

		public string getUserPassword()
		{
			return savedUserPassword;
		}
		
		public string getNamespace()
		{
			return savedNamespace;
		}

		private void serverUrlTB_OnKeyPress(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				buttonOK_Click(sender, e);
			}
			else if (e.KeyCode == Keys.Escape)
			{
				this.Close();
			}
		}

		private void buttonOK_OnKeyPress(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
			{
				this.Close();
			}
		}

		private void buttonCancel_OnKeyPress(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
			{
				this.Close();
			}
		}

		public bool makeCLConnection(ref string cBIUrl, 
									ref string userName, 
									ref string userPassword, 
									ref string userNamespace,
									ref bool isAnonymous)
		{
			Console.WriteLine("Connecting...");
			cBICMS = new contentManagerService1();
			if (cBICMS == null)
			{
				Console.WriteLine("Unable to get a contentManagerService1 instance.");
				return false;
			}
			//Test for Anonymous Authentication
			try
			{
				// sn_dg_prm_smpl_connect_start_1
				cBIUrl = "http://localhost:9300/p2pd/servlet/dispatch";
				cBICMS.Url = cBIUrl;
				// sn_dg_prm_smpl_connect_end_1
				searchPathMultipleObject homeDirSearchPath = new searchPathMultipleObject();
				homeDirSearchPath.Value = "~";
				
				baseClass[] bc = cBICMS.query ( homeDirSearchPath, new propEnum[]{} , new sort[]{}, new queryOptions () );
				if (bc != null)
				{
					isAnonymous = true;
				}
			}
			catch(Exception ex) 
			{
				// Anonymous if OFF
				isAnonymous = false;
				if (0 != ex.Message.CompareTo("The client did something wrong"))
				{
					SamplesException.ShowExceptionMessage("\n" + ex.Message, false, "Error connecting to server");
					return false;
				}
			}
			if (isAnonymous == true)
			{
				// Anonymous if ON
				connectedToServer = true;
				Console.WriteLine("Connected.");
				return true;
			}
			else
			{
				// Attempt to log on.
				if ( (userName == null) || (0 == userName.CompareTo("")) )
				{
					Console.Write("userName: ");
					userName = Console.ReadLine();
				}
				if ( (userPassword == null) || (0 == userPassword.CompareTo("")) )
				{
					Console.Write("userPassword: ");
					userPassword = Console.ReadLine();
				}
				if ( (userNamespace == null) || (0 == userNamespace.CompareTo("")) )
				{
					Console.Write("userNamespace: ");
					userNamespace = Console.ReadLine();
				}
				SamplesLogon logon = new SamplesLogon(this);
				logon.specificUserLogon(false, userName, userPassword, userNamespace);
				if( !logon.loggedOn ) 
				{
					Console.WriteLine("Unable to connect to server." );
					connectedToServer = false;
					return false;
				} 
				else 
				{
					connectedToServer = true;
					savedUserName = logon.getUserName();
					savedUserPassword = logon.getUserPassword();
					savedNamespace = logon.getNamespace();
					Console.WriteLine("Connected.");
					return true;
				}
			}
		}

		public static account getLogonAccount(SamplesConnect connectedAs)
		{
			propEnum[] props =
				new propEnum[] { propEnum.searchPath, propEnum.defaultName, propEnum.policies };
			account myAccount = null;

			if (connectedAs.CBICMS == null)
			{
				Console.WriteLine("Invalid parameter passed to function logon.");
				return myAccount;
			}

			try
			{
				searchPathMultipleObject dummy = new searchPathMultipleObject();
				dummy.Value = "~";
				baseClass[] bc =
					connectedAs.CBICMS.query(dummy, props, new sort[] {}, new queryOptions());

					if ((bc != null) && (bc.Length == 1))
					{
						myAccount = (account)bc[0];
					}
			}
			catch (Exception ex)
			{
				//An exception here likely indicates the client is not currently
				//logged in, so the query fails.
				Console.WriteLine("Caught Exception:\n" + ex.Message);
			}
			return myAccount;
		}

		public credential getCredential()
		{
			baseClass[] results;
			searchPathMultipleObject credSearchPath = new searchPathMultipleObject();
			credSearchPath.Value = "~/credential[@name='Credential']";


			results = CBICMS.query(credSearchPath, new propEnum[] {}, new sort[] {}, new queryOptions());
			for (int i = 0; i < results.Length; i++)
			{
				if (results[i] is credential)
				{
					return (credential) results[i];
				}
			}
			return addCredential();
		}

		public credential addCredential()
		{
			credential mCredential = new credential();
			anyTypeProp mCredentials = new anyTypeProp();
			mCredentials.value = credentialString;
			baseClass[] addedObjects;
			
			//Prepare the name property for the new credential object
			multilingualToken[] names = new multilingualToken[1];
			names[0] = new multilingualToken();
			locale[] locales = getLocale();
			names[0].locale = locales[0].locale1;
			names[0].value = "Credential";
			multilingualTokenProp credNameTokenProp = new multilingualTokenProp();
			credNameTokenProp.value = names;
			
			//Add the searchPath, name and defaultname to the new credential object
			mCredential.name = credNameTokenProp;
			mCredential.credentials = mCredentials;

			baseClass[] addArray = new baseClass[1];
			addArray[0] = mCredential;

			//Add the credential object to the content store
			searchPathSingleObject parentPath = new searchPathSingleObject();
			parentPath.Value = getLogonAccount(this).searchPath.value;
			addOptions ao = new addOptions();
			ao.updateAction = updateActionEnum.replace;
			try
			{
				addedObjects = CBICMS.add(parentPath, addArray, ao);
				for (int i = 0; i < addedObjects.Length; i++)
				{
					if (addedObjects[i] is credential)
					{
						return (credential) addedObjects[i];
					}
				}
															   
			}
			catch (Exception ex)
			{
				Console.WriteLine("Caught Exception:\n" + ex.Message);
			}
			return null;
		}

		public locale[] getLocale()
		{
			configurationData data = null;
			locale[] locales = null;

			configurationDataEnum[] config = new configurationDataEnum[1];
			config[0] = configurationDataEnum.serverLocale;

			try
			{
				/**
				* Use this method to retrieve global configuration data.
				*  
				* Input Parameters
				*
				* config
				* 	Specifies the set of properties to be returned.
				* 
				* Return Value
				* 	This method returns the server locale. 
				*/

				data = CBISS.getConfiguration(config);
				locales = data.serverLocale;

				if (locales == null)
				{
					Console.WriteLine("No serverLocale configured!");
				}
			}
			catch(Exception ex)
			{
				Console.WriteLine("Caught Exception:\n" + ex.Message);
			}

			return locales;
		}

		//property definition for the server URL 
		public string CBIURL
		{
			get
			{
				return cBIUrl;
			}
		}

		public string credentialString
		{
			get
			{
				string credentialXML = "<credential>";

				//Namespace
				if (savedNamespace != "")
				{
					credentialXML += "<namespace>";
					credentialXML += savedNamespace;
					credentialXML += "</namespace>";
				}
				
				//Username
				credentialXML += "<username>";
				if (savedUserName == "")
				{
					credentialXML += "Anonymous";
				}
				else
				{
					credentialXML += savedUserName;
				}
				credentialXML += "</username>";

				//Password
				if (savedUserPassword != "")
				{
					credentialXML += "<password>";
					credentialXML += savedUserPassword;
					credentialXML += "</password>";
				}
				credentialXML += "</credential>";
				return credentialXML;
			}
		}
			//property definitions to give read access the various service objects
			//
			//header and url information is retrieved from the contentManagerService1 object
			//as this it the service used to connect and logon.
			public agentService CBIAS
		{
			get
			{
				// sn_dg_prm_smpl_connect_start_2
				if (cBIAS == null)
				{
					cBIAS = new agentService();
					cBIAS.Url = cBICMS.Url;
				}
				if (cBIAS.biBusHeaderValue == null)
				{
					cBIAS.biBusHeaderValue = cBICMS.biBusHeaderValue;
				}
				// sn_dg_prm_smpl_connect_end_2
				return cBIAS;
			}
		}
  
		public batchReportService1 CBIBRS
		{
			get
			{
				if (cBIBRS == null)
				{
					cBIBRS = new batchReportService1();
					cBIBRS.Url = cBICMS.Url;
				}
				if (cBIBRS.biBusHeaderValue == null)
				{
					cBIBRS.biBusHeaderValue = cBICMS.biBusHeaderValue;
				}
				return cBIBRS;
			}
		}
		public contentManagerService1 CBICMS
		{
			//This service is the initial connect and logon point.
			//It _must_ be initialized before calling this accessor.
			get
			{
				return cBICMS;
			}
		}
		public dataIntegrationService1 CBIDIS
		{
			get
			{
				if (cBIDIS == null)
				{
					cBIDIS = new dataIntegrationService1();
					cBIDIS.Url = cBICMS.Url;
				}
				if (cBIDIS.biBusHeaderValue == null)
				{
					cBIDIS.biBusHeaderValue = cBICMS.biBusHeaderValue;
				}
				return cBIDIS;
			}
		}
		public deliveryService1 CBIDS
		{
			get
			{
				if (cBIDS == null)
				{
					cBIDS = new deliveryService1();
					cBIDS.Url = cBICMS.Url;
				}
				if (cBIDS.biBusHeaderValue == null)
				{
					cBIDS.biBusHeaderValue = cBICMS.biBusHeaderValue;
				}
				return cBIDS;
			}
		}
		public eventManagementService1 CBIEMS
		{
			get
			{
				if (cBIEMS == null)
				{
					cBIEMS = new eventManagementService1();
					cBIEMS.Url = cBICMS.Url;
				}
				if (cBIEMS.biBusHeaderValue == null)
				{
					cBIEMS.biBusHeaderValue = cBICMS.biBusHeaderValue;
				}
				return cBIEMS;
			}
		}
		public jobService1 CBIJS
		{
			get
			{
				if (cBIJS == null)
				{
					cBIJS = new jobService1();
					cBIJS.Url = cBICMS.Url;
				}
				if (cBIJS.biBusHeaderValue == null)
				{
					cBIJS.biBusHeaderValue = cBICMS.biBusHeaderValue;
				}
				return cBIJS;
			}
		}
		public monitorService1 CBIMS
		{
			get
			{
				if (cBIMS == null)
				{
					cBIMS = new monitorService1();
					cBIMS.Url = cBICMS.Url;
				}
				if (cBIMS.biBusHeaderValue == null)
				{
					cBIMS.biBusHeaderValue = cBICMS.biBusHeaderValue;
				}
				return cBIMS;
			}
		}
		public reportService1 CBIRS
		{
			get
			{
				if (cBIRS == null)
				{
					cBIRS = new reportService1();
					cBIRS.Url = cBICMS.Url;
				}
				if (cBIRS.biBusHeaderValue == null)
				{
					cBIRS.biBusHeaderValue = cBICMS.biBusHeaderValue;
				}
				return cBIRS;
			}
		}
		public systemService1 CBISS
		{
			get
			{
				if (cBISS == null)
				{
					cBISS = new systemService1();
					cBISS.Url = cBICMS.Url;
				}
				if (cBISS.biBusHeaderValue == null)
				{
					cBISS.biBusHeaderValue = cBICMS.biBusHeaderValue;
				}
				return cBISS;
			}
		}


	}
}
