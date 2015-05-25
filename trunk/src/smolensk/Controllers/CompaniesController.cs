using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Script.Serialization;
using meridian.smolensk.proto;
using meridian.smolensk.system;
using smolensk.Domain;
using smolensk.Mappers;
using smolensk.Models.ModelValidators.Attributes;
using smolensk.Models.ViewModels;
using smolensk.Models.ViewModels.Mail;
using smolensk.Services;
using smolensk.common;
using library.Classes;
using smolensk.Extensions;

namespace smolensk.Controllers
{
    public class CompaniesController : BaseController
    {
        public ActionResult Index()
        {
            return RedirectToAction("Categories");
        }

        public ActionResult Categories(int page = 1, int pageSize = Constants.PageSize)
        {
            var model = Meridian.Default.GetCompanyCategories(page, pageSize);

            var routeData = new RouteValueDictionary
                                {
                                    //{"category", model.Category != null ? (long?) model.Category.Id : null}
                                };
            model.Alphabet = new AlphabetViewModel("CompaniesList", routeData, "letter",
                                                   "alphabet")
                                 {
                                     Alphabet = Alphabet.Rus,
                                     Letter = Constants.AnyLetter,
                                 };

            return View("Categories", model);
        }

        public ActionResult CategoriesMenu(long? categoryBaseId, long? selectedId)
        {
            var model = Meridian.Default.GetCompanyCategoriesMenu(selectedId, selectedId);

            return PartialView("CategoriesMenu", model);
        }

        public ActionResult List(long? category, SortingType sorting, string letter, Alphabet alphabet, int page, int pageSize)
        {
            var meridian = Meridian.Default;
            var model = meridian.GetCompanies(category, page, pageSize, sorting, letter);
            model.RouteName = "CompaniesList";

            model.Alphabet = new AlphabetViewModel(model.RouteName, Url.RequestContext.RouteData.Values, "letter", "alphabet")
                                 {
                                     Alphabet = alphabet,
                                     Letter = letter,
                                 };

            if (category.HasValue)
            {
                model.TopCompanies = meridian.GetTopCompanies(category.Value);
            }
            
            return View("List", model);
        }

        public ActionResult Favorites(long? category, SortingType sorting, string letter, Alphabet alphabet, int page, int pageSize)
        {
            var currentUser = HttpContext.UserPrincipal();
            if (currentUser == null)
                return new HttpNotFoundResult();
            
            var meridian = Meridian.Default;
            var model = meridian.GetCompanies(category, page, pageSize, sorting, letter, null, null, currentUser.id);
            model.RouteName = "CompaniesFavorite";
            model.OnlyFavorite = true;

            model.Alphabet = new AlphabetViewModel(model.RouteName, Url.RequestContext.RouteData.Values, "letter", "alphabet")
            {
                Alphabet = alphabet,
                Letter = letter
            };

            if (category.HasValue)
                model.TopCompanies = meridian.GetTopCompanies(category.Value);
            
            return View("List", model);
        }

        public ActionResult EntityMap()
        {
            List<IGeoLocation> entityList = new List<IGeoLocation>();
            entityList.AddRange(meridian.companiesStore.GetEntityMap());
            return PartialView("Widgets/YandexMap", entityList);
        }
        [Authorize403()]
        public ActionResult FavoriteEntityMap()
        {
            List<IGeoLocation> entityList = new List<IGeoLocation>();
            entityList.AddRange(meridian.companiesStore.GetFavoriteEntityMap(HttpContext.UserPrincipal().id));
            return PartialView("Widgets/YandexMap", entityList);
        }

        public ActionResult Search(long? category = null, SortingType sorting = SortingType.Rating, 
            int page = 1, int pageSize = Constants.PageSize, 
            string filterQuery = null, long? filterCategory = null)
        {
            var meridian = Meridian.Default;
            if (filterCategory == 0)
            {
                filterCategory = null;
            }

            var model = meridian.GetCompanies(category, page, pageSize, sorting, Constants.AnyLetter, filterQuery,
                                              filterCategory);

            model.Alphabet = new AlphabetViewModel("CompaniesList", Url.RequestContext.RouteData.Values, "letter",
                                                   "alphabet")
                                 {
                                     Alphabet = Alphabet.Rus,
                                     Letter = Constants.AnyLetter,
                                 };

            if (category.HasValue)
            {
                model.TopCompanies = meridian.GetTopCompanies(category.Value);
            }

            return View("Search", model);
        }

        public ActionResult One(long id)
        {
            CompanyViewModel model = Meridian.Default.GetCompany(id);

            if (model == null)
            {
                return new HttpNotFoundResult();
            }

            var routeData = new RouteValueDictionary
                                {
                                    {"category", model.Category != null ? (long?) model.Category.Id : null}
                                };
            model.Alphabet = new AlphabetViewModel("CompaniesList", routeData, "letter",
                                                   "alphabet")
                                 {
                                     Alphabet = Alphabet.Rus,
                                     Letter = Constants.AnyLetter,
                                 };

            if (model.Category != null)
            {
                model.TopCompanies = Meridian.Default.GetTopCompanies(model.Category.Id);
            }
            else
            {
                model.TopCompanies = new List<CompanyViewModel>();
            }

            companies company = Meridian.Default.companiesStore.Get(id);
            company.IncrementViewsCount();

            return View("One", model);
        }

        [HttpPost]
        public ActionResult WriteMail(long companyId, string theme, string message)
        {
            if (!HttpContext.Request.IsAuthenticated)
            {
                return null;
            }

            var model = new CompanyMailModel
                            {
                                Company = Meridian.Default.companiesStore.Get(companyId),
                                User = HttpContext.UserPrincipal(),
                                Message = message,
                                Theme = theme,
                            };
            new Mailer(this).SendMessageToCompany(model);

            return RedirectToAction("One", new {id = companyId});
        }


        [HttpPost]
        public ActionResult GetCompanies(string newTag)
        {
            string[] words = newTag.SplitWords();

            var organizations = meridian.companiesStore.All().Where(item =>
                (
                (HttpUtility.HtmlDecode(item.title).ClearCompanyName() == words[0] || HttpUtility.HtmlDecode(item.title).ClearCompanyName().Contains(words[0]) || HttpUtility.HtmlDecode(item.title).ClearCompanyName().StartsWith(words[0]))
                && (HttpUtility.HtmlDecode(item.title).ClearCompanyName() == words[1] || HttpUtility.HtmlDecode(item.title).ClearCompanyName().Contains(words[1]) || HttpUtility.HtmlDecode(item.title).ClearCompanyName().StartsWith(words[1]))
                && (HttpUtility.HtmlDecode(item.title).ClearCompanyName() == words[2] || HttpUtility.HtmlDecode(item.title).ClearCompanyName().Contains(words[2]) || HttpUtility.HtmlDecode(item.title).ClearCompanyName().StartsWith(words[2]))
                )
                )
                .Select(item => new RequestsAutoComplete
                {
                    Id = item.id.ToString(),
                    Title = HttpUtility.HtmlDecode(item.title),
                    Additional = item.address
                }).ToList();

            return Content(new JavaScriptSerializer().Serialize(organizations));
        }
    }
}
