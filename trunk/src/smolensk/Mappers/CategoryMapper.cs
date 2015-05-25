using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using meridian.smolensk.proto;
using smolensk.ViewModels;
using meridian.smolensk.system;

namespace smolensk.Mappers
{
    public static class CategoryMapper
    {
        public static CategoryViewModel ToViewModel(news_categories category)
        {
            return new CategoryViewModel(category.id) { Title = category.title };
        }

        public static CategoriesListViewModel CreateCategoriesList(Meridian meridian, long? selectedCategoryId)
        {
            var categories = meridian.news_categoriesStore.All().OrderBy(c => c.order_id);

            CategoriesListViewModel result = new CategoriesListViewModel();
            result.SelectedCategoryId = selectedCategoryId;
            result.Categories = categories.Select(c => ToViewModel(c));

            return result;
        }
    }
}