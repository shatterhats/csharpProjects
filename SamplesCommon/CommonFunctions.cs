/** 
Licensed Materials - Property of IBM

IBM Cognos Products: DOCS

(C) Copyright IBM Corp. 2005

US Government Users Restricted Rights - Use, duplication or disclosure restricted by GSA ADP Schedule Contract with
IBM Corp.
*/
using System;
using System.IO;
using cognosdotnet_10_2;


namespace SamplesCommon
{
	public class CommonFunctions
	{
		public CommonFunctions()
		{
		}

		/*
		*  This function deals with executing reports with charts or graphics.
		*  the img tag contains credentials that are not valid when the report 
		*  is not run through report or query studio therefore we must extract 
		*  the img from content mgr and then save it locally, then replace the 
		*  img tag returned from CRN with a path to the local graphic.
		*/
		public string setupGraphics(contentManagerService1 cBICMS, string html)
		{
			string start = null;
			string end = null;
			string imgTag = null;
			int idx_start = 0;
			int idx_end = 0;
			string[] graphFileName = null;
			baseClass[] graphicList = new baseClass[0];
			CommonFunctions cf = new CommonFunctions();
			baseClass[] bcOutputList = new baseClass[0];

			searchPathMultipleObject outputPath = new searchPathMultipleObject();
			outputPath.Value = "~~/output";

			// Get the list of outputs generated during this session
			bcOutputList = cBICMS.query(outputPath, 
				new propEnum[] { propEnum.creationTime, propEnum.searchPath },
				new sort[] {}, 
				new queryOptions());
			if ((bcOutputList == null) || (bcOutputList.GetLength(0)<= 0) )
			{
				return html;
			}

			// Find the latest output from the list
			output latest_output = getLatestOutput(bcOutputList);
			
			searchPathMultipleObject latestOutputPath = new searchPathMultipleObject();
			latestOutputPath.Value = latest_output.searchPath.value + "/graphic";

			//"Found Graphic in report... saving locally.");
			graphicList = cBICMS.query(latestOutputPath,
				new propEnum[] {propEnum.name, propEnum.defaultName, propEnum.searchPath, propEnum.data, propEnum.dataType },
				new sort[] {},
				new queryOptions());

			if ((graphicList==null) || (graphicList.GetLength(0)<=0))
			{
				return html;
			}
			graphFileName = new string[graphicList.GetLength(0)];
			for(int i=0; i<graphicList.GetLength(0);i++)
			{
				// search&replace img tag with local image 
				// (except when it's already pointing to a local image: i.e.<img src="../image.jpg">)
			next_imgTag:
				idx_start = html.IndexOf("<img", idx_start);
				if (idx_start == -1)
				{
					return html;
				}
				start = html.Substring(0, idx_start);
				idx_end = html.IndexOf(">", idx_start);
				imgTag = html.Substring(idx_start, idx_end-idx_start+1);
				if (imgTag.IndexOf("src=\"..", 0, imgTag.Length) == -1)
				{
					// dump the graphic data into a PNG file in <install_location>/webcontent/samples
					graphic graphObj = (graphic)graphicList[i];
					graphFileName[i] = cf.getSamplesPath();
					graphFileName[i] += "graphToDisplay_" + i.ToString() + ".png";
					if (File.Exists(graphFileName[i]))
					{
						File.Delete(graphFileName[i]);
					}
					FileStream fs = new FileStream(graphFileName[i], FileMode.CreateNew);
					BinaryWriter bw = new BinaryWriter(fs);
					bw.Write(graphObj.data.value); 
					bw.Flush();
					bw.Close();

					end = html.Substring(idx_end+ 1, html.Length - (idx_end+1));
					html = start + "<img src='" + graphFileName[i] + "'>" + end;
				}
				else
				{
					idx_start++;
					goto next_imgTag;
				}
				idx_start++;
			}
			return html;
		}

		public string getSamplesPath()
		{
			string samplesPath = "";

			// Get the current working directory
			string currentDirectory = Directory.GetCurrentDirectory();
			
			// if current working directory is <install_location>\sdk\csharp\bin
			// webcontent path is: ..\..\..\webcontent
			// if current working directory is <install_location>\sdk\csharp\<SampleName>\bin\debug
			// webcontent path is: ..\..\..\..\..\webcontent

			if (currentDirectory.EndsWith("bin"))
			{
				samplesPath = currentDirectory + "\\..\\..\\..\\webcontent\\samples\\";
			}
			else if (currentDirectory.EndsWith("Debug"))
			{
				samplesPath = currentDirectory + "\\..\\..\\..\\..\\..\\webcontent\\samples\\";
			}
			return samplesPath;
		}

		public output getLatestOutput(baseClass[] bcOutputList)
		{
			output currentOutput = new output();
			output latest_output = new output(); // the most recent output generated
			
			latest_output = (output)bcOutputList[0];
			if (bcOutputList.GetLength(0) > 1)
			{
				for (int outputIdx=1; outputIdx < bcOutputList.GetLength(0); outputIdx++)
				{
					currentOutput = (output)bcOutputList[outputIdx];
					if (latest_output.creationTime.value < currentOutput.creationTime.value)
					{
						latest_output = currentOutput;
					}
				}
			}
			return latest_output;
		}
			
	}
}
