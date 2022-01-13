/** 
Licensed Materials - Property of IBM

IBM Cognos Products: DOCS

(C) Copyright IBM Corp. 2005, 2008

US Government Users Restricted Rights - Use, duplication or disclosure restricted by GSA ADP Schedule Contract with
IBM Corp.
*/
//  Copyright (C) 2008 Cognos ULC, an IBM Company. All rights reserved.
//  Cognos (R) is a trademark of Cognos ULC, (formerly Cognos Incorporated).
//
// Description: This code sample demonstrates how to get information about 
//              report objects using the query method. 
//
//              Use this method to request objects from Content Manager.

using System;
using System.Text;
using System.Web.Services.Protocols;
using System.Threading;
using System.Windows.Forms;
using SamplesCommon;
using cognosdotnet_10_2;

namespace ViewReports
{
	/// <summary>
	/// Demonstrate the query() method.
	/// </summary>
	class ViewReports
	{
		public ViewReports(){}

		static void Main(string[] args)
		{
			string cBIUrl = "";
			contentManagerService1 cBIServer = null;
			SamplesConnect connectDlg = new SamplesConnect();
			ViewReportsDlg ViewReportsDlgObject = new ViewReportsDlg();

			if (args.GetLength(0) == 0 )
			{
				// GUI mode
				connectDlg.ShowDialog();
				if (connectDlg.IsConnectedToCBI() == true) 
				{
					cBIServer = connectDlg.CBICMS;
					cBIUrl = connectDlg.CBIURL;
					ViewReportsDlgObject.setConnection(cBIServer, cBIUrl);
					ViewReportsDlgObject.ShowDialog();				
				}
			}
		}

		public bool doViewReportsAndQueries( contentManagerService1 cBICMS, ref string resultMessage ) 
		{
			if (cBICMS == null)
			{
				resultMessage = "the Server connection provided is invalid.";
				return false;
			}
			propEnum[] props = new propEnum[] { propEnum.searchPath, propEnum.defaultName };
			sort[] s = new sort[]{ new sort() };
			s[0].order = orderEnum.ascending;
			s[0].propName = propEnum.defaultName;
			queryOptions qo = new queryOptions();

			StringBuilder output = new StringBuilder();

			// Look for all of the reports.
			output.AppendFormat( "\nReports:\n" );

			searchPathMultipleObject reportsPath = new searchPathMultipleObject();
			reportsPath.Value = "/content//report";

			baseClass[] bc = cBICMS.query( reportsPath, props, s, qo );
			if( bc.Length > 0 ) 
			{
				foreach( baseClass report_item in bc ) 
				{
					output.AppendFormat( "  {0}\n", report_item.defaultName.value );
					output.AppendFormat( "    {0}\n", report_item.searchPath.value );
				}
			} 
			else 
			{
				output.Append( "  No reports currently exist.\n" );
			}

			// Find all of the queries.
			output.AppendFormat( "\nQueries:\n" );
			searchPathMultipleObject queriesPath = new searchPathMultipleObject();
			queriesPath.Value = "/content//query";

			baseClass[] bcQueries = cBICMS.query( queriesPath, props, s, qo );
			if( bcQueries.Length > 0 ) 
			{
				foreach( baseClass query_item in bcQueries ) 
				{
					output.AppendFormat( "  {0}\n", query_item.defaultName.value );
					output.AppendFormat( "    {0}\n", query_item.searchPath.value );
				}
			} 
			else 
			{
				output.Append( "  No queries in this package.\n" );
			}

			resultMessage = output.ToString();
			return true;
		}
	}
}
