/*
 * Project : SenseFramework - Core
 * Author : Ekin Bulut 
 * Date : 24.02.2017
 * 
 * Desc : Logger Installer for IOC using Castle Windsor. It uses log4net by using logging facilities of Windsor.
 * 
 */

using System.IO;
using Castle.Facilities.Logging;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using log4net.Config;

namespace SenseFramework.Core.Installers
{
    /// <summary>
    /// Windsor Installer
    /// </summary>
    internal class LoggerInstaller : IWindsorInstaller
    {
        /// <summary>
        /// Adds facilites to container for log4net.
        /// </summary>
        /// <param name="container">IOC manager container</param>
        /// <param name="store">Configuration store</param>
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            XmlConfigurator.ConfigureAndWatch(new FileInfo("log4net.config"));
#pragma warning disable CS0618 // Type or member is obsolete
            container.AddFacility<LoggingFacility>(f => f.UseLog4Net());
#pragma warning restore CS0618 // Type or member is obsolete
        }
    }
}
