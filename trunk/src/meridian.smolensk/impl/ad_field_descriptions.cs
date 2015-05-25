using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace meridian.smolensk.proto
{
    public partial class ad_field_descriptions : IDictionaryCategory, IValueListAspectProvider
    {
        public bool MultiValue
        {
            get { return false; }
        }

        public bool FreeValue
        {
            get { return this.is_anyvalue; }
        }

        public bool Selectable
        {
            get { return false; }
        }
        public bool ShowIsNoSelect
        {
            get { return !this.title.Equals("Тип предложения"); }
        }

        public IEnumerable<IDictionaryValue> GetAllValues()
        {
            return this.Descriptions;
        }

        public IValueListAspect GetValueListAspect(string _fieldName)
        {
            return new ValueListAspect<ad_lookup_values>(this,
                () => this.Descriptions, (a) =>
                    this.AddDescriptions(new ad_lookup_values()
                    {
                        value = a
                    }, true), "DescriptionsValues"
                );
        }
    }
}
