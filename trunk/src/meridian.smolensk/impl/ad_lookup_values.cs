using System.Linq;

namespace meridian.smolensk.proto
{
    public partial class ad_lookup_values : IDictionaryValue, IValueListItem
    {
        public IDictionaryCategory Category
        {
            get { return this.GetDescriptionsAd_field_description(); }
            set
            {
                //throw new NotImplementedException();
            }
        }

        public string Value
        {
            get { return this.value; }
            set { this.value = value; }
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
            get { return GetValues().Any(); }
        }
    }
}
