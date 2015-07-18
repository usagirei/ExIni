using System.Reflection;
using System.Runtime.InteropServices;

#if X86
[assembly: AssemblyTitle("ExIni x86")]
#elif X64
[assembly: AssemblyTitle("ExIni x64")]
#else
[assembly: AssemblyTitle("ExIni")]
#endif

[assembly: AssemblyDescription("Extended INI File Handler")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Usagirei")]
[assembly: AssemblyProduct("ExIni")]
[assembly: AssemblyCopyright("Copyright © Usagirei 2015")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

[assembly: ComVisible(false)]

[assembly: Guid("b8adf1ac-aade-485a-8997-14c4b42e0a8b")]


#if !GIT
[assembly: AssemblyVersion("0.0.0.0")]
[assembly: AssemblyFileVersion("0.0.0.0")]
[assembly: AssemblyInformationalVersion("development build - internal use only")]
#endif