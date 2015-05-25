using System;
using System.Collections.Generic;
using admin.db;

namespace meridian.smolensk.proto
{
    public interface IValueListAspect
    {
        IEnumerable<IValueListItem> GetAllValues();
        string FieldName { get;  }
        string ProtoName { get; }
        IValueListItem Create(string _value);
        IDatabaseEntity GetParent();
    }

    public class ValueListAspect<T> : IValueListAspect
    {
        public ValueListAspect(IDatabaseEntity _parent, Func<IEnumerable<IValueListItem>> _getAllValues,
                               Func<string, IValueListItem> _create, string _fieldName)
        {
            m_parent = _parent;
            m_getAllValues = _getAllValues;
            m_create = _create;
            m_fieldName = _fieldName;
        }

        private IDatabaseEntity m_parent;
        private Func<IEnumerable<IValueListItem>> m_getAllValues;
        private Func<string, IValueListItem> m_create;
        private string m_fieldName;

        public IEnumerable<IValueListItem> GetAllValues()
        {
            return m_getAllValues();
        }

        public string FieldName
        {
            get { return m_fieldName; }
        }

        public IValueListItem Create(string _value)
        {
            return m_create(_value);
        }


        public IDatabaseEntity GetParent()
        {
            return m_parent;
        }


        public string ProtoName
        {
            get { return typeof(T).Name; }
        }
    }
}