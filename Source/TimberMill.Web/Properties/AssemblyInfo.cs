using System.Reflection;
using Kraken.Framework.Core;

[assembly: AssemblyTitle("TimberMill")]
[assembly: AssemblyDescription("Nlog receiver")]
[assembly: AssemblyConfiguration("")]

#if DEBUG
[assembly: AssemblyProduct("TimberMill (Debug)")]
[assembly: AssemblyCompilation(BuildConfiguration.Debug)]
#else
[assembly: AssemblyProduct("TimberMill (Release)")]
[assembly:  AssemblyCompilation(BuildConfiguration.Release)]
#endif

