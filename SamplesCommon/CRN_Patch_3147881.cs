/** 
Licensed Materials - Property of IBM

IBM Cognos Products: DOCS

(C) Copyright IBM Corp. 2005

US Government Users Restricted Rights - Use, duplication or disclosure restricted by GSA ADP Schedule Contract with
IBM Corp.
*/
using System;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.IO;
using System.Net;

  // Define a SOAP Extension that traces the SOAP request and SOAP
  // response for the XML Web service method the SOAP extension is
  // applied to.

public class SOAP_Extension_3147881 : SoapExtension
{
	Stream oldStream;
	Stream newStream;
 

	// Save the Stream representing the SOAP request or SOAP response into
	// a local memory buffer.
	public override Stream ChainStream( Stream stream )
	{
		oldStream = stream;
		newStream = new MemoryStream();
		return newStream;
	}

	public override object GetInitializer(LogicalMethodInfo methodInfo, SoapExtensionAttribute attribute)
	{
		return "";
	}

	public override object GetInitializer(Type WebServiceType)
	{
		return "";   
	}

	public override void Initialize(object initializer)
	{
  
	}

	public override void ProcessMessage(SoapMessage message)
	{
		switch (message.Stage)
		{
			case SoapMessageStage.BeforeSerialize:
				break;
			case SoapMessageStage.AfterSerialize:
				newStream.Position=0;
				Copy(newStream, oldStream);
				break;
			case SoapMessageStage.BeforeDeserialize:
				adjustBiBusHeader(message);
				break;
			case SoapMessageStage.AfterDeserialize:
				break;
			default:
				throw new Exception("invalid stage");
		}
	}

	public void adjustBiBusHeader(SoapMessage message)
	{
		newStream.Position=0;
		Stream tempStream = getNewStream();
		newStream.Position=0;
		Copy(tempStream,newStream);
		newStream.Position=0;
  
	}
	private Stream getNewStream()
	{
		Copy(oldStream,newStream);
		newStream.Position=0;
		System.Text.UTF8Encoding enc = new System.Text.UTF8Encoding();
		byte[] tempBytes = new byte[(int)newStream.Length];
		newStream.Read(tempBytes,0,(int)newStream.Length);
		String inboundSOAP = enc.GetString(tempBytes);
		//enhance the open and closing tags for dispatcherTransportVars
		inboundSOAP = inboundSOAP.Replace("<bus:dispatcherTransportVars","<dispatcherTransportVars");
		inboundSOAP = inboundSOAP.Replace("</bus:dispatcherTransportVars","</dispatcherTransportVars");
		//enhance the open and closing tags for conversationContext
		inboundSOAP = inboundSOAP.Replace("<bus:conversationContext","<conversationContext");
		inboundSOAP = inboundSOAP.Replace("</bus:conversationContext","</conversationContext");
		//enhance the missing xsi:type for the conversationContext elements
		inboundSOAP = inboundSOAP.Replace("<id>","<id xsi:type=\"xsd:string\">");
		inboundSOAP = inboundSOAP.Replace("<affinityStrength>","<affinityStrength xsi:type=\"xsd:int\">");
		inboundSOAP = inboundSOAP.Replace("<status>","<status xsi:type=\"xsd:string\">");
		inboundSOAP = inboundSOAP.Replace("<bus:cookieVars","<cookieVars");
		inboundSOAP = inboundSOAP.Replace("</bus:cookieVars","</cookieVars");
		inboundSOAP = inboundSOAP.Replace("<bus:environmentVars","<environmentVars");
		inboundSOAP = inboundSOAP.Replace("</bus:environmentVars","</environmentVars");
  
		String finalXML = inboundSOAP;
		enc = new System.Text.UTF8Encoding();
		byte[] bytes = enc.GetBytes(finalXML);
  
		MemoryStream myNewStream = new MemoryStream(bytes,0,bytes.Length,true);
		myNewStream.Position=0;
		return myNewStream;
	}

	void Copy(Stream from, Stream to)
	{
		TextReader reader = new StreamReader(from);
		TextWriter writer = new StreamWriter(to);
		writer.WriteLine(reader.ReadToEnd());
		writer.Flush();
	}
}

[AttributeUsage(AttributeTargets.Method)]
public class Cognos_ReportNet_Inbound_SOAP_Patch_3147881 : SoapExtensionAttribute
{


	private int priority;

	public override Type ExtensionType
	{
		get { return typeof(SOAP_Extension_3147881); }
	}

	public override int Priority
	{
		get { return priority; }
		set { priority = value; }
	}

}

