/*
 * Project : SenseFramework - Core
 * Author : Ekin Bulut 
 * Date : 24.02.2017
 * 
 * Desc : This static class returns the exact path of the assemblies of the default application folder.
 * 
 */

using System;
using System.IO;
using System.Reflection;

namespace SenseFramework.Core.Configuration
{
    public static class AssemblyInstaller
    {
        /// <summary>
        /// Gets the assembly directory.
        /// </summary>
        /// <value>
        /// The assembly directory.
        /// </value>
        public static string AssemblyDirectory
        {
            get
            {
                var codeBase = Assembly.GetExecutingAssembly().CodeBase;

                var uri = new UriBuilder(codeBase);

                var path = Uri.UnescapeDataString(uri.Path);

                return Path.GetDirectoryName(path);
            }
        }
    }
}
