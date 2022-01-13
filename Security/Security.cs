/** 
Licensed Materials - Property of IBM

IBM Cognos Products: DOCS

(C) Copyright IBM Corp. 2005, 2008

US Government Users Restricted Rights - Use, duplication or disclosure restricted by GSA ADP Schedule Contract with
IBM Corp.
*/
//*
//*  security.sln
//*
//*  Copyright (C) 2008 Cognos ULC, an IBM Company. All rights reserved.
//*  Cognos (R) is a trademark of Cognos ULC, (formerly Cognos Incorporated).
//*
//*  This sample illustrates the use of the logon and logoff methods.
//*

using System;
using System.Web.Services.Protocols;
using SamplesCommon;
using cognosdotnet_10_2;

namespace Security
{
	/// <summary>
	/// Summary description for Security.
	/// </summary>
	class Security
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		/// 
		public Security(){}

		static void Main(string[] args)
		{
			string cBIUrl = "";
			contentManagerService1 cBIServer = null;
			SamplesConnect connectDlg = new SamplesConnect();
			SecurityDlg securityDlgObject = new SecurityDlg();

			// The savedUserName and savedNamespace variables are only used for convenience, 
			// so that the user name and the namespace can be remembered when prompting for 
			// logon multiple times.
			string savedUserName = "";
			string savedNamespace = "";
			
			if (args.GetLength(0) == 0 )
			{
				// GUI mode
				connectDlg.ShowDialog();
				if (connectDlg.IsConnectedToCBI() == true) 
				{
					cBIServer = connectDlg.CBICMS;
					cBIUrl = connectDlg.CBIURL;
					savedUserName = connectDlg.getUserName();
					savedNamespace = connectDlg.getNamespace();
					securityDlgObject.setConnection(connectDlg, cBIUrl, savedUserName, savedNamespace);
					securityDlgObject.ShowDialog();				
				}
			}
		}

		public bool getLogonInfo(SamplesConnect cBIConnection, ref string result)
		{
			if ( cBIConnection == null)
			{
				result = "...the Server connection is invalid.\n";
				return false;
			}
			try
			{
				account myAccount = new account();
				baseClass[] bc = new baseClass[1];
				propEnum[] props =
					new propEnum[] { propEnum.searchPath, propEnum.defaultName };
				searchPathMultipleObject homeSearchPath = new searchPathMultipleObject();
				homeSearchPath.Value = "~";

				bc = cBIConnection.CBICMS.query(homeSearchPath, props, new sort[] {}, new queryOptions());
				if ( (bc != null) && (bc.GetLength(0) >0) )
				{
					for (int i=0; i<bc.GetLength(0); i++)
					{
						myAccount.defaultName = new tokenProp();
						myAccount.defaultName.value = bc[i].defaultName.value;
						myAccount.searchPath = new stringProp();
						myAccount.searchPath.value = bc[i].searchPath.value;
					}
					result += "You are currently logged on as: " + myAccount.defaultName.value;
					result += "\nYour searchPath is: " + myAccount.searchPath.value;
				}
			}
			catch(SoapException ex)
			{
				SamplesException.ShowExceptionMessage( ex, true, "Security Samples - getLogonInfo()" );
				result += "getLogonInfo() Failed with error:" + ex.Message;
				return false;
			}
			catch(System.Exception ex)
			{
				SamplesException.ShowExceptionMessage( ex.Message, true, "Security Samples - getLogonInfo()" );
				result += "getLogonInfo() Failed with error:" + ex.Message;
				return false;
			}

			return true;
		}

		public bool doLogon(SamplesConnect cBIConnection, string savedUserName, string savedNamespace, ref string result)
		{
			if ( cBIConnection == null)
			{
				result = "...the Server connection is invalid.\n";
				return false;
			}
		getAccountInfo:
			account myAccount = new account();
			baseClass[] bc = new baseClass[1];
			
			propEnum[] props =
				new propEnum[] { propEnum.searchPath, propEnum.defaultName };
			searchPathMultipleObject homeSearchPath = new searchPathMultipleObject();
			homeSearchPath.Value = "~";

			try
			{
				bc = cBIConnection.CBICMS.query(homeSearchPath, props, new sort[] {}, new queryOptions());
			}
			catch(System.Exception ex)
			{
				// Anonymous is OFF, attempt to log on.
				SamplesLogon logon = new SamplesLogon( cBIConnection );
				logon.setUserName(savedUserName);
				logon.setNamespace(savedNamespace);
				logon.ShowDialog( );
				if( !logon.loggedOn ) 
				{
					result = "...unable to log.";
					return false;
				} 
				else 
				{
					savedUserName = logon.getUserName();
					goto getAccountInfo;
				}
			}
			if (bc != null)
			{
				// Anonymous is ON.
				getLogonInfo(cBIConnection, ref result);
			}
			return true;
		}

		public bool doLogonAs(SamplesConnect cBIConnection, string savedUserName, string savedNamespace, ref string result)
		{
			if ( cBIConnection == null)
			{
				result = "...the Server connection is invalid.\n";
				return false;
			}
			doLogoff(cBIConnection, ref result);
			result += "\n";
			account myAccount = new account();
			baseClass[] bc = new baseClass[1];
			propEnum[] props =
				new propEnum[] { propEnum.searchPath, propEnum.defaultName };
			searchPathMultipleObject homeSearchPath = new searchPathMultipleObject();
			homeSearchPath.Value = "~";

			try
			{
				bc = cBIConnection.CBICMS.query(homeSearchPath, props, new sort[] {}, new queryOptions());
				SamplesLogon logon = new SamplesLogon( cBIConnection );
				logon.setUserName(savedUserName);
				logon.setNamespace(savedNamespace);
				logon.setSwitchUserMode(true);
				logon.ShowDialog( );
				if( logon.loggedOn ) 
				{
					getLogonInfo(cBIConnection, ref result);
					return true;
				}
				else
				{
					result = "...unable to log on.";
					return false;
				} 
			}
			catch(System.Exception ex)
			{
				// Anonymous is OFF, attempt to log on.
				SamplesLogon logon = new SamplesLogon( cBIConnection );
				logon.setUserName(savedUserName);
				logon.setNamespace(savedNamespace);
				logon.ShowDialog( );
				if( logon.loggedOn ) 
				{
					getLogonInfo(cBIConnection, ref result);
					return true;
				}
				else
				{
					result = "...unable to log on.";
					return false;
				} 
			}
		}

		public bool doLogoff(SamplesConnect cBIConnection, ref string result)
		{
			if ( cBIConnection == null)
			{
				result += "\nInvalid parameter passed to function logon.";
				return false;
			}
			
			// sn_dg_sdk_method_contentManagerService_logoff_start_0
			cBIConnection.CBICMS.logoff();
			// sn_dg_sdk_method_contentManagerService_logoff_end_0
			cBIConnection.CBICMS.biBusHeaderValue = new biBusHeader();
			result = "You have successfully logged off.";
			return true;
		}

	}
}
