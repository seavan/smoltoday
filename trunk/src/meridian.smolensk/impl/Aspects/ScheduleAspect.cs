using System;
using System.Collections.Generic;
using admin.db;

namespace meridian.smolensk.proto
{
    public class ScheduleAspect : Aspect, IScheduleAspect
    {
        public ScheduleAspect(
            IDatabaseEntity _parent,
            string _fieldName,
            Func<IEnumerable<ILookupValue>> _getPlaces,
            Func<SortedList<long, List<DateTime>>> _getSchedule,
            Action<long, DateTime> _SetSchedule,
            Action<long> _ClearSchedule
            )
            : base(_fieldName, _parent)
        {
            m_GetPlaces = _getPlaces;
            m_GetSchedule = _getSchedule;
            m_SetSchedule = _SetSchedule;
            m_ClearSchedule = _ClearSchedule;
        }

        private Func<IEnumerable<ILookupValue>> m_GetPlaces;
        private Func<SortedList<long, List<DateTime>>> m_GetSchedule;
        private Action<long, DateTime> m_SetSchedule;
        private Action<long> m_ClearSchedule;

        public IEnumerable<ILookupValue> GetAvalablePlaces()
        {
            return m_GetPlaces();
        }

        public SortedList<long, List<DateTime>> GetPlacesSchedule()
        {
            return m_GetSchedule();
        }

        public void SetSchedule(long placeId, DateTime time)
        {
            m_SetSchedule(placeId, time);
        }

        public void ClearSchedule(long placeId)
        {
            m_ClearSchedule(placeId);
        }
    }
}