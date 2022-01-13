/** 
Licensed Materials - Property of IBM

IBM Cognos Products: DOCS

(C) Copyright IBM Corp. 2005, 2007

US Government Users Restricted Rights - Use, duplication or disclosure restricted by GSA ADP Schedule Contract with
IBM Corp.
*/
// *
// * ExecuteReport.sln
// *
// * Copyright (C) 2007 Cognos ULC, an IBM Company. All rights reserved.
// * Cognos (R) is a trademark of Cognos ULC, (formerly Cognos Incorporated).
// *
// * Description:  Executes a report.
using System;
using System.IO;
using System.Windows.Forms;
using System.Web.Services.Protocols;
using SamplesCommon;
using cognosdotnet_10_2;

namespace ExecuteReport
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	class ExecuteReport
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		/// 
		public ExecuteReport(){}

        [STAThread]
        static void Main(string[] args)
		{
			string cBIUrl = "";
			contentManagerService1 cBICMS = null;
			SamplesConnect connectDlg = new SamplesConnect();
			ExecuteReportDlg executeReportDlgObject = new ExecuteReportDlg();
			
			if (args.GetLength(0) == 0 )
			{
				// GUI mode
				connectDlg.ShowDialog();
				if (connectDlg.IsConnectedToCBI() == true) 
				{
					cBICMS = connectDlg.CBICMS;
					cBIUrl = connectDlg.CBIURL;
					executeReportDlgObject.setConnection(connectDlg, cBIUrl);
					executeReportDlgObject.setReportList(BaseClassWrapper.buildReportQueryList(cBICMS));
					executeReportDlgObject.setSelectedReportIndex(0);
					executeReportDlgObject.ShowDialog();				
				}
			}
		}

		public string doExecuteReport(SamplesConnect cBIConnection, string reportPath)
		{
			if (cBIConnection == null)
			{
				return null;
			}
			string html = "";

			string ERR_MESG = "run() failed to return a valid report in this format";

			cognosdotnet_10_2.asynchReply executeReportResponse = null;
			option[] arrRunOpts = new option[4];
			// sn_dg_prm_smpl_runreport_P1_start_0
			parameterValue[] arrParm = new parameterValue[] {};
			// sn_dg_prm_smpl_runreport_P1_end_0
			// sn_dg_prm_smpl_runreport_P3_start_0
			runOptionBoolean blnPromptOption = new runOptionBoolean();
			runOptionStringArray outputFormat = new runOptionStringArray();
			asynchOptionInt primaryWait = new asynchOptionInt();   // primary wait threshold
			string[] strarrFmt = new string[1];
			runOptionBoolean blnSaveOption = new runOptionBoolean();
			
			// Specify do not save the output
			blnSaveOption.name = runOptionEnum.saveOutput;
			blnSaveOption.value = false;

			// execute the report in HTML format
			strarrFmt[0] = "HTML";
			outputFormat.name = runOptionEnum.outputFormat;
			outputFormat.value = strarrFmt;

			// Specify do not prompt for parameters (being passed)
			blnPromptOption.name = runOptionEnum.prompt;
			blnPromptOption.value = false;

			// set the primary wait threshold to 0 seconds - wait indefinitely
			primaryWait.name = asynchOptionEnum.primaryWaitThreshold;
			primaryWait.value = 0;

			// fill the array with the run options
			arrRunOpts[0] = blnPromptOption;
			arrRunOpts[1] = outputFormat;
			arrRunOpts[2] = primaryWait;
			arrRunOpts[3] = blnSaveOption;
			// sn_dg_prm_smpl_runreport_P3_end_0

			searchPathSingleObject cmReportPath = new searchPathSingleObject();
			cmReportPath.Value = reportPath;

			// execute the report
			// sn_dg_sdk_method_reportService_getOutput_start_0
			// sn_dg_sdk_method_reportService_run_start_0
			// sn_dg_prm_smpl_runreport_P4_start_0
			executeReportResponse = cBIConnection.CBIRS.run(cmReportPath, arrParm, arrRunOpts);
			// sn_dg_sdk_method_reportService_run_end_0
			// If response is not immediately complete, call wait until complete
			if (!executeReportResponse.status.Equals(asynchReplyStatusEnum.complete))
			{
				// sn_dg_sdk_method_reportService_getOutput_end_0
				while (!executeReportResponse.status.Equals(asynchReplyStatusEnum.complete))
				{
					//before calling wait, double check that it is okay
					if (!hasSecondaryRequest(executeReportResponse, "wait"))
					{
						return ERR_MESG;
					}
					executeReportResponse =
						cBIConnection.CBIRS.wait(
						executeReportResponse.primaryRequest,
						new parameterValue[] {},
						new option[] {});
				}

				//After calling wait() it is necessary to check to make sure 
				//the output is ready before retrieving it
				// sn_dg_sdk_method_reportService_getOutput_start_1
				if (outputIsReady(executeReportResponse))
				{
					executeReportResponse =
						cBIConnection.CBIRS.getOutput(
						executeReportResponse.primaryRequest,
						new parameterValue[] {},
						new option[] {});
				}
				// sn_dg_sdk_method_reportService_getOutput_end_1
				// sn_dg_prm_smpl_runreport_P4_end_0
				else
				{
					return ERR_MESG;
				}
			}

			html = getOutputPage(executeReportResponse);

			baseClass[] bcOutput;

			searchPathMultipleObject outputPath = new searchPathMultipleObject();
			outputPath.Value = "~~/output";

			bcOutput = cBIConnection.CBICMS.query(outputPath, new propEnum[] { propEnum.searchPath }, new sort[] {}, new queryOptions());
			
			if ((bcOutput != null) && (bcOutput.GetLength(0)> 0) )
			{
				CommonFunctions cf = new CommonFunctions();
				html = cf.setupGraphics(cBIConnection.CBICMS, html);
			}

			return html;
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

		public bool outputIsReady(asynchReply response)
		{
			for (int i = 0; i < response.details.Length; i++)
			{
				if ((response.details[i] is asynchDetailReportStatus)
                    && (((asynchDetailReportStatus)response.details[i]).status == asynchDetailReportStatusEnum.responseReady)
					&& (hasSecondaryRequest(response, "getOutput")))
				{
					return true;
				}
			}
			return false;
		}

		public string getOutputPage(asynchReply executeReportResponse)
		{
			// sn_dg_sdk_method_reportService_getOutput_start_2
			asynchDetailReportOutput reportOutput = null;
			for (int i = 0; i < executeReportResponse.details.Length; i++)
			{
				if (executeReportResponse.details[i] is asynchDetailReportOutput)
				{
					reportOutput =
						(asynchDetailReportOutput)executeReportResponse.details[i];
					break;
				}
			}
			// sn_dg_sdk_method_reportService_getOutput_end_2

			//text based output is split into pages -- return the current page
			return reportOutput.outputPages[0].ToString();
		}
	}
}
