/** 
Licensed Materials - Property of IBM

IBM Cognos Products: DOCS

(C) Copyright IBM Corp. 2005, 2008

US Government Users Restricted Rights - Use, duplication or disclosure restricted by GSA ADP Schedule Contract with
IBM Corp.
*/
// *
// * Copy.sln
// *
// * Copyright (C) 2008 Cognos ULC, an IBM Company. All rights reserved.
// * Cognos (R) is a trademark of Cognos ULC, (formerly Cognos Incorporated).
// *
// * Description:  Copies a report to another location.

using System;
using SamplesCommon;
using cognosdotnet_10_2;

namespace Copy
{
	/// <summary>
	/// Summary description for Copy.
	/// </summary>
	class Copy
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		/// 
		public Copy(){}
		
		static void Main(string[] args)
		{
			string cBIUrl = "";
			contentManagerService1 cBICMS = null;
			CopyDlg copyDlgObject = new CopyDlg();
			SamplesConnect connectDlg = new SamplesConnect();
				
			if (args.GetLength(0) == 0 )
			{
				// GUI mode
				connectDlg.ShowDialog();
				if (connectDlg.IsConnectedToCBI() == true) 
				{
					cBICMS = connectDlg.CBICMS;
					cBIUrl = connectDlg.CBIURL;
					copyDlgObject.setConnection(cBICMS, cBIUrl);
					copyDlgObject.setReportList(BaseClassWrapper.buildReportQueryList(cBICMS));
					copyDlgObject.setSelectedReportIndex(0);
					copyDlgObject.ShowDialog();				
				}
			}
		}

		public bool doCopy(contentManagerService1 cBICMS, string reportPath, string targetPath, ref string resultMessage)
		{
			if (cBICMS == null)
			{
				resultMessage = "...the Server connection is invalid.\n";
				return false;
			}
			report rReport = new report();
			
			stringProp reportToCopy = new stringProp();
			reportToCopy.value = reportPath;
			rReport.searchPath = reportToCopy;
			baseClass[] bcaCopy = {rReport};
			copyOptions cpOptions = new copyOptions();

			searchPathSingleObject targetPathSO = new searchPathSingleObject();
			targetPathSO.Value = targetPath;

			// sn_dg_sdk_method_contentManagerService_copy_start_0
			baseClass[] bcaCopyResults = cBICMS.copy(bcaCopy, targetPathSO, cpOptions);

			if (bcaCopyResults.GetLength(0) > 0)
			{
				//returns the number of successfully copied baseClass objects
				resultMessage = "...the report has been successfully copied to : " + targetPath + ".\n";
				return true;
			}
				// sn_dg_sdk_method_contentManagerService_copy_end_0
			else
			{
				resultMessage = "...copying the report to : \"" + targetPath + "\" failed.\n";
				return false;
			}
		}
	}
}
