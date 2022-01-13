/** 
Licensed Materials - Property of IBM

IBM Cognos Products: DOCS

(C) Copyright IBM Corp. 2005, 2007

US Government Users Restricted Rights - Use, duplication or disclosure restricted by GSA ADP Schedule Contract with
IBM Corp.
*/
using System;
using System.Web.Services.Protocols;
using System.Xml;
using System.Text;

namespace Exceptions
{
	/// <summary>
	/// Simple exception object for use with IBM Cognos.
	/// </summary>
	public class CognosException
	{
		private SoapException _exception = null;

		/// <summary>
		/// Create a CognosException object.
		/// </summary>
		/// <param name="ex">A SoapException thrown by an IBM Cognos method call.</param>
		public CognosException( SoapException ex )
		{
			_exception = ex;
		}

		/// <summary>
		/// Return the exception message.
		/// </summary>
		public string Message {
			get {
				return _exception.Message;
			}
		}

		/// <summary>
		/// Return the exception severity.
		/// </summary>
		public string Severity {
			get {
				return _exception.Detail.SelectSingleNode( "//severity" ).InnerText;
			}
		}

		/// <summary>
		/// Return the exception errorCode.
		/// </summary>
		public string ErrorCode {
			get {
				return _exception.Detail.SelectSingleNode( "//errorCode" ).InnerText;
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
		/// Convert this CognosException into a string for printing.
		/// </summary>
		/// <returns>A string representation of the CognosException.</returns>
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
		/// Convert a SoapException into a CognosException string.
		/// 
		/// This is the same as creating a CognosException and calling
		/// its ToString() method.
		/// </summary>
		/// <param name="ex">The SoapException to format.</param>
		/// <returns>A string representation.</returns>
		static public string ConvertToString( SoapException ex ) {
			CognosException exception = new CognosException( ex );

			return exception.ToString();
		}
	}
}
