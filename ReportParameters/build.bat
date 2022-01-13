@echo off

rem Licensed Materials - Property of IBM
rem IBM Cognos Products: DOCS
rem (C) Copyright IBM Corp. 2005, 2012
rem US Government Users Restricted Rights - Use, duplication or disclosure restricted by GSA ADP Schedule Contract with
rem IBM Corp.

rem  Copyright (C) 2007 Cognos ULC, an IBM Company. All rights reserved.
rem  Cognos (R) is a trademark of Cognos ULC, (formerly Cognos Incorporated).

rem Build ReportParameters using the .NET Framework command-line tools.

echo If you didn't run build.bat in ..\SamplesCommon, press Ctrl-C and do it now.
echo.
pause

copy ..\SamplesCommon\SamplesCommon.dll SamplesCommon.dll
copy ..\..\cognosdotnet_10_2.dll .
copy ..\..\cognosdotnetassembly_10_2.dll .

set ICON=/win32icon:..\SamplesCommon\SamplesApplication.ico

set SOURCE=ReportParameters.cs

set COGDLLS=/r:cognosdotnet_10_2.dll /r:cognosdotnetassembly_10_2.dll

csc /nologo /t:winexe /out:ReportParameters.exe /r:SamplesCommon.dll %ICON% %COGDLLS% %SOURCE%

echo Done.
