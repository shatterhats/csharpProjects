/** 
Licensed Materials - Property of IBM

IBM Cognos Products: DOCS

(C) Copyright IBM Corp. 2005, 2008

US Government Users Restricted Rights - Use, duplication or disclosure restricted by GSA ADP Schedule Contract with
IBM Corp.
*/
// *
// * Cancel.sln
// *
// * Copyright (C) 2008 Cognos ULC, an IBM Company. All rights reserved.
// * Cognos (R) is a trademark of Cognos ULC, (formerly Cognos Incorporated).
// *
// * Description:  Cancels a running report.

using System;
using System.Windows.Forms;
using System.Web.Services.Protocols;
using SamplesCommon;
using cognosdotnet_10_2;

namespace CancelReport
{
	class CancelReport
	{
		public CancelReport(){}

		static void Main(string[] args)
		{
			string cBIUrl = "";
			reportService1 cBIRS = null;
			contentManagerService1 cBICMS = null;
			SamplesConnect connectDlg = new SamplesConnect();
			CancelReportDlg cancelReportDlgObject = new CancelReportDlg();

			if (args.GetLength(0) == 0 )
			{
				// GUI mode
				connectDlg.ShowDialog();
				if (connectDlg.IsConnectedToCBI() == true) 
				{
					cBIRS = connectDlg.CBIRS;
					cBICMS = connectDlg.CBICMS;
					cBIUrl = connectDlg.CBIURL;
					cancelReportDlgObject.setConnection(cBIRS, cBIUrl);
					cancelReportDlgObject.setReportList(BaseClassWrapper.buildReportQueryList(cBICMS));
					cancelReportDlgObject.setSelectedReportIndex(0);
					cancelReportDlgObject.ShowDialog();				
				}
			}
		}

		public string doCancelReport(reportService1 cBIRS, string reportPath, ref string resultMessage)
		{
			if (cBIRS == null)
			{
				return "the Server connection provided is invalid.";
			}
			asynchReply runResponse = null;

			option[] arrReportRunOpts = new option[4];

			asynchOptionInt primaryWait = new asynchOptionInt();   // primary wait threshold
			asynchOptionBoolean includeReq = new asynchOptionBoolean();
			runOptionStringArray formatList = new runOptionStringArray();
			runOptionBoolean blnOutputRunOpts = new runOptionBoolean();
			runOptionBoolean continueConversation = new runOptionBoolean();

			parameterValue[] paramValueArray = new parameterValue[] {};

			// Specify to save the output
			// When Cancel is invoked, the output will not be saved.
			blnOutputRunOpts.name = runOptionEnum.saveOutput;
			blnOutputRunOpts.value = false;

			// execute the report in HTML format
			string[] format = new string[1];
			format[0] = "HTML";
			formatList.name = runOptionEnum.outputFormat;
			formatList.value = format;
			
			continueConversation.name = runOptionEnum.continueConversation;
			continueConversation.value = true;

			// set the primary wait threshold to 1 second, so we can call cancel
			primaryWait.name = asynchOptionEnum.primaryWaitThreshold;
			primaryWait.value = 1;

			// ensure the response always includes the primary request
			includeReq.name = asynchOptionEnum.alwaysIncludePrimaryRequest;
			includeReq.value = true;

			// fill the array with the run options
			arrReportRunOpts[0] = blnOutputRunOpts;
			arrReportRunOpts[1] = formatList;
			arrReportRunOpts[2] = primaryWait;
			arrReportRunOpts[3] = includeReq;

			searchPathSingleObject reportPathSO = new searchPathSingleObject();
			reportPathSO.Value = reportPath;

			// set the continue conversation as a run options
			// execute the report
			// sn_dg_sdk_method_reportService_cancel_start_0
			runResponse = cBIRS.run(reportPathSO, paramValueArray, arrReportRunOpts);
			// sn_dg_sdk_method_reportService_cancel_end_0


            //Check to see if we can cancel
            if (hasSecondaryRequest(runResponse, "cancel"))
            {
                //Use the cancel method to stop execution and saving of report.
                // sn_dg_sdk_method_reportService_cancel_start_1
                cBIRS.cancel(runResponse.primaryRequest);
                // sn_dg_sdk_method_reportService_cancel_end_1

                resultMessage += "The report has been successfully cancelled.";
            }
            else
            {
                resultMessage += "The report ran too quickly to be cancelled.";
            }

			return resultMessage;
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


	}
}
