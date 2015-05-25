using meridian.smolensk.system;

namespace meridian.smolensk.proto
{
    public partial class restaurants_entries : IDictionaryValue
    {
        public IDictionaryCategory Category
        {
            get
            {
                return this.GetEntriesValuesRestaurant_entrie() != null
                           ? this.GetEntriesValuesRestaurant_entrie().GetEntriesValuesRestaurant_entry_categorie()
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
                return this.GetEntriesValuesRestaurant_entrie() != null
                           ? this.GetEntriesValuesRestaurant_entrie().title
                           : null;
            }
            set
            {
                //throw new NotImplementedException();
            }
        }


        public long ValueId
        {
            get { return entry_id; }
            set
            {
                if (value != entry_id)
                {
                    this.DeleteAggregations();
                    entry_id = value;
                    this.LoadAggregations(Meridian.Default);
                    Meridian.Default.restaurants_entriesStore.Update(this);
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