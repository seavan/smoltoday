using System.Linq;

namespace meridian.smolensk.proto
{
    public partial class restaurant_entries : IDictionaryValue, IValueListItem
    {

        public IDictionaryCategory Category
        {
            get { return this.GetEntriesValuesRestaurant_entry_categorie(); }
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
            get { return GetEntriesValues().Any(); }
        }
    }
}