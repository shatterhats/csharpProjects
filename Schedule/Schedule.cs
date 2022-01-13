/** 
Licensed Materials - Property of IBM

IBM Cognos Products: DOCS

(C) Copyright IBM Corp. 2005, 2007

US Government Users Restricted Rights - Use, duplication or disclosure restricted by GSA ADP Schedule Contract with
IBM Corp.
*/
// *
// * Schedule.sln
// *
// * Copyright (C) 2007 Cognos ULC, an IBM Company. All rights reserved.
// * Cognos (R) is a trademark of Cognos ULC, (formerly Cognos Incorporated).
// *
// * Description:  Schedule running a report.
using System;
using System.Web.Services.Protocols;
using SamplesCommon;

using System.Globalization;

using cognosdotnet_10_2;

namespace Schedule
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	class Schedule
	{
		public Schedule(){}

		static void Main(string[] args)
		{
			string cBIUrl = "";
			contentManagerService1 cBICMS = null;
			SamplesConnect connectDlg = new SamplesConnect();
			ScheduleDlg schedDlgObject = new ScheduleDlg();

			if (args.GetLength(0) == 0 )
			{
				// GUI mode
				connectDlg.ShowDialog();
				if (connectDlg.IsConnectedToCBI() == true) 
				{
					cBICMS = connectDlg.CBICMS;
					cBIUrl = connectDlg.CBIURL;
					schedDlgObject.setConnection(connectDlg, cBIUrl);
					schedDlgObject.setReportList(BaseClassWrapper.buildReportQueryList(cBICMS));
					schedDlgObject.setSelectedReportIndex(0);
					schedDlgObject.ShowDialog();				
				}
			}
		}

		//Create a simple schedule
		public bool createSchedule(
			SamplesConnect connection,
			BaseClassWrapper reportToSchedule,
			ref string resultMessage)
		{
			schedule newSched = new schedule();

			//
			//Set the schedule properties
			//

			// sn_dg_prm_smpl_schedulereport_P1_start_0
			//get the credential for the schedule
			credential schedCred = connection.getCredential();
			baseClassArrayProp credentials = new baseClassArrayProp();
			credentials.value = new baseClass[] {schedCred};
			newSched.credential = credentials;
			// sn_dg_prm_smpl_schedulereport_P1_end_0

			// sn_dg_prm_smpl_schedulereport_P5_start_0
			//mark the schedule as active
			booleanProp isActive = new booleanProp();
			isActive.value = true;
			newSched.active = isActive;

			//Set the type of schedule
			cognosdotnet_10_2.nmtokenProp scheduleType = new nmtokenProp();
			scheduleType.value = "daily";
			newSched.type = scheduleType;
		
			//make the schedule for every x minutes
			nmtokenProp period = new nmtokenProp();
			period.value = "minute";
			newSched.dailyPeriod = period;

			//set that every x minutes to be every 1 minute
			positiveIntegerProp runFreqProp = new positiveIntegerProp();
			runFreqProp.value = "1";
			newSched.everyNPeriods = runFreqProp;
			// sn_dg_prm_smpl_schedulereport_P5_end_0

			// sn_dg_prm_smpl_schedulereport_P3_start_0
			//set the owner
			baseClassArrayProp ownersProp = new baseClassArrayProp();
			baseClass[] owners = new baseClass[] { SamplesConnect.getLogonAccount(connection) };
			ownersProp.value = owners;
			newSched.owner = ownersProp;
			// sn_dg_prm_smpl_schedulereport_P3_end_0

			// sn_dg_prm_smpl_schedulereport_P2_start_0
			// set schedule time to now + 2 minutes
			System.DateTime startTime = new DateTime();
			startTime = DateTime.Now;
			startTime = startTime.AddMinutes(2);
			dateTimeProp schedStartTime = new dateTimeProp();
			schedStartTime.value = startTime;
			newSched.startDate = schedStartTime;

			// set schedule end time to now + 5 minutes
			System.DateTime endTime = new DateTime();
			endTime = DateTime.Now;
			endTime = endTime.AddMinutes(5);
			dateTimeProp schedEndTime = new dateTimeProp();
			schedEndTime.value = endTime;
			newSched.endDate = schedEndTime;

			// set the schedule end type
			nmtokenProp endType = new nmtokenProp();
			endType.value = "onDate";
			newSched.endType = endType;
			// sn_dg_prm_smpl_schedulereport_P2_end_0

			//
			//Build the run options for the schedule
			//

			// sn_dg_prm_smpl_schedulereport_P4_start_0
			//Set the name of the reportView
			multilingualToken[] reportViewName = new multilingualToken[1];
			reportViewName[0] = new multilingualToken();
			reportViewName[0].locale = "en-us";
			reportViewName[0].value = "View of Report " + reportToSchedule.baseclassobject.defaultName.value;

			//Save the output as report view with name saveasName
			runOptionSaveAs saveAs = new runOptionSaveAs();
			saveAs.name = runOptionEnum.saveAs;
			saveAs.objectClass = reportSaveAsEnum.reportView;
			saveAs.objectName = reportViewName;
			saveAs.parentSearchPath = reportToSchedule.parentPath.value;

			//Turn off prompting
			runOptionBoolean prompt = new runOptionBoolean();
			prompt.name = runOptionEnum.prompt;
			prompt.value = false;

			//set the output format
			runOptionStringArray format = new runOptionStringArray();
			format.name = runOptionEnum.outputFormat;
			format.value = new string[] { "HTML" };

			//put the run options where they need to go
			runOption[] schedRunOptArr = new runOption[3];
			schedRunOptArr[0] = saveAs;
			schedRunOptArr[1] = prompt;
			schedRunOptArr[2] = format;

			optionArrayProp schedRunOptions = new optionArrayProp();
			schedRunOptions.value = schedRunOptArr;
			newSched.options = schedRunOptions;
			// sn_dg_prm_smpl_schedulereport_P4_end_0

			// sn_dg_prm_smpl_schedulereport_P5_start_1
			searchPathSingleObject reportSearchPath = new searchPathSingleObject();
			reportSearchPath.Value = ((baseClass) reportToSchedule.baseclassobject).searchPath.value;
			//  add the schedule to the report
			addOptions ao = new addOptions();
			ao.updateAction = updateActionEnum.replace;
			baseClass newBc = connection.CBICMS.add(
				reportSearchPath,
				new baseClass[] { newSched },
				ao)[0];
			// sn_dg_prm_smpl_schedulereport_P5_end_1

			if (newBc != null)
			{
				resultMessage = "Schedule Created";
				return true;
			}
			resultMessage = "Schedule Creation Failed.";
			return false;
		}

	
	}
}
