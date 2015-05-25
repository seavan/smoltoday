using admin.db;

namespace meridian.smolensk.proto
{
    public class Aspect : IAspect
    {
        public Aspect(string _fieldName, IDatabaseEntity _parent)
        {
            m_FieldName = _fieldName;
            m_Parent = _parent;
        }
        private string m_FieldName;
        private IDatabaseEntity m_Parent;

        public string FieldName
        {
            get { return m_FieldName; }
            set { m_FieldName = value; }
        }


        public IDatabaseEntity GetParent()
        {
            return m_Parent;
        }
    }
}