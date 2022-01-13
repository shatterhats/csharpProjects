/** 
Licensed Materials - Property of IBM

IBM Cognos Products: DOCS

(C) Copyright IBM Corp. 2005, 2008

US Government Users Restricted Rights - Use, duplication or disclosure restricted by GSA ADP Schedule Contract with
IBM Corp.
*/
// *
// * Permissions.sln
// *
// * Copyright (C) 2008 Cognos ULC, an IBM Company. All rights reserved.
// * Cognos (R) is a trademark of Cognos ULC, (formerly Cognos Incorporated).
// *
// * Description: This sample illustrates how to manipulate permissions.
// *
// * Input: Search Path to a permissions object. Possible values are:
// *        Name				Search Path
// *	Administration			/capability/securedFunction[@name='Administration']
// *	Query Studio			/capability/securedFunction[@name='Query Studio']
// *	Report Studio			/capability/securedFunction[@name='Report Studio']
// *	SDK				        /capability/securedFunction[@name='SDK']
// *
// *
// * Outcome: Adds or removes the current user from the permissions/Administration user list.
// *
// * 

using System;
using System.Web.Services.Protocols;
using SamplesCommon;
using cognosdotnet_10_2;

namespace Permissions
{
	/// <summary>
	/// Summary description for Permissions.
	/// </summary>
	class Permissions
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		/// 
		public Permissions(){}
		
		static void Main(string[] args)
		{
			string cBIUrl = "";
			PermissionsDlg permissionsDlgObject = null;
			contentManagerService1 cmService = null;
			SamplesConnect connectDlg = new SamplesConnect();

			if (args.GetLength(0) == 0 )
			{
				// GUI mode
				connectDlg.ShowDialog();
				if (connectDlg.IsConnectedToCBI() == true) 
				{
					cmService = connectDlg.CBICMS;
					cBIUrl = connectDlg.CBIURL;
					permissionsDlgObject = new PermissionsDlg();
					permissionsDlgObject.setConnection(cmService, cBIUrl);
					permissionsDlgObject.ShowDialog();				
				}
			}
		}

		public bool setPermissions(contentManagerService1 CBICMS, ref string resultMessage, String path)
		{
			baseClass[] results = new baseClass[] {};
			folder csFolder = null;
			account myAccount = null;
			permission newPermission = null;
			string permState = "";
		    
			myAccount = getLogonAccount(CBICMS);
			

			string folderName = path;
			searchPathMultipleObject cmTargetPath = new searchPathMultipleObject ();
			cmTargetPath.Value = folderName;
			results = CBICMS.query(cmTargetPath, 
				new propEnum[] { propEnum.searchPath, propEnum.policies },
				new sort[] {},
				new queryOptions());

			if ( (results == null) || (results.GetLength(0) <= 0) )
			{
				resultMessage = "..expected folder was not found for the current user.\n" +
					"Please create this folder before running this sample.";
				return false;
			}

			csFolder = (folder)results[0];

			policy pol;
			for (int i = 0; i < csFolder.policies.value.GetLength(0); i++)
			{
				pol = csFolder.policies.value[i];
				if (0 == pol.securityObject.searchPath.value.CompareTo(myAccount.searchPath.value))
				{
					bool found = false;

					newPermission = new permission();
					newPermission.name = "read";
					int k = pol.permissions.GetLength(0) + 1;
					permission[] cur = new permission[k];

					for (int j = 0; j < pol.permissions.GetLength(0); j++)
					{
						if (0 == pol.permissions[j].name.CompareTo("read"))
						{
							if (pol.permissions[j].access == accessEnum.deny)
							{
								pol.permissions[j].access = accessEnum.grant;
								newPermission.access = accessEnum.grant;

								permState = "GRANTED";
							}
							else
							{
								pol.permissions[j].access = accessEnum.deny;
								newPermission.access = accessEnum.deny;

								permState = "DENIED";
							}
							found = true;
						}

						cur[j] = pol.permissions[j];

					}
					if (! found)
					{
						cur[cur.GetLength(0) - 1] = newPermission;
						pol.permissions = cur;
					}

					CBICMS.update(
						new baseClass[] { csFolder },
						new updateOptions());
					resultMessage += "Successfully " + permState + " " + newPermission.name + " permission on folder for " + myAccount.defaultName.value;
					return true;
				}
			}
			resultMessage = "Unable to find \"" + folderName + "\" for " + myAccount.defaultName.value;
			return false;
		}

		public account getLogonAccount(contentManagerService1 cBICMS)
		{
			propEnum[] props =
				new propEnum[] { propEnum.searchPath, propEnum.defaultName, propEnum.policies, propEnum.objectClass };
			account myAccount = new account();

			try
			{
				searchPathMultipleObject cmSearchPath = new searchPathMultipleObject ();
				cmSearchPath.Value = "~";
				baseClass[] bc = cBICMS.query(cmSearchPath, props, new sort[] {}, new queryOptions());

				if ((bc != null) && (bc.GetLength(0) > 0))
				{
					for (int i = 0; i < bc.GetLength(0); i++)
					{
						myAccount = (account)bc[i];
					}
				}
			}
			catch (System.Exception ex)
			{
				//An exception here likely indicates the client is not currently
				//logged in, so the query fails.
				return null;
			}

			return myAccount;
		}
	}
}
