/** 
Licensed Materials - Property of IBM

IBM Cognos Products: DOCS

(C) Copyright IBM Corp. 2005, 2008

US Government Users Restricted Rights - Use, duplication or disclosure restricted by GSA ADP Schedule Contract with
IBM Corp.
*/
// *
// * Email.sln
// *
// * Copyright (C) 2008 Cognos ULC, an IBM Company. All rights reserved.
// * Cognos (R) is a trademark of Cognos ULC, (formerly Cognos Incorporated).
// *
// * Description: This code sample demonstrates how to run a report and send the output to a specific
// *              user using the run and deliver methods.
// *

using System;
using System.Web.Services.Protocols;
using System.Windows.Forms;
using SamplesCommon;
using cognosdotnet_10_2;

namespace Email
{
	class EmailArgsObject
	{
		public BaseClassWrapper reportObj = null;
		public string emailAddress = "";
		public string emailSubject = "";
		public string emailBody = "";
		public Email emailObject = null;

		public EmailArgsObject(Email emailObj, BaseClassWrapper repObj, string addr, string subj, string body)
		{
			emailObject = emailObj;
			reportObj = repObj;
			emailAddress = addr;
			emailSubject = subj;
			emailBody = body;
		}
	}

	/// <summary>
	/// Summary description for Email.
	/// </summary>
	class Email
	{
		public Email(){}

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		static void Main(string[] args)
		{
            Control.CheckForIllegalCrossThreadCalls = false;
			string cBIUrl = "";
			contentManagerService1 cmService = null;
			EmailDlg emailDlgObject = new EmailDlg();
			SamplesConnect connectDlg = new SamplesConnect();
			
			if (args.GetLength(0) == 0 )
			{
				// GUI mode
				connectDlg.ShowDialog();
				if (connectDlg.IsConnectedToCBI() == true) 
				{
					cmService = connectDlg.CBICMS;
					cBIUrl = connectDlg.CBIURL;
					emailDlgObject.setConnection(connectDlg, cBIUrl);
					emailDlgObject.setReportList(BaseClassWrapper.buildReportQueryList(cmService));
					emailDlgObject.setSelectedReportIndex(0);
					emailDlgObject.addEmailOptions();
					emailDlgObject.setSelectedEmailOption(0);
					emailDlgObject.ShowDialog();				
				}
			}
		}

		public string sendEmail(SamplesConnect connection, 
			BaseClassWrapper reportOrQueryObject, 
			string emailAddress, 
			string emailSubject, 
			string emailBody)
		{
			if (connection == null)
			{
				return "...the connection is invalid.\n";
			}
			option[] emailRunOptions = new option[4]; // holds the run options for running the report
			option[] emailOptions = new option[5];    // holds all other email options for delivering the output
			
			// 1. Set the run options
			runOptionStringArray deliveryFormat = new runOptionStringArray();
			string[] formatList = new string[1];
			formatList[0] = "HTML";
			deliveryFormat.name = runOptionEnum.outputFormat;
			deliveryFormat.value = formatList;
			emailRunOptions[0] = deliveryFormat;

			runOptionBoolean promptFlag = new runOptionBoolean();
			promptFlag.name = runOptionEnum.prompt;
			promptFlag.value = false;
			emailRunOptions[1] = promptFlag;

			// Set the primary wait threshold
			asynchOptionInt primaryWaitRunOpts = new asynchOptionInt();
			primaryWaitRunOpts.name = asynchOptionEnum.primaryWaitThreshold;
			primaryWaitRunOpts.value = 0;
			emailRunOptions[2] = primaryWaitRunOpts;

			asynchOptionBoolean alwaysIncludePrimaryRequestFlag = new asynchOptionBoolean();
			alwaysIncludePrimaryRequestFlag.name = asynchOptionEnum.alwaysIncludePrimaryRequest;
			alwaysIncludePrimaryRequestFlag.value = true;
			emailRunOptions[3] = alwaysIncludePrimaryRequestFlag;

			// 2. Set the delivery options
            // a) specify email delivery
            runOptionBoolean emailDelivery = new runOptionBoolean();
            emailDelivery.name = runOptionEnum.email;
            emailDelivery.value = true;
            emailOptions[0] = emailDelivery;

			// b) set the output to be an email attachment
			runOptionBoolean emailAttach = new runOptionBoolean();
			emailAttach.name = runOptionEnum.emailAsAttachment;
			emailAttach.value = true;
			emailOptions[1] = emailAttach;

			// c) Set the email body
			memoPartString memoText = new memoPartString();
			memoText.name = "Body";
			memoText.text = emailBody;
			memoText.contentDisposition = smtpContentDispositionEnum.inline;
			deliveryOptionMemoPart bodyMemo = new deliveryOptionMemoPart();
			bodyMemo.name = deliveryOptionEnum.memoPart;
			bodyMemo.value = memoText;
			emailOptions[2] = bodyMemo;
			
			// d) Set the email address(es)
			if (0 != emailAddress.CompareTo(""))
			{
				addressSMTP singleAddress = new addressSMTP();
                singleAddress.Value = emailAddress;
				addressSMTP[] addressValue = new addressSMTP[] {singleAddress};
				
				// c) i. Option is set to email to a specific user
				deliveryOptionAddressSMTPArray addressDeliveryOption = new deliveryOptionAddressSMTPArray();
				addressDeliveryOption.name = deliveryOptionEnum.toAddress;
				addressDeliveryOption.value = addressValue;
				emailOptions[3] = addressDeliveryOption;
			}
			else
			{
				// c) ii. Option is set to email to all contacts
				deliveryOptionAddressSMTPArray addressDeliveryOption = new deliveryOptionAddressSMTPArray();
				addressDeliveryOption.name = deliveryOptionEnum.toAddress;
				addressDeliveryOption.value = getContactEmails(connection.CBICMS);
				emailOptions[3] = addressDeliveryOption;
			}

			// e) Set the email subject
			deliveryOptionString subjectOptionString = new deliveryOptionString();
			subjectOptionString.name = deliveryOptionEnum.subject;
			subjectOptionString.value = emailSubject;
			emailOptions[4] = subjectOptionString;

			searchPathSingleObject reportPath = new searchPathSingleObject();
			reportPath.Value = reportOrQueryObject.searchPath.value;

			// execute the report
			// sn_dg_sdk_method_reportService_deliver_start_0
			asynchReply sendEmailResponse =  connection.CBIRS.run(
				reportPath, 
				new parameterValue[] {}, 
				emailRunOptions);
            connection.CBIRS.deliver(sendEmailResponse.primaryRequest, new parameterValue[] { }, emailOptions);
            // sn_dg_sdk_method_reportService_deliver_end_0

            //If the request has not yet completed, keep waiting until it has finished
            while ((sendEmailResponse.status != asynchReplyStatusEnum.complete) &&
                (sendEmailResponse.status != asynchReplyStatusEnum.conversationComplete))
            {
                sendEmailResponse = connection.CBIRS.wait(sendEmailResponse.primaryRequest, new parameterValue[] { }, new option[] { });
            }

			return "...the report : \"" + reportOrQueryObject.defaultName.value + "\" was successfully emailed.\n";
		}

		public addressSMTP[] getContactEmails(contentManagerService1 cmService)
		{
			try
			{
				baseClass[] bcContacts = new baseClass[0];
				contact contacts = new contact();
				runOptionStringArray arrStrAddressRunOpts = new runOptionStringArray();
			    
				propEnum[] props = 
					new propEnum[] { propEnum.searchPath, propEnum.defaultName, propEnum.email };
			    
				searchPathMultipleObject contactSearchPath = new searchPathMultipleObject();
				contactSearchPath.Value = "CAMID(\":\")/contact";

				bcContacts = cmService.query(contactSearchPath, props, new sort[] {}, new queryOptions());
				int nbContacts = bcContacts.GetLength(0);
				addressSMTP[] contactList = new addressSMTP[nbContacts];
				
				if ( (bcContacts == null) || (nbContacts <= 0) )
				{
					//No contacts setup in Content Store
					return contactList;
				}
				else
				{
					for(int i=0; i<nbContacts; i++)
					{
						baseClass bc = bcContacts[i];
						contacts = (contact)bc;
						contactList[i] = new addressSMTP();
						contactList[i].Value = contacts.email.value;
					}		        
				}
				return contactList;
			}
			catch(SoapException ex)
			{
				SamplesException.ShowExceptionMessage( ex, true, "Email" );
				return null;
			}
			catch(System.Exception ex)
			{
				SamplesException.ShowExceptionMessage( ex.Message, true, "Email" );
				return null;
			}
		}
	}
}
