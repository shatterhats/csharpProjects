/** 
Licensed Materials - Property of IBM

IBM Cognos Products: DOCS

(C) Copyright IBM Corp. 2005, 2007

US Government Users Restricted Rights - Use, duplication or disclosure restricted by GSA ADP Schedule Contract with
IBM Corp.
*/
//  Copyright (C) 2007 Cognos ULC, an IBM Company. All rights reserved.
//  Cognos (R) is a trademark of Cognos ULC, (formerly Cognos Incorporated).
// sn_dg_sdk_headerexception_start_1

using System;
using System.Text;
using cognosdotnet_10_2;

namespace SamplesCommon
{
	/// <summary>
	/// Extract the interesting bits from a biBusHeader after a biBusHeader
	/// fault.
	/// </summary>
	public class HeaderExceptionHelper
	{
		private CAMException _exception = null;

		/// <summary>
		/// Create a HeaderExceptionHelper object.
		/// </summary>
		/// <param name="crn">The contentManagerService1 object in use during the last exception.</param>
		public HeaderExceptionHelper( contentManagerService1 cmService )
		{
			// Pull the CAM exception out of the biBusHeader.
			_exception = cmService.biBusHeaderValue.CAM.exception;
		}

		/// <summary>
		/// Get the Severity string from this biBusHeader exception.
		/// </summary>
		public string Severity {
			get {
				return _exception.severity.ToString();
			}
		}

		/// <summary>
		/// Get the errorCode string from this biBusHeader exception.
		/// </summary>
		public string ErrorCode {
			get {
				return _exception.errorCodeString;
			}
		}

		/// <summary>
		/// Get the details (messageString) from this biBusHeader exception.
		/// </summary>
		public string[] Details {
			get {
				string[] retval = new string[_exception.messages.Length];

				for( int idx = 0; idx < _exception.messages.Length; idx++ ) {
					retval[idx] = _exception.messages[idx].messageString;
				}

				return retval;
			}
		}

		/// <summary>
		/// Get the promptInfo (and useful captions/displayObjects inside) to 
		/// facilitate prompting the user, if this is a recoverable exception.
		/// </summary>
		public promptInfo PromptInfo {
			get {
				return _exception.promptInfo;
			}
		}

		/// <summary>
		/// Convert this biBusHeader exception into a string for printing.
		/// </summary>
		/// <returns>A string representation of the biBusHeader exception.</returns>
		public override string ToString() {
			StringBuilder str = new StringBuilder();
			
			str.AppendFormat( "Severity:  {0}\n", Severity );
			str.AppendFormat( "ErrorCode: {0}\n", ErrorCode );
			str.AppendFormat( "Details:\n" );
			foreach( string s in Details ) {
				str.AppendFormat( "\t{0}\n", s );
			}

			return str.ToString();
		}

		/// <summary>
		/// Convert a biBusHeader exception into a string.
		/// 
		/// This is the same as creating a HeaderExceptionHelper and calling
		/// its ToString() method.
		/// </summary>
		/// <param name="ex">The Service object that threw the exception.</param>
		/// <returns>A string representation of the biBusHeader exception.</returns>
		static public string ConvertToString( contentManagerService1 cmService ) {
			HeaderExceptionHelper exception = new HeaderExceptionHelper( cmService );

			return exception.ToString();
		}
	}
}
// sn_dg_sdk_headerexception_end_1
