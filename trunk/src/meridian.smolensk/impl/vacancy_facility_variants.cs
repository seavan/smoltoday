using System.Linq;

namespace meridian.smolensk.proto
{
    public partial class vacancy_facility_variants : IDictionaryValue, IValueListItem
    {
        public IDictionaryCategory Category
        {
            get { return this.GetVariantsVacancy_facilitie(); }
            set
            {
                //throw new NotImplementedException();
            }
        }

        public string Value
        {
            get { return this.title; }
            set { title = value; }
        }


        public long ValueId
        {
            get { return id; }
            set
            {
                //throw new NotImplementedException();
            }
        }

        public string FreeValue
        {
            get { return null; }
            set
            {
                //throw new NotImplementedException();
            }
        }

        public bool IsUsed
        {
            get { return GetFacilitiesValues().Any(); }
        }
    }
}
