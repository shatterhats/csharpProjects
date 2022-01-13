/** 
Licensed Materials - Property of IBM

IBM Cognos Products: DOCS

(C) Copyright IBM Corp. 2005

US Government Users Restricted Rights - Use, duplication or disclosure restricted by GSA ADP Schedule Contract with
IBM Corp.
*/
using System;
using cognosdotnet_10_2;

namespace SamplesCommon
{
	public class BaseClassWrapper
	{
		public BaseClassWrapper[] reportAndQueryList = new BaseClassWrapper[0];
        private cognosdotnet_10_2.baseClass m_BaseClassObject = null;

		public BaseClassWrapper()
		{
		}

        public BaseClassWrapper(cognosdotnet_10_2.baseClass wrapThis)
		{
			m_BaseClassObject = wrapThis;
		}

		public override string ToString()
		{
			return m_BaseClassObject.defaultName.value;
		}

		//public ReportAndQueryObject(contentManagerService1 cBICMS)
		//{
		//	reportAndQueryList = buildReportQueryList(cBICMS);
		//}

		//public ReportAndQueryObject[] getReportAndQueryList(contentManagerService1 cBICMS)
		//{
		//	return reportAndQueryList;
		//}

		public static BaseClassWrapper[] buildReportQueryList(contentManagerService1 cBICMS)
		{
			baseClass[] reports = new baseClass[0];
			baseClass[] queries = new baseClass[0];
			
			propEnum[] props =
				new propEnum[] { propEnum.searchPath, propEnum.defaultName, propEnum.objectClass, propEnum.parent};
			sort[] sortOptions = { new sort() };
			sortOptions[0].order = orderEnum.ascending;
			sortOptions[0].propName = propEnum.defaultName;

			searchPathMultipleObject reportsPath = new searchPathMultipleObject();
			reportsPath.Value = "/content//report";

			searchPathMultipleObject queriesPath = new searchPathMultipleObject();
			queriesPath.Value = "/content//query";

			reports =
				cBICMS.query(
				reportsPath,
				props,
				sortOptions,
				new queryOptions());
			queries =
				cBICMS.query(
				queriesPath,
				props,
				sortOptions,
				new queryOptions());

			BaseClassWrapper[] reportQueryList = new BaseClassWrapper[reports.GetLength(0) + queries.GetLength(0)];
			
			int nbReports = 0;
			int nbQueries = 0;
			if ((reports != null) && (reports.GetLength(0) > 0))
			{
				nbReports = reports.GetLength(0);
				for (int i=0; i<nbReports; i++)
				{
					reportQueryList[i] = new BaseClassWrapper(reports[i]);
					//reportQueryList[i].defaultName.value = reports[i].defaultName.value;
					//reportQueryList[i].searchPath.value = reports[i].searchPath.value;
					//reportQueryList[i].objectClass.value = reports[i].objectClass.value;
				}
			}
			if ((queries != null) && (queries.GetLength(0) > 0))
			{
				nbQueries = queries.GetLength(0);
				for (int j=0; j<nbQueries; j++)
				{
					reportQueryList[nbReports+j] = new BaseClassWrapper(queries[j]);
					//reportQueryList[nbReports+j].defaultName.value = queries[j].defaultName.value;
					//reportQueryList[nbReports+j].searchPath.value =	queries[j].searchPath.value;
					//reportQueryList[nbReports+j].objectClass.value = queries[j].objectClass.value;
				}
			}
			return reportQueryList;
		}

		public static string[] getPackageNameList(contentManagerService1 cBICMS)
		{
			sort[] sortOptions = { new sort() };
			sortOptions[0].order = orderEnum.ascending;
			sortOptions[0].propName = propEnum.defaultName;
			propEnum[] props = new propEnum[] { propEnum.searchPath, propEnum.defaultName };

			searchPathMultipleObject packagesPath = new searchPathMultipleObject();
			packagesPath.Value = "/content//package";

			baseClass[] bc = cBICMS.query(packagesPath, props, sortOptions, new queryOptions());

			string[] packageNames = new string[bc.GetLength(0)];
			for (int i = 0; i < bc.GetLength(0); i++)
			{
				packageNames[i] = bc[i].defaultName.value;
			}
			return packageNames;
		}

        public cognosdotnet_10_2.baseClass baseclassobject
		{
			get
			{
				return m_BaseClassObject;
			}
		}

        public cognosdotnet_10_2.stringProp searchPath
		{
			get
			{
				return m_BaseClassObject.searchPath;
			}
		}

        public cognosdotnet_10_2.stringProp parentPath
		{
			get
			{
				return m_BaseClassObject.parent.value[0].searchPath;
			}
		}

        public cognosdotnet_10_2.tokenProp defaultName
		{
			get
			{
				return m_BaseClassObject.defaultName;
			}
		}

        public cognosdotnet_10_2.classEnumProp objectClass
		{
			get
			{
				return m_BaseClassObject.objectClass;
			}
		}

	}
}
