SET dllPath="C:\Idera_UpTime_Project\BatchRun\Uptime.Automation\Uptime.Automation.Tests\bin\Debug\Uptime.Automation.Tests.dll"
SET workingDirectory="C:\Idera_UpTime_Project\BatchRun\Uptime.Automation\Uptime.Automation.SuiteRunner\bin\Debug"
SET solutionPath="C:\Idera_UpTime_Project\BatchRun\Uptime.Automation\Uptime.Automation.sln"


cd c:\
cd "%ProgramFiles(x86)%\Microsoft Visual Studio 12.0\Common7\Tools\"
call "VsDevCmd.bat"
cd C:\Windows\Microsoft.NET\Framework64\v4.0.30319\
c:
cd %workingDirectory%
start %workingDirectory% Uptime.Automation.SuiteRunner.exe  
pause