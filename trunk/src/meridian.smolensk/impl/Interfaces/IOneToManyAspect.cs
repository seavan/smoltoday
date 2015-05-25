using System.Collections.Generic;
using admin.db;

namespace meridian.smolensk.proto
{
    public interface IOneToManyAspect
    {
        string FieldName { get; }

        IEnumerable<ILookupValue> GetAvalableValues();

        IEnumerable<ILookupValue> GetSelectedValues();

        void SetValue(long valueId);
        void RemoveValue(long valueId);

        IDatabaseEntity GetParent();
    }
}