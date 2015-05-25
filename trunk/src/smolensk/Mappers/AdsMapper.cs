using System;
using System.Collections.Generic;
using System.Linq;
using meridian.smolensk.proto;
using meridian.smolensk.system;
using smolensk.common;
using smolensk.Models.CodeModels;
using smolensk.Models.ViewModels;

namespace smolensk.Mappers
{
    public static class AdsMapper
    {
        public static FilterAdsViewModel ToFilterAdsViewModel(ad_categories category, long type, string sort = "asc")
        {
           long descId = category.GetRootDescriptionId("Тип предложения");
            var filterModel = new FilterAdsViewModel
                {
                    Types = Meridian.Default.ad_lookup_valuesStore.All()
                                    .Where(item => item.description_id == descId)
                                    .Select(item => new AdType {Type = item.value, Id = item.id})
                                    .OrderBy(item => item.Id)
                                    .ToList(),
                    Sort = sort,
                    CategoryId = category.id,
                    DescriptionId = descId
                };

            foreach (var filterType in filterModel.Types)
            {
                filterType.AdsCount = Meridian.Default.ad_fieldsStore.GetExisting()
                            .Count(item => item.description_id == descId && item.value_id == filterType.Id
                                && (item.GetAdFieldsAd_advertisment().category_id == category.id || category.Subcategories.Any(sub => sub.id == item.GetAdFieldsAd_advertisment().category_id)));
            }

            filterModel.Type = type == 0 && filterModel.Types.Any() ? filterModel.Types.OrderByDescending(item => item.AdsCount).First().Id : type;

            return filterModel;
        }

        public static AdsListViewModel ToAdsListViewModel(List<ad_advertisments> ads, int page, int pageSize = Constants.PageSize)
        {
            int count = ads.Count;
            int size = count / pageSize + Convert.ToInt32(count % pageSize != 0);

            return new AdsListViewModel
            {
                Advertisments = MappingUtils.TakePage(ads, page, pageSize),
                TotalPages = size,
                CurrentPage = page
            };
        }

        public static List<AdvertProperty> GetProperties(long categoryId, long adId = 0)
        {
            var result = new List<AdvertProperty>();

            var category = Meridian.Default.ad_categoriesStore.Get(categoryId);
            ad_advertisments ad = null;

            if (adId > 0)
            {
                ad = Meridian.Default.ad_advertismentsStore.Get(adId);
            }

            var fieldDesciptions = Meridian.Default.ad_field_descriptionsStore.All()
                        .Where(item => category.CategoryIds.Contains(item.ad_category_id)).OrderBy(item => item.id);
            
            foreach (var desciption in fieldDesciptions)
            {
                var adProp = new AdvertProperty
                    {
                        Title = desciption.title,
                        DescriptionId = desciption.id,
                        Values = Meridian.Default.ad_lookup_valuesStore.All()
                                         .Where(item => item.description_id == desciption.id)
                                         .ToDictionary(item => item.id, item => item.value)
                    };

                if (ad != null)
                {
                    var adField = Meridian.Default.ad_fieldsStore.All()
                                .FirstOrDefault(item => item.description_id == desciption.id && item.ad_id == ad.id);
                    if (adField != null)
                    {
                        adProp.Value = adField.value;
                        adProp.ValueId = adField.value_id;
                    }
                }

                result.Add(adProp);
            }

            return result;
        }

        public static IEnumerable<ad_categories> GetFilled(this IEnumerable<ad_categories> categories)
        {
            return categories.Where(item => item.AdsCount > 0);
        }
    }
}