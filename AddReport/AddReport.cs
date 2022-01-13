/** 
Licensed Materials - Property of IBM

IBM Cognos Products: DOCS

(C) Copyright IBM Corp. 2005, 2008

US Government Users Restricted Rights - Use, duplication or disclosure restricted by GSA ADP Schedule Contract with
IBM Corp.
*/
/**
 * AddReport.sln
 *
 * Copyright (C) 2008 Cognos ULC, an IBM Company. All rights reserved.
 * Cognos (R) is a trademark of Cognos ULC, (formerly Cognos Incorporated).
 *
 * Description: This code sample demonstrates how to add reports using the 
 *              following methods:
 *              - validate(search, object, options)
 *                Use this method to validate reports in the content store.
 *              - add(search, object, options)
 *                Use this method to add reports to the content store.
 *
 */

using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Web.Services.Protocols;
using SamplesCommon;
using cognosdotnet_10_2;
using System.Xml;

namespace AddReport
{
	/// <summary>
	/// Summary description for AddReport.
	/// </summary>
	public class AddReport
	{
		public AddReport(){}

        [STAThread]		
		static void Main(string[] args)
		{		
			string cBIUrl = "";
            string accountPath = "";
			reportService1 cBIServer = null;			
			AddReportDlg ardlgObject = new AddReportDlg();
			SamplesConnect connectDlg = new SamplesConnect();
			
			if (args.GetLength(0) == 0 )
			{
				// GUI mode
				connectDlg.ShowDialog();
				if (connectDlg.IsConnectedToCBI() == true) 
				{
					cBIServer = connectDlg.CBIRS;
					cBIUrl = connectDlg.CBIURL;
                    accountPath = connectDlg.GetAccountPath();
					
					ardlgObject.setConnection(cBIServer, cBIUrl, accountPath);
					ardlgObject.CBISS = connectDlg.CBISS;
					ardlgObject.ShowDialog();
				}
			}
		}

        public bool validateReportSpec(reportService1 cBIRS, reportServiceReportSpecification reportSpec, ref string resultMessage)
		{	
			asynchReply validationResults = null;
			if (cBIRS == null)
			{
				resultMessage = "...the Server connection is invalid.\n";
				return false;
			}

			option[] validateOptions = new option[2];

			asynchOptionInt primaryWaitThreshold = new asynchOptionInt();
			primaryWaitThreshold.name = asynchOptionEnum.primaryWaitThreshold;
			primaryWaitThreshold.value = 0;
			validateOptions[0] = primaryWaitThreshold;

			asynchOptionInt secondaryWaitThreshold = new asynchOptionInt();
			secondaryWaitThreshold.name = asynchOptionEnum.secondaryWaitThreshold;
			secondaryWaitThreshold.value = 0;
			validateOptions[1] = secondaryWaitThreshold;

			// sn_dg_sdk_method_reportService_validateSpecification_start_0
			validationResults = cBIRS.validateSpecification(reportSpec, new parameterValue[]{}, validateOptions);
			// sn_dg_sdk_method_reportService_validateSpecification_end_0
			if (validationResults == null)
			{
				resultMessage = "...unknown error validating the report.";
				return false;
			}

			bool status = true;
			string errresult = "";
			string defects = "";
			// sn_dg_sdk_method_reportService_validateSpecification_start_1
			for (int i = 0; i < validationResults.details.Length; i++)
			{
				if (validationResults.details[i] is asynchDetailReportValidation)
				{
					if ( ( (asynchDetailReportValidation) validationResults.details[i]).defects.Value.Length > 0 )
					{
						defects = ( (asynchDetailReportValidation) validationResults.details[i]).defects.Value;
					}
				}

			}

			//Parse the defects xml string to see what type of errors, if any
			// sn_dg_sdk_method_reportService_validateSpecification_end_1
			XmlDocument vrDocument = new XmlDocument();
			vrDocument.LoadXml(defects);
			XmlElement root = vrDocument.DocumentElement;
			XmlNodeList queryProblems = root.SelectNodes("//queryProblems");
			XmlNodeList layoutProblems = root.SelectNodes("//layoutProblems");

			for (int i=0; i<queryProblems.Count; i++)
			{
				XmlNode queryProblemsNode = queryProblems.Item(i);
				if (queryProblemsNode.HasChildNodes)
				{
					errresult += "\nThe following queryProblems were found:\n";
					XmlNodeList messageNodes = queryProblemsNode.SelectNodes("//message[@type='xmlStructure']/@title");
					for (int j=0; j<messageNodes.Count; j++)
					{
						XmlNode messageNode = messageNodes.Item(j);
						if (messageNode != null)
						{
							errresult += "\t" + messageNode.Value + "\n";
							status = false;
						}
					}
				}
			}
			for (int i=0; i<layoutProblems.Count; i++)
			{
				XmlNode layoutProblemsNode = layoutProblems.Item(i);
				if (layoutProblemsNode.HasChildNodes)
				{
					errresult += "\nThe following layoutProblems were found:\n";
					XmlNodeList messageNodes = layoutProblemsNode.SelectNodes("//message[@type='layout']/@title");
					for (int j=0; j<messageNodes.Count; j++)
					{
						XmlNode messageNode = messageNodes.Item(j);
						if (messageNode != null)
						{
							errresult += "\t" + messageNode.Value + "\n";
							status = false;
						}
					}
				}
			}
			if (!status)
			{
				resultMessage = errresult;
				return false;
			}
			resultMessage += "\n...validation succeeded.";
			return true;
		}

		public bool addReportSpec(systemService1 cBISS,
			reportService1 cBIRS,
            reportServiceReportSpecification reportSpec, 
			string inputReportName,
            string accountPath,
			ref string resultMessage)
		{
			string newReportName = "My Sample Report";
            string searchPath = "";

            if (accountPath.Length > 0)
            {
                searchPath = accountPath + "/folder[@name='My Folders']";
            }
            else
            {
                searchPath = "CAMID(\"::Anonymous\")/folder[@name='My Folders']";
            }
 
			
			if (cBIRS == null)
			{
				resultMessage = "...the Server connection is invalid.\n...the specification was not added.";
				return false;
			}

			if (!validateReportSpec(cBIRS, reportSpec, ref resultMessage))
			{
				resultMessage += "\n...the specification was not added.";
				return false;
			}
			report newReport = new report();
	
			anyTypeProp reportSpecProperty = new anyTypeProp();
			reportSpecProperty.value = reportSpec.value.Value.ToString();
 	
			multilingualToken[] reportNames = new multilingualToken[1];
			reportNames[0] = new multilingualToken();
			if (0 != inputReportName.CompareTo(""))
			{
				newReportName = inputReportName;
			}
			reportNames[0].value = newReportName;
			newReport.name = new multilingualTokenProp();
			newReport.name.value = reportNames;

			configurationData data = null;
			locale[] locales = null;
			configurationDataEnum[] config = new configurationDataEnum[1];
			config[0] = configurationDataEnum.serverLocale;

			// sn_dg_sdk_method_systemService_getConfiguration_start_0
			data = cBISS.getConfiguration(config);
			locales = data.serverLocale;

			if (locales == null)
			{
				locales[0] = new locale();
				locales[0].locale1 = "en";
			}
			// sn_dg_sdk_method_systemService_getConfiguration_end_0

			reportNames[0].locale = locales[0].locale1;

			newReport.specification = reportSpecProperty;
			
			addOptions addReportOptions = new addOptions();
			addReportOptions.updateAction = updateActionEnum.replace;
			
			searchPathSingleObject searchPathSO = new searchPathSingleObject();
			searchPathSO.Value = searchPath;

			// sn_dg_sdk_method_reportService_add_start_0
			cBIRS.add(searchPathSO, newReport, addReportOptions);
			// sn_dg_sdk_method_reportService_add_end_0

			resultMessage = "\n...the report \"" + newReport + "\" has been added successfully to \"" + searchPath + "\".";
			return true;
		}


	}
}
