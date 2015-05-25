using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using meridian.smolensk.proto;
using smolensk.Domain;
using smolensk.Models.CodeModels;
using smolensk.Models.ViewModels;
using meridian.smolensk.system;
using smolensk.ViewModels;
using smolensk.common;
using smolensk.Extensions;

namespace smolensk.Mappers
{
    public static class CompaniesMapper
    {
        private const string AbsoluteUrlPrefix = "http://";

        public static CompanyViewModel GetCompany(this Meridian meridian, long id)
        {
            if (!meridian.companiesStore.Exists(id))
            {
                return null;
            }

            return meridian.companiesStore.Get(id).ToCompanyViewModel();
        }

        public static CompaniesListViewModel GetCompanies(this Meridian meridian,
            long? categoryId, int page, int pageSize, SortingType sorting, string letter = Constants.AnyLetter,
            string filterQuery = null, long? filterCategory = null, long? userId = null)
        {
            CompanyCategoryViewModel category = null;
            if (categoryId.HasValue)
            {
                var c = meridian.company_categoriesStore.GetCategory(categoryId.Value);
                category = c.ToCategory();
            }

            IEnumerable<CompanyViewModel> companies = GetCompaniesPage(meridian, categoryId, page, pageSize, letter, filterQuery, filterCategory, userId, sorting);
            IList<CompanyViewModel> companiesList = companies.ToList();

            int totalPages = GetCompaniesPagesCount(meridian, categoryId, pageSize, letter, filterQuery, filterCategory, userId);

            //NOTE: Переписываем категорию, чтобы в левом углу отображалась родительская категория
            //а в списке блока поиска могла быть выделена запрошенная подкатегория
            if (filterCategory.HasValue)
            {
                var c = meridian.company_categoriesStore.Get(filterCategory.Value);
                if (c.parent.HasValue())
                {
                    categoryId = c.parent;
                    category = meridian.company_categoriesStore.Get(c.parent).ToCategory();
                }
            }

            var model = new CompaniesListViewModel
                            {
                                PageSize = pageSize,
                                CurrentPage = page,
                                Category = category,
                                Sorting = sorting,
                                Letter = letter,
                                TotalPages = totalPages,
                                Companies = companiesList,
                                SearchBlock = meridian.ToSearchCompanyBlock(categoryId, filterQuery, filterCategory),
                            };


            return model;
        }

        public static SearchCompanyBlockViewModel ToSearchCompanyBlock(this Meridian meridian, long? category, string query, long? filterCategory, bool onlyFilled = true)
        {
            List<CompanyCategoryViewModel> filterCategories;
            if (category.HasValue)
            {
                var c = meridian.company_categoriesStore.GetCategory(category.Value);
                filterCategories = c.GetChildren().FilterByFilled(onlyFilled).Select(t => t.ToCategory()).ToList();
            }
            else
            {
                filterCategories = meridian.company_categoriesStore.All()
                    .Where(c => !c.parent.HasValue())
                    .FilterByFilled(onlyFilled)
                    .Select(c => c.ToCategory())
                    .ToList();
            }

            return new SearchCompanyBlockViewModel
                       {
                           Categories = filterCategories,
                           CategoryId = filterCategory,
                           Query = query,
                       };
        }

        public static IEnumerable<CompanyViewModel> GetCompaniesPage(this Meridian meridian,
            long? categoryId, int page, int pageSize, string letter = Constants.AnyLetter,
            string filterQuery = null, long? filterCategory = null, long? userId = null, 
            SortingType? sorting = null, bool onlyStable = false)
        {
            IEnumerable<companies> query = meridian.companiesStore.All();
            if (onlyStable)
            {
                query = query.Where(c => c.stable_order.HasValue()).OrderByDescending(c => c.stable_order);
            }
            else
            {
                query = query.OrderByDescending(c => c.paid_order);
            }
            query = ApplyFilter(meridian, query, categoryId, letter, filterQuery, filterCategory, userId);
            if (sorting.HasValue)
                query = ApplySorting(query, sorting.Value);

            query = MappingUtils.TakePage(query, page, pageSize);

            return query.Select(c => c.ToCompanyViewModel());
        }

        public static int GetCompaniesPagesCount(this Meridian meridian,
            long? categoryId, int pageSize, string letter = Constants.AnyLetter,
            string filterQuery = null, long? filterCategory = null, long? userId = null, bool onlyStable = false)
        {
            IEnumerable<companies> query = meridian.companiesStore.All();
            if (onlyStable)
            {
                query = query.Where(c=>c.stable_order.HasValue()).OrderByDescending(c => c.stable_order);
            }
                //.OrderByDescending(c => c.paid_order); //NOTE: Кол-во не меняется, можно не делать лишнюю сортировку
            query = ApplyFilter(meridian, query, categoryId, letter, filterQuery, filterCategory, userId);

            int count = query.Count();

            return MappingUtils.CalculatePagesCount(count, pageSize);
        }

        private static IEnumerable<companies> ApplyFilter(Meridian meridian, IEnumerable<companies> query,
            long? categoryId, string letter, string filterQuery, long? filterCategory, long? userId = null)
        {
            query = query.GetFavorites(userId);
            if (categoryId.HasValue)
            {
                var category = meridian.company_categoriesStore.GetCategory(categoryId.Value);
                long[] ids = GetAllCategoriesIds(meridian, category);
                query = query.Where(c => ids.Contains(c.category_id));
            }

            if (letter != Constants.AnyLetter)
            {
                query = query.Where(c => c.title.StartsWith(letter, StringComparison.InvariantCultureIgnoreCase));
            }

            if (!string.IsNullOrEmpty(filterQuery))
            {
                query = query
                    .Where(c => c.title.IndexOf(filterQuery, StringComparison.InvariantCultureIgnoreCase) != -1
                                || c.description.IndexOf(filterQuery, StringComparison.InvariantCultureIgnoreCase) != -1);
            }

            if (filterCategory.HasValue)
            {
                query = query.Where(c => c.category_id == filterCategory.Value);
            }

            return query;
        }

        private static IEnumerable<companies> ApplySorting(IEnumerable<companies> query, SortingType sorting)
        {
            switch (sorting)
            {
                case SortingType.Rating:
                    query = query.OrderByDescending(c => c.GetRating());
                    break;
                case SortingType.Alphabet:
                    query = query.OrderBy(c => c.title);
                    break;
                case SortingType.Novelty:
                default:
                    query = query.OrderByDescending(c => c.publish_date);
                    break;
            }

            return query;
        }

        public static CompanyViewModel ToCompanyViewModel(this companies company, bool onlyDesk=false)
        {
            Meridian meridian = Meridian.Default;

            var model = new CompanyViewModel(company.id)
                            {
                                Title = company.title,
                                Address = company.address,
                                WorkTime = company.work_time,
                                Www = PrepareUrl(company.www),
                                Email = company.email.Trim(),
                                Phones = company.phones,
                                Description = company.description,
                                PublishDate = company.publish_date,
                                PublishDateStr = Formatter.FormatCompanyPublishDate(company.publish_date),
                                Leader = company.leader,
                                IsPaid = company.paid_order != 0,
                                PaidOrder = company.paid_order,
                                IsStable = company.stable_order != 0,
                                StableOrder = company.stable_order,

                                Comments = company,
                                Marks = company,
                                GeoLocation = company,
                                Favorite = company,
                                Rating = company.GetRating(),
                            };

            model.LogoUrl = GetLogoUrl(company);
            model.Files = GetFiles(company);
            model.KindsOfActivities = company.GetKidsOfActivities()
                .Select(k => new DictionaryElement(k.id, k.name))
                .ToList();

            if (company.GetCategory() != null)
            {
                model.Category = company.GetCategory().ToCategory();
            }

            if (!onlyDesk)
            {
                model.Files = GetFiles(company);
                model.Photos = company.GetPhotos()
                    .Select(p => new RelatedPhoto
                                     {
                                         Link = Constants.CompaniesDataFolder + p.normal,
                                         PhotoUrl = Constants.CompaniesDataFolder + p.thumbnaill,
                                         Title = "",
                                     })
                    .ToList();
                model.Vacancies = company.GetActualVacancies()
                    .Select(v => meridian.ToVacancyViewModel(v))
                    .ToList();
            }

            return model;
        }

        private static string PrepareUrl(string url)
        { 
            if (string.IsNullOrWhiteSpace(url))
                return string.Empty;

            return url.StartsWith(AbsoluteUrlPrefix) ? url : AbsoluteUrlPrefix + url.Trim();
        }

        private static List<FileElement> GetFiles(companies company)
        {
            return company.GetFiles()
                .Select(f => new FileElement
                                 {
                                     Id = f.id,
                                     FileName = f.file,
                                     Size = f.size,
                                     Title = f.title,
                                     Url = Constants.CompanyFilesDataFolder+f.file,
                                 }).ToList();
        }

        private static string GetLogoUrl(companies company)
        {
            var photo = company.GetPhotoLogo();
            if (photo == null)
            {
                return "/content/images/companyEmpty.jpg";
            }

            return Constants.CompaniesDataFolder + photo.normal;

        }

        private static long[] GetAllCategoriesIds(Meridian meridian, company_categories category)
        {
            var categories = new List<company_categories> {category};

            var subs = category.GetChildren().ToList();

            categories.AddRange(subs);

            return categories.Select(c => c.id).ToArray();
        }

        public static IList<CompanyViewModel> GetTopCompanies(this Meridian meridian, long categoryId, int top = Constants.TopCompanies)
        {
            return meridian.company_categoriesStore.Get(categoryId).GetCompanies()
                .OrderByDescending(c => c.GetPopularity())
                .Take(top)
                .Select(c => c.ToCompanyViewModel(true))
                .ToList();
        }

        public static IEnumerable<SelectListItem> GetOwnerships(this Meridian meridian)
        {
            return meridian.company_ownershipsStore.All()
                .Select(c => new SelectListItem
                {
                    Text = c.title,
                    Value = c.id.ToString()
                });
        }



        public static companies GetCompany(long id, string name)
        {
            name = name != null ? name.Trim() : null;
            if (string.IsNullOrEmpty(name)) return null;
            
            companies cur = null;
            var listAllOrg = Meridian.Default.companiesStore.All();

            if (id > 0)
                cur = listAllOrg.FirstOrDefault(i => i.id == id && HttpUtility.HtmlDecode(i.title).ClearCompanyName() == HttpUtility.HtmlDecode(name).ClearCompanyName());

            if (cur == null)
                cur = listAllOrg.FirstOrDefault(i => HttpUtility.HtmlDecode(i.title).ClearCompanyName() == HttpUtility.HtmlDecode(name).ClearCompanyName());

            return cur;
        }
    }
}