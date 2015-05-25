using System;
using System.Diagnostics;
using System.Reflection;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using System.Web.Routing;
using admin.web.common;
using log4net;
using log4net.Config;
using meridian.smolensk.proto;
using meridian.smolensk.system;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using smolensk.common;
using smolensk.common.Infrastructure;
using smolensk.Extensions;
using smolensk.Mappers;
using smolensk.Models.ModelValidators;
using smolensk.Models.ModelValidators.Attributes;
using smolensk.Services;

namespace smolensk
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : HttpApplication
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
    "static", "{*url}", new { controller = "Main", action = "Static" }, new { isStatic = new StaticRouteConstraint() }
);

            routes.MapRoute("accountingActivation", "Security/Activate/{email}/{activationKey}", new { controller = "Security", action = "Activate" });
            routes.MapRoute("accountingRegainPassword", "Security/RegainPassword/{email}/{regainkey}", new { controller = "Security", action = "RegainPassword" });
            routes.MapRoute("authenticationAuto", "Security/Autologin/{id}", new { controller = "Security", action = "Autologin" });

            routes.MapRoute("OAuthSignIn", "Security/OAuthSignIn/{serviceName}", new { controller = "Security", action = "OAuthSignIn" });

            routes.MapRoute(
                "Profile", // Route name
                "Profile/{action}", // URL with parameters
                new { controller = "Profile", action = "Index" } // Parameter defaults
            );
            routes.MapRoute(
                "ProfileUser", // Route name
                "Profile/User/{userId}", // URL with parameters
                new { controller = "Profile", action = "User", userId = UrlParameter.Optional } // Parameter defaults
            );
            routes.MapRoute(
                "ProfileMessages", // Route name
                "Profile/Messages/{sortDirection}/{page}", // URL with parameters
                new { controller = "Profile", action = "Messages", sortDirection = SortingDirection.Desc, page = 1 } // Parameter defaults
            );
            routes.MapRoute(
                "ProfileComments", // Route name
                "Profile/Comments/{sortDirection}/{page}", // URL with parameters
                new { controller = "Profile", action = "Comments", sortDirection = SortingDirection.Desc, page = 1 } // Parameter defaults
            );
            routes.MapRoute(
                "ProfileMarks", // Route name
                "Profile/Marks/{sortDirection}/{page}", // URL with parameters
                new { controller = "Profile", action = "Marks", sortDirection = SortingDirection.Desc, page = 1 } // Parameter defaults
            );
            routes.MapRoute(
                "ProfileActions", // Route name
                "Profile/Actions/{page}", // URL with parameters
                new { controller = "Profile", action = "Actions", page = 1 } // Parameter defaults
            );
            routes.MapRoute(
                "ProfileDiscounts", // Route name
                "Profile/Discounts/{page}", // URL with parameters
                new { controller = "Profile", action = "Discounts", page = 1 } // Parameter defaults
            );
            routes.MapRoute(
                "ProfileCompanies", // Route name
                "Profile/Companies/{page}", // URL with parameters
                new { controller = "Profile", action = "Companies", page = 1 } // Parameter defaults
            );
            routes.MapRoute(
                "ProfileRestaurants", // Route name
                "Profile/Restaurants/{page}", // URL with parameters
                new { controller = "Profile", action = "Restaurants", page = 1 } // Parameter defaults
            );
            routes.MapRoute(
                "ProfileBlogsList", // Route name
                "Profile/BlogsList/{page}", // URL with parameters
                new { controller = "Profile", action = "BlogsList", page = 1 } // Parameter defaults
            );
            routes.MapRoute(
                "ProfileObtainedPhotoList", // Route name
                "Profile/PhotoBank/{page}", // URL with parameters
                new { controller = "Profile", action = "PhotoBank", page = 1 } // Parameter defaults
            );
            routes.MapRoute(
                "ProfileAlbumsList", // Route name
                "Profile/PhotoProfile/{page}", // URL with parameters
                new { controller = "Profile", action = "PhotoProfile", page = 1 } // Parameter defaults
            );
            routes.MapRoute(
                "ProfileAlbum", // Route name
                "Profile/PhotoAlbum/{albumId}/{page}", // URL with parameters
                new { controller = "Profile", action = "PhotoAlbum", albumId = 0, page = 1 } // Parameter defaults
            );
            routes.MapRoute(
                "ProfileAdverts", // Route name
                "Profile/Adverts/{page}", // URL with parameters
                new { controller = "Profile", action = "Adverts", page = 1 } // Parameter defaults
            );
            routes.MapRoute(
                "ProfileFavoriteAdverts", // Route name
                "Profile/FavoriteAdverts/{page}", // URL with parameters
                new { controller = "Profile", action = "FavoriteAdverts", page = 1 } // Parameter defaults
            );

            routes.MapRoute(
                "BlogsMain", // Route name
                "Blogs/Index/{dateFilter}", // URL with parameters
                new { controller = "Blogs", action = "Index", dateFilter = DateFilterTypes.ToDay } // Parameter defaults
                );
            routes.MapRoute(
                "BlogsList", // Route name
                "Blogs/List/{sortingType}/{page}/{categoryId}", // URL with parameters
                new { controller = "Blogs", action = "List", sortingType = SortingType.Rating, page = 1, categoryId = UrlParameter.Optional } // Parameter defaults
                );
            routes.MapRoute(
                "BlogsAuthorList", // Route name
                "Blogs/Author/{authorId}/{sortingType}/{page}", // URL with parameters
                new { controller = "Blogs", action = "Author", authorId = 0, sortingType = SortingType.Rating, page = 1 } // Parameter defaults
                );


            routes.MapRoute(
                "VacancyCompanyList", // Route name
                "Vacancies/SearchCompany/{regionId}/{cityId}/{allCompanies}/{letter}/{filter}", // URL with parameters
                new { controller = "Vacancy", action = "SearchCompany",
                      regionId = 0,
                      cityId = 0,
                      allCompanies = "off",
                      letter = Constants.AnyLetter,
                      filter = UrlParameter.Optional,
                } // Parameter defaults
                );

            routes.MapRoute(
                "RestaurantsList", // Route name
                "Restaurants/List/{letter}/{alphabet}/{page}/{entries}", // URL with parameters
                new { controller = "Restaurants", action = "List", page = 1, entries = "", letter = Constants.AnyLetter,
                alphabet = Alphabet.Rus } // Parameter defaults
            );

            routes.MapRoute(
                "CompaniesList", // Route name
                "Companies/List/{sorting}/{letter}/{alphabet}/{page}/{pageSize}/{category}", // URL with parameters
                new {controller = "Companies", action = "List", 
                    sorting = SortingType.Rating, 
                    letter = Constants.AnyLetter, 
                    alphabet = Alphabet.Rus,
                    page = 1, pageSize = Constants.DefaultListPageSize,
                    category = UrlParameter.Optional,
                    } // Parameter defaults
                );

            routes.MapRoute(
                "CompaniesFavorite", // Route name
                "Companies/Favorites/{sorting}/{letter}/{alphabet}/{page}/{pageSize}/{category}", // URL with parameters
                new
                {
                    controller = "Companies",
                    action = "Favorites",
                    sorting = SortingType.Rating,
                    letter = Constants.AnyLetter,
                    alphabet = Alphabet.Rus,
                    page = 1,
                    pageSize = Constants.PageSize,
                    category = UrlParameter.Optional,
                } // Parameter defaults
                );
            
            
            //routes.MapRoute(
            //    "CompanyCategories", // Route name
            //    "Companies/Categories/{page}/{pageSize}", // URL with parameters
            //    new
            //        {
            //            controller = "Companies",
            //            action = "Categories",
            //            page = 1,
            //            pageSize = Constants.PageSize
            //        } // Parameter defaults
            //    );
            routes.MapRoute(
                    "DiscountOne", // Route name
                    "Discounts/One/{id}/{entryName}", // URL with parameters
                    new { controller = "Discounts", action = "One", id = UrlParameter.Optional } // Parameter defaults
            );

            routes.MapRoute(
                "DiscountsList", // Route name
                "Discounts/{action}/{type}/{page}/{categoryId}/{companyId}", // URL with parameters
                new
                {
                    controller = "Discounts",
                    action="Index",
                    type = SaleType.DiscountsOnCard,
                    page = 1,
                    categoryId = UrlParameter.Optional,
                    companyId = UrlParameter.Optional,
                } // Parameter defaults
                );
            routes.MapRoute(
                "ActionsList", // Route name
                "Poster/Index/{dateFilter}", // URL with parameters
                new
                {
                    controller = "Poster",
                    action = "Index",
                    dateFilter = ActionDateFilterType.Now
                } // Parameter defaults
                );
            routes.MapRoute(
                "PlaceSchedule", // Route name
                "Poster/PlaceSchedule/{id}/{filter}", // URL with parameters
                new
                {
                    controller = "Poster",
                    action = "PlaceSchedule",
                    filter = ScheduleFilterType.In3Days
                } // Parameter defaults
                );
            routes.MapRoute(
                "ActionSchedule", // Route name
                "Poster/ActionSchedule/{id}/{filter}", // URL with parameters
                new
                {
                    controller = "Poster",
                    action = "ActionSchedule",
                    filter = ScheduleFilterType.Today
                } // Parameter defaults
                );
            routes.MapRoute(
                "ActionsListByCategory", // Route name
                "Poster/Category/{id}/{dateFilter}", // URL with parameters
                new
                {
                    controller = "Poster",
                    action = "Category",
                    dateFilter = ActionDateFilterType.Now
                } // Parameter defaults
                );
            routes.MapRoute(
                "ActionsListBlock", // Route name
                "Poster/ActionsList/{id}/{sorting}/{sortingDir}", // URL with parameters
                new
                {
                    controller = "Poster",
                    action = "ActionsList",
                    sorting = ActionSortingType.Alphabet,
                    sortingDir = SortingDirection.Asc
                } // Parameter defaults
                );
            routes.MapRoute(
                "PLacesListBlock", // Route name
                "Poster/PLacesList/{id}/{sorting}/{sortingDir}", // URL with parameters
                new
                {
                    controller = "Poster",
                    action = "PLacesList",
                    sorting = PlaceSortingType.Title,
                    sortingDir = SortingDirection.Asc
                } // Parameter defaults
                );
            routes.MapRoute(
                            "Video0", // Route name
                            "video/{_id}", // URL with parameters
                            new { controller = "Main", action = "Video" } // Parameter defaults
                        );

            routes.MapRoute(
                    "NewsList", // Route name
                    "News/List/{page}/{categoryId}/{year}/{month}/{day}", // URL with parameters
                    new { controller = "News", action = "List", page = 1 } // Parameter defaults
            );
            
            //routes.MapRoute(
            //        "NewsCaregory", // Route name
            //        "News/Category/{categoryId}/{year}/{month}/{day}", // URL with parameters
            //        new { controller = "News", action = "Category" } // Parameter defaults
            //);

            //routes.MapRoute(
            //        "NewsArchive", // Route name
            //        "News/Archive/{year}/{month}/{day}", // URL with parameters
            //        new { controller = "News", action = "Archive", year = UrlParameter.Optional } // Parameter defaults
            //);
            routes.MapRoute(
                    "NewsOne", // Route name
                    "News/Single/{id}/{entryName}", // URL with parameters
                    new { controller = "News", action = "Single", id = UrlParameter.Optional } // Parameter defaults
            );
            routes.MapRoute(
                    "PhotoOne", // Route name
                    "PhotoBank/Image/{id}/{entryName}", // URL with parameters
                    new { controller = "PhotoBank", action = "Image", id = UrlParameter.Optional } // Parameter defaults
            );
            routes.MapRoute(
                    "RestaurantOne", // Route name
                    "Restaurants/One/{id}/{entryName}", // URL with parameters
                    new { controller = "Restaurants", action = "One", id = UrlParameter.Optional } // Parameter defaults
            );
            routes.MapRoute(
                    "AdvertOne", // Route name
                    "Adverts/One/{id}/{entryName}", // URL with parameters
                    new { controller = "Adverts", action = "One", id = UrlParameter.Optional } // Parameter defaults
            );
            routes.MapRoute(
                    "PosterActionOne", // Route name
                    "Poster/Action/{id}/{entryName}", // URL with parameters
                    new { controller = "Poster", action = "Action", id = UrlParameter.Optional } // Parameter defaults
            );
            routes.MapRoute(
                    "PosterPlaceOne", // Route name
                    "Poster/Place/{id}/{entryName}", // URL with parameters
                    new { controller = "Poster", action = "Place", id = UrlParameter.Optional } // Parameter defaults
            );
            routes.MapRoute(
                    "CompanyOne", // Route name
                    "Companies/One/{id}/{entryName}", // URL with parameters
                    new { controller = "Companies", action = "One", id = UrlParameter.Optional } // Parameter defaults
            );
            routes.MapRoute(
                    "BlogOne", // Route name
                    "Blogs/One/{id}/{entryName}", // URL with parameters
                    new { controller = "Blogs", action = "One", id = UrlParameter.Optional } // Parameter defaults
            );
            routes.MapRoute(
                    "BlogList", // Route name
                    "Blogs/List/{sortingType}/{page}/{categoryId}", // URL with parameters
                    new { controller = "Blogs", action = "List", sortingType = SortingType.Rating, page = UrlParameter.Optional, categoryId = UrlParameter.Optional } // Parameter defaults
            );
            routes.MapRoute(
                    "VacancyOne", // Route name
                    "Vacancy/Vacancy/{id}/{entryName}", // URL with parameters
                    new { controller = "Vacancy", action = "Vacancy", id = UrlParameter.Optional } // Parameter defaults
            );
            routes.MapRoute(
                    "ResumeOne", // Route name
                    "Vacancy/Resume/{id}/{entryName}", // URL with parameters
                    new { controller = "Vacancy", action = "Resume", id = UrlParameter.Optional } // Parameter defaults
            );
            routes.MapRoute(
                    "VacancyCompanyOne", // Route name
                    "Vacancy/Company/{id}/{entryName}", // URL with parameters
                    new { controller = "Vacancy", action = "Company", id = UrlParameter.Optional } // Parameter defaults
            );


            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Main", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );
        }

        protected void Application_AuthenticateRequest(Object sender, EventArgs e)
        {
            Context.User = Request.RequestContext.HttpContext.UserPrincipal();
        }

        protected void Application_Start()
        {
            XmlConfigurator.Configure();

            AreaRegistration.RegisterAllAreas();

            Stopwatch watch = new Stopwatch();
            log.Debug("Initializing meridian");
            watch.Start();

            var connstring = WebConfigurationManager.ConnectionStrings["default"].ConnectionString;
            MeridianMonitor.Default.Init(connstring, "", 0, "", "");
            Meridian.Default.Init(connstring);

            watch.Stop();
            log.DebugFormat("Meridian initialization took {0}ms", watch.ElapsedMilliseconds);

            var wtw = new WebcamThreadWorker(Server.MapPath("~/content/images/webcam1.jpg"));
            //wtw.Start();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
            RegisterValidators();

            LoadServiceLocator();

            ModelMetadataProviders.Current = new CustomMetadataProvider();

            log.Debug("Smolensk portal started sucessfully");
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            var principal = GetCurrentPrincipalErrorProne();
            string userId = principal != null ? principal.id.ToString() : "None";
            string path = GetCurrentPathErrorProne();
            string referrer = GetReferrerErrorProne();
            string message = string.Format("Unhandled exception. Path='{0}', Ref='{1}', UserId={2}", path, referrer, userId);

            Exception ex = Server.GetLastError();
            log.Error(message, ex);
        }

        /// <summary>
        /// Пытаемся получить страницу, с которой пришел пользователь
        /// </summary>
        /// <returns></returns>
        private string GetReferrerErrorProne()
        {
            try
            {
                return Request != null && Request.UrlReferrer != null ? Request.UrlReferrer.ToString() : string.Empty;
            }
            catch (HttpException)
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Пытаемся получить адрес, на который был запрос. Это возможно далеко не всегда.
        /// </summary>
        private string GetCurrentPathErrorProne()
        {
            try
            {
                return Request != null ? Request.Url.ToString() : string.Empty;
            }
            catch (HttpException)
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Хотим из последних сил получить текущего пользователя. Если все упало, 
        /// то даже меридиан нам ничего не отдаст, кроме нового исключения
        /// </summary>
        /// <returns>Текущий пользователь или null</returns>
        private accounts GetCurrentPrincipalErrorProne()
        {
            try
            {
                return Request.RequestContext.HttpContext.UserPrincipal();
            }
            catch (Exception)
            {
                return null;
            }
        }

        protected void RegisterValidators()
        {
            DataAnnotationsModelValidatorProvider
                .RegisterAdapter(typeof(EqualityAttribute), typeof(EqualityValidator));
            DataAnnotationsModelValidatorProvider
                .RegisterAdapter(typeof(NeedOneAttribute), typeof(NeedOneValidator));
            DataAnnotationsModelValidatorProvider
                .RegisterAdapter(typeof(UniqueEMailAttribute), typeof(UniqueEMailValidator));
            DataAnnotationsModelValidatorProvider
               .RegisterAdapter(typeof(NeedSelectEntityAttribute), typeof(NeedSelectEntityValidator));
        }

        private static void LoadServiceLocator()
        {
            IUnityContainer container = new UnityContainer();
            container.LoadConfiguration();

            var serviceLocator = new UnityBackedServiceLocator(container);
            ServiceLocator.Initialize(serviceLocator);
        }
    }
}