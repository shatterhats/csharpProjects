/** 
Licensed Materials - Property of IBM

IBM Cognos Products: DOCS

(C) Copyright IBM Corp. 2005, 2008

US Government Users Restricted Rights - Use, duplication or disclosure restricted by GSA ADP Schedule Contract with
IBM Corp.
*/
// *
// * PrintReport.sln
// *
// * Copyright (C) 2008 Cognos ULC, an IBM Company. All rights reserved.
// * Cognos (R) is a trademark of Cognos ULC, (formerly Cognos Incorporated).
// *
// * Description:  Prints a report.
using System;
using System.Web.Services.Protocols;
using SamplesCommon;
using cognosdotnet_10_2;

namespace PrintReport
{
	/// <summary>
	/// Summary description for PrintReport.
	/// </summary>
	class PrintReport
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		/// 
		public PrintReport(){}

		static void Main(string[] args)
		{
			string cBIUrl = "";
			contentManagerService1 cmService = null;
			SamplesConnect connectDlg = new SamplesConnect();
			PrintReportDlg printReportDlgObject = new PrintReportDlg();
			
			if (args.GetLength(0) == 0 )
			{
				// GUI mode
				connectDlg.ShowDialog();
				if (connectDlg.IsConnectedToCBI() == true) 
				{
					cmService = connectDlg.CBICMS;
					cBIUrl = connectDlg.CBIURL;
					printReportDlgObject.setConnection(connectDlg, cBIUrl);
					printReportDlgObject.setReportList(BaseClassWrapper.buildReportQueryList(cmService));
					printReportDlgObject.setSelectedReportIndex(0);
					printReportDlgObject.ShowDialog();				
				}
			}
		}

		public baseClass[] getAvailablePrinters(SamplesConnect connection, ref string returnMessage)
		{
			try 
			{
				baseClass[] bcPrinters = new baseClass[1];
				propEnum[] props =
					new propEnum[] { propEnum.searchPath, propEnum.defaultName, propEnum.printerAddress };

				searchPathMultipleObject printersSearchPath = new searchPathMultipleObject();
				printersSearchPath.Value = "CAMID(\":\")/printer";

				bcPrinters = connection.CBICMS.query(printersSearchPath, props, new sort[] {}, new queryOptions());
				
				if ( (bcPrinters == null) || (bcPrinters.GetLength(0) == 0) )
				{
					returnMessage = "There are no printers defined on the Server.";
				}
				return bcPrinters;
			}
			catch(SoapException ex)
			{
				SamplesException.ShowExceptionMessage( ex, true, "Print Report Sample - getAvailablePrinters" );
				returnMessage = "getAvailablePrinters failed with error: " + ex.Message;
				return null;
			}
			catch(System.Exception ex)
			{
				SamplesException.ShowExceptionMessage( ex.Message, true, "Print Report Sample - getAvailablePrinters" );
				returnMessage = "getAvailablePrinters failed with error: " + ex.Message;
				return null;
			}
		}

		public bool addPrinter(SamplesConnect connection, string printerName, string printerAddress, ref string returnMessage)
		{
			try
			{
				stringProp strpropLocation = new stringProp();
				tokenProp tokenPrinterName = new tokenProp();
				printer objNewPrinter = new printer();
				
				baseClass[] bcParent = new baseClass[1];
				baseClass[] bcAddPrinter = new baseClass[1];
				baseClass[] bcNewPrinter = new baseClass[1];
				addOptions add_options = new addOptions();
				propEnum[] props =
					new propEnum[] { propEnum.searchPath, propEnum.defaultName, propEnum.parent };

				searchPathMultipleObject printersSearchString = new searchPathMultipleObject();
				printersSearchString.Value = "CAMID(\":\")/printer";

				baseClass[] bcPrinters = connection.CBICMS.query(printersSearchString, props, new sort[] {}, new queryOptions());
				            
				if ( (bcPrinters != null) && (bcPrinters.GetLength(0) > 0) )
				{
					int nbPrinters = bcPrinters.GetLength(0);
					for (int i=0; i<nbPrinters; i++)
					{
						printerName = printerName.ToLower();
						string existingPrinterName = bcPrinters[i].defaultName.value.ToLower();
				        
						if (0 == printerName.CompareTo(existingPrinterName) )
						{
							returnMessage = "A printer with this name already exists.";
							return false;
						}
					}
				}
				searchPathMultipleObject printerSiblingPath = new searchPathMultipleObject();
				printerSiblingPath.Value = "CAMID(\":\")"; 

				tokenPrinterName.value = printerName;
				strpropLocation.value = printerAddress;
				    
				//Do not set the searchPath when you add an object to the content store.
				objNewPrinter.defaultName = tokenPrinterName;
				objNewPrinter.printerAddress = strpropLocation;
				    
				//Identify the printer parent object.
				    
				bcParent = connection.CBICMS.query(printerSiblingPath, props, new sort[] {}, new queryOptions());

				searchPathSingleObject printerParentPath = new searchPathSingleObject();
				printerParentPath.Value = bcParent[0].searchPath.value;

				bcAddPrinter[0] = objNewPrinter;
				add_options.updateAction = updateActionEnum.replace;

				// sn_dg_sdk_method_contentManagerService_add_start_0
				bcNewPrinter = connection.CBICMS.add(printerParentPath, bcAddPrinter, add_options);
				// sn_dg_sdk_method_contentManagerService_add_end_0

				returnMessage = "The printer \"" + printerName + "\" was added successfully.";

			}
			catch(SoapException ex)
			{
				SamplesException.ShowExceptionMessage( ex, true, "Print Report Sample - AddPrinter" );
				returnMessage = "AddPrinter failed with error: " + ex.Message;
				return false;
			}
			catch(System.Exception ex)
			{
				SamplesException.ShowExceptionMessage( ex.Message, true, "Print Report Sample - AddPrinter" );
				returnMessage = "AddPrinter failed with error: " + ex.Message;
				return false;
			}
			return true;
		}

		public bool deletePrinter(SamplesConnect connection, string printerToDelete, ref string returnMessage)
		{
			try 
			{

				deleteOptions delete_options = new deleteOptions();
				baseClass[] bcaDeletePrinter = new baseClass[1];
				propEnum[] props =
					new propEnum[] { propEnum.searchPath, propEnum.defaultName, propEnum.parent };
			    
				//Set the force option to true. When the force option is true,
				//a selected object will be deleted if the current user has either write
				//or setPolicy permission for the following:
				//- the selected object
				//- the parent of the selected object
				//- every descendant of the selected object
				delete_options.force = true;
			    
				searchPathMultipleObject printerToDeleteSearchPath = new searchPathMultipleObject();
				printerToDeleteSearchPath.Value = "CAMID(\":\")/printer[@name='" + printerToDelete + "']";			        			    

				// sn_dg_sdk_method_contentManagerService_query_start_0
				bcaDeletePrinter = connection.CBICMS.query(printerToDeleteSearchPath, props, new sort[] {}, new queryOptions());
				// sn_dg_sdk_method_contentManagerService_query_end_0

				if ( (bcaDeletePrinter == null) || (bcaDeletePrinter.GetLength(0) == 0) )
				{
					returnMessage = "Unable to retrieve the printer \"" + printerToDelete + ".";
					return false;
				}
				// sn_dg_sdk_method_contentManagerService_delete_start_0
				int result = connection.CBICMS.delete(bcaDeletePrinter, delete_options);
				if (0 >= result)
				{
					returnMessage = "Error occured while deleting the printer.";
					return false;
				}
				// sn_dg_sdk_method_contentManagerService_delete_end_0

				returnMessage = "The printer \"" + printerToDelete + " was successfully deleted.";
			}	
			catch(SoapException ex)
			{
				SamplesException.ShowExceptionMessage( ex, true, "Print Report Sample - deletePrinter" );
				returnMessage = "DeletePrinter failed with error: " + ex.Message;
				return false;
			}
			catch(System.Exception ex)
			{
				SamplesException.ShowExceptionMessage( ex.Message, true, "Print Report Sample - deletePrinter" );
				returnMessage = "DeletePrinter failed with error: " + ex.Message;
				return false;
			}
			return true;
		}

		public bool changePrinterName(SamplesConnect connection, string originalName, string newPrinterName, ref string returnMessage)
		{
			try
			{
				baseClass[] bcAddPrinter = new baseClass[1];
				baseClass[] bcNewPrinterName = new baseClass[1];
			    
				propEnum[] props =
					new propEnum[] { propEnum.searchPath, propEnum.defaultName, propEnum.parent };
			    
				searchPathMultipleObject printersPath = new searchPathMultipleObject();
				printersPath.Value = "CAMID(\":\")/printer";

				baseClass[] bcPrinters = connection.CBICMS.query(printersPath, props, new sort[] {}, new queryOptions());
			    
				bool oldPrinterExists = false;
				if ( (bcPrinters == null) || (bcPrinters.GetLength(0) == 0) )
				{
					returnMessage = "Unable to retreive printer list";
					return false;
				}
				for (int i=0; i < bcPrinters.GetLength(0); i++)
				{    
					string existingPrinterName = bcPrinters[i].defaultName.value.ToLower();
					originalName = originalName.ToLower();
					if (0 == existingPrinterName.CompareTo(originalName))
					{
						oldPrinterExists = true;
						bcAddPrinter[0] = bcPrinters[i];
						bcAddPrinter[0].defaultName.value = newPrinterName;
					}
					if (0 == existingPrinterName.CompareTo(newPrinterName))
					{
						returnMessage = "The printer name \"" + newPrinterName + "\" already exists.";
						return false;
					}
				}
			    
				if (!oldPrinterExists)
				{
					returnMessage = "The selected printer name \"" + originalName + "\" does not exist.";
					return false;
				}

				updateOptions updateOpts = new updateOptions();
				// sn_dg_sdk_method_contentManagerService_update_start_0
				bcNewPrinterName = connection.CBICMS.update(bcAddPrinter, updateOpts);
				// sn_dg_sdk_method_contentManagerService_update_end_0
			        
				returnMessage = "The printer \"" + originalName + "\" has been renamed to \"" + newPrinterName + "\" successfully.";
				return true;
			}
			catch(SoapException ex)
			{
				SamplesException.ShowExceptionMessage( ex, true, "Print Report Sample - changePrinterName" );
				returnMessage = "changePrinterName failed with error: " + ex.Message;
				return false;
			}
			catch(System.Exception ex)
			{
				SamplesException.ShowExceptionMessage( ex.Message, true, "Print Report Sample - changePrinterName" );
				returnMessage = "changePrinterName failed with error: " + ex.Message;
				return false;
			}
		}

		public bool changePrinterAddress(SamplesConnect connection, string printerName, string newNetworkAddress, ref string returnMessage)
		{
			try
			{
				bool oldPrinterExists = false;
				printer objPrinter = new printer();
				tokenProp strNewPrinterName = new tokenProp();
				baseClass[] bcPrinters = new baseClass[1];
				baseClass[] bcAddPrinter = new baseClass[1];
				baseClass[] bcNewPrinterAddress = new baseClass[1];
				stringProp propNetworkAddress = new stringProp();
			    
				propEnum[] props =
					new propEnum[] { propEnum.searchPath, propEnum.defaultName, propEnum.parent };
			    
				searchPathMultipleObject printersSearchPath = new searchPathMultipleObject();
				printersSearchPath.Value = "CAMID(\":\")/printer";

				bcPrinters = connection.CBICMS.query(printersSearchPath, props, new sort[] {}, new queryOptions());
			    
				if ( (bcPrinters == null) || (bcPrinters.GetLength(0) == 0) )
				{
					returnMessage = "Unable to retreive printer list";
					return false;
				}
				for (int i=0; i < bcPrinters.GetLength(0); i++)
				{    
					string existingPrinterName = bcPrinters[i].defaultName.value.ToLower();
					printerName = printerName.ToLower();
					if (0 == existingPrinterName.CompareTo(printerName))
					{
						oldPrinterExists = true;
						objPrinter.defaultName = new tokenProp();
						objPrinter.defaultName.value = printerName;
						objPrinter.searchPath = new stringProp();
						objPrinter.searchPath.value = bcPrinters[i].searchPath.value;
					}
				}
			    
				if (!oldPrinterExists)
				{
					returnMessage = "The printer to be modified: \"" + printerName + "\" does not exist.";
					return false;
				}
			    
				propNetworkAddress.value = newNetworkAddress;
				objPrinter.printerAddress = new stringProp();
				objPrinter.printerAddress = propNetworkAddress;
				bcAddPrinter[0] = objPrinter;
				                    
				updateOptions updateOpts = new updateOptions();
				bcNewPrinterAddress = connection.CBICMS.update(bcAddPrinter, updateOpts );

			        
				returnMessage = "The printer \"" + printerName + "\" is now set to the network address \"" + newNetworkAddress + ".";
				return true;

			}
			catch(SoapException ex)
			{
				SamplesException.ShowExceptionMessage( ex, true, "Print Report Sample - changePrinterAddress" );
				returnMessage = "changePrinterAddress failed with error: " + ex.Message;
				return false;
			}
			catch(System.Exception ex)
			{
				SamplesException.ShowExceptionMessage( ex.Message, true, "Print Report Sample - changePrinterAddress" );
				returnMessage = "changePrinterAddress failed with error: " + ex.Message;
				return false;
			}
		}

		public bool startPrint(SamplesConnect connection, string printerSearchPath, string reportPath, ref string returnMessage)
		{
			try
			{
				runOptionBoolean saveOutputFlag = new runOptionBoolean();
				saveOutputFlag.name = runOptionEnum.saveOutput;
				saveOutputFlag.value = false;

				string[] stringFormat = new string[1];
				stringFormat[0] = "PDF";
				runOptionStringArray outputFormatStrArr = new runOptionStringArray();
				outputFormatStrArr.name = runOptionEnum.outputFormat;
				outputFormatStrArr.value = stringFormat;

				asynchOptionBoolean includePrimaryRequestFlag = new asynchOptionBoolean();
				includePrimaryRequestFlag.name = asynchOptionEnum.alwaysIncludePrimaryRequest;
				includePrimaryRequestFlag.value = true;

				asynchOptionInt primaryWaitThreshold = new asynchOptionInt();
				primaryWaitThreshold.name = asynchOptionEnum.primaryWaitThreshold;
				primaryWaitThreshold.value = 0;

				runOptionBoolean promptFlag = new runOptionBoolean();
				promptFlag.name = runOptionEnum.prompt;
				promptFlag.value = false;

				option[] runOpts = new option[5];
				runOpts[0] = saveOutputFlag;
				runOpts[1] = outputFormatStrArr;
				runOpts[2] = includePrimaryRequestFlag;
				runOpts[3] = primaryWaitThreshold;
				runOpts[4] = promptFlag;

				searchPathSingleObject reportSearchPath = new searchPathSingleObject();
				reportSearchPath.Value = reportPath;

				asynchReply reportResponse = connection.CBIRS.run(reportSearchPath, new parameterValue[] {}, runOpts);

				runOptionBoolean printRunOpts = new runOptionBoolean();
				
				printRunOpts.name = runOptionEnum.print;
				printRunOpts.value = true;

				runOptionString printerRunOpts = new runOptionString();
				printerRunOpts.name = runOptionEnum.printer;
				printerRunOpts.value = printerSearchPath;

				option[] printOpts = new option[2];
				printOpts[0] = printRunOpts;
				printOpts[1] = printerRunOpts;

				connection.CBIRS.deliver(reportResponse.primaryRequest, new parameterValue[] {}, printOpts);

				//If the request has not yet completed, keep waiting until it has finished
				// sn_dg_sdk_method_reportService_wait_start_0
				while (reportResponse.status != asynchReplyStatusEnum.complete) 
				{
					reportResponse = connection.CBIRS.wait(reportResponse.primaryRequest, new parameterValue[] {}, new option[] {} );
				}				
				// sn_dg_sdk_method_reportService_wait_end_0

				returnMessage = "The report \"" + reportPath + "\"has been submitted to the printer successfully.";
				return true;
			}
			catch(SoapException ex)
			{
				SamplesException.ShowExceptionMessage( ex, true, "Print Report Sample - startPrint" );
				returnMessage = "startPrint failed with error: " + ex.Message;
				return false;
			}
			catch(System.Exception ex)
			{
				SamplesException.ShowExceptionMessage( ex.Message, true, "Print Report Sample - startPrint" );
				returnMessage = "startPrint failed with error: " + ex.Message;
				return false;
			}
		}


	}
}
