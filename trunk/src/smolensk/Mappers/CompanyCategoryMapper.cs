using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using meridian.smolensk.proto;
using meridian.smolensk.system;
using smolensk.Models.ViewModels;
using smolensk.ViewModels;
using smolensk.common;

namespace smolensk.Mappers
{
    public static class CompanyCategoryMapper
    {
        public static CategoriesListViewModel GetCompanyCategoriesMenu(this Meridian meridian, long? categoryBaseId, long? selectedId, bool onlyFilled = true)
        {
            var model = new CategoriesListViewModel();

            IEnumerable<company_categories> query = meridian.company_categoriesStore.All();

            if (!categoryBaseId.HasValue)
            {
                query = query.Where(c => !c.parent.HasValue());
            }
            else
            {
                query = query.Where(c => c.parent == categoryBaseId.Value);
            }

            var roots = query.FilterByFilled(onlyFilled)
                             .Select(c => new CategoryViewModel(c.id) { Title = c.name })
                             .ToList();

            model.Categories = roots;
            model.SelectedCategoryId = selectedId;

            return model;
        }

        public static CompanyCategoriesViewModel GetCompanyCategories(this Meridian meridian, int page, int pageSize)
        {
            var model = new CompanyCategoriesViewModel
                            {
                                Categories = GetCompanyCategoriesTree(meridian),
                                SearchBlock = meridian.ToSearchCompanyBlock(null, null, null),
                            };

            model.CurrentPage = page;
            model.PageSize = pageSize;
            model.TotalPages = meridian.GetCompaniesPagesCount(null, pageSize, Constants.AnyLetter, null, null,null, true);
            model.Entities = meridian.GetCompaniesPage(null, page, pageSize, Constants.AnyLetter, null, null,null, null, true).ToList();

            return model;
        }

        public static IList<CompanyCategoryViewModel> GetCompanyCategoriesTree(this Meridian meridian, bool onlyRoot=false, bool onlyFilled = true)
        {
            var roots = meridian.company_categoriesStore.All()
                .Where(c => !c.parent.HasValue())
                .FilterByFilled(onlyFilled)
                .Select(c => c.ToCategory());

            if (!onlyRoot)
            {
                roots = FillCategories(roots, onlyFilled);
            }

            return roots.ToList();
        }

        private static IEnumerable<CompanyCategoryViewModel> FillCategories(IEnumerable<CompanyCategoryViewModel> categories, bool onlyFilled = true)
        {
            var meridian = Meridian.Default;
            var list = new List<CompanyCategoryViewModel>();

            foreach (CompanyCategoryViewModel category in categories)
            {
                long parentId = category.Id;

                var children = meridian.company_categoriesStore.All()
                    .Where(c => c.parent == parentId)
                    .FilterByFilled(onlyFilled)
                    .Select(c => c.ToCategory());

                category.Children = FillCategories(children, onlyFilled).ToList();
                list.Add(category);
            }
            return list;
        }

        public static CompanyCategoryViewModel ToCategory(this company_categories category)
        {
            CompanyCategoryViewModel parent = null;
            if (category.parent.HasValue())
            {
                parent = category.GetChildrenCompany_categorie().ToCategory();
            }

            int count = category.Companies.Count(); 

            return new CompanyCategoryViewModel(category.id)
                       {
                           CountOfCompanies = count,
                           Icon = category.icon,
                           IconUrl = Constants.CompanyCategoriesFolder + category.icon,
                           Title = category.name,
                           Children = new List<CompanyCategoryViewModel>(),
                           Parent = parent,
                           Popularity = category.GetPopularity(),
                       };
        }

        public static IList<IComment> GetLastComments(int count = Constants.CountOfLastComments)
        {
            IEnumerable<IComment> query = Meridian.Default.company_commentsStore.All()
                .Where(c=>!c.delete)
                .OrderByDescending(c => c.CreateDate)
                .Take(count);

            return query.ToList();
        }

        public static IEnumerable<company_categories> FilterByFilled(this IEnumerable<company_categories> query, bool onlyFilled)
        {
            if (!onlyFilled)
                return query;
            return query.Where(c => c.GetCompaniesCount() > 0);
        }
    }
}