/** 
Licensed Materials - Property of IBM

IBM Cognos Products: DOCS

(C) Copyright IBM Corp. 2005, 2007

US Government Users Restricted Rights - Use, duplication or disclosure restricted by GSA ADP Schedule Contract with
IBM Corp.
*/
// *
// * Move.sln
// *
// * Copyright (C) 2007 Cognos ULC, an IBM Company. All rights reserved.
// * Cognos (R) is a trademark of Cognos ULC, (formerly Cognos Incorporated).
// *
// * Description:  Moves a report to another location.

using System;
using System.Web.Services.Protocols;
using SamplesCommon;
using cognosdotnet_10_2;

namespace Move
{
	/// <summary>
	/// Summary description for Move.
	/// </summary>
	class Move
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		/// 
		public Move(){}
		
		static void Main(string[] args)
		{
			string cBIUrl = "";
			MoveDlg moveDlgObject = new MoveDlg();
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
					moveDlgObject.setConnection(cmService, cBIUrl);
					moveDlgObject.setReportList(BaseClassWrapper.buildReportQueryList(cmService));
					moveDlgObject.setSelectedReportIndex(0);
					moveDlgObject.ShowDialog();				
				}
			}
		}

		public bool doMove(contentManagerService1 cBICMS, string reportPath, string targetPath, ref string resultMessage)
		{
			if (cBICMS == null)
			{
				resultMessage = "...the connection is invalid.\n";
			}
			report rReport = new report();
			
			stringProp reportToMove = new stringProp();
			reportToMove.value = reportPath;
			rReport.searchPath = reportToMove;
			baseClass[] bcaMove = {rReport};
			moveOptions cpOptions = new moveOptions();

			searchPathSingleObject cmTargetPath = new searchPathSingleObject();
			cmTargetPath.Value = targetPath;

			// sn_dg_sdk_method_contentManagerService_move_start_0
			baseClass[] bcaMoveResults = cBICMS.move(bcaMove, cmTargetPath, cpOptions);
			
			if (bcaMoveResults.GetLength(0) > 0)
			{
				//the number of successfully copied objects
				resultMessage = "...the report has been successfully moved to the target location \"" + targetPath + "\".";
				return true;
			}
			// sn_dg_sdk_method_contentManagerService_move_end_0
			else
			{
				resultMessage = "...moving the report to the target location : \"" + targetPath + "\" failed.";
				return false;
			}
		}

	}
}
