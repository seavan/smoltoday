using System.Linq;
using meridian.smolensk.system;

namespace meridian.smolensk.proto
{
    public partial class ad_fields : IDictionaryValue
    {
        public IDictionaryCategory Category
        {
            get
            {
                return this.GetValuesAd_lookup_value() != null
                           ? this.GetValuesAd_lookup_value().GetDescriptionsAd_field_description()
                           : Meridian.Default.ad_field_descriptionsStore.GetDescription(this.description_id);
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
                return this.GetValuesAd_lookup_value() != null
                           ? this.GetValuesAd_lookup_value().value
                           : null;
            }
            set
            {
                //throw new NotImplementedException();
            }
        }


        public long ValueId
        {
            get { return value_id; }
            set
            {
                if (value != value_id)
                {
                    this.DeleteAggregations();
                    value_id = value;
                    this.LoadAggregations(Meridian.Default);
                    Meridian.Default.ad_fieldsStore.Update(this);
                }
            }
        }
        public string FreeValue
        {
            get { return this.value; }
            set
            {
                if (value != this.value)
                {
                    this.DeleteAggregations();
                    this.value = value;
                    this.LoadAggregations(Meridian.Default);
                    Meridian.Default.ad_fieldsStore.Update(this);
                }
            }
        }
    }
}
