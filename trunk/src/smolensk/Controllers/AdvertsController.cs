using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using meridian.smolensk.proto;
using smolensk.Domain;
using smolensk.Mappers;
using smolensk.Models.CodeModels;
using smolensk.Models.ViewModels;
using smolensk.common;
using smolensk.Models.ViewModels.Mail;
using smolensk.Services;
using smolensk.Models.ModelValidators.Attributes;

namespace smolensk.Controllers
{
    public class AdvertsController : BaseController
    {
        public ActionResult Index()
        {
            var model = meridian.ad_categoriesStore.GetRootCategories().GetFilled().ToList();
            ViewBag.AdvertsCount = meridian.ad_fieldsStore.All().GroupBy(f => f.ad_id).Count();
            return View("Index", model);
        }

        public ActionResult One(long id)
        {
            if (!meridian.ad_advertismentsStore.Exists(id))
                return new HttpNotFoundResult();

            var ad = meridian.ad_advertismentsStore.Get(id);

            var model = new AdViewModel
                {
                    Advertisment = ad,
                    Properties = AdsMapper.GetProperties(ad.category_id, ad.id),
                    IsOwner = Request.IsAuthenticated && HttpContext.UserPrincipal().id == ad.account_id
                };

            var adRequest = meridian.ad_advert_requestsStore.All().FirstOrDefault(item => item.ad_id == id);
            
            if (adRequest != null)
            {
                model.InInterestingRequest = adRequest.in_interesting;
                model.PinToListRequest = adRequest.pin_to_list;
            }

            var photosModel = new PhotoScrollViewModel
                {
                    PhotoHeight = 52,
                    PhotoWidth = 80,
                    Callback = "selectImage",
                    ShowPhotosCount = 1
                };

            foreach (var photo in ad.Photos)
            {
                photosModel.Photos.Add(new RelatedPhoto
                    {
                        PhotoUrl = photo.PreviewUrl,
                        Link = photo.PhotoUrl
                    });
            }

            photosModel.PhotosCount = 3;
            model.PhotosModel = photosModel;

            ad.IncrementViewsCount();

            return View(model);
        }

        public ActionResult SearchForm()
        {
            string query = Request.QueryString["q"];
            int categoryId = Convert.ToInt32(Request.QueryString["category"]);
            var model = new SearchAdViewModel {Q = query, Category = categoryId};

            var categories = meridian.ad_categoriesStore.GetRootCategories().GetFilled().ToList();
            model.Categories = categories.Select(item => new SelectListItem {Text = item.title, Value = item.id.ToString(), Selected = item.id == categoryId}).ToList();
            model.Categories.Insert(0, new SelectListItem { Selected = categoryId == 0, Text = "Все категории", Value = "0" });
            
            return View(model);
        }

        public ActionResult Search(SearchAdViewModel model)
        {
            var ads = meridian.ad_advertismentsStore.All()
                        .Where(item => item.title.Contains(model.Q) || item.description.Contains(model.Q))
                        .ToList();
            if (model.Category > 0)
            {
                ads = ads.Where(item => item.ParentCategoryId == model.Category).ToList();
            }

            var list = AdsMapper.ToAdsListViewModel(ads, model.Page, model.PageSize);
            list.Title = string.Format("Результаты поиска по запросу \"{0}\"", model.Q);

            return View(list);
        }

        public ActionResult Menu()
        {
            var model = meridian.ad_categoriesStore.GetRootCategories().GetFilled().ToList();
            return View(model);
        }

        public ActionResult SubMenu(string action, int id = 0)
        {
            if (id > 0)
            {
                ad_categories model = null;

                switch (action.ToLower())
                {
                    case "category":
                        model = meridian.ad_categoriesStore.Get(id);
                        break;
                    case "one":
                        var ad = meridian.ad_advertismentsStore.Get(id);
                        model = ad.GetAdvertismentsAd_categorie();
                        break;
                }

                if (model != null)
                {
                    ViewBag.Id = model.id;

                    if (!model.IsRootCategory)
                    {
                        model = meridian.ad_categoriesStore.Get(model.ParentCategoryId);
                    }

                    return View(model);
                }
            }

            return null;
        }

        public ActionResult Category(int id, int page = 1, int pageSize = Constants.AdvertsPageSize, long type = 0, string sort = "date")
        {
            var model = new CategoryAdsViewModel
            {
                Category = meridian.ad_categoriesStore.Get(id),
                Type = type,
                Sort = sort
            };

            model.Filter = AdsMapper.ToFilterAdsViewModel(model.Category, type, sort);
            List<ad_advertisments> topListAds = meridian.ad_fieldsStore.GetExisting()
                .Where(item => item.description_id == model.Filter.DescriptionId &&
                        item.value_id == model.Filter.Type)
                .Select(item => meridian.ad_advertismentsStore.Get(item.ad_id)).Where(ad => ad.pin_to_list &&
                    (ad.category_id == id || model.Category.Subcategories.Any(sub => sub.id == ad.category_id)))
                .OrderBy(ad => ad.id)
                .ToList();

            List<ad_advertisments> ads = meridian.ad_fieldsStore.GetExisting()
                .Where(item => item.description_id == model.Filter.DescriptionId && 
                        item.value_id == model.Filter.Type)
                .Select(item => meridian.ad_advertismentsStore.Get(item.ad_id)).Where(ad => !ad.pin_to_list &&
                    (ad.category_id == id || model.Category.Subcategories.Any(sub => sub.id == ad.category_id)))
                .ToList();

            switch (sort)
            {
                case "asc":
                    ads = ads.OrderBy(item => item.price).ToList();
                    break;
                case "desc":
                    ads = ads.OrderByDescending(item => item.price).ToList();
                    break;
                case "date":
                    ads = ads.OrderByDescending(item => item.created_date).ToList();
                    break;
            }

            topListAds.AddRange(ads);

            model.Advertisments = AdsMapper.ToAdsListViewModel(topListAds, page, pageSize);
            
            return View(model);
        }

        public ActionResult InterestingAds(string type, int categoryId = 0)
        {
            var result = new InterestingAdsViewModel();
            //количество выводимых объявлений
            //TODO: заменить на корректное значение: отражать столько объявлений на скольких в админке проставят флажок "показывать на главной", т.е. от 0 и до N

            //TODO: Нефига не понял, почему интересные объявления выводятся по флагу on_main. Даже если учесть, что это главная объявлений имеется ввиду,
            //как минимум нужно флаг in_interesting тоже проверять. Пока оставил только флаг in_interesting.
            const int count = 9;

            switch (type.ToLower())
            {
                case "main":
                    result.Advertismentses =
                        meridian.ad_advertismentsStore.All()
                                .Where(item => /*item.on_main*/ item.in_interesting)
                                .OrderBy(item => item.id).Take(count)
                                .ToList();
                    break;
                case "interesting":
                    var category = meridian.ad_categoriesStore.Get(categoryId);
                    var subcategories =
                        meridian.ad_categoriesStore.All()
                                .Where(item => item.parent_id == category.id)
                                .Select(item => item.id)
                                .ToList();

                    result.Category = category.title;
                    result.Advertismentses =
                        meridian.ad_advertismentsStore.All()
                                .Where(item =>
                                    item.in_interesting &&
                                    (item.category_id == categoryId || subcategories.Contains(item.category_id)))
                                .OrderBy(item => item.id).Take(count)
                                .ToList();
                    break;
            }

            return View(result);
        }

        public ActionResult SimilarAds(long id)
        {
            ad_advertisments ad = meridian.ad_advertismentsStore.Get(id);
            List<ad_advertisments> similarAds = ad.GetSimilarAds();

            return View(similarAds);
        }

        [HttpPost]
        public JsonResult AdRequest(long id, string type)
        {
            var accountId = HttpContext.UserPrincipal().id;
            var adRequest = meridian.ad_advert_requestsStore.All()
                .FirstOrDefault(item => item.account_id == accountId && item.ad_id == id) ?? new ad_advert_requests();

            string message = string.Empty;
            string typeMessage = string.Empty;
            switch (type)
            {
                case "interesting":
                    adRequest.in_interesting = true;
                    message = "Запрошено размещение в интересном";
                    typeMessage = "запрос на размещение в интересном";
                    break;
                case "pintolist":
                    adRequest.pin_to_list = true;
                    message = "Запрошено поднятие в списках";
                    typeMessage = "запрос на поднятие в списках";
                    break;
            }

            adRequest.account_id = accountId;
            adRequest.ad_id = id;

            meridian.ad_advert_requestsStore.Persist(adRequest);

            var mailModel = new AdvertRequestModel
            {
                Account = meridian.accountsStore.Get(accountId),
                AdvertismentId = id,
                Type = typeMessage
            };

            new Mailer(this).SendAdvertRequestEmailMail(mailModel);

            return Json(new { message });
        }

        [HttpPost]
        [Authorize403]
        public ActionResult WriteMail(AdvMailModel model)
        {
            var store = meridian.ad_advertismentsStore;
            if (!store.Exists(model.AdvId))
                return HttpNotFound();

            model.Adv =  store.Get(model.AdvId);
            model.User = HttpContext.UserPrincipal();

            new Mailer(this).SendMessageToAdvOwner(model);

            return RedirectToAction("One", new { id = model.AdvId });
        }
    }
}
