/** 
Licensed Materials - Property of IBM

IBM Cognos Products: DOCS

(C) Copyright IBM Corp. 2005, 2008

US Government Users Restricted Rights - Use, duplication or disclosure restricted by GSA ADP Schedule Contract with
IBM Corp.
*/
// *
// * CreateDrillThroughTarget.sln
// *
// * Copyright (C) 2008 Cognos ULC, an IBM Company. All rights reserved.
// * Cognos (R) is a trademark of Cognos ULC, (formerly Cognos Incorporated).
// *
// * Description:  Creates a target definition for drill through.
using System;
using System.IO;
using System.Windows.Forms;
using System.Web;
using System.Xml;
using SamplesCommon;
using cognosdotnet_10_2;

namespace CreateDrillThroughTarget
{
    /// <summary>
    /// Summary description for Class1.
    /// </summary>
	class CreateDrillThroughTarget
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		/// 
		public CreateDrillThroughTarget() { }

        [STAThread]
        static void Main(string[] args)
		{
			string cBIUrl = "";
			contentManagerService1 cBICMS = null;
			SamplesConnect connectDlg = new SamplesConnect();
			CreateDrillThroughTargetDlg createDrillThroughTargetDlgObject = new CreateDrillThroughTargetDlg();

			if (args.GetLength(0) == 0)
			{
				// GUI mode
				connectDlg.ShowDialog();
				if (connectDlg.IsConnectedToCBI() == true)
				{
					cBICMS = connectDlg.CBICMS;
					cBIUrl = connectDlg.CBIURL;
					createDrillThroughTargetDlgObject.setConnection(connectDlg, cBIUrl);
					createDrillThroughTargetDlgObject.setPackageList(BaseClassWrapper.getPackageNameList(cBICMS));
					createDrillThroughTargetDlgObject.ShowDialog();
				}
			}
		}

		public string createDrillThrough(SamplesConnect cBIConnection, BaseClassWrapper report, string packageName)
		{
			if (cBIConnection == null)
			{
				return null;
			}

			baseParameter[] reportPrompts = getPrompts(cBIConnection, report);
			drillPath drillThroughDef = new drillPath();

			//Get a name from the user and set it
			SamplesInput getDrillThroughName = new SamplesInput();
			string dtName = getDrillThroughName.getInput("Drill Through Name", "Enter a name for the Drill Through Definition", "IBM Cognos Software Development Kit Drill Through Sample");
			drillThroughDef = setDrillThroughName(dtName, drillThroughDef);

			// set a description
			drillThroughDef = setDrillThroughDescription(drillThroughDef);

			// set drill through contact to the current user
			account myAccount = SamplesConnect.getLogonAccount(cBIConnection);
			drillThroughDef = setDrillThroughContact(myAccount, drillThroughDef);

			// set the drill through action
			drillThroughDef = setDrillThroughAction(drillThroughDef);

			// set the drill through target
			drillThroughDef = setDrillThroughTarget(report, drillThroughDef);

			// set the drill through parameter values
			drillThroughDef = setDrillThroughParameters(cBIConnection, report, drillThroughDef);

			return addDrillThroughDefinition(cBIConnection, drillThroughDef, packageName);

		}

		public BaseClassWrapper[] getPromptedReports(SamplesConnect cBIConnection, String packageName)
		{
			baseClass[] reports = new baseClass[0];

			propEnum[] props =
				new propEnum[] { propEnum.searchPath, propEnum.defaultName, propEnum.objectClass, propEnum.parent };
			sort[] sortOptions = { new sort() };
			sortOptions[0].order = orderEnum.ascending;
			sortOptions[0].propName = propEnum.defaultName;

			searchPathMultipleObject reportsPath = new searchPathMultipleObject();
            reportsPath.Value = "/content/folder[@name='Samples']/folder[@name='Models']/package[@name='" + packageName + "']//report";

			reports =
				cBIConnection.CBICMS.query(
				reportsPath,
				props,
				sortOptions,
				new queryOptions());

			BaseClassWrapper[] reportList = new BaseClassWrapper[reports.GetLength(0)];

			int nbReports = 0;
			int count = 0;
			if ((reports != null) && (reports.GetLength(0) > 0))
			{
				nbReports = reports.GetLength(0);

				for (int i = 0; i < nbReports; i++)
				{
					BaseClassWrapper report = new BaseClassWrapper(reports[i]);
					if (hasPrompts(cBIConnection, report))
					{
						reportList[count++] = report;
					}
				}
			}

			BaseClassWrapper[] promptedReportList = new BaseClassWrapper[count];
			for (int i = 0; i < count; i++)
				promptedReportList[i] = reportList[i];

			return promptedReportList;
		}

		public bool hasPrompts(SamplesConnect cBIConnection, BaseClassWrapper report)
		{
			searchPathSingleObject reportPath = new searchPathSingleObject();
			reportPath.Value = report.searchPath.value;

            asynchReply getParamsReply = cBIConnection.CBIRS.getParameters(reportPath, new parameterValue[] { }, new option[] { });

            if (!getParamsReply.status.Equals(asynchReplyStatusEnum.conversationComplete))
            {
                while (!getParamsReply.status.Equals(asynchReplyStatusEnum.conversationComplete))
                {
                    getParamsReply = cBIConnection.CBIRS.wait(
                        getParamsReply.primaryRequest,
                        new parameterValue[] { },
                        new option[] { });
                }

            }

            for (int i = 0; i < getParamsReply.details.Length; i++)
            {
                if (getParamsReply.details[i] is asynchDetailParameters)
                {
                    return (((asynchDetailParameters)getParamsReply.details[i]).parameters.Length > 0);
                }
            }

			return false;
		}

		public baseParameter[] getPrompts(SamplesConnect cBIConnection, BaseClassWrapper report)
		{
			searchPathSingleObject reportPath = new searchPathSingleObject();
			reportPath.Value = report.searchPath.value;

            asynchReply getParamsReply = cBIConnection.CBIRS.getParameters(reportPath, new parameterValue[] { }, new option[] { });

            if (!getParamsReply.status.Equals(asynchReplyStatusEnum.conversationComplete))
            {
                while (!getParamsReply.status.Equals(asynchReplyStatusEnum.conversationComplete))
                {
                    getParamsReply = cBIConnection.CBIRS.wait(
                        getParamsReply.primaryRequest,
                        new parameterValue[] { },
                        new option[] { });
                }

            }

            for (int i = 0; i < getParamsReply.details.Length; i++)
            {
                if (getParamsReply.details[i] is asynchDetailParameters)
                {
                    return ((asynchDetailParameters)getParamsReply.details[i]).parameters;
                }
            }

			return null;
		}

		public BaseClassWrapper getPackage(SamplesConnect cBIConnection, string packageName)
		{
			searchPathMultipleObject packagesPath = new searchPathMultipleObject();
			packagesPath.Value = "/content//package[@name='" + packageName + "']";

			baseClass[] bc = cBIConnection.CBICMS.query(packagesPath, new propEnum[] {}, new sort[] {}, new queryOptions());

			string[] packageNames = new string[bc.GetLength(0)];
			if (bc.Length == 1)
			{
				return new BaseClassWrapper(bc[0]);
			}

			return null;
		}

		public bool hasSecondaryRequest(asynchReply response, string secondaryRequest)
		{
			asynchSecondaryRequest[] secondaryRequests =
				response.secondaryRequests;
			for (int i = 0; i < secondaryRequests.Length; i++)
			{
				if (secondaryRequests[i].name.CompareTo(secondaryRequest)
					== 0)
				{
					return true;
				}
			}
			return false;
		}

		// set a name
		public drillPath setDrillThroughName(string dtName, drillPath drillThroughDef)
		{
			tokenProp myDrillName = new tokenProp();
			myDrillName.value = dtName;
			drillThroughDef.defaultName = myDrillName;
			return drillThroughDef;
		}

		// set a description
		public drillPath setDrillThroughDescription(drillPath drillThroughDef)
		{
			stringProp myDrillDesc = new stringProp();
			myDrillDesc.value = "This is an example of how to create a Drill-through definition using the SDK.";
			drillThroughDef.defaultDescription = myDrillDesc;
			return drillThroughDef;
		}

		// set a contact
		public drillPath setDrillThroughContact(account myAccount, drillPath drillThroughDef)
		{
			baseClass[] contactData = new baseClass[] {myAccount};
			baseClassArrayProp contact = new baseClassArrayProp();
			contact.value = contactData;
			drillThroughDef.contact = contact;
			return drillThroughDef;
		}

		// set an action
		public drillPath setDrillThroughAction(drillPath drillThroughDef)
		{
			baseReportActionEnumProp drillAction = new baseReportActionEnumProp();
			drillAction.value = baseReportActionEnum.run;
			drillThroughDef.action = drillAction;
			return drillThroughDef;
		}

		// set a target
		public drillPath setDrillThroughTarget(BaseClassWrapper targetReport, drillPath drillThroughDef)
		{
			baseClassArrayProp targetProp = new baseClassArrayProp();
			baseClass[] targets = new baseClass[] {targetReport.baseclassobject};
			targetProp.value = targets;
			drillThroughDef.target = targetProp;
			return drillThroughDef;
		}

		// set parameters
		public drillPath setDrillThroughParameters(SamplesConnect cBIConnection, BaseClassWrapper report, drillPath drillThroughDef)
		{
			//get the parameters for the target report
			baseParameter[] parameters = getPrompts(cBIConnection, report);

			baseParameterAssignment[] paramAssignments = new baseParameterAssignment[parameters.Length];

			//loop through and set parameter info
			parameterAssignmentDataItem paramAssignmentItem;
			metadataModelItemName paramDataItemName;
			for (int i = 0; i < parameters.Length; i++) 
			{
				paramAssignmentItem = new parameterAssignmentDataItem();

				string parameterName = ( (parameter) parameters[i]).name;
				paramAssignmentItem.parameterName = parameterName;

				paramDataItemName = new metadataModelItemName();
				string itemNameStr = ( (parameter) parameters[i]).modelFilterItem;
				paramDataItemName.Value = itemNameStr;
				paramAssignmentItem.dataItemName = paramDataItemName;
				
				paramAssignments[i] = paramAssignmentItem;
			}

			//add the parameter info to the drillThroughDef
			baseParameterAssignmentArrayProp parameterAssignmentsProp = new baseParameterAssignmentArrayProp();
			parameterAssignmentsProp.value = paramAssignments;
			drillThroughDef.parameterAssignments = parameterAssignmentsProp;

			return drillThroughDef;
		}
	

		public string addDrillThroughDefinition(SamplesConnect cBIConnection, drillPath drillThroughDef, string packageName)
		{

			string addResult;
			searchPathSingleObject parentPath = new searchPathSingleObject();

			baseClass[] bcDrill = new baseClass[1];
			bcDrill[0] = drillThroughDef;

			addOptions addOpts = new addOptions();
			addOpts.updateAction = updateActionEnum.replace;

			string packagePathStr = getPackage(cBIConnection, packageName).baseclassobject.searchPath.value;
			if (packagePathStr != null) 
			{
				parentPath.Value = packagePathStr;
			}

			baseClass[] drillResult = cBIConnection.CBICMS.add(parentPath, bcDrill, addOpts);
			drillPath response = (drillPath) drillResult[0];
			addResult = "Added Drill Through Definition with search path: " + response.searchPath.value;

			return addResult;
		}
	}
}
