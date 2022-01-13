/** 
Licensed Materials - Property of IBM

IBM Cognos Products: DOCS

(C) Copyright IBM Corp. 2005, 2008

US Government Users Restricted Rights - Use, duplication or disclosure restricted by GSA ADP Schedule Contract with
IBM Corp.
*/
// *
// * Submit.sln
// *
// * Copyright (C) 2008 Cognos ULC, an IBM Company. All rights reserved.
// * Cognos (R) is a trademark of Cognos ULC, (formerly Cognos Incorporated).
// *
// * Description:  Creates a schedule on a report to be run at a specified time.
using System;
using System.Web.Services.Protocols;
using SamplesCommon;
using cognosdotnet_10_2;
using System.Globalization;

namespace Submit
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	class Submit
	{
		public Submit(){}

		static void Main(string[] args)
		{
			string cBIUrl = "";
			contentManagerService1 cBICMS = null;
			SamplesConnect connectDlg = new SamplesConnect();
			SubmitDlg submitDlgObject = new SubmitDlg();

			if (args.GetLength(0) == 0 )
			{
				// GUI mode
				connectDlg.ShowDialog();
				if (connectDlg.IsConnectedToCBI() == true) 
				{
					cBICMS = connectDlg.CBICMS;
					cBIUrl = connectDlg.CBIURL;
					submitDlgObject.setConnection(connectDlg, cBIUrl);
					submitDlgObject.setReportList(BaseClassWrapper.buildReportQueryList(cBICMS));
					submitDlgObject.setSelectedReportIndex(0);
					submitDlgObject.ShowDialog();				
				}
			}
		}

		public bool doSubmit(SamplesConnect connection, 
			string reportPath, 
			bool submitAtFlag, 
			ref string resultMessage)
		{
			if (connection.IsConnectedToCBI() == false)
			{
				resultMessage = "The Server connection provided is not valid.";
				return false;
			}
			runOption[] runOpts = new runOption[3];
			runOptionBoolean roSaveOutput = new runOptionBoolean();
			runOptionBoolean roPrompt = new runOptionBoolean();
			runOptionStringArray roOutputFormat = new runOptionStringArray();

			// We want to save this output
			roSaveOutput.name = runOptionEnum.saveOutput;
			roSaveOutput.value = true;

			//Set the report not to prompt as we pass the parameter if any
			roPrompt.name = runOptionEnum.prompt;
			roPrompt.value = false;

			//What format do we want the report in: PDF, HTML, or XML?
			roOutputFormat.name = runOptionEnum.outputFormat;
			roOutputFormat.value = new string[] { "HTML" };

			// Fill the array with the run options.
			runOpts[0] = roSaveOutput;
			runOpts[1] = roOutputFormat;
			runOpts[2] = roPrompt;

			string jobName = "NewJob";
			string jobPath =
                "/content/folder[@name='Samples']/folder[@name='Models']/package"
                + "[@name='GO Data Warehouse (query)']"
				+ "/jobDefinition[@name='"
				+ jobName
				+ "']";
			searchPathSingleObject cmJobPath = new searchPathSingleObject();
			cmJobPath.Value = jobPath;

			// set submit time to now + 2 minutes
			System.DateTime startTime = new DateTime();
			startTime = DateTime.Now;
			startTime = startTime.AddMinutes(2); 
				
			if (!createJob(connection, jobPath, jobName, new string[] { reportPath }, ref resultMessage))
			{
				return false;
			}

			// submit the job for execution
			parameterValue[] reportParameters = new parameterValue[] {};
			string reportEventID = "-1";
			if (submitAtFlag)
			{
				reportEventID = connection.CBIEMS.runAt(startTime, cmJobPath, reportParameters, runOpts);
			}
			else
			{
				asynchReply jobRunResponse = connection.CBIJS.run(cmJobPath, reportParameters, runOpts);

				if ( (!jobRunResponse.status.Equals(asynchReplyStatusEnum.complete))
					&& (!jobRunResponse.status.Equals(asynchReplyStatusEnum.conversationComplete)) )
				{
					while ( (!jobRunResponse.status.Equals(asynchReplyStatusEnum.complete))
						&& (!jobRunResponse.status.Equals(asynchReplyStatusEnum.conversationComplete)) )
					{
						//before calling wait, double check that it is okay
						if (!hasSecondaryRequest(jobRunResponse, "wait"))
						{
							resultMessage = "The Server did something wrong";
							return false;
						}
						jobRunResponse =
							connection.CBIJS.wait(
							jobRunResponse.primaryRequest,
							new parameterValue[] {},
							new option[] {});
					}
				}

				if (jobRunResponse.details != null) 
				{
					for (int i = 0; i < jobRunResponse.details.Length; i++)
					{
						if (jobRunResponse.details[i] is asynchDetailEventID)
						{
							reportEventID = ( (asynchDetailEventID) jobRunResponse.details[i]).eventID;
						}
					}
				}

				
			}

			propEnum[] propsQ = new propEnum[2];
			propsQ[0] = propEnum.searchPath;
			propsQ[1] = propEnum.defaultName;
			searchPathMultipleObject cmJobQPath = new searchPathMultipleObject();
			cmJobQPath.Value = jobPath;
			connection.CBICMS.query(cmJobQPath, propsQ, new sort[] {}, new queryOptions());

			//  show the eventID returned for the submitted report
			resultMessage = "The eventID for this job is:    "	+ reportEventID	+ "\n";

			return true;
		}

		public bool createJob(
			SamplesConnect connection,
			string jobPath,
			string  jobName,
			string[] reports,
			ref string resultMessage)
		{
			jobDefinition myJob = new jobDefinition();
			runOptionBoolean saveOutput = new runOptionBoolean();
			tokenProp jobNameProp = new tokenProp();
			optionArrayProp jobrunOptions = new optionArrayProp();
			baseClass[] jobsToAdd = new baseClass[1];
			baseClass[] bcJob = new baseClass[1];
			runOption[] runOptions = new runOption[1];
			baseClass[] parents = new baseClass[] {};
			string sPath;
			propEnum[] requestedProperties = new propEnum[3];
			addOptions addOpts = new addOptions();
			nmtokenProp stepSequenceType = new nmtokenProp();

			saveOutput.name = runOptionEnum.saveOutput;
			saveOutput.value = true;
			runOptions[0] = saveOutput;

			jobrunOptions.value = runOptions;
            myJob.options = jobrunOptions;

			jobNameProp.value = jobName;
			myJob.defaultName = jobNameProp;

			//Identify the parent object.
            sPath = "/content/folder[@name='Samples']/folder[@name='Models']/package[@name='GO Data Warehouse (query)']";

			requestedProperties[0] = propEnum.searchPath;
			requestedProperties[1] = propEnum.defaultName;
			requestedProperties[2] = propEnum.parent;

			stepSequenceType.value = "parallel";

			searchPathMultipleObject cmParentPath = new searchPathMultipleObject();
			cmParentPath.Value = sPath;
			parents = connection.CBICMS.query(cmParentPath, requestedProperties, new sort[] {}, new queryOptions());

			if (parents.GetLength(0) <= 0)
			{
				resultMessage += "Error: Unable to retrieve parent objects.\n" +
					"Failed to create job in content store.";
				return false;
			}

			myJob.sequencing = stepSequenceType;
			myJob.parent = parents[0].parent;
			jobsToAdd[0] = myJob;

			addOpts.updateAction = updateActionEnum.replace;

			searchPathSingleObject cmSPath = new searchPathSingleObject();
			cmSPath.Value = sPath;

			bcJob[0] = connection.CBICMS.add(cmSPath, jobsToAdd, addOpts)[0];

			//now, add one jobStepDefinition for each report
			jobStepDefinition[] steps = new jobStepDefinition[reports.GetLength(0)];

			for (int i = 0; i < reports.GetLength(0); i++)
			{
				baseClassArrayProp bcap = new baseClassArrayProp();
				steps[i] = new jobStepDefinition();
				stringProp searchPath = new stringProp();
				baseClass temp = (baseClass)new report();

				searchPath.value = reports[i];

				temp.searchPath = searchPath;
				baseClass[] bca = new baseClass[1];
				bca[0] = temp;
				bcap.value = bca;

				steps[i].stepObject = bcap;

				//now, add each definition to the job
				addHelper(connection, steps[i], jobPath);
			}
			return true;
		}

		/**
		 * Add an object to the Content Store.
		 *
		 * @param   bc  An object that extends baseClass, such as a Report.
		 *
		 * @return      The new object.
		 */
		public baseClass[] addHelper(SamplesConnect connection, jobStepDefinition bc, string path)
		{
			addOptions addOpts = new addOptions();
			baseClass[] jobSteps = new baseClass[1];
			addOpts.updateAction = updateActionEnum.replace;
			jobSteps[0] = bc;
			baseClass[] newbc = new baseClass[1];
			searchPathSingleObject addPath = new searchPathSingleObject();
			addPath.Value = path;
			newbc[0] = connection.CBICMS.add(addPath, jobSteps, addOpts)[0];
			return newbc;
		}


		public bool hasSecondaryRequest(asynchReply response, string secondaryRequest)
		{
			asynchSecondaryRequest[] secondaryRequests =
				response.secondaryRequests;
			for (int i = 0; i < secondaryRequests.Length; i++)
			{
				if (secondaryRequests[i].name.CompareTo(secondaryRequest)
					== 0)
				{
					return true;
				}
			}
			return false;
		}
	}
}
