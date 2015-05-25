using System;
using System.Collections.Generic;
using System.Linq;
using admin.db;

namespace meridian.smolensk.proto
{
    public class LookupAspect : Aspect, ILookupValueAspect 
    {
        public LookupAspect(string _fieldName, IDatabaseEntity _parent, Func<IEnumerable<ILookupValue>> _getAll, bool _showIsNoSelect = true ) : base(_fieldName, _parent)
        {
            m_getAll = _getAll;
            m_showIsNoSelect = _showIsNoSelect;
        }

        private Func<IEnumerable<ILookupValue>> m_getAll;

        private bool m_showIsNoSelect;

        public IEnumerable<ILookupValue> GetValues()
        {
            return m_getAll();
        }

        public bool ShowIsNoSelect { get { return m_showIsNoSelect; } }
        
    }

}