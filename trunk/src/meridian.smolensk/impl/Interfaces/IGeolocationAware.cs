using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace meridian.smolensk.proto
{
    public interface IGeolocationAware
    {
        IEnumerable<IGeoLocation> GetEntityMap();
    }
}
