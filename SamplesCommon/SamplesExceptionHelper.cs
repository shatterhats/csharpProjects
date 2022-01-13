/** 
Licensed Materials - Property of IBM

IBM Cognos Products: DOCS

(C) Copyright IBM Corp. 2005, 2008

US Government Users Restricted Rights - Use, duplication or disclosure restricted by GSA ADP Schedule Contract with
IBM Corp.
*/
//  Copyright (C) 2008 Cognos ULC, an IBM Company. All rights reserved.
//  Cognos (R) is a trademark of Cognos ULC, (formerly Cognos Incorporated).

// sn_dg_sdk_exception_start_1
using System;
using System.Web.Services.Protocols;
using System.Xml;
using System.Text;

namespace SamplesCommon
{
	/// <summary>
	/// Simple exception handling object for use with IBM Cognos.
	/// </summary>
	public class ExceptionHelper
	{
		private SoapException _exception = null;

		/// <summary>
		/// Create an ExceptionHelper object.
		/// </summary>
		/// <param name="ex">A SoapException thrown by a call to an IBM Cognos service.</param>
		public ExceptionHelper( SoapException ex )
		{
			_exception = ex;
		}

		/// <summary>
		/// Return the exception message.
		/// </summary>
		public string Message 
		{
			get 
			{
				return _exception.Message;
			}
		}

		/// <summary>
		/// Return the exception severity.
		/// </summary>
		public string Severity 
		{
			get 
			{
				XmlNode severityNode = _exception.Detail.SelectSingleNode( "//severity" );
				if (severityNode != null)
				{
					return severityNode.InnerText;
				}
				return "";
			}
		}

		/// <summary>
		/// Return the exception errorCode.
		/// </summary>
		public string ErrorCode 
		{
			get 
			{
				XmlNode errorNode = _exception.Detail.SelectSingleNode( "//errorCode" );
				if (errorNode != null)
				{
					return errorNode.InnerText;
				}
				return "";
			}
		}

		/// <summary>
		/// Return the exception messageStrings.
		/// </summary>
		public string[] Details {
			get {
				XmlNodeList nodes = _exception.Detail.SelectNodes( "//messageString" );
				string[] retval = new string[nodes.Count];
				for( int idx = 0; idx < nodes.Count; idx++ ) {
					retval[idx] = nodes[idx].InnerText;
				}

				return retval;
			}
		}

		/// <summary>
		/// Convert this exception into a string for printing.
		/// </summary>
		/// <returns>A string representation of the exception.</returns>
		public override string ToString() {
			StringBuilder str = new StringBuilder();
			
			str.AppendFormat( "Message:   {0}\n", Message );
			str.AppendFormat( "Severity:  {0}\n", Severity );
			str.AppendFormat( "ErrorCode: {0}\n", ErrorCode );
			str.AppendFormat( "Details:\n" );
			foreach( string s in Details ) {
				str.AppendFormat( "\t{0}\n", s );
			}

			return str.ToString();
		}

		/// <summary>
		/// Convert a SoapException into an exception string.
		/// 
		/// This is the same as creating an ExceptionHelper and calling
		/// its ToString() method.
		/// </summary>
		/// <param name="ex">The SoapException to format.</param>
		/// <returns>A string representation of the exception.</returns>
		static public string ConvertToString( SoapException ex ) {
			ExceptionHelper exception = new ExceptionHelper( ex );

			return exception.ToString();
		}
	}
}
// sn_dg_sdk_exception_end_1
