@echo off

rem Licensed Materials - Property of IBM
rem IBM Cognos Products: DOCS
rem (C) Copyright IBM Corp. 2005, 2012
rem US Government Users Restricted Rights - Use, duplication or disclosure restricted by GSA ADP Schedule Contract with
rem IBM Corp.

rem  Copyright (C) 2008 Cognos ULC, an IBM Company. All rights reserved.
rem  Cognos (R) is a trademark of Cognos ULC, (formerly Cognos Incorporated).

rem Build the SamplesCommon assembly using the .NET Framework command-line tools.
rem
rem CHANGE the following environment variable to point to your IBM Cognos BI server.

set CRN_HOME=http://localhost:9300/p2pd/servlet/dispatch/

rem Build the library and the executable.

set ICON=/win32icon:SamplesApplication.ico

set RESOURCES=SamplesAbout.resx SamplesConnect.resx SamplesInput.resx SamplesListInput.resx SamplesLogon.resx SamplesPath.resx SamplesWindow.resx

set COMPILED_RESOURCES=/res:SamplesAbout.resources,SamplesCommon.SamplesAbout.resources /res:SamplesConnect.resources,SamplesCommon.SamplesConnect.resources /res:SamplesInput.resources,SamplesCommon.SamplesInput.resources /res:SamplesListInput.resources,SamplesCommon.SamplesListInput.resources /res:SamplesLogon.resources,SamplesCommon.SamplesLogon.resources /res:SamplesPath.resources,SamplesCommon.SamplesPath.resources /res:SamplesWindow.resources,SamplesCommon.SamplesWindow.resources

set SOURCE=AssemblyInfo.cs BaseClassWrapper.cs CommonFunctions.cs ReportAndQueryObject.cs SamplesConnect.cs SamplesAbout.cs SamplesException.cs SamplesExceptionHelper.cs SamplesHeaderExceptionHelper.cs SamplesInput.cs SamplesListInput.cs SamplesLogon.cs SamplesPath.cs SamplesWindow.cs

set COGDLLS=/r:../../cognosdotnet_10_2.dll /r:../../cognosdotnetassembly_10_2.dll

resgen /compile %RESOURCES%
csc /nologo /t:library /out:SamplesCommon.dll %COGDLLS% %SOURCE% %ICON% %COMPILED_RESOURCES%

del *.resources

echo Done.
