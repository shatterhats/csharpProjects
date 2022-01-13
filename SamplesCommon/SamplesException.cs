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
using System.Web.Services.Protocols;
using System.Text;
using cognosdotnet_10_2;
using System.Xml;
using System.Windows.Forms;

namespace SamplesCommon
{
	/// <summary>
	/// Display a simple dialog box reporting an error to the user.
	/// </summary>
	public class SamplesException
	{
		/// <summary>
		/// You can't make this, just call the static method.
		/// </summary>
		private SamplesException()
		{
		}

		/// <summary>
		/// Turn a SoapException into a string suitable for display to a user.
		/// </summary>
		/// <param name="ex">A SoapException object.</param>
		/// <returns>A string representation of the exception.</returns>
		public static string FormatException( SoapException ex ) {
			return ExceptionHelper.ConvertToString( ex );
		}

		/// <summary>
		/// Display a SOAP exception in a simple dialog box.
		/// </summary>
		/// <param name="ex">The exception object.</param>
		/// <param name="gui">True if we should display a GUI, false if we shouldn't.</param>
		public static void ShowExceptionMessage( SoapException ex, bool gui, string title ) 
		{
			string error = ExceptionHelper.ConvertToString( ex );
			if( gui ) 
			{
				MessageBox.Show( error, title, MessageBoxButtons.OK, MessageBoxIcon.Error );
			} else 
			{
				Console.WriteLine( error );
			}
		}

		public static string getExceptionMessage( SoapException ex) 
		{
			return ExceptionHelper.ConvertToString( ex );
		}

		public static void ShowExceptionMessage( string error, bool gui, string title ) 
		{
			if( gui ) 
			{
				MessageBox.Show( error, title, MessageBoxButtons.OK, MessageBoxIcon.Error );
			} 
			else 
			{
				Console.WriteLine( error );
			}
		}
	}

}
