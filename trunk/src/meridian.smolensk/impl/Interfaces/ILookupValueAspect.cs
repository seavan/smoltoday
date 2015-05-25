using System.Collections.Generic;
using admin.db;

namespace meridian.smolensk.proto
{
    public interface ILookupValueAspect
    {
        IEnumerable<ILookupValue> GetValues();

        bool ShowIsNoSelect { get; }
    }

}