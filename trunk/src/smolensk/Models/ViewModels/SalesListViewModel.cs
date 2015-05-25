using System.Collections.Generic;
using smolensk.Mappers;
using smolensk.common;
using meridian.smolensk.proto;

namespace smolensk.Models.ViewModels
{
    public class SalesListViewModel : IBreadCrumbsProvider
    {
        public IEnumerable<SaleViewModel> Items { get; set; }
        public SaleCategoryViewModel Category { get; set; }
        public CompanyViewModel Company { get; set; }

        public SaleType? Type { get; set; }        
        public SortingType Sorting { get; set; }
        public string RouteName { get; set; }
        public string Title { get; set; }
        public bool IsFavorite { get; set; }

        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }

        public List<SaleType> AvailableTypes { get; set; }

        public IEnumerable<INavigateableItem> GetBreadCrumbs()
        {
            var result = new List<INavigateableItem>();
            if (Company != null || Category != null || IsFavorite)
                result.Add(new NavigateableItemDummy(string.Empty, "Скидки"));
            //if (IsFavorite)
            //    result.Add(new NavigateableItemDummy(string.Empty, "Избранные"));
            //else if (Company != null)
            //    result.Add(new NavigateableItemDummy(string.Empty, Company.Title));
            //else if (Category != null)
            //    result.Add(new NavigateableItemDummy(string.Empty, Category.Title));
            return result;
        }
    }
}