@echo off

set MSBUILD=%WINDIR%\Microsoft.NET\Framework\v4.0.30319
set BUILD=%CD%\.build

set PATH=%MSBUILD%;%PATH%

if not exist "%BUILD%\MSBuild.Community.Tasks.dll" (
	echo Place a copy of the MSBuildTasks Binaries and targets in the .build directory
	echo Source can be found at https://github.com/loresoft/msbuildtasks
	echo You may need to compile from source
	goto end
)
if not exist "%MSBUILD%\msbuild.exe" (
	echo MSBuild Not Found, Aborting
	goto end
)

echo ---------- Cleaning Solution
del Build\* /q /s
echo ---------- Building Solution
msbuild.exe Source\.build /p:Platform=x86

:end
pause