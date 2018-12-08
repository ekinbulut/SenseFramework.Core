/*
 * Project : SenseFramework - Core
 * Author : Ekin Bulut 
 * Date : 24.02.2017
 * 
 * Desc : This is the core of the all application. 
 *        All components are gathered in here by Windsor Installers.
 * 
 */

using Castle.Windsor;

namespace SenseFramework.Core.IoC
{
    using Installers;

    public delegate void ContainerFlowHandler(string message);
    public static class IoCManager
    {

        public static event ContainerFlowHandler MessageFlow;

        /// <summary>
        /// The _container
        /// </summary>
        private static IWindsorContainer _container;

        /// <summary>
        /// Gets the container.
        /// </summary>
        /// <value>
        /// The container.
        /// </value>
        public static IWindsorContainer Container
        {
            get
            {
                if (_container == null)
                {
                    _container = new WindsorContainer();

                }
                return _container;
            }
        }

        /// <summary>
        /// Registers the logging module.
        /// </summary>
        internal static void RegisterLoggingModule()
        {
            Container.Install(new LoggerInstaller());
        }

        /// <summary>
        /// Registers all core modules from implemantations.
        /// </summary>
        internal static void RegisterCoreModules()
        {
            Container.Install(new TierModuleInstaller());
        }

        public static void OnMessageFlow(string message)
        {
            MessageFlow?.Invoke(message);
        }
    }
}
