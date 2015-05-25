using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using meridian.smolensk.system;
using smolensk.Mappers;
using meridian.smolensk.proto;
using smolensk.ViewModels;
using smolensk.common;
using smolensk.Domain;

namespace smolensk.Controllers
{
    public class NewsController : BaseController
    {
        public ActionResult Index()
        {
            SetDateList();

            DateTime date = DateTime.Today;
            IEnumerable<news> query = meridian.newsStore.LoadNewsByPublishDate(date);
            
            int countNews = query.Count();
            if (countNews < Config.CountMinNews)
            {
                query = meridian.newsStore.LoadLastNews(Constants.NewsPageSize);
            }

            int tPage = MappingUtils.CalculatePagesCount(query.Count(), Constants.NewsPageSize);
            int cPage = GetPage();
            IEnumerable<news> newsByDate = MappingUtils.TakePage(query, cPage, Constants.NewsPageSize);

            var model = NewsMapper.CreateListViewModel(meridian, newsByDate);
            model.CurrentPage = cPage;
            model.TotalPages = tPage;
            model.Date = date;
            model.mainNews = true;

            return View("List", model);
        }

        public ActionResult Single(long id)
        {
            if (!meridian.newsStore.Exists(id))
                return new HttpNotFoundResult();

            news news = meridian.newsStore.Get(id);
            SingleNewsViewModel model = NewsMapper.CreateSingleNewsItem(meridian, news);

            news.IncrementViews();
            meridian.newsStore.Update(news);

            SetDateList();

            return View("Single", model);
        }

        public ActionResult List(int page, long? categoryId, int? year, int? month, int? day)
        {
            DateTime date = DateTime.Today;
            if (year.HasValue && month.HasValue && day.HasValue)
            {
                date = new DateTime(year.Value, month.Value, day.Value);
            }

            IEnumerable<news> query = categoryId.HasValue && meridian.news_categoriesStore.Exists(categoryId.Value) 
                ? meridian.newsStore.LoadNewsByCategory(categoryId.Value, date)
                : meridian.newsStore.LoadNewsByPublishDate(date);

            int tPage = MappingUtils.CalculatePagesCount(query.Count(), Constants.NewsPageSize);
            int cPage = page;
            IEnumerable<news> newsList = MappingUtils.TakePage(query, cPage, Constants.NewsPageSize);

            var model = NewsMapper.CreateListViewModel(meridian, newsList);
            model.CurrentPage = cPage;
            model.TotalPages = tPage;
            model.Date = date;

            if (categoryId.HasValue && meridian.news_categoriesStore.Exists(categoryId.Value))
            {
                var category = meridian.news_categoriesStore.Get(categoryId.Value);
                model.Category = CategoryMapper.ToViewModel(category);
            }

            SetDateList();

            return View("Category", model);
        }

        public ActionResult CategoryMenu(long? categoryId, int? year, int? month, int? day)
        {
            DateTime date = DateTime.Today;

            if (year.HasValue && month.HasValue && day.HasValue)
            {
                date = new DateTime(year.Value, month.Value, day.Value);
            }

            var model = CategoryMapper.CreateCategoriesList(meridian, categoryId);
            model.Date = date;

            return PartialView(model);
        }

        public ActionResult CityNews()
        {
            var cityNews = meridian.newsStore.LoadCityNews().ToArray();

            var model = NewsMapper.CreateListViewModel(meridian, cityNews);
            model.Items = model.Items.OrderByDescending(i => i.PublishDate);

            return PartialView("CityNews", model);
        }

        public ActionResult PopularNews()
        {
            var popularNews = meridian.newsStore.LoadPopularNews();

            var model = NewsMapper.CreateListViewModel(meridian, popularNews);

            return PartialView("PopularNews", model);
        }

        public ActionResult MainNews()
        {
            var mainNews = meridian.newsStore.LoadMainNews();

            var model = NewsMapper.CreateListViewModel(meridian, mainNews);

            return PartialView("Widgets/MainNews", model);
        }

        public ActionResult TodaysNews()
        {
            DateTime date = DateTime.Today;
            IEnumerable<news> query = meridian.newsStore.LoadNewsByPublishDate(date);

            int countNews = query.Count();
            if(countNews <=0 )
            {
                date = date.AddDays(-1);
                DateRange dr = new DateRange();
                dr.toDate = date;
                dr.fromDate = date.AddDays(-1).Date;
                query = meridian.newsStore.LoadNewsByPublishDate(date);
            }

            int tPage = MappingUtils.CalculatePagesCount(query.Count(), Constants.NewsPageSize);
            int cPage = GetPage();
            IEnumerable<news> newsByDate = MappingUtils.TakePage(query, cPage, Constants.NewsPageSize);

            var model = NewsMapper.CreateListViewModel(meridian, newsByDate);
            model.CurrentPage = cPage;
            model.TotalPages = tPage;
            model.Date = date;

            return PartialView("NewsList", model);
        }

        public ActionResult NewsByDate()
        {
            string dateStr = Request.QueryString["date"];
            DateTime date;
            if (dateStr == null)
            {
                date = DateTime.Today;
                date = date.AddDays(-1);
            }
            else
            {
                date = DateTime.Parse(dateStr);
            }
            var newsByDate = meridian.newsStore.LoadNewsByPublishDate(date);

            var model = NewsMapper.CreateListViewModel(meridian, newsByDate);

            return PartialView("NewsList", model);
        }

        public ActionResult BuzzedNews()
        {
            var buzzedNews = meridian.newsStore.LoadBuzzedNews();

            var model = NewsMapper.CreateListViewModel(meridian, buzzedNews);

            return PartialView("BuzzedNews", model);
        }

        public ActionResult NewsByCategories()
        {
            var model = NewsMapper.CreateCategoryList(meridian, meridian.news_categoriesStore.All().Where(c => meridian.newsStore.LoadNewsByCategory(c.id).Count() > 0));

            return PartialView("CategoryList", model);
        }

        public ActionResult NewsByCategoryLast(long categoryId)
        {
            var model = NewsMapper.CreateListViewModel(meridian, meridian.newsStore.LoadLastNews(2, categoryId));

            return PartialView("NewsByCategoryLast", model);
        }

        public ActionResult NewsByCategoryPopular(long categoryId)
        {
            var lastNews = meridian.newsStore.LoadLastNews(2, categoryId);
            var popularNews = meridian.newsStore.LoadPopularNews(3, categoryId).Where(n => !lastNews.Contains(n));
            var model = NewsMapper.CreateListViewModel(meridian, popularNews);
            return PartialView("NewsByCategoryPopular", model);
        }

        public ActionResult ImagesByTheme(long id)
        {
            if (!meridian.newsStore.Exists(id))
                return new HttpNotFoundResult();

            SetDateList();

            return View(meridian.newsStore.Get(id));
        }

        public ActionResult ImagesList(long id, int page = 0)
        {
            if (!meridian.newsStore.Exists(id))
                return new HttpNotFoundResult();

            return PartialView(meridian.newsStore.Get(id).GetImagesByTheme(16*page));
        }

        public ActionResult VideosByTheme(long id)
        {
            if (!meridian.newsStore.Exists(id))
                return new HttpNotFoundResult();

            SetDateList();

            return View(meridian.newsStore.Get(id));
        }

        public ActionResult VideosList(long id, int page = 0)
        {
            if (!meridian.newsStore.Exists(id))
                return new HttpNotFoundResult();

            return PartialView(meridian.newsStore.Get(id).GetImagesByTheme(12 * page));
        }

        private void SetDateList()
        {
            ViewBag.dateList = String.Join(",", 
                meridian.newsStore.GetAllVisible()
                                  .Select(t => String.Format("\"{0}\"", Formatter.FormatCompanyPublishDate(t.publish_date)))
                                  .Distinct());
           
            ViewBag.dateCurrent = Formatter.FormatCompanyPublishDate(DateTime.Now);
        }

        private int GetPage()
        {
            string page = Request.QueryString["page"];
            int pageNumber;
            if (string.IsNullOrEmpty(page))
            {
                pageNumber = 1;
            }
            else
            {
                pageNumber = int.Parse(page);
            }

            return pageNumber;
        }
    }
}
