using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using meridian.smolensk.system;
using smolensk.Mappers;
using smolensk.Models;
using smolensk.ViewModels;
using smolensk.Models.ViewModels;
using meridian.smolensk.proto;
using System.Collections.Generic;

namespace smolensk.Controllers
{
    public class MainController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Cams()
        {
            return View();
        }

        public ActionResult Restaurants()
        {
            //Всё переехало в RestaurantsController - здесь только демонстрационный код
            //Роуты в Global.asax переправлены
            return View();
        }


        public ActionResult Informer()
        {
            var model = new InformerViewModel();

            var activeRecord = meridian.main_page_widgetsStore.GetRecord();

            model.JamsDegree = activeRecord.jams_degree;
            model.JamsDescription = activeRecord.jams_description;
            model.DollarChange = activeRecord.usd_change;
            model.DollarPrice = activeRecord.usd_price;
            model.EuroChange = activeRecord.eur_change;
            model.EuroPrice = activeRecord.eur_price;

            return PartialView("Widgets/Informer", model);
        }


        public ActionResult Static(string url)
        {
            var page = Meridian.Default.pagesStore.GetStaticPageByUrl(url);
            if (page != null)
            {
                return View(new StaticPageViewModel(page) { Title = page.title, Content = page.html });
            }
            return HttpNotFound();
        }

        public ActionResult EntityMap()
        {
            List<IGeoLocation> entityList = new List<IGeoLocation>();
            entityList.AddRange(meridian.restaurantsStore.GetEntityMap());
            entityList.AddRange(meridian.companiesStore.GetEntityMap());
            //entityList.AddRange(meridian.actionsStore.GetEntityMap());
            entityList.AddRange(meridian.placesStore.GetEntityMap());

            return PartialView("Widgets/YandexMap", entityList);
        }

        public ActionResult MainSlider()
        {
            List<IMainSlider> entityList = new List<IMainSlider>();
            entityList.AddRange(meridian.newsStore.LoadSliderMainNews());
            entityList.AddRange(meridian.actionsStore.LoadMainActions());
            entityList.AddRange(meridian.news_videosStore.LoadMainVideoNews());

            return PartialView("MainSlider", entityList);
        }

        public ActionResult InBlogs()
        {
            return PartialView("Widgets/InBlogs", meridian.blogsStore.LoadForMain());
        }

        public ActionResult MostDiscussedNews()
        {
            var news = meridian.newsStore.LoadBuzzedNews(4);
            var viewModel = NewsMapper.CreateListViewModel(meridian, news);

            return PartialView("../News/MostDiscussedMain", viewModel);
        }

        public ActionResult PhotoBankRow()
        {
            List<photobank_photos> list = new List<photobank_photos>();
            list.AddRange(meridian.photobank_photosStore.LoadForMain());
            var day = meridian.photobank_photosStore.GetPhotoDay();
            if (day!=null)
                list.Add(day);

            return PartialView("Blocks/PhotoBankRow", list);
        }
    }
}
