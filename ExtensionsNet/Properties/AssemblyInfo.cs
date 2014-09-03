using System;
using System.Reflection;

// Conformité CLS.
[assembly: CLSCompliant(true)]

// Les informations générales relatives à un assembly dépendent de
// l'ensemble d'attributs suivant.
[assembly: AssemblyTitle("ExtensionsNet")]
[assembly: AssemblyDescription("Extensions for .NET Framework 4, Silverlight 5, Windows 8, Windows Phone 8.1 and Windows Phone Silverlight 8.")]
#if DEBUG
[assembly: AssemblyConfiguration("Debug")]
#else
[assembly: AssemblyConfiguration("Release")]
#endif
[assembly: AssemblyProduct("ExtensionsNet")]
[assembly: AssemblyCopyright("Copyright (c) 2014, ExtensionsNet by Cyril Schumacher")]

// Les informations de version pour un assembly se composent des quatre valeurs suivantes :
// Version principale, Version secondaire, Numéro de build, Révision
[assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyFileVersion("1.0.0.0")]