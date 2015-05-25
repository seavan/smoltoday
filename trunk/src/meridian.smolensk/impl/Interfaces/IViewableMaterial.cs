using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace meridian.smolensk.impl.Interfaces
{
    public interface IViewableMaterial
    {
        int ViewsCount { get; }
        void IncrementViewsCount();
    }
}
