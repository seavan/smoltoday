using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace meridian.smolensk.proto
{
    public partial class vacancy_facilities : IDictionaryCategory, IValueListAspectProvider
    {
        //NOTE: Возможно, стоит добавить признак в самой БД, но пока так
        public vacancy_facility_variants GetDefaultVariant()
        {
            return GetVariants().First();
        }

        /// <summary>
        /// Используется на страницах профиля
        /// </summary>
        public bool Checked { get; set; }

        public vacancy_facility_variants SelectedVariant { get; set; }


        public bool MultiValue
        {
            get { return false; }
        }

        public bool FreeValue
        {
            get { return false; }
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
            return this.Variants;
        }

        public IValueListAspect GetValueListAspect(string _fieldName)
        {
            return new ValueListAspect<vacancy_facility_variants>(this,
                () => this.Variants, (a) =>
                    this.AddVariants(new vacancy_facility_variants()
                    {
                        title = a
                    }, true), "FacilitiesValues"
                );
        }
    }
}
