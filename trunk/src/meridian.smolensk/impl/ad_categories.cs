using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using meridian.smolensk.system;

namespace meridian.smolensk.proto
{
    public partial class ad_categories : ILookupValue, ILookupValueAspectProvider
    {


        public int lookup_value_level
        {
            get { return parent_id > 0 ? 1 : 0; }
        }

        public bool lookup_value_disabled
        {
            get { return parent_id == 0; }
        }
        public string lookup_title
        {
            get { return title; }
        }
    
        public long AdsCount
        {
            get
            {
                List<long> subcategories =
                    Meridian.Default.ad_categoriesStore.All()
                            .Where(item => item.parent_id == id)
                            .Select(item => item.id)
                            .ToList();

                List<long> descriptions =
                    Meridian.Default.ad_field_descriptionsStore.All().Where(
                        d => d.ad_category_id == id || subcategories.Contains(d.ad_category_id) || (parent_id > 0 && d.ad_category_id == parent_id)).Select(t => t.id).ToList();

               
                return Meridian.Default.ad_fieldsStore.All().Where(
                    f => f.GetAdFieldsAd_advertisment() != null && ((descriptions.Contains(f.description_id) && parent_id <= 0) || (descriptions.Contains(f.description_id) && parent_id > 0 && f.GetAdFieldsAd_advertisment().category_id == id))).GroupBy(f => f.ad_id).
                    Count();


            }
        }

        public long ParentCategoryId
        {
            get
            {
                return parent_id == 0 ? id : parent_id;
            }
        }

        public bool IsRootCategory
        {
            get { return parent_id == 0; }
        }

        public bool HasSubcategory(long subcategoryId)
        {
            return Meridian.Default.ad_categoriesStore.All().Any(item => item.id == subcategoryId && item.parent_id == id);
        }

        public List<ad_categories> GetPopularSubcategories()
        {
            var result = new List<ad_categories>();

            if (parent_id == 0)
            {
                result = Meridian.Default.ad_categoriesStore.All()
                                 .Where(item => item.parent_id == id)
                                 .OrderByDescending(item => item.AdsViewCount)
                                 .Take(4)
                                 .ToList();
            }

            return result;
        }

        public long GetRootDescriptionId(string name)
        {
            var desc = Meridian.Default.ad_field_descriptionsStore.All()
                        .FirstOrDefault(item => item.ad_category_id == ParentCategoryId && item.title == name);
            return desc == null ? 0 : desc.id;
        }

        public List<ad_advertisments> GetAllAdvertisments()
        {
            var result = Advertisments;

            if (parent_id == 0)
            {
                var ids = Subcategories.Select(item => item.id).ToList();
                result = Meridian.Default.ad_advertismentsStore.All().Where(item => ids.Contains(item.category_id));
            }

            return result.ToList();
        }

        public List<long> CategoryIds
        {
            get { return IsRootCategory ? new List<long> {id} : new List<long> {id, ParentCategoryId}; }
        }

        private long AdsViewCount
        {
            get
            {
                return Meridian.Default.ad_advertismentsStore.All()
                            .Where(item => item.category_id == id)
                            .Sum(item => item.view_count);
            }
        }

        public ILookupValueAspect GetLookupValueAspect(string _fieldName)
        {
            if (_fieldName != "parent_id") return null;

            return new LookupAspect("parent_id", this, () =>
            {
                var categories = Meridian.Default.ad_categoriesStore.All();
                var parentCategories = categories.Where(s => s.parent_id == 0).Select(s => new LookupValueDummy()
                {
                    lookup_title  = s.title,
                    id = s.id
                });

                return parentCategories;
            });

        }
    }
}
