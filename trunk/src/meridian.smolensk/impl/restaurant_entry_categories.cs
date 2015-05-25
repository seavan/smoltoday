using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace meridian.smolensk.proto
{
    public partial class restaurant_entry_categories : IDictionaryCategory, IValueListAspectProvider
    {


        public bool MultiValue
        {
            get { return is_multiple; }
        }

        public bool FreeValue
        {
            get { return is_anyvalue; }
        }

        public bool Selectable
        {
            get { return true; }
        }
        public bool ShowIsNoSelect
        {
            get { return true; }
        }

        public IEnumerable<IDictionaryValue> GetAllValues()
        {
            return this.EntriesValues;
        }

        public IValueListAspect GetValueListAspect(string _fieldName)
        {
            return new ValueListAspect<restaurant_entries>(this,
                () => this.EntriesValues, (a) =>
                    this.AddEntriesValues(new restaurant_entries()
                        {
                            title = a
                        }, true), "EntriesValues"
                );
        }
    }
}