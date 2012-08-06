using System.Reflection;
using Kraken.Framework.Core;

[assembly: AssemblyTitle("TimberMill.Tests")]
[assembly: AssemblyDescription("Nlog receiver")]
[assembly: AssemblyConfiguration("")]

#if DEBUG
[assembly: AssemblyProduct("TimberMill.Tests (Debug)")]
[assembly: AssemblyCompilation(BuildConfiguration.Debug)]
#else
[assembly: AssemblyProduct("TimberMill.Tests (Release)")]
[assembly:  AssemblyCompilation(BuildConfiguration.Release)]
#endif

