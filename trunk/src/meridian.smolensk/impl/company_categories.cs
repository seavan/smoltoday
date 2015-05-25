using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using meridian.smolensk.impl.Interfaces;
using meridian.smolensk.system;
using smolensk.common;

namespace meridian.smolensk.proto
{
    public partial class company_categories : IPopularityMaterial, ILookupValue, ILookupValueAspectProvider
    {
        #region Implementation of IPopularityMaterial

        //NOTE: Учитывается только структура КАТЕГОРИЯ-ПОДКАТЕГОРИЯ, более сложная структура категорий - будет проигнорирована
        public int GetPopularity()
        {
            var meridian = Meridian.Default;

            if (parent.HasValue())
            {
                return meridian.companiesStore.All()
                    .Where(c => c.category_id == id)
                    .Sum(c => c.GetPopularity());
            }

            int rootValue = meridian.companiesStore.All()
                .Where(c => c.category_id == id)
                .Sum(c => c.GetPopularity());

            int subValue = meridian.company_categoriesStore.All()
                .Where(c => c.parent == id)
                .Sum(c => c.GetPopularity());

            return rootValue + subValue;
        }

        #endregion


        public string title
        {
            get { return name; }
        }
        public string lookup_title
        {
            get { return name; }
        }

        public int lookup_value_level
        {
            get { return GetChildrenCompany_categorie() != null ? 1 : 0; }
        }

        public bool lookup_value_disabled
        {
            get { return GetChildrenCompany_categorie() == null; }
        }

        public ILookupValueAspect GetparentLookupValueAspect()
        {
            return new LookupAspect("category_id", this, () => Meridian.Default.company_categoriesStore.All().Where(s => s.GetChildrenCompany_categorie() == null).OrderBy(s => s.name).Select(s => new LookupValueDummy()
                {
                    id = s.id,
                    lookup_title = s.name,

                })
            );
        }

        public int GetCompaniesCount()
        {
            return Companies.Count() + Children.Sum(child => child.GetCompaniesCount());
        }
        
    }
}
