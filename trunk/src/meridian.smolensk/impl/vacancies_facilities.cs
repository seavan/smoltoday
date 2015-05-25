using System.Linq;
using meridian.smolensk.system;

namespace meridian.smolensk.proto
{
    public partial class vacancies_facilities : IDictionaryValue
	{
        public IDictionaryCategory Category
        {
            get
            {
                return this.GetFacilitiesValuesVacancy_facility_variant() != null
                           ? this.GetFacilitiesValuesVacancy_facility_variant().GetVariantsVacancy_facilitie()
                           : null;
            }
            set
            {
                //this.restaurant_entry_category_id = value.id;
            }
        }

        public string Value
        {
            get
            {
                return this.GetFacilitiesValuesVacancy_facility_variant() != null
                           ? this.GetFacilitiesValuesVacancy_facility_variant().title
                           : null;
            }
            set
            {
                //throw new NotImplementedException();
            }
        }


        public long ValueId
        {
            get { return variant_id; }
            set
            {
                if (value != variant_id)
                {
                    this.DeleteAggregations();
                    variant_id = value;
                    this.LoadAggregations(Meridian.Default);
                    Meridian.Default.vacancies_facilitiesStore.Update(this);
                }
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
	}
}
