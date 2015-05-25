using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Practices.Unity;
using CuttingEdge.Conditions;

namespace smolensk.common.Infrastructure
{
    public class UnityBackedServiceLocator : IServiceLocator
    {
        private IUnityContainer container;

        public UnityBackedServiceLocator(IUnityContainer container)
        {
            Condition.Requires(container, "container").IsNotNull();

            this.container = container;
        }

        public T Locate<T>()
        {
            return (T)container.Resolve(typeof(T));
        }

        public T Locate<T>(string serviceName)
        {
            return (T)container.Resolve(typeof(T), serviceName);
        }
    }
}