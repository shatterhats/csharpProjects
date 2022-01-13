/** 
Licensed Materials - Property of IBM

IBM Cognos Products: DOCS

(C) Copyright IBM Corp. 2005, 2008

US Government Users Restricted Rights - Use, duplication or disclosure restricted by GSA ADP Schedule Contract with
IBM Corp.
*/
// Copyright (C) 2008 Cognos ULC, an IBM Company. All rights reserved.
// Cognos (R) is a trademark of Cognos ULC, (formerly Cognos Incorporated).
//
// Description: This code sample demonstrates how to run and print a report with  
//              prompts using the getParameters method.
//
//              Use this method to return the list of parameters used by the 
//              report, including optional parameters. This method also returns
//              parameters from the model and stored procedures that are used 
//              by the report. 

using System;
using System.Text;
using System.Web.Services.Protocols;
using System.Threading;
using System.Windows.Forms;
using SamplesCommon;
using cognosdotnet_10_2;

namespace ReportParameters
{
	/// <summary>
	/// Demonstrate the getParameters() method.
	/// </summary>
	public class ReportParameters
	{
		/// <summary>
		/// Create a ReportParameters object.
		/// </summary>
		public ReportParameters()
		{
		}

		public static reportService1 repSvc = null;
		public static contentManagerService1 cmService = null;
		public static SamplesConnect connection = null;
		public static SamplesWindow gui = null;

		/// <summary>
		/// This C# method calls the getParameters method to
		/// return the list of parameters used by the report.
		/// </summary>
		/// <param name="reportPath">Specifies the search path of the report.</param>
		/// <param name="crn">Specifies the object that provides the connection to the report service.</param>
		/// <returns>An array of report parameters.</returns>
		public baseParameter[] getReportParameters( string reportPath, reportService1 cBIRS ) 
		{
			searchPathSingleObject cmReportPath = new searchPathSingleObject();
			cmReportPath.Value = reportPath;

			// sn_dg_prm_smpl_runreport_P1_start_1
			// sn_dg_sdk_method_reportService_getParameters_start_0
			asynchReply gpReply = cBIRS.getParameters( cmReportPath, new parameterValue[] {}, new runOption[]{} );
			// sn_dg_sdk_method_reportService_getParameters_end_0
			// sn_dg_prm_smpl_runreport_P1_end_1

			if ((gpReply.status != asynchReplyStatusEnum.complete) 
				&& (gpReply.status != asynchReplyStatusEnum.conversationComplete) )
			{
				while ( (gpReply.status != asynchReplyStatusEnum.complete)
					&& (gpReply.status != asynchReplyStatusEnum.conversationComplete) )
				{
					gpReply = cBIRS.wait(gpReply.primaryRequest,new parameterValue[] {}, new option[] {});
				}

			}

			if (gpReply.details == null)
			{
				return null;
			}

			// sn_dg_sdk_method_reportService_getParameters_start_1
			for (int i = 0; i < gpReply.details.Length; i++)
			{
				if (gpReply.details[i] is asynchDetailParameters)
				{
					return ((asynchDetailParameters)gpReply.details[i]).parameters;
				}
			}
			// sn_dg_sdk_method_reportService_getParameters_end_1

			return null;
		}

		/// <summary>
		/// This C# method assigns values to each parameter for the specified report.
		/// </summary>
		/// <param name="reportName">The name of the report.</param>
		/// <param name="prm">An array of parameters.</param>
		/// <returns>An array of parameter values.</returns>
		public parameterValue[] setReportParameters( string reportName, baseParameter[] prm, bool isGui ) 
		{
			if( prm.Length > 0 ) 
			{
				parameterValue[] parms = new parameterValue[prm.Length];
				int pidx = 0;

				if( isGui ) 
				{
					SamplesInput inputter = new SamplesInput();
					// sn_dg_prm_smpl_runreport_P2_start_0
					foreach( parameter p in prm ) 
					{
						// Prompt the user to type a value for the parameter.
						// If the value is DateTime, the format must be in the ISO 8601 
						// format. For example, a date and time of 2001-05-31T14:39:25.035Z 
						// represents the thirty-first day of May in the year 2001. The time, 
						// measured in Coordinated Universal Time (UTC) as indicated by the Z, 
						// is 14 hours, 39 minutes, 25 seconds, and 35 milliseconds.
						string desc = "Enter a value for prompt '" + p.name + "' (of type " + p.type.ToString() + "):";
						string val = inputter.getInput( null, desc, p.type.ToString() );

						simpleParmValueItem item = new simpleParmValueItem();
						item.use = val;
						parmValueItem[] pvi = new parmValueItem[1];
						pvi[0] = item;

						parms[pidx] = new parameterValue();
						parms[pidx].name = p.name;
						parms[pidx].value = pvi;
						pidx = pidx+1;
					}
					// sn_dg_prm_smpl_runreport_P2_end_0
				} 
				else 
				{ // is console
					foreach( parameter p in prm ) 
					{
						// Prompt the user to type a value for the parameter.
						// If the value is DateTime, the format must be in the ISO 8601 
						// format. For example, a date and time of 2001-05-31T14:39:25.035Z 
						// represents the thirty-first day of May in the year 2001. The time, 
						// measured in Coordinated Universal Time (UTC) as indicated by the Z, 
						// is 14 hours, 39 minutes, 25 seconds, and 35 milliseconds.
						string desc = "Enter a value for prompt \"" + p.name + "\" (of type " + p.type.ToString() + "):";
						Console.WriteLine( desc );
						string val = Console.ReadLine();

						simpleParmValueItem item = new simpleParmValueItem();
						item.use = val;
						parmValueItem[] pvi = new parmValueItem[1];
						pvi[0] = item;

						parms[pidx] = new parameterValue();
						parms[pidx].name = p.name;
						parms[pidx].value = pvi;
						pidx = pidx+1;
					}
				}

				return parms;
			}

			return null;
		}
		/// <summary>
		/// Application entry-point.  Decide if we're running in GUI mode or
		/// command-line mode, and behave accordingly.
		/// </summary>
		/// <param name="args">The command-line arguments.</param>
		public static void Main( string[] args ) 
		{
            Control.CheckForIllegalCrossThreadCalls = false;
            try 
			{
				if( args[0].CompareTo( "--test" ) == 0 ) 
				{
					// Run command-line version.
					ReportParameters test = new ReportParameters();

                    baseParameter[] param = test.getReportParameters("/content/folder[@name='Samples']/folder[@name='Models']/package[@name='GO Data Warehouse (query)']/folder[@name='SDK Report Samples']/report[@name='Order Method Range List']", repSvc);
					foreach( parameter p in param ) 
					{
						Console.WriteLine( "Name: {0}, Type: {1}", p.name, p.type );
					}
                    parameterValue[] pv = test.setReportParameters("/content/folder[@name='Samples']/folder[@name='Models']/package[@name='GO Data Warehouse (query)']/folder[@name='SDK Report Samples']/report[@name='Order Method Range List']", param, false);
					foreach( parameterValue p in pv ) 
					{
						Console.WriteLine( "Name: {0}, Value: {1}", p.name, p.value );
					}

					//Console.WriteLine( output );
				} 
				else 
				{
					// Complain.
					Console.WriteLine( "Unknown argument: {0}", args[0] );
					Console.WriteLine( "Use '--test' to run an automated test." );
				}
			} 
			catch( IndexOutOfRangeException ) 
			{
				// If it's not a test, we should run the GUI.
				gui = new SamplesWindow();

				gui.Activated += new EventHandler( gui_Activated );
				gui.Actions.Click += new EventHandler( Actions_Click );

				Application.Run( gui );
			}
		}

		private static bool wasActivated = false;

		/// <summary>
		/// The UI window has been activated; we need to set up some values
		/// and create the service connections.
		/// </summary>
		/// <param name="sender">The object that sent this event.</param>
		/// <param name="e">Additional event arguments. (not used)</param>
		private static void gui_Activated( object sender, EventArgs e ) 
		{
			if( !wasActivated ) 
			{
				wasActivated = true;

				SamplesWindow ui = (SamplesWindow)sender;

				ui.applicationName = "Report Parameters";
				ui.applicationTitle = "Report Parameters";
				ui.applicationAction = "Go";
				ui.applicationVersion = "1.0";

				ui.AddText( "Connecting..." );

				ThreadPool.QueueUserWorkItem( new WaitCallback( createConnection ) );
			}
		}

		/// <summary>
		/// Create the service connections.
		/// 
		/// We do this in a separate thread so the UI isn't tied up waiting
		/// for the service constructors to return.  Under .NET,
		/// that can take a while.
		/// </summary>
		/// <param name="state">State for the thread. (not used)</param>
		private static void createConnection( object state ) 
		{
			try 
			{
				gui.Actions.Enabled = false;

				repSvc = new reportService1();
				repSvc.Url = gui.serverUrl;
				cmService = new contentManagerService1();
				cmService.Url = gui.serverUrl;

				gui.AddText( "... done creating connection." );

				gui.Actions.Enabled = true;
			} 
			catch( SoapException ex ) 
			{
				SamplesException.ShowExceptionMessage(ex,true,ex.Message);

				gui.Close();
			}
		}

		/// <summary>
		/// The user has clicked on the View button, so do the work.
		/// </summary>
		/// <param name="sender">The object that sent this event. (not used)</param>
		/// <param name="e">Additional event arguments. (not used)</param>
		private static void Actions_Click( object sender, EventArgs e ) 
		{
			gui.Actions.Enabled = false;
			gui.AddText( "Collecting parameters..." );
			Boolean bTestAnonymous = false;

			// Use the URL specified in the GUI...
			repSvc.Url = gui.serverUrl;
			cmService.Url = gui.serverUrl;
			
			//Test for Anonymous Authentication
			searchPathMultipleObject homeDir = new searchPathMultipleObject();
			homeDir.Value = "~";

			try
			{
				baseClass[] bc = cmService.query ( homeDir, new propEnum[]{} , new sort[]{}, new queryOptions () );
				if (bc != null)
					bTestAnonymous = true;
				else 
					bTestAnonymous = false;
			}
			catch( Exception ex ) 
			{
				ex.Message.ToString ();
			}


			if (bTestAnonymous == true)
			{
				gui.Actions.Enabled = true;
				ReportParameters test = new ReportParameters();

                baseParameter[] param = test.getReportParameters("/content/folder[@name='Samples']/folder[@name='Models']/package[@name='GO Data Warehouse (query)']/folder[@name='SDK Report Samples']/report[@name='Order Method Range List']", repSvc);
				foreach( baseParameter p in param ) 
				{
					StringBuilder output = new StringBuilder();
					output.AppendFormat( "Name: {0}, Type: {1}", p.name, p.type );
					gui.AddText( output.ToString() );
				}

                parameterValue[] pv = test.setReportParameters("/content/folder[@name='Samples']/folder[@name='Models']/package[@name='GO Data Warehouse (query)']/folder[@name='SDK Report Samples']/report[@name='Order Method Range List']", param, true);
				foreach( parameterValue p in pv ) 
				{
					StringBuilder output = new StringBuilder();
					foreach( simpleParmValueItem pvi in p.value ) 
					{
						output.AppendFormat( "Name: {0}, Value: {1}", p.name, pvi.use );
					}
					gui.AddText( output.ToString() );
				}

				//gui.AddTextLines( output );
				gui.AddText( "... done query." );
			}
			else
			{
				// Attempt to log on.
				SamplesLogon logon = new SamplesLogon( cmService );
				logon.ShowDialog( gui );
			
				if( !logon.loggedOn ) 
				{
					gui.AddText( "Unable to log on." );
					return;
				} 
				else 
				{
					ReportParameters test = new ReportParameters();

                    baseParameter[] param = test.getReportParameters("/content/folder[@name='Samples']/folder[@name='Models']/package[@name='GO Data Warehouse (query)']/folder[@name='SDK Report Samples']/report[@name='Order Method Range List']", repSvc);
					foreach( parameter p in param ) 
					{
						StringBuilder output = new StringBuilder();
						output.AppendFormat( "Name: {0}, Type: {1}", p.name, p.type );
						gui.AddText( output.ToString() );
					}

                    parameterValue[] pv = test.setReportParameters("/content/folder[@name='Samples']/folder[@name='Models']/package[@name='GO Data Warehouse (query)']/folder[@name='SDK Report Samples']/report[@name='Order Method Range List']", param, true);
					foreach( parameterValue p in pv ) 
					{
						StringBuilder output = new StringBuilder();
						foreach( simpleParmValueItem pvi in p.value ) 
						{
							output.AppendFormat( "Name: {0}, Value: {1}", p.name, pvi.use );
						}
						gui.AddText( output.ToString() );
					}

					//gui.AddTextLines( output );
					gui.AddText( "... done querying." );
				}
			}
			gui.Actions.Enabled = true;
		}
	}
}
