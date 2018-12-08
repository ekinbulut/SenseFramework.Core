/*
 * Project : SenseFramework - Core
 * Author : Ekin Bulut 
 * Date : 24.02.2017
 * 
 * Desc : This class is a proxy for gathering the process of repositories
 * 
 */

using System;
using Castle.DynamicProxy;

namespace SenseFramework.Core.Intercepters
{
    using Messaging;

    public class DisplayIntercepter : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            try
            {
                Messanger.Logger.Info("Inserting record...");

                invocation.Proceed();
            }
            catch (Exception error)
            {
                Messanger.Logger.Error(error.Message);
            }

        }
    }
}
