using System.Linq;
using meridian.smolensk.system;

namespace meridian.smolensk.proto
{
    public partial class vacancy_professionals : ILookupValueAspectProvider, ILookupValue
    {

        public ILookupValueAspect GetLookupValueAspect(string _fieldName)
        {
            if (_fieldName == "parent_id")
            {
                return new LookupAspect(_fieldName, this, () =>
                Meridian.Default.vacancy_professionalsStore.All().Where(s => s.parent_id == 0).OrderBy(s => s.title));
            }

            return null;
        }


        public int lookup_value_level
        {
            get { return parent_id > 0 ? 1 : 0; }
        }

        public bool lookup_value_disabled
        {
            get { return false; }
        }
        public string lookup_title
        {
            get { return title; }
        }
    }
}
