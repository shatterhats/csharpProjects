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
// Description: This code sample demonstrates how to get information about an 
//              object using the query method. 
//
//              Use this method to request objects from Content Manager.
 
using System;
using System.Text;
using System.Web.Services.Protocols;
using System.Threading;
using System.Windows.Forms;
using SamplesCommon;
using cognosdotnet_10_2;

namespace CMTester
{
	/// <summary>
	/// Demonstrate the query() method.
	/// </summary>
	public class CMTester
	{
		/// <summary>
		/// Create a CMTester object.
		/// </summary>
		public CMTester() 
		{
		}

		public static contentManagerService1 cBICMS = null;
		public static SamplesWindow gui = null;

		/// <summary>
		/// This C# method returns a string that contains either the 
		/// information about the specified objects (if the request succeeded)
		/// or an error message (if the request failed).
		/// </summary>
		/// <param name="crn">The connection to the Content Manager service.</param>
		/// <returns>The searchPath, defaultName, creationTime and version of the specified objects.</returns>
		public string contentMgrTester( contentManagerService1 cmService ) 
		{
			try 
			{
				propEnum[] props = new propEnum[] { propEnum.searchPath,
													  propEnum.defaultName,
													  propEnum.creationTime,
													  propEnum.version };

				searchPathMultipleObject homePath = new searchPathMultipleObject();
				homePath.Value = "~";

				baseClass[] bc = cmService.query( homePath, props, new sort[]{}, new queryOptions() );

				StringBuilder output = new StringBuilder();
				if( bc.Length > 0 ) 
				{
					for( int i = 0; i < bc.Length; i++ ) 
					{
						account myAccount = (account)bc[i];

						output.AppendFormat( "The defaultName is: {0}\n", myAccount.defaultName.value );
						output.AppendFormat( "The searchPath is: {0}\n", myAccount.searchPath.value );
						output.AppendFormat( "The creationTime is: {0}\n", myAccount.creationTime.value.ToString() );
						output.AppendFormat( "The version is: {0}\n\n", myAccount.version.value );
						output.Append( "Content Manager is responding and operational." );
					}
				} 
				else 
				{
					output.Append( "\nError occurred in function contentMgrTester." );
				}

				return output.ToString();
			} 
			catch( SoapException ex ) 
			{
				string str = SamplesException.FormatException( ex ) + "\n\nCM Tester:\nCannot connect to CM.\nCheck if CRN is running.";
				return str;
			} 
			catch( NullReferenceException ) 
			{
				string str = "Invalid data passed to contentMgrTester.";
				return str;
			}
		}

		/// <summary>
		/// Application entry-point.  Decide if we're running in GUI mode or
		/// command-line mode, and behave accordingly.
		/// </summary>
		/// <param name="args">The command-line arguments.</param>
		public static void Main( string[] args ) 
		{
			try 
			{
				if( args[0].CompareTo( "--test" ) == 0 ) 
				{
					// Run command-line version.
					cBICMS = new contentManagerService1();
					cBICMS.Url = "http://localhost:9300/p2pd/servlet/dispatch";

					CMTester test = new CMTester();
					string output = test.contentMgrTester( cBICMS );

					Console.WriteLine( output );
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
		/// and create the service connection.
		/// </summary>
		/// <param name="sender">The object that sent this event.</param>
		/// <param name="e">Additional event arguments. (not used)</param>
		private static void gui_Activated( object sender, EventArgs e ) 
		{
			if( !wasActivated ) 
			{
				wasActivated = true;

				SamplesWindow ui = (SamplesWindow)sender;

				ui.applicationName = "CM Tester";
				ui.applicationTitle = "Content Manager Test";
				ui.applicationAction = "Query";
				ui.applicationVersion = "1.0";

				ui.AddText( "Connecting to Server..." );

				ThreadPool.QueueUserWorkItem( new WaitCallback( createConnection ) );
			}
		}

		/// <summary>
		/// Create the service connection.
		/// 
		/// We do this in a separate thread so the UI isn't tied up waiting
		/// for the service constructor to return.  Under .NET,
		/// that can take a while.
		/// </summary>
		/// <param name="state">State for the thread. (not used)</param>
		private static void createConnection( object state ) 
		{
			try 
			{
				gui.Actions.Enabled = false;

				cBICMS = new contentManagerService1();

				gui.AddText( "... done creating connection." );

				gui.Actions.Enabled = true;
			} 
			catch( SoapException ex ) 
			{
				SamplesException.ShowExceptionMessage( ex, true ," ");

				gui.Close();
			}
		}

		/// <summary>
		/// The user has clicked on the Query button, so do the query.
		/// </summary>
		/// <param name="sender">The object that sent this event. (not used)</param>
		/// <param name="e">Additional event arguments. (not used)</param>
		private static void Actions_Click( object sender, EventArgs e ) 
		{
			gui.Actions.Enabled = false;
			gui.AddText( "Sending query..." );
			Boolean bTestAnonymous = false;

			// Use the URL specified in the GUI...
			cBICMS.Url = gui.serverUrl;
					
			//Test for Anonymous Authentication
					
			try
			{
				searchPathMultipleObject homePath = new searchPathMultipleObject();
				homePath.Value = "~";

				baseClass[] bc = cBICMS.query ( homePath, new propEnum[]{} , new sort[]{}, new queryOptions () );
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
				CMTester test = new CMTester();
				string output = test.contentMgrTester( cBICMS );

				gui.AddTextLines( output );
				gui.AddText( "... done query." );
			}
			else
			{
			{
				// Attempt to log on.
				SamplesLogon logon = new SamplesLogon( cBICMS );
				logon.ShowDialog( gui );
			
				if( !logon.loggedOn ) 
				{
					gui.AddText( "Unable to log on." );
					return;
				} 
				else 
				{
					gui.Actions.Enabled = true;
					CMTester test = new CMTester();
					string output = test.contentMgrTester( cBICMS );

					gui.AddTextLines( output );
					gui.AddText( "... done query." );
				}
			}
		  }
		}
	}
}
