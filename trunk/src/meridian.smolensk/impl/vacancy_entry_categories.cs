using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace meridian.smolensk.proto
{
    public partial class vacancy_entry_categories : IDictionaryCategory, IValueListAspectProvider
	{
        public bool MultiValue
        {
            get { return this.title.Equals("Образование") ? false : true; }
        }

        public bool FreeValue
        {
            get { return false; }
        }

        public bool Selectable
        {
            get { return false; }
        }
        public bool ShowIsNoSelect
        {
            get { return true; }
        }

        public IEnumerable<IDictionaryValue> GetAllValues()
        {
            return this.Entries;
        }

        public IValueListAspect GetValueListAspect(string _fieldName)
        {
            return new ValueListAspect<vacancy_entries>(this,
                () => this.Entries, (a) =>
                    this.AddEntries(new vacancy_entries()
                    {
                        title = a
                    }, true), "EntriesValues"
                );
        }
	}
}
