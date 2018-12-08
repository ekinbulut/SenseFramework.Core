/*
 * Project : SenseFramework - Core
 * Author : Ekin Bulut 
 * Date : 25.02.2017
 * 
 * Desc : This module executes the registration of components into IOC Manager. 
 *        This interface should be implemented for module recognization.
 *        
 */
namespace SenseFramework.Core.Integrations
{
    /// <summary>
    /// Interface of the TierApplicationModule
    /// </summary>
    public interface ITierApplicationModule
    {
        /// <summary>
        /// Registers the module for Windsor container.
        /// </summary>
        void RegisterModule();
    }
}
