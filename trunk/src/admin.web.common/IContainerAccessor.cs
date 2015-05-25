using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Practices.Unity;

namespace admin.web.common
{
    [Obsolete]
    public interface IContainerAccessor
    {
        IUnityContainer Container { get; }
    }


}
