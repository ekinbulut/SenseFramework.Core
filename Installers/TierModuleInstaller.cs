/*
 * Project : SenseFramework - Core
 * Author : Ekin Bulut 
 * Date : 24.02.2017
 * 
 * Desc : TierModuleInstaller is a windsor installer which registers all other modules 
 *        whom used by the application. This module finds all other child classes from other 
 *        assemblies and executes the nessesary method which helps to register components into 
 *        the IOC Manager.
 * 
 */
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;


namespace SenseFramework.Core.Installers
{
    using Configuration;
    using Integrations;
    using Intercepters;

    internal class TierModuleInstaller : IWindsorInstaller
    {
        /// <summary>
        /// Performs the installation in the <see cref="T:Castle.Windsor.IWindsorContainer" />.
        /// </summary>
        /// <param name="container">The container.</param>
        /// <param name="store">The configuration store.</param>
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<DisplayIntercepter>().ImplementedBy<DisplayIntercepter>().LifestyleSingleton());

            container.Register(
                Classes.FromAssemblyInDirectory(new AssemblyFilter(AssemblyInstaller.AssemblyDirectory))
                .BasedOn<ITierApplicationModule>()
                .WithServiceFromInterface()
                .LifestyleSingleton());

            var modules = container.ResolveAll<ITierApplicationModule>();

            foreach (ITierApplicationModule module in modules)
            {
                module.RegisterModule();
            }
        }
    }
}
