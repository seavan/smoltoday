using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using smolensk.Models.ViewModels;
using meridian.smolensk.proto;
using meridian.smolensk.system;
using smolensk.common;
using System.ComponentModel;
using smolensk.Services;

namespace smolensk.Mappers
{
    public enum SaleType
    {
        /// <summary> Скидки
        /// </summary>
        [Description("Скидки")]
        Discounts = 1,        
        /// <summary> Распродажи
        /// </summary>
        [Description("Распродажи")]
        Sale = 2,
        /// <summary> Акции
        /// </summary>
        [Description("Акции")]
        Promotion = 3,
        /// <summary> Скидки по банковской карте
        /// </summary>
        [Description("Скидки для владельцев карт Смоленского Банка")]
        DiscountsOnCard = 4        
    }
    
    public static class SaleMapper
    {
        private static SaleCategoryViewModel GetCategory(long? category_id)
        {
            var c_store = Meridian.Default.sale_categoriesStore;

            return category_id.HasValue && c_store.Exists(category_id.Value) ? c_store.Get(category_id.Value).ToCategory() : null;
        }

        public static SaleCategoryViewModel ToCategory(this sale_categories category)
        {
            return new SaleCategoryViewModel(category.id) { Title = category.title };
        }

        public static SaleCategoriesListViewModel GetSalesCategoriesList(this Meridian meridian, long? selectedCategoryId, bool onlyFilled = true)
        {
            var categories = meridian.sale_categoriesStore.All().GetOnlyFilled(onlyFilled).OrderBy(c => c.order_id);

            return new SaleCategoriesListViewModel
            {
                SelectedCategoryId = selectedCategoryId,
                Categories = categories.Select(c => ToCategory(c))
            };
        }
        
        public static SaleViewModel ToSaleViewModel(this sales s)
        {
            var meridian = Meridian.Default;
            var c_store = meridian.companiesStore;
            var model = new SaleViewModel(s.id)
            {
                Title = s.title,
                Text = s.text,
                Phone = s.phone,
                Site = s.site,
                Products = s.products,
                SalesOffices = s.sales_offices,
                WorkTime = s.work_time, 
                Unlimited = s.GetSaleTypeSale_type() != null && s.GetSaleTypeSale_type().unlimited,
                Company = c_store.Exists(s.company_id) ? c_store.Get(s.company_id).ToCompanyViewModel(true) : null,
                ImageForMain = Constants.SalesDataFolder + (!string.IsNullOrEmpty(s.image_for_main) ? s.image_for_main : "emptyImageMain.gif"),
                Image = !string.IsNullOrEmpty(s.image) ? Constants.SalesDataFolder + s.image : string.Empty,
                Comments = s,  
                Favorite = s,
                Percent = s.percent > 0 ? s.percent : (int?)null,
                PercentMax = s.percent_max > 0 ? s.percent_max : (int?)null,
                Category = GetCategory(s.category_id),
                Date = new smolensk.Models.CodeModels.DateRange(
                    s.start_date.Equals(DateTime.MinValue) ? (DateTime?)null : s.start_date,
                    s.end_date.Equals(DateTime.MinValue) ? (DateTime?)null : s.end_date)
            };
           
            return model;
        }

        public static SalesListViewModel GetSalesList(this Meridian meridian, SaleType? type = SaleType.Discounts,
            long? category_id = null, long? company_id = null, long? user_id = null, SortingType sorting = SortingType.Novelty,
            int page = 1, int pageSize = Constants.SalesPageSize)
        {
            var model = new SalesListViewModel();

            var filteredList = GetAll(meridian)
                .GetFavorites(user_id)
                .FilterByCategory(category_id)
                .FilterByCompany(company_id).ToArray();

            model.AvailableTypes = filteredList.GetAvailableTypes().ToList();
            model.Type = !type.HasValue || model.AvailableTypes.Contains(type.Value) ? type : model.AvailableTypes.FirstOrDefault();

            var list = filteredList.FilterByType(model.Type).Sorting(sorting).ToArray();

            model.TotalPages = MappingUtils.CalculatePagesCount(list.Count(), pageSize);
            model.CurrentPage = page;

            list = MappingUtils.TakePage(list, page, pageSize).ToArray();

            model.Items = list.Select(s => s.ToSaleViewModel()).ToArray();
            model.Category = GetCategory(category_id);
            model.Sorting = sorting;           
            
            return model;
        }

        public static IEnumerable<sales> FilterByCategory(this IEnumerable<sales> query, long? category_id)
        {
            if (!category_id.HasValue || category_id.Value == 0) 
                return query;

            return query.Where(a => a.category_id == category_id.Value);
        }

        public static IEnumerable<sales> FilterByCompany(this IEnumerable<sales> query, long? company_id)
        {
            if (!company_id.HasValue || company_id.Value == 0)
                return query;

            return query.Where(s => s.company_id == company_id.Value);
        }

        public static IEnumerable<sales> GetMain(this IEnumerable<sales> query)
        {
            return query.Where(s => s.is_main);
        }

        public static IEnumerable<sales> FilterByType(this IEnumerable<sales> query, SaleType? type)
        {
            return !type.HasValue ?query : query.Where(s => s.sale_type_id == (long)type.Value);
        }

        public static IEnumerable<sales> Sorting(this IEnumerable<sales> query, SortingType? sorting = SortingType.Novelty)
        {
            switch (sorting)
            {
                case SortingType.Novelty:
                    return query.OrderByDescending(s => s.publish_date);

                case SortingType.Value:
                    return query.OrderByDescending(s => s.percent_max > 0 ? s.percent_max : s.percent );
            }
            return query;
        }

        private static IEnumerable<sale_categories> GetOnlyFilled(this IEnumerable<sale_categories> query, bool onlyFilled)
        {
            if (!onlyFilled)
                return query;
            return query.Where(c => c.GetSalesCount() > 0);
        }

        private static IEnumerable<sales> GetAll(Meridian meridian)
        {
            return meridian.salesStore.All();
        }

        private static IEnumerable<SaleType> GetAvailableTypes(this IEnumerable<sales> query)
        {
            var store = Meridian.Default.sale_typesStore;
            return query.Select(s => s.sale_type_id).Distinct()
                .Where(s => store.Exists(s))
                .Select(s => store.Get(s))
                .OrderBy(s => s.order)
                .Select(s => (SaleType)s.id);
        }

        public static SalesListViewModel GetBestSales(this Meridian meridian)
        {
            var list = GetAll(meridian).GetMain().Sorting(SortingType.Novelty).Take(3);

            return new SalesListViewModel { Items = list.Select(s => s.ToSaleViewModel()) };
        }
    }
}