using System;
using System.Collections.Generic;
using System.Linq;
using admin.db;

namespace meridian.smolensk.proto
{
    public class DictionaryAspect<_Category, _Value> : Aspect, IDictionaryValuesAspect
        where _Category : IDictionaryCategory
        where _Value : IDictionaryValue
    {
        public DictionaryAspect(
            IDatabaseEntity _parent,
            string _fieldName,
            Func<IEnumerable<_Category>> _getCategories,
            Func<IEnumerable<_Value>> _getValues,
            Action<long, long> _removeValue,
            Action<long, long, string> _addValue
            ) : base(_fieldName, _parent)
        {
            m_getCategories = _getCategories;
            m_getValues = _getValues;
            m_removeValue = _removeValue;
            m_addValue = _addValue;
        }

        private Func<IEnumerable<_Category>> m_getCategories;
        private Func<IEnumerable<_Value>> m_getValues;
        private Action<long, long> m_removeValue;
        private Action<long, long, string> m_addValue;



        public IDictionaryCategory[] GetCategories()
        {
            return m_getCategories().Cast<IDictionaryCategory>().ToArray();
        }

        public IEnumerable<IDictionaryValue> GetValues()
        {
            return m_getValues().Cast<IDictionaryValue>();
        }

        public void RemoveValue(long catId, long valueId = 0)
        {
            m_removeValue(catId, valueId);
        }

        public void SetValue(long catId, long valueId, string freeValue)
        {
            m_addValue(catId, valueId, freeValue);
        }


    }
}