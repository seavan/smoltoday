using System;
using System.Collections.Generic;
using admin.db;

namespace meridian.smolensk.proto
{
    public interface IScheduleAspect
    {
        string FieldName { get; }

        IEnumerable<ILookupValue> GetAvalablePlaces();

        SortedList<long, List<DateTime>> GetPlacesSchedule();

        void SetSchedule(long placeId, DateTime time);
        void ClearSchedule(long placeId);

        IDatabaseEntity GetParent();
    }
}