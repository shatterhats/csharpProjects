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
//              packages and reports object using the query method.
//
//              Use this method to request objects from Content Manager.

using System;
using System.Windows.Forms;
using System.Text;
using System.Web.Services.Protocols;
using SamplesCommon;
using cognosdotnet_10_2;

namespace ViewAll
{
	class ViewAll
	{
		public ViewAll(){}

		static void Main(string[] args)
		{
			string cBIUrl = "";
			contentManagerService1 cBICMS = null;
			SamplesConnect connectDlg = new SamplesConnect();
			ViewAllDlg viewAllDlgObject = new ViewAllDlg();

			if (args.GetLength(0) == 0 )
			{
				// GUI mode
				connectDlg.ShowDialog();
				if (connectDlg.IsConnectedToCBI() == true) 
				{
					cBICMS = connectDlg.CBICMS;
					cBIUrl = connectDlg.CBIURL;
					viewAllDlgObject.setConnection(cBICMS, cBIUrl);
					viewAllDlgObject.ShowDialog();				
				}
			}
		}

		public bool doViewAll(contentManagerService1 cBIServer, ref string resultMessage)
		{
			if (cBIServer == null)
			{
				resultMessage = "The connection provided is invalid.";
				return false;
			}
			propEnum[] props = new propEnum[] { propEnum.searchPath, propEnum.defaultName };
			sort[] s = new sort[]{ new sort() };
			s[0].order = orderEnum.ascending;
			s[0].propName = propEnum.defaultName;
			queryOptions qo = new queryOptions();

			StringBuilder output = new StringBuilder();

			// Look for all of the packages.
			searchPathMultipleObject packagePath = new searchPathMultipleObject();
			packagePath.Value = "/content//package";

			baseClass[] bc = cBIServer.query( packagePath, props, s, qo );
			if( bc.Length > 0 ) 
			{
				foreach( baseClass pack_item in bc ) 
				{
					output.AppendFormat( "\n  {0}\n", pack_item.defaultName.value );
					output.AppendFormat( "    {0}\n", pack_item.searchPath.value );

					// Find all of the reports in this package.
					output.AppendFormat( "\n    Reports:\n" );
                    string reportPath = pack_item.searchPath.value + "//report";

					searchPathMultipleObject reportsSearchPath = new searchPathMultipleObject();
					reportsSearchPath.Value = reportPath;

					baseClass[] bcReports = cBIServer.query( reportsSearchPath, props, s, qo );
					if( bcReports.Length > 0 ) 
					{
						foreach( baseClass report_item in bcReports ) 
						{
							output.AppendFormat( "      {0}\n", report_item.defaultName.value );
							output.AppendFormat( "        {0}\n", report_item.searchPath.value );
						}
					} 
					else 
					{
						output.Append( "      No reports in this package.\n" );
					}

					// Find all of the queries in this package.
					output.AppendFormat( "\n    Queries:\n" );
                    string queryPath = pack_item.searchPath.value + "//query";

					searchPathMultipleObject queriesSearchPath = new searchPathMultipleObject();
					queriesSearchPath.Value = queryPath;

					baseClass[] bcQueries = cBIServer.query( queriesSearchPath, props, s, qo );
					if( bcQueries.Length > 0 ) 
					{
						foreach( baseClass query_item in bcQueries ) 
						{
							output.AppendFormat( "      {0}\n", query_item.defaultName.value );
							output.AppendFormat( "        {0}\n", query_item.searchPath.value );
						}
					} 
					else 
					{
						output.Append( "      No queries in this package.\n" );
					}
				}
			} 
			else 
			{
				output.Append( "There are currently no published packages or reports.\n" );
			}

			resultMessage = output.ToString();
			return true;
		}
	}
}
