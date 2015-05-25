using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CuttingEdge.Conditions;

namespace smolensk.common.Infrastructure
{
    public class ServiceLocator
    {
        private static IServiceLocator instance;

        private ServiceLocator()
        {
        }

        public static IServiceLocator Instance
        {
            get
            {
                if (instance == null)
                    throw new InvalidOperationException("Service locator was not initialized yet");

                return instance;
            }
        }

        public static void Initialize(IServiceLocator serviceLocator)
        {
            Condition.Requires(serviceLocator, "serviceLocator").IsNotNull();

            instance = serviceLocator;
        }

        public static void Cleanup()
        {
            instance = null;
        }
    }
}