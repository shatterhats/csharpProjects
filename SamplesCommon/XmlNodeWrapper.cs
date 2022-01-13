/** 
Licensed Materials - Property of IBM

IBM Cognos Products: DOCS

(C) Copyright IBM Corp. 2005

US Government Users Restricted Rights - Use, duplication or disclosure restricted by GSA ADP Schedule Contract with
IBM Corp.
*/
using System;
using System.Xml;

namespace SamplesCommon
{
	/// <summary>
	/// Summary description for XmlNodeWrapper.
	/// </summary>
	public class XmlNodeWrapper
	{
		private XmlNode m_node = null;

		private XmlNodeWrapper(){}

		public XmlNodeWrapper(XmlNode node)
		{
			m_node = node;
		}

		public XmlNode XMLNODE
		{
			set
			{
				m_node = value;
			}

			get
			{
				return m_node;
			}
		}

		public override string ToString()
		{
			return m_node.Attributes.GetNamedItem("name").InnerText;
		}

		public string PATH
		{
			get
			{
				string pkgPath = m_node.Attributes.GetNamedItem("_path").InnerText;

				//strip the pkg element from the path
				string path = pkgPath.Substring(pkgPath.IndexOf(".") + 1);
				return path;

			}
		}
	}
}
