/** 
Licensed Materials - Property of IBM

IBM Cognos Products: DOCS

(C) Copyright IBM Corp. 2005, 2008

US Government Users Restricted Rights - Use, duplication or disclosure restricted by GSA ADP Schedule Contract with
IBM Corp.
*/
//  Copyright (C) 2008 Cognos ULC, an IBM Company. All rights reserved.
//  Cognos (R) is a trademark of Cognos ULC, (formerly Cognos Incorporated).

using System;
using System.IO;
using System.Text;
using System.Web.Services.Protocols;
using SamplesCommon;
using cognosdotnet_10_2;

namespace reportrunner
{
	/// <summary>
	/// Run a report from the samples deployment archive, and save its output
	/// as HTML.
	/// 
	/// Note that this application does no error handling; errors will cause
	/// ugly exception stack traces to appear on the console, and the 
	/// application will exit ungracefully.
	/// </summary>
	class ReportRunner
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main( string[] args )
		{
			// Change this URL if your server is in another location or a
			// different port.
			string serverHost = "localhost";
			string serverPort = "9300";

			// Change this search path if you want to run a different report.
			searchPathSingleObject reportPath = new searchPathSingleObject();
            reportPath.Value = "/content/folder[@name='Samples']/folder[@name='Models']/package[@name='GO Data Warehouse (query)']/folder[@name='SDK Report Samples']/report[@name='Product Description List']";

			// Output filename
			string outputPath = "reportrunner.html";

			// Specify a user to log in as.
			string userName = "";
			string userPassword = "";
			string userNamespace = "";

			// Parse the command-line arguments.
			bool exit = false;
			for( int idx = 0; idx < args.Length; idx++ ) {
				if( args[idx].CompareTo( "-host" ) == 0 ) {
					idx++;
					serverHost = args[idx];
				} else if( args[idx].CompareTo( "-port" ) == 0 ) {
					idx++;
					serverPort = args[idx];
				} else if( args[idx].CompareTo( "-report" ) == 0 ) {
					idx++;
					reportPath.Value = args[idx];
				} else if( args[idx].CompareTo( "-output" ) == 0 ) {
					idx++;
					outputPath = args[idx];
				} else if( args[idx].CompareTo( "-user" ) == 0 ) {
					idx++;
					userName = args[idx];
				} else if( args[idx].CompareTo( "-password" ) == 0 ) {
					idx++;
					userPassword = args[idx];
				} else if( args[idx].CompareTo( "-namespace" ) == 0 ) {
					idx++;
					userNamespace = args[idx];
				} else {
					Console.WriteLine( "Unknown argument: {0}\n", args[idx] );

					showUsage();

					exit = true;
				}
			}

			if( !exit ) {
				// Create a connection to the server.
				//
				// Note that creating the Service object takes "a 
				// while" (based on your system speed)... if you're doing a GUI 
				// application, it's a good idea to offload this into a separate 
				// worker thread (see the ThreadPool class in the .NET Framework).
				string Server_URL = "http://" + serverHost + ":" + serverPort + "/p2pd/servlet/dispatch";

				Console.WriteLine( "Creating connection to {0}:{1}...", serverHost, serverPort );
				Console.WriteLine( "Server URL: {0}", Server_URL );
				reportService1 cBIRS = new reportService1();
				cBIRS.Url = Server_URL;
				Console.WriteLine( "... done." );

				// Set up the biBusHeader for a logon.
				if( userName.Length > 0 && userPassword.Length > 0 && userNamespace.Length > 0 ) {
					Console.WriteLine( "Logging on as {0} in the {1} namespace.", userName, userNamespace );
					setUpHeader( cBIRS, userName, userPassword, userNamespace );
				}

				// Set up the report parameters.
				parameterValue[] parameters = new parameterValue[]{};

				option[] runOptions = new option[5];
				
				runOptionBoolean saveOutput = new runOptionBoolean();
				saveOutput.name = runOptionEnum.saveOutput;
				saveOutput.value = false;
				runOptions[0] = saveOutput;

				// TODO: Output format should be specified on the command-line
				runOptionStringArray outputFormat = new runOptionStringArray();
				outputFormat.name = runOptionEnum.outputFormat;
				outputFormat.value = new string[]{ "HTML" };
				runOptions[1] = outputFormat;

				runOptionOutputEncapsulation outputEncapsulation = new runOptionOutputEncapsulation();
				outputEncapsulation.name = runOptionEnum.outputEncapsulation;
				outputEncapsulation.value = outputEncapsulationEnum.none;
				runOptions[2] = outputEncapsulation;

				asynchOptionInt primaryWait = new asynchOptionInt();
				primaryWait.name = asynchOptionEnum.primaryWaitThreshold;
				primaryWait.value = 0;
				runOptions[3] = primaryWait;

                asynchOptionInt secondaryWait = new asynchOptionInt();
                secondaryWait.name = asynchOptionEnum.secondaryWaitThreshold;
				secondaryWait.value = 0;
				runOptions[4] = secondaryWait;

				// Now, run the report.
				try {
					Console.WriteLine( "Running the report..." );
					Console.WriteLine( "Report search path is:" );
					Console.WriteLine( reportPath.Value );

					asynchReply res = cBIRS.run( reportPath, parameters, runOptions );
					Console.WriteLine( "... done." );

					// The report is finished, let's fetch the results and save them to
					// a file.
					string data = null;
					if( res.status == asynchReplyStatusEnum.complete )
					{
						for (int i = 0; i < res.details.Length; i++)
						{
							if (res.details[i] is asynchDetailReportOutput)
							{
								data = ( (asynchDetailReportOutput)res.details[i]).outputPages[0];
							}
						}

						Console.WriteLine( "Writing report output to {0}...", outputPath );
						FileStream fs = new FileStream( outputPath, FileMode.Create );

						// URIs in the output are relative on the server; we need to
						// make them absolute so they reference the server properly.
						string uriFix = "http://" + serverHost + ":" + serverPort + "/crn/";
						//foreach( string hunk in data ) {
							string fixed_hunk = data.Replace( "../", uriFix );

							byte[] hunk_data = UTF8Encoding.UTF8.GetBytes( fixed_hunk );
							fs.Write( hunk_data, 0, hunk_data.Length );
						//}

						fs.Close();
						Console.WriteLine( "... done." );
					}
				} catch( SoapException ex ) {
					string ex_str = Exceptions.CognosException.ConvertToString( ex );
					Console.WriteLine( "SOAP exception!\n" );
					Console.WriteLine( ex_str );
				} catch( Exception ex ) {
					Console.WriteLine( "Unhandled exception!" );
					Console.WriteLine( "Message: {0}", ex.Message );
					Console.WriteLine( "Stack trace:\n{0}", ex.StackTrace );
				}
			}
		}

		/// <summary>
		/// This function will prepare the biBusHeader.
		/// 
		/// If no error was reported, then logon was successful.
		/// </summary>
		/// <param name="reportService1">An initialized report service object.</param>
		/// <param name="user">Log in as this User ID in the specified namespace.</param>
		/// <param name="pass">Password for user in the specified namespace.</param>
		/// <param name="name">The security namespace to log on to.</param>
		static void setUpHeader( reportService1 cBIRS, string user, string pass, string name ) {
			// Scrub the header to remove the conversation context.
			if( cBIRS.biBusHeaderValue != null ) {
				if( cBIRS.biBusHeaderValue.tracking != null ) {
					if( cBIRS.biBusHeaderValue.tracking.conversationContext != null ) {
						cBIRS.biBusHeaderValue.tracking.conversationContext = null;
					}
				}

				return;
			}

			// Set up a new biBusHeader for the "logon" action.
			cBIRS.biBusHeaderValue = new biBusHeader();
			cBIRS.biBusHeaderValue.CAM = new CAM();
			cBIRS.biBusHeaderValue.CAM.action = "logonAs";
			cBIRS.biBusHeaderValue.hdrSession = new hdrSession();

			formFieldVar[] ffs = new formFieldVar[3];

			ffs[0] = new formFieldVar();
			ffs[0].name = "CAMUsername";
			ffs[0].value = user;
			ffs[0].format = formatEnum.not_encrypted;

			ffs[1] = new formFieldVar();
			ffs[1].name = "CAMPassword";
			ffs[1].value = pass;
			ffs[1].format = formatEnum.not_encrypted;

			ffs[2] = new formFieldVar();
			ffs[2].name = "CAMNamespace";
			ffs[2].value = name;
			ffs[2].format = formatEnum.not_encrypted;

			cBIRS.biBusHeaderValue.hdrSession.formFieldVars = ffs;
		}

		static void showUsage() {
			Console.WriteLine( "Run a report and save the output as HTML.\n" );
			Console.WriteLine( "usage:\n" );
			Console.WriteLine( "-host hostName            Host name of the server. " );
			Console.WriteLine( "                          Default: localhost" );
			Console.WriteLine( "-port portNumber          Port number of the server 'host'." );
			Console.WriteLine( "                          Default: 80" );
			Console.WriteLine( "-report searchPath        Search path to a report." );
			Console.WriteLine( "                          Default: /content/package[@name='GO Sales and Retailers']/folder[@name='Documentation Report Samples']/report[@name='Show Detailed Rows and Summaries']" );
			Console.WriteLine( "-output outputPath        File name for the output HTML document." );
			Console.WriteLine( "                          Default: reportrunner.html" );
			Console.WriteLine( "-user userName            User to log on as. Must exist in 'userNamespace'." );
			Console.WriteLine( "                          Default: none" );
			Console.WriteLine( "-password userPassword    Password for 'userName' in 'userNamespace'." );
			Console.WriteLine( "                          Default: none" );
			Console.WriteLine( "-namespace userNamespace  Security namespace to log on to." );
			Console.WriteLine( "                          Default: none" );
		}
	}
}
