using System;
using System.Collections.Generic;
using System.Linq;
using admin.db;

namespace meridian.smolensk.proto
{
    public class OneToManyAspect<ValueType> : Aspect, IOneToManyAspect where ValueType : ILookupValue
    {
        public OneToManyAspect(
            IDatabaseEntity _parent,
            string _fieldName,
            Func<IEnumerable<ValueType>> _getAvailableValues,
            Func<IEnumerable<ValueType>> _getSelectedValues,
            Action<long> _addValue,
            Action<long> _removeValue
            )
            : base(_fieldName, _parent)
        {
            m_getAvailableValues = _getAvailableValues;
            m_getSelectedValues = _getSelectedValues;
            m_removeValue = _removeValue;
            m_addValue = _addValue;
        }


        private Func<IEnumerable<ValueType>> m_getAvailableValues;
        private Func<IEnumerable<ValueType>> m_getSelectedValues;
        private Action<long> m_removeValue;
        private Action<long> m_addValue;

        public IEnumerable<ILookupValue> GetAvalableValues()
        {
            return m_getAvailableValues().Cast<ILookupValue>();
        }

        public IEnumerable<ILookupValue> GetSelectedValues()
        {
            return m_getSelectedValues().Cast<ILookupValue>();
        }

        public void SetValue(long valueId)
        {
            m_addValue(valueId);
        }

        public void RemoveValue(long valueId)
        {
            m_removeValue(valueId);
        }
    }
}