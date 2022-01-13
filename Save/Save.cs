/** 
Licensed Materials - Property of IBM

IBM Cognos Products: DOCS

(C) Copyright IBM Corp. 2005, 2008

US Government Users Restricted Rights - Use, duplication or disclosure restricted by GSA ADP Schedule Contract with
IBM Corp.
*/
// *
// * Save.sln
// *
// * Copyright (C) 2008 Cognos ULC, an IBM Company. All rights reserved.
// * Cognos (R) is a trademark of Cognos ULC, (formerly Cognos Incorporated).
// *
// * Description:  Saves a report.
using System;
using System.Windows.Forms;
using System.Web.Services.Protocols;
using SamplesCommon;
using cognosdotnet_10_2;

namespace Save
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	class Save
	{
		public Save(){}

		static void Main(string[] args)
		{
			string cBIUrl = "";
			contentManagerService1 cBICMS = null;
			SamplesConnect connectDlg = new SamplesConnect();
			SaveDlg SaveDlgObject = new SaveDlg();

			if (args.GetLength(0) == 0 )
			{
				// GUI mode
				connectDlg.ShowDialog();
				if (connectDlg.IsConnectedToCBI() == true) 
				{
					cBICMS = connectDlg.CBICMS;
					cBIUrl = connectDlg.CBIURL;
					SaveDlgObject.setConnection(connectDlg, cBIUrl);
					SaveDlgObject.setReportList(BaseClassWrapper.buildReportQueryList(cBICMS));
					SaveDlgObject.setSelectedReportIndex(0);
					SaveDlgObject.ShowDialog();				
				}
			}
		}

		/** 
			* runOption will execute a query/report and save either the report 
			* or the report output back in the content store, as specified by the
			* saveAs parameter.
			*
			* This method executes a report and saves the output
			* or the report spec, as indicated by the saveAs flag
			*/
		public bool runOption(SamplesConnect connection, 
			string reportPath, 
			bool saveAs, 
			string newReportName,
			ref string resultMessage)
		{
			if (connection == null)
			{
				resultMessage = "The connection provided is invalid.";
				return false;
			}
			
			runOption[] executerunOptions = new runOption[4];
			runOption[] saveAsrunOptions = new runOption[2];

			runOptionBoolean roSaveOutput = new runOptionBoolean();
			runOptionStringArray roOutputFormat = new runOptionStringArray();
			runOptionBoolean roPrompt = new runOptionBoolean();
			runOptionBoolean roContinueConv = new runOptionBoolean();
			asynchReply rsr = null;
			string[] reportFormat = null;

			// We may want to save this output, but not by using
			// runOptions. That would be for another sample.
			roSaveOutput.name = runOptionEnum.saveOutput;
			roSaveOutput.value = false;

			//What format do we want the report in? HTML.
			reportFormat = new string[] { "HTML" };
			roOutputFormat.name = runOptionEnum.outputFormat;
			roOutputFormat.value = reportFormat;

			//Set the report not to prompt as we pass the parameter if any
			roPrompt.name = runOptionEnum.prompt;
			roPrompt.value = false;

			//Remember to set continueConversation to true, so we can invoke
			//secondary requests     
			roContinueConv.name = runOptionEnum.continueConversation;
			roContinueConv.value = true;

			// Fill the array with the run options.
			executerunOptions[0] = roSaveOutput;
			executerunOptions[1] = roOutputFormat;
			executerunOptions[2] = roPrompt;
			executerunOptions[3] = roContinueConv;

			parameterValue[] reportParameters = new parameterValue[0];

			searchPathSingleObject cmReportPath = new searchPathSingleObject();
			cmReportPath.Value = reportPath;

			rsr = connection.CBIRS.run(cmReportPath, reportParameters, executerunOptions);

			if (rsr == null)
			{
				resultMessage = "...executing the report failed.";
				return false;
			}
			if (saveAs)
			{
				int position = reportPath.IndexOf("/report");
				string packagePath = reportPath.Substring(0, position);
				
				multilingualToken[] nameTokens = new multilingualToken[2];
				nameTokens[0] = new multilingualToken();
				nameTokens[0].locale = "en-us";
				nameTokens[0].value = newReportName;

				runOptionSaveAs roSaveAs = new runOptionSaveAs();
				roSaveAs.name = runOptionEnum.saveAs;
				roSaveAs.objectClass = reportSaveAsEnum.reportView;
				roSaveAs.objectName = nameTokens;
				roSaveAs.parentSearchPath = packagePath;

				saveAsrunOptions[0] = roSaveAs;
				runOptionBoolean  roContinueConv2 = new runOptionBoolean();
				roContinueConv2.name = runOptionEnum.continueConversation;
				roContinueConv2.value = true;
				saveAsrunOptions[1] = roContinueConv2;

				rsr = connection.CBIRS.deliver(rsr.primaryRequest,new parameterValue[] {}, saveAsrunOptions);

				// If it has not yet completed, keep waiting until it is done.
				if (rsr.status != asynchReplyStatusEnum.complete)
				{
					while (rsr.status != asynchReplyStatusEnum.complete)
					{
						rsr = connection.CBIRS.wait(rsr.primaryRequest, new parameterValue[] {},new option[] {});
					}
					rsr = connection.CBIRS.getOutput(rsr.primaryRequest,new parameterValue[] {}, new option[] {});
				}	
				resultMessage = "...the 'save as' request completed successfuly.";
			}
			else
			{
				option[] saverunOptions = new option[2];
				runOptionBoolean bSaveOutput = new runOptionBoolean();
				bSaveOutput.name = runOptionEnum.saveOutput;
				bSaveOutput.value = true;
				saverunOptions[0] = bSaveOutput;
				runOptionBoolean  roContinueConv2 = new runOptionBoolean();
				roContinueConv2.name = runOptionEnum.continueConversation;
				roContinueConv2.value = true;
				saverunOptions[1] = roContinueConv2;

				rsr = connection.CBIRS.deliver(rsr.primaryRequest, new parameterValue[] {}, saverunOptions);

				// If it has not yet completed, keep waiting until it is done.
				if (rsr.status != asynchReplyStatusEnum.complete)
				{
					while (rsr.status != asynchReplyStatusEnum.complete)
					{
						rsr = connection.CBIRS.wait(rsr.primaryRequest,new parameterValue[] {}, new option[] {});
					}
					rsr = connection.CBIRS.getOutput(rsr.primaryRequest, new parameterValue[] {}, new option[] {});
				}
				resultMessage = "...the 'save' request completed successfuly.";
			}
			return true;
		}
	}
}
