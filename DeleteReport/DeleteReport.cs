/** 
Licensed Materials - Property of IBM

IBM Cognos Products: DOCS

(C) Copyright IBM Corp. 2005, 2008

US Government Users Restricted Rights - Use, duplication or disclosure restricted by GSA ADP Schedule Contract with
IBM Corp.
*/
// *
// * deleteReport.sln
// *
// * Copyright (C) 2008 Cognos ULC, an IBM Company. All rights reserved.
// * Cognos (R) is a trademark of Cognos ULC, (formerly Cognos Incorporated).
// *
// * Description: This code sample demonstrates how to delete reports using the
// *              following methods:
// *              - query
// *                Use this method to request objects from Content Manager.
// *              - delete
// *                Use this method to delete objects from the content store.
// *

using System;
using System.Windows.Forms;
using System.Web.Services.Protocols;
using SamplesCommon;
using cognosdotnet_10_2;

namespace DeleteReport
{
	/// <summary>
	/// Summary description for DeleteReport.
	/// </summary>
	class DeleteReport
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		/// 
		public DeleteReport(){}

		static void Main(string[] args)
		{
			string cBIUrl = "";
			contentManagerService1 cmService = null;
			SamplesConnect connectDlg = new SamplesConnect();
			DeleteReportDlg deleteReportDlgObject = new DeleteReportDlg();
			
			if (args.GetLength(0) == 0 )
			{
				// GUI mode
				connectDlg.ShowDialog();
				if (connectDlg.IsConnectedToCBI() == true) 
				{
					cmService = connectDlg.CBICMS;
					cBIUrl = connectDlg.CBIURL;
					deleteReportDlgObject.setConnection(cmService, cBIUrl);
					BaseClassWrapper[] objectList = BaseClassWrapper.buildReportQueryList(cmService);
					deleteReportDlgObject.setReportList(objectList);
					deleteReportDlgObject.setSelectedReportIndex(0);
					deleteReportDlgObject.ShowDialog();				
				}
			}
		}


		public bool doDeleteReport(contentManagerService1 cBICMS, BaseClassWrapper report, ref string resultMessage)
		{
			// Set up the delete() method options.
			//
			// Set the force option to true.  When the force option is 
			// true, a selected object will be deleted if the current user
			// has either write or setPolicy permission for the following
			// objects in the Content Store:
			// - the selected object
			// - the parent of the selected object
			// - every descendant of the selected object

			// sn_dg_prm_smpl_deletereport_start_0
			deleteOptions del = new deleteOptions();
			del.force = true;

			// The recursive option guarantees that every report history 
			// attached to this report will also be deleted.
			del.recursive = true;

			// extract the baseClass from the report parameter
			baseClass[] bc = new baseClass[1];
			bc[0] = report.baseclassobject;

			int nbItemsDeleted = cBICMS.delete( bc, del );

			if (nbItemsDeleted>0)
			{
				resultMessage = "...The item \"" + report.searchPath.value + "\" was successfully deleted.";
			}
			// sn_dg_prm_smpl_deletereport_end_0
			else
			{
				resultMessage = "An error occurred while deleting the item \"" + report.searchPath.value + "\" .";
			}
			return true;
		}

	}
}
