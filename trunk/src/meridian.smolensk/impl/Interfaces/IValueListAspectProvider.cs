using System.Collections.Generic;

namespace meridian.smolensk.proto
{
    public interface IValueListAspectProvider
    {
        IValueListAspect GetValueListAspect(string _fieldName);
    }
}