/** 
Licensed Materials - Property of IBM

IBM Cognos Products: DOCS

(C) Copyright IBM Corp. 2005, 2010

US Government Users Restricted Rights - Use, duplication or disclosure restricted by GSA ADP Schedule Contract with
IBM Corp.
*/
/**
 * CreateReport.cs
 *
 * Copyright (C) 2008 Cognos ULC, an IBM Company. All rights reserved.
 * Cognos (R) is a trademark of Cognos ULC, (formerly Cognos Incorporated).
 *
 * Description: This code sample demonstrates how to create reports using the 
 *              following methods:
 *				- query(searchPath, properties, sortBy, options)
 *				- add(parentPath, object, options)
 *				- runSpecification(specification, parameterValues, options)
 *				- wait(conversation, parameterValues, options)
 *
 */

using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Web.Services.Protocols;
using SamplesCommon;
using cognosdotnet_10_2;
using System.Xml;

namespace CreateReport
{
	public class TableData
	{
		public TableData m_tableNameColumnMap;
		public string m_tableName = "";
		public XmlNodeWrapper[] m_columns = null;

		public TableData()
		{
			m_tableName = "";
			m_columns = null;
		}

		public TableData(string tbName, XmlNodeWrapper[] cols)
		{
			m_tableName = tbName;
			int nbCols = cols.GetLength(0);
			m_columns = new XmlNodeWrapper[nbCols];
			m_columns = cols;
		}

		public string getTableName()
		{
			return m_tableName;
		}

		public XmlNodeWrapper[] getColumns()
		{
			return m_columns;
		}

	}


	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	class CreateReport
	{
		public CreateReport(){}
		
		static void Main(string[] args)
		{
			SamplesConnect connectDlg = new SamplesConnect();
			CreateReportDlg createReportDlgObject = new CreateReportDlg();

			if (args.GetLength(0) == 0 )
			{
				// GUI mode
				connectDlg.ShowDialog();
				if (connectDlg.IsConnectedToCBI() == true) 
				{
					createReportDlgObject.setConnection(connectDlg);
					createReportDlgObject.ShowDialog();				
				}
			}
		}

		public string getPackageName(SamplesConnect connection)
		{
			string packageName = "";
			try
			{
				// 1. Prompt for the Package Name
				PackageNameDlg packageNameDlg = new PackageNameDlg();
				packageNameDlg.setConnection(connection);

				// 1.1 get the list of baseClass packages
				sort[] sortOptions = { new sort() };
				sortOptions[0].order = orderEnum.ascending;
				sortOptions[0].propName = propEnum.defaultName;
				propEnum[] props = new propEnum[] { propEnum.searchPath, propEnum.defaultName };

				searchPathMultipleObject packagesPath = new searchPathMultipleObject();
				packagesPath.Value = "/content//package";
				baseClass[] bc = connection.CBICMS.query(packagesPath, props, sortOptions, new queryOptions());

				// 1.2 Get the name of each package from the baseClass object 
				// to display in the dropdown list.   
				string[] packageNames = new string[bc.GetLength(0)];
				for (int i = 0; i < bc.GetLength(0); i++)
				{
					packageNames[i] = bc[i].defaultName.value;
				}
				packageNameDlg.setPackageNames(packageNames);
				packageNameDlg.setSelectedPackage(1);
				packageNameDlg.ShowDialog();
				if (packageNameDlg.isOKed)
				{
					packageName = packageNameDlg.getSelectedPackageName();
				}
				else
				{
					return "";
				}
			}
			catch(SoapException ex)
			{
				SamplesException.ShowExceptionMessage( ex, true, "Create Report Sample - getPackageName" );
				return "";
			}
			catch(System.Exception ex)
			{
				SamplesException.ShowExceptionMessage( ex.Message, true, "Create Report Sample - getPackageName" );
				return "";
			}
			return packageName;
		}

		public string getReportName()
		{
			try
			{
				string reportName = "";
					
				// 2. Prompt for the new report name
				ReportNameDlg reportNameDlg = new ReportNameDlg();
				reportNameDlg.ShowDialog();
				if (reportNameDlg.isOKed)
				{
					// 2.1 Get the name of the report entered by the user
					reportName = reportNameDlg.getReportName();
				}
				else
				{
					return "";
				}
				return reportName;
			}
			catch(SoapException ex)
			{
				SamplesException.ShowExceptionMessage( ex, true, "Create Report Sample - getReportName" );
				return "";
			}
			catch(System.Exception ex)
			{
				SamplesException.ShowExceptionMessage( ex.Message, true, "Create Report Sample - getReportName" );
				return "";
			}

		}

		public XmlNode buildListColumnNode(XmlDocument xmlDoc, string myNameSpace, string columnLabel, string columnValue)
		{
			XmlNode nextNode, currentNode, listColumnNode, styleNode, currentStyleNode;
			XmlAttribute attribNode;

			listColumnNode = xmlDoc.CreateNode(XmlNodeType.Element, "listColumn", myNameSpace);

			//Build listColumnTitle from the bottom up
			//dataItemLabel
			// sn_dg_prm_smpl_modifyreport_P2_start_0
			currentNode = xmlDoc.CreateNode(XmlNodeType.Element, "dataItemLabel", myNameSpace);
			attribNode = xmlDoc.CreateAttribute("refDataItem");
			attribNode.Value = columnLabel;
			currentNode.Attributes.Append(attribNode);
			// sn_dg_prm_smpl_modifyreport_P2_end_0

			//dataSource
			nextNode = xmlDoc.CreateNode(XmlNodeType.Element, "dataSource", myNameSpace);
			nextNode.AppendChild(currentNode);
			currentNode = nextNode;

			//textItem
			nextNode = xmlDoc.CreateNode(XmlNodeType.Element, "textItem", myNameSpace);
			nextNode.AppendChild(currentNode);
			currentNode = nextNode;

			//contents
			nextNode = xmlDoc.CreateNode(XmlNodeType.Element, "contents", myNameSpace);
			nextNode.AppendChild(currentNode);
			currentNode = nextNode;

            //style for listColumnTitle
            nextNode = xmlDoc.CreateNode(XmlNodeType.Element, "defaultStyle", myNameSpace);
            attribNode = xmlDoc.CreateAttribute("refStyle");
            attribNode.Value = "lt";
            nextNode.Attributes.Append(attribNode);
            currentStyleNode = nextNode;

            nextNode = xmlDoc.CreateNode(XmlNodeType.Element, "defaultStyles", myNameSpace);
            nextNode.AppendChild(currentStyleNode); //defaultStyle
            currentStyleNode = nextNode;

            nextNode = xmlDoc.CreateNode(XmlNodeType.Element, "style", myNameSpace);
            nextNode.AppendChild(currentStyleNode); //defaultStyles
            styleNode = nextNode;

            //listColumnTitle
			nextNode = xmlDoc.CreateNode(XmlNodeType.Element,"listColumnTitle", myNameSpace);

            nextNode.AppendChild(styleNode); //style
            nextNode.AppendChild(currentNode);

			//Add the listColumnTitle Element to the listColumnElement
			listColumnNode.AppendChild(nextNode);

			//Build listColumnBody from the bottom up
			//dataItemValue
			// sn_dg_prm_smpl_modifyreport_P2_start_1
			currentNode = xmlDoc.CreateNode(XmlNodeType.Element, "dataItemValue", myNameSpace);
			attribNode = xmlDoc.CreateAttribute("refDataItem");
			attribNode.Value = columnValue;
			currentNode.Attributes.Append(attribNode);
			// sn_dg_prm_smpl_modifyreport_P2_end_1

			nextNode = xmlDoc.CreateNode(XmlNodeType.Element, "dataSource", myNameSpace);
			nextNode.AppendChild(currentNode);
			currentNode = nextNode;

			//textItem
			nextNode = xmlDoc.CreateNode(XmlNodeType.Element, "textItem", myNameSpace);
			nextNode.AppendChild(currentNode);
			currentNode = nextNode;

			//contents
			nextNode = xmlDoc.CreateNode(XmlNodeType.Element, "contents", myNameSpace);
			nextNode.AppendChild(currentNode);
			currentNode = nextNode;

            //style for listColumnBody
            nextNode = xmlDoc.CreateNode(XmlNodeType.Element, "defaultStyle", myNameSpace);
            attribNode = xmlDoc.CreateAttribute("refStyle");
            attribNode.Value = "lc";
            nextNode.Attributes.Append(attribNode);
            currentStyleNode = nextNode;

            nextNode = xmlDoc.CreateNode(XmlNodeType.Element, "defaultStyles", myNameSpace);
            nextNode.AppendChild(currentStyleNode); //defaultStyle
            currentStyleNode = nextNode;

            nextNode = xmlDoc.CreateNode(XmlNodeType.Element, "style", myNameSpace);
            nextNode.AppendChild(currentStyleNode); //defaultStyles
            styleNode = nextNode;

            //listColumnBody
			nextNode = xmlDoc.CreateNode(XmlNodeType.Element, "listColumnBody", myNameSpace);

            nextNode.AppendChild(styleNode); //style
			nextNode.AppendChild(currentNode);

			//Add the listColumnBody to the listColumnElement
			listColumnNode.AppendChild(nextNode);

			return listColumnNode;

		}

		public XmlNode buildDataItemNode(XmlDocument xmlDoc, string myNameSpace, string name, string expression)
		{
			XmlNode expressionNode, dataItemNode;
			XmlAttribute attribNode;

			//expression
			expressionNode = xmlDoc.CreateNode(XmlNodeType.Element, "expression", myNameSpace);
			expressionNode.InnerText = expression;

			//dataItem
			dataItemNode = xmlDoc.CreateNode(XmlNodeType.Element, "dataItem", myNameSpace);
			attribNode = xmlDoc.CreateAttribute("name");
			attribNode.Value = name;
			dataItemNode.Attributes.Append(attribNode);

			attribNode = xmlDoc.CreateAttribute("aggregate");
			attribNode.Value = "none";
			dataItemNode.Attributes.Append(attribNode);

			dataItemNode.AppendChild(expressionNode);

			return dataItemNode;
		}

		public reportServiceSpecification createReportSpec(SamplesConnect connection, string packageName, string targetLocation, string newReportName, string tableName, XmlNodeWrapper[] selectedColumns) 
		{		
			try
			{
				// sn_dg_prm_smpl_modifyreport_P1_start_0
				XmlDocument xmlDoc = new XmlDocument();
				XmlNode root,
					currentNode,
					nextNode,
					listColumnsNode,
                    cssNode,
                    currentStyleNode,
                    styleNode,
					selectionNode;
				XmlAttribute attribNode;

				string defaultPackageName, strName, strReportXML;
				report reportName = new report();
				addOptions addOptions = new addOptions();
				tokenProp tokenName = new tokenProp();
				anyTypeProp anyTypeName = new anyTypeProp();
				reportServiceReportSpecification rspecReport = new reportServiceReportSpecification();
				
				string myNS = "http://developer.cognos.com/schemas/report/13.0/";

				//
				//root report element
				//
				root = xmlDoc.CreateNode(XmlNodeType.Element, "report", myNS);
				attribNode = xmlDoc.CreateAttribute("expressionLocale");
				attribNode.Value = "en-us";
				root.Attributes.Append(attribNode);

				xmlDoc.AppendChild(root);				

				//Add all the rest of the foundation report elements
				// sn_dg_prm_smpl_modifyreport_P1_end_0

				//Insert version comment
				currentNode = xmlDoc.CreateComment("RS:8.1");
				root.AppendChild(currentNode);

				//set modelPath and add to report
                defaultPackageName = "/content/folder[@name='Samples']/folder[@name='Models']/package[@name='" 
					+ packageName 
					+ "']/model[@name='model']";
				currentNode = xmlDoc.CreateNode(XmlNodeType.Element, "modelPath", myNS);
				currentNode.InnerText = defaultPackageName;
				root.AppendChild(currentNode);

				//
				//query structure, build from bottom up
				//

				//model
				currentNode = xmlDoc.CreateNode(XmlNodeType.Element, "model", myNS);

				//source
				nextNode = xmlDoc.CreateNode(XmlNodeType.Element, "source", myNS);
				nextNode.AppendChild(currentNode); //model
				currentNode = nextNode;

				//query
				nextNode = xmlDoc.CreateNode(XmlNodeType.Element, "query", myNS);
				attribNode = xmlDoc.CreateAttribute("name");
				attribNode.Value = "Query1";
				nextNode.Attributes.Append(attribNode);

				nextNode.AppendChild(currentNode); //source

				//selection - also part of query
				//we need to keep a reference to this element for
				//adding columns
				selectionNode = xmlDoc.CreateNode(XmlNodeType.Element, "selection", myNS);
				nextNode.AppendChild(selectionNode); //selection
				currentNode = nextNode;

				//queries
				nextNode = xmlDoc.CreateNode(XmlNodeType.Element, "queries", myNS);
				nextNode.AppendChild(currentNode); //query
				currentNode = nextNode;

				//add queries to root report element
				root.AppendChild(currentNode); //queries

				//
				//layout structure, build from bottom up
				//

				//CSS
				cssNode = xmlDoc.CreateNode(XmlNodeType.Element, "CSS", myNS);
				attribNode = xmlDoc.CreateAttribute("value");
				attribNode.Value = "border-collapse:collapse";
                cssNode.Attributes.Append(attribNode);

                //style for list
                nextNode = xmlDoc.CreateNode(XmlNodeType.Element, "defaultStyle", myNS);
                attribNode = xmlDoc.CreateAttribute("refStyle");
                attribNode.Value = "ls";
                nextNode.Attributes.Append(attribNode);
                currentStyleNode = nextNode;

                nextNode = xmlDoc.CreateNode(XmlNodeType.Element, "defaultStyles", myNS);
                nextNode.AppendChild(currentStyleNode); //defaultStyle
                currentStyleNode = nextNode;

                nextNode = xmlDoc.CreateNode(XmlNodeType.Element, "style", myNS);
                nextNode.AppendChild(currentStyleNode); //defaultStyles
                nextNode.AppendChild(cssNode); //css
                styleNode = nextNode;

                //list
				nextNode = xmlDoc.CreateNode(XmlNodeType.Element, "list", myNS);

				attribNode = xmlDoc.CreateAttribute("refQuery");
				attribNode.Value = "Query1";
				nextNode.Attributes.Append(attribNode);

                nextNode.AppendChild(styleNode); //style

				//listColumns -- also added to list
				//We need to keep a reference to this element for 
				//adding columns
				listColumnsNode = xmlDoc.CreateNode(XmlNodeType.Element, "listColumns", myNS);
				nextNode.AppendChild(listColumnsNode); //listColumns
				currentNode = nextNode;

                //style for pageBody
                nextNode = xmlDoc.CreateNode(XmlNodeType.Element, "defaultStyle", myNS);
                attribNode = xmlDoc.CreateAttribute("refStyle");
                attribNode.Value = "pb";
                nextNode.Attributes.Append(attribNode);
                currentStyleNode = nextNode;

                nextNode = xmlDoc.CreateNode(XmlNodeType.Element, "defaultStyles", myNS);
                nextNode.AppendChild(currentStyleNode); //defaultStyle
                currentStyleNode = nextNode;

                nextNode = xmlDoc.CreateNode(XmlNodeType.Element, "style", myNS);
                nextNode.AppendChild(currentStyleNode); //defaultStyles
                styleNode = nextNode;

                //contents
				nextNode = xmlDoc.CreateNode(XmlNodeType.Element, "contents", myNS);
				nextNode.AppendChild(currentNode); //list
				currentNode = nextNode;

                //pageBody
				nextNode = xmlDoc.CreateNode(XmlNodeType.Element, "pageBody", myNS);

                nextNode.AppendChild(styleNode); //style

				nextNode.AppendChild(currentNode); //contents
				currentNode = nextNode;

                //style for page
                nextNode = xmlDoc.CreateNode(XmlNodeType.Element, "defaultStyle", myNS);
                attribNode = xmlDoc.CreateAttribute("refStyle");
                attribNode.Value = "pg";
                nextNode.Attributes.Append(attribNode);
                currentStyleNode = nextNode;

                nextNode = xmlDoc.CreateNode(XmlNodeType.Element, "defaultStyles", myNS);
                nextNode.AppendChild(currentStyleNode); //defaultStyle
                currentStyleNode = nextNode;

                nextNode = xmlDoc.CreateNode(XmlNodeType.Element, "style", myNS);
                nextNode.AppendChild(currentStyleNode); //defaultStyles
                styleNode = nextNode;

                //page
				nextNode = xmlDoc.CreateNode(XmlNodeType.Element, "page", myNS);

				attribNode = xmlDoc.CreateAttribute("name");
				attribNode.Value = "Page1";
				nextNode.Attributes.Append(attribNode);

                nextNode.AppendChild(styleNode); //style
                nextNode.AppendChild(currentNode); //pageBody
				currentNode = nextNode;

				//reportPages
				nextNode = xmlDoc.CreateNode(XmlNodeType.Element, "reportPages", myNS);
				nextNode.AppendChild(currentNode); //page
				currentNode = nextNode;

				//layout
				nextNode = xmlDoc.CreateNode(XmlNodeType.Element, "layout", myNS);
				nextNode.AppendChild(currentNode); //reportPages
				currentNode = nextNode;

				//put layout in layouts and add to report
				nextNode = xmlDoc.CreateNode(XmlNodeType.Element, "layouts", myNS);
				nextNode.AppendChild(currentNode); //layout
				root.AppendChild(nextNode);

				//in a for loop, for each UI selected addition, 
				//add a dataItem to the selectionElement 
				//and add a listColumn to the listColumnsElement
				int nbSelectedColumns = selectedColumns.GetLength(0);
				for (int i=0; i<nbSelectedColumns; i++)
				{
					//dataItem
					selectionNode.AppendChild(buildDataItemNode(xmlDoc, myNS, selectedColumns[i].ToString(), selectedColumns[i].PATH)); //from UI selection
					//listColumns
					listColumnsNode.AppendChild(buildListColumnNode(xmlDoc, myNS, selectedColumns[i].ToString(), selectedColumns[i].ToString())); //ditto
				}
			        
				//debugging info
				//Console.WriteLine("\n OUTER XML : " + xmlDoc.OuterXml);
				//Console.WriteLine("\n INNER XML : " + xmlDoc.InnerXml);

				strReportXML = root.OuterXml;
				strName = newReportName;

				//take all that xml and start building the report object
				// sn_dg_prm_smpl_modifyreport_P3_start_0
				tokenName.value = strName;
				anyTypeName.value = strReportXML;
			
				reportName.defaultName = tokenName;
				reportName.specification = anyTypeName;
				addOptions.updateAction = updateActionEnum.replace;
				reportName.specification.value = strReportXML;

				searchPathSingleObject targetPath = new searchPathSingleObject();
				targetPath.Value = targetLocation;

				connection.CBIRS.add(targetPath, reportName, addOptions);
				// sn_dg_prm_smpl_modifyreport_P3_end_0

				rspecReport.value = new specification();
				rspecReport.value.Value = reportName.specification.value;
			    
				return rspecReport;
			}
			catch(SoapException ex)
			{
				SamplesException.ShowExceptionMessage( ex, true, "Create Report Sample - createReportSpec" );
				return null;
			}
			catch(System.Exception ex)
			{
				SamplesException.ShowExceptionMessage( ex.Message, true, "Create Report Sample - createReportSpec" );
				return null;
			}
		}

		public bool executeReportSpec(SamplesConnect connection, reportServiceSpecification reportSpec)
		{
			try
			{
				//Run the specification and send the results to a file.
				option[] runOptions = new option[0];
				asynchReply executeResponse = new asynchReply();
				executeResponse = connection.CBIRS.runSpecification(reportSpec, new parameterValue[] {} , runOptions);

				//If the request has not yet completed, keep waiting until it has finished
				while ( executeResponse.status != asynchReplyStatusEnum.complete )
				{
					executeResponse = connection.CBIRS.wait(executeResponse.primaryRequest,new parameterValue[] {}, new option[] {});
				}
				return true;
			}
			catch(SoapException ex)
			{
				SamplesException.ShowExceptionMessage( ex, true, "Create Report Sample - executeReportSpec" );
				return false;
			}
			catch(System.Exception ex)
			{
				SamplesException.ShowExceptionMessage( ex.Message, true, "Create Report Sample - executeReportSpec" );
				return false;
			}
		}
	}
}
