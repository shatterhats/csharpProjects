/** 
Licensed Materials - Property of IBM

IBM Cognos Products: DOCS

(C) Copyright IBM Corp. 2005, 2008

US Government Users Restricted Rights - Use, duplication or disclosure restricted by GSA ADP Schedule Contract with
IBM Corp.
*/
// *
// * Capabilities.sln
// *
// * Copyright (C) 2008 Cognos ULC, an IBM Company. All rights reserved.
// * Cognos (R) is a trademark of Cognos ULC, (formerly Cognos Incorporated).
// *
// * Description: This sample illustrates how to manipulate capabilities.
// *
// * Input: Search Path to a capabilities object. Possible values are:
// *        Name				Search Path
// *	Administration			/capability/securedFunction[@name='Administration']
// *	Query Studio			/capability/securedFunction[@name='Query Studio']
// *	Report Studio			/capability/securedFunction[@name='Report Studio']
// *	SDK						/capability/securedFunction[@name='SDK']
// *
// *
// * Outcome: Adds or removes the current user from the capabilities/Administration user list.
// *
// * 

using System;
using System.Web.Services.Protocols;
using SamplesCommon;
using cognosdotnet_10_2;

namespace Capabilities
{
	/// <summary>
	/// Summary description for Capabilities.
	/// </summary>
	class Capabilities
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		/// 
		public Capabilities(){}
		
		static void Main(string[] args)
		{
			string cBIUrl = "";
			contentManagerService1 cmService = null;
			CapabilitiesDlg capabilitiesDlgObject = null;
			SamplesConnect connectDlg = new SamplesConnect();

			if (args.GetLength(0) == 0 )
			{
				// GUI mode
				connectDlg.ShowDialog();
				if (connectDlg.IsConnectedToCBI() == true) 
				{
					cmService = connectDlg.CBICMS;
					cBIUrl = connectDlg.CBIURL;				
					capabilitiesDlgObject = new CapabilitiesDlg();
					capabilitiesDlgObject.setConnection(cmService, cBIUrl);
					capabilitiesDlgObject.ShowDialog();				
				}
			}
		}

		public bool setCapabilities(contentManagerService1 cBICMS, ref string resultMessage)
		{
			string secFuncPath = "/capability/securedFunction[@name='Administration']";
			account myAccount = getLogonAccount(cBICMS);
			baseClass[] results = new baseClass[0];
			securedFunction securedFunction = null;
			searchPathMultipleObject cmTargetPath = new searchPathMultipleObject();
			cmTargetPath.Value = secFuncPath;

			results =
					cBICMS.query(
						cmTargetPath,
						new propEnum[] {
							propEnum.searchPath,
							propEnum.policies,
							propEnum.defaultName },
						new sort[] {},
						new queryOptions());
				securedFunction = (securedFunction)results[0];
			
			policy pol;
			int numPolicies = securedFunction.policies.value.GetLength(0);
			policy[] tmpPolicies = new policy[numPolicies + 1];
			policy[] newPolicies;

			int j = 0;
			for (int i = 0; i < numPolicies; i++)
			{
				pol = securedFunction.policies.value[i];
				String polSecPath =
					pol.securityObject.searchPath.value;
				if (0 != polSecPath.CompareTo(myAccount.searchPath.value))
				{
					tmpPolicies[j++] = pol;
				}
			}

			if (j < numPolicies)
			{
				newPolicies = new policy[j];
				for (int i = 0; i < j; i++)
				{
					newPolicies[i] = tmpPolicies[i];
				}
			}
			else
			{
				policy newPolicy = null;
				for (int i = 0; i < myAccount.policies.value.GetLength(0); i++)
				{
					if (-1 != myAccount.policies.value[i].securityObject.ToString().IndexOf("account"))
					{
						newPolicy = myAccount.policies.value[i];
					}
				}
				newPolicies = tmpPolicies;
				newPolicies[j] = newPolicy;
			}

			policyArrayProp policyPropForUpdate = new policyArrayProp();
			policyPropForUpdate.value = newPolicies;

			securedFunction.policies = policyPropForUpdate;
			cBICMS.update(new baseClass[] { securedFunction }, new updateOptions());
			
			resultMessage = "The \"" + securedFunction.defaultName.value + "\" secured function " + 
						    "has been successfully updated.";
			return true;
		}

		public account getLogonAccount(contentManagerService1 cBICMS)
		{
			propEnum[] props =
				new propEnum[] { propEnum.searchPath, propEnum.defaultName, propEnum.policies, propEnum.objectClass };
			account myAccount = new account();

			try
			{

				searchPathMultipleObject cmQueryPath = new searchPathMultipleObject();
				cmQueryPath.Value = "~";
				baseClass[] bc = cBICMS.query(cmQueryPath, props, new sort[] {}, new queryOptions());

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
