/** 
Licensed Materials - Property of IBM

IBM Cognos Products: DOCS

(C) Copyright IBM Corp. 2005, 2008

US Government Users Restricted Rights - Use, duplication or disclosure restricted by GSA ADP Schedule Contract with
IBM Corp.
*/
// *
// * cmQuery.sln
// *
// * Copyright (C) 2008 Cognos ULC, an IBM Company. All rights reserved.
// * Cognos (R) is a trademark of Cognos ULC, (formerly Cognos Incorporated).
// *
// * Description: This code sample demonstrates how to delete reports using the
// *              following methods:
// *              - query: Use this method to request objects from Content Manager.
// *
// * To run this sample from the command line use:
// * cmquery.exe -sp <searchPath> [-un <userName> -pwd <userPassword> -ns <userNamepsace>]
// *

using System;
using System.Windows.Forms;
using System.Web.Services.Protocols;
using SamplesCommon;
using cognosdotnet_10_2;

namespace CMQuery
{
	/// <summary>
	/// CMQuery is a simple command-line application that lets you explore
	/// the Content Manager/Content Store database.
	/// </summary>
	public class CMQuery
	{
		public CMQuery(){}
		
		static void Main(string[] args)
		{
			bool isGUImode = false;
			string BIServerURL = "";
			string userName = "";
			string userPassword = "";
			string userNamespace = "";
			string searchPath = "";
			
			CMQuery cmQueryObj = new CMQuery();
			CMQueryDlg cmQueryDlgObject = new CMQueryDlg();
				
			if (args.GetLength(0) == 0 )
			{
				// GUI mode
				isGUImode = true;
				SamplesConnect connectDlg = new SamplesConnect();
				connectDlg.ShowDialog();
				if (connectDlg.IsConnectedToCBI() == true) 
				{
					cmQueryDlgObject.setConnection(connectDlg.CBICMS, 
													connectDlg.CBIURL, 
													userName, 
													userPassword, 
													userNamespace);
					cmQueryDlgObject.ShowDialog();				
				}
			}
			else
			{
				// Command Line mode
				isGUImode = false;
				if (!cmQueryObj.getCLInput(args, ref searchPath,
					ref userName,
					ref userPassword,
					ref userNamespace) )
				{
					return;
				}

				SamplesConnect connectCL = new SamplesConnect();
				bool isAnonymous = true;
				if (!connectCL.makeCLConnection(ref BIServerURL, 
					ref userName,
					ref userPassword, 
					ref userNamespace,
					ref isAnonymous) )
				{
					return;
				}
				if (isAnonymous && (0 != userName.CompareTo("")) )
				{
					userName = "";
					Console.WriteLine("\n***Note: This sample ignores user credentials for Anonymous connections\n");
				}

				string output = cmQueryObj.doQuery(connectCL.CBICMS, 
													searchPath, 
													userName, 
													userPassword, 
													userNamespace, isGUImode);
				Console.WriteLine(output);
			}
		}

		public bool getCLInput(string[] args,
								ref string searchPath,
								ref string userName,
								ref string userPassword,
								ref string userNamespace)
		{
			try
			{
				// command line mode
				int argc = args.GetLength(0);
				for (int i=0; i<argc; i++)
				{
					if (0 == args[i].CompareTo("-sp"))
					{
						searchPath = args[++i];
					}
					else if (0 == args[i].CompareTo("-un"))
					{
						userName = args[++i];
					}
					else if (0 == args[i].CompareTo("-pwd"))
					{
						userPassword = args[++i];
					}
					else if (0 == args[i].CompareTo("-ns"))
					{
						userNamespace = args[++i];
					}
					else if (0 == args[i].CompareTo("-h"))
					{
						//display help
						Console.WriteLine("cmquery.exe -sp <searchPath> [-un <userName> -pwd <userPassword> -ns <userNamepsace>].");
						return false;
					}
					else 
					{
						// invalid argument
						Console.WriteLine("Invalid argument: {0}", args[0]);
						Console.WriteLine("cmquery.exe -sp <searchPath> [-un <userName> -pwd <userPassword> -ns <userNamepsace>].");
						return false;
					}
				}
			}
			catch(System.Exception ex)
			{
				if ( (searchPath == null) || (0 == searchPath.CompareTo("")) )
				{
					searchPath = "/*";
					Console.WriteLine("\n***Note: The searchPath argument is missing, '" + searchPath + "' will be used instead.\n");
					return true;
				}
				SamplesException.ShowExceptionMessage("getCLInput() failed with error: " + ex.Message, false, 
														"Content Manager Query Sample - doQuery()" );
				Console.WriteLine("\nValid arguments:\ncmquery.exe -sp <search Path> [-un <userName> -pwd <userPassword> -ns <userNamepsace>].");
				return false;
			}

			return true;
		}

		public string doQuery(contentManagerService1 cBICMS, 
			string searchPath, 
			string userName, 
			string userPassword, 
			string userNamespace,
			bool isGUImode)
		{
			string output = "";
			try
			{
				// Search properties: we need the defaultName and the searchPath.
				propEnum[] properties =
				{ propEnum.defaultName, propEnum.searchPath };

				// Sort options: ascending sort on the defaultName property.
				sort[] sortBy = { new sort()};
				sortBy[0].order = orderEnum.ascending;
				sortBy[0].propName = propEnum.defaultName;

				// Query options; use the defaults.
				queryOptions options = new queryOptions();

				searchPathMultipleObject qPath = new searchPathMultipleObject();
				qPath.Value = searchPath;

				// Make the query.
				baseClass[] results =
					cBICMS.query(qPath, properties, sortBy, options);

				// Display the results.
				output += "Results:\n\n";
				for (int i = 0; i < results.GetLength(0); i++)
				{
					tokenProp theDefaultName = results[i].defaultName;
					stringProp theSearchPath = results[i].searchPath;

					output += "\t" + theDefaultName.value + "\t\t" + theSearchPath.value + "\n";
				}
			}
			catch(SoapException ex)
			{
				SamplesException.ShowExceptionMessage("\n" + ex, isGUImode, "Content Manager Query Sample - doQuery()" );
				return "The error occurred in doQuery()";
			}
			catch(System.Exception ex)
			{
				if (0 != ex.Message.CompareTo("INPUT_CANCELLED_BY_USER"))
				{
					SamplesException.ShowExceptionMessage("\n" + ex.Message, isGUImode, "Content Manager Query Sample - doQuery()" );					
				}
				return "The error occurred in doQuery()";
			}
			return output;
		}
	}
}
