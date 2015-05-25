using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace smolensk.common.Infrastructure
{
    public interface IServiceLocator
    {
        T Locate<T>();
        T Locate<T>(string serviceName);
    }
}