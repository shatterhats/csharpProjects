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
//              packages using the query method. 
//
//              Use this method to request objects from Content Manager.


using System;
using System.Text;
using System.Web.Services.Protocols;
using System.Threading;
using System.Windows.Forms;
using SamplesCommon;
using cognosdotnet_10_2;

namespace ViewPackages
{
	/// <summary>
	/// Demonstrate the query() method.
	/// </summary>
	class ViewPackages
	{
		public ViewPackages(){}

		static void Main(string[] args)
		{
			string cBIUrl = "";
			contentManagerService1 cBIServer = null;
			SamplesConnect connectDlg = new SamplesConnect();
			ViewPackagesDlg ViewPackagesDlgObject = new ViewPackagesDlg();

			if (args.GetLength(0) == 0 )
			{
				// GUI mode
				connectDlg.ShowDialog();
				if (connectDlg.IsConnectedToCBI() == true) 
				{
					cBIServer = connectDlg.CBICMS;
					cBIUrl = connectDlg.CBIURL;
					ViewPackagesDlgObject.setConnection(cBIServer, cBIUrl);
					ViewPackagesDlgObject.ShowDialog();				
				}
			}
		}

		public bool doViewPackages( contentManagerService1 cBICMS, ref string resultMessage ) 
		{
			if (cBICMS == null)
			{
				resultMessage = "The Server connection provided is not valid.";
				return false;
			}
			StringBuilder output = new StringBuilder();
			// Look for all of the packages.
			propEnum[] props = new propEnum[] { propEnum.searchPath, propEnum.defaultName };
			sort[] s = new sort[]{ new sort() };
			s[0].order = orderEnum.ascending;
			s[0].propName = propEnum.defaultName;
			queryOptions qo = new queryOptions();

			searchPathMultipleObject packagePath = new searchPathMultipleObject();
			packagePath.Value = "/content//package";

			baseClass[] packageList = cBICMS.query( packagePath, props, s, qo );

			if( packageList.Length > 0 ) 
			{
				foreach( baseClass pack_item in packageList ) 
				{
					output.AppendFormat( "\n  {0}\n", pack_item.defaultName.value );
					output.AppendFormat( "    {0}\n", pack_item.searchPath.value );
				}
			} 
			else 
			{
				output.Append( "There are currently no published packages.\n" );
			}
			resultMessage = output.ToString();
			return true;
		}

	}
}
