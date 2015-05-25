using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using meridian.smolensk.proto;
using smolensk.common;
using smolensk.Domain;
using smolensk.Mappers;
using smolensk.Models.CodeModels;
using smolensk.Models.ViewModels;
using smolensk.Models.ViewModels.Mail;
using smolensk.Services;

namespace smolensk.Controllers
{
    public class PhotoBankController : BaseController
    {
        private Mailer _mailer;

        public PhotoBankController(): base()
        {
            _mailer = new Mailer(this);
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MenuCategories()
        {
            List<photobank_categories> model = meridian.photobank_categoriesStore.All()
                .OrderBy(item => item.title).ToList();

            string catId = TempData["ImageCategoryId"] != null ?  TempData["ImageCategoryId"].ToString() : string.Empty;
            if (!string.IsNullOrEmpty(catId))
                ViewBag.CategotyId = int.Parse(catId);

            return View(model);
        }

        [ChildActionOnly]
        public ActionResult TagsCloud()
        {
            var tags = meridian.photobank_photo_tagsStore.All();
            //TODO: выборка 20 наиболее популярных тегов (наибольшее количество повторений). Так и оставить?
            List<TagModel> model = tags.GroupBy(item => item.tag_id)
                             .Select(item => new TagModel
                                 {
                                     Title = meridian.photobank_tagsStore.Get(item.Key).title,
                                     Count = item.Count()
                                 }).OrderByDescending(tag => tag.Count).Take(20).ToList();

            return View(model);
        }

        public ActionResult Category(int id, int page = 1, int pageSize = Constants.PhotosPageSize)
        {
            var category = meridian.photobank_categoriesStore.Get(id);
            var photos = meridian.photobank_photosStore.All().Where(item => item.category_id == id).ToList();
            var model = PhotosMapper.ToPhotoListViewModel(photos, page, pageSize);
            model.Title = category.title;
            return View("PhotoList", model);
        }

        public ActionResult Image(long id)
        {
            var image = meridian.photobank_photosStore.Get(id);
            image.view_count++;
            meridian.photobank_photosStore.Update(image);

            var model = PhotosMapper.ToPhotoViewModel(id);
            TempData["ImageCategoryId"] = model.Photo.category_id;
            return View(model);
        }

        public ActionResult Profile(long id, int page = 1, int pageSize = Constants.PhotosPageSize)
        {
            var model = PhotosMapper.ToProfileViewModel(id, page, pageSize);
            return View(model);
        }

        public ActionResult License()
        {
            return View();
        }

        public ActionResult Search(string q, int page = 1, int pageSize = Constants.PhotosPageSize)
        {
            var photos = meridian.photobank_photosStore.All().Where(item => item.title.Contains(q));
            var photosByTags = meridian.photobank_photosStore.All().Where(item => item.Tags.Any(t => t.title.Contains(q)));
            var result = photos.Union(photosByTags).Distinct().ToList();
            var model = PhotosMapper.ToPhotoListViewModel(result, page, pageSize);
            model.Title = string.Format("Результат поиска по запросу: \"{0}\"", q);
            return View("PhotoList", model);
        }

        public ActionResult NewPhotos()
        {
            List<photobank_photos> model = meridian.photobank_photosStore.All().Where(item => 
                !string.IsNullOrEmpty(item.preview_square))
                .OrderByDescending(item => item.publish_date).Take(12).ToList();
            return View(model);
        }

        public ActionResult Last(int page = 1, int pageSize = Constants.PhotosPageSize)
        {
            //TODO:изменить метод получения фотографий
            var photos = meridian.photobank_photosStore.All()
                .OrderByDescending(item => item.publish_date).Take(Constants.PageSize).ToList();

            var model = PhotosMapper.ToPhotoListViewModel(photos, page, pageSize);
            model.Title = "Последние новинки";
            return View("PhotoList", model);
        }

        public ActionResult Categories()
        {
            var model = meridian.photobank_categoriesStore.All().OrderBy(item => item.title).ToList();
            return View(model);
        }

        public ActionResult Cart()
        {
            return View(GetCartViewModel(true));
        }

        public ActionResult CartInfo()
        {
            CartViewModel model = GetCartViewModel();

            return PartialView(model);
        }

        public ActionResult Order()
        {
            
            return View();
        }

        private CartViewModel GetCartViewModel(bool fullModel = false)
        {
            var model = new CartViewModel();

            if (HttpContext.UserPrincipal() == null)
                return model;

            long accountId = HttpContext.UserPrincipal().id;
            var items = meridian.photobank_cartStore.All().Where(item => item.account_id == accountId).ToList();

            foreach (var item in items)
            {
                var price = meridian.photobank_photo_pricesStore.Get(item.price_id);

                if (price != null)
                {
                    model.Items.Add(price);
                }
            }

            if (fullModel)
            {
                model.Licenses = meridian.photobank_licensesStore.All().ToList();
            }

            return model;
        }

        [HttpPost]
        public ActionResult AddToCart(long priceId = 0, long id = 0)
        {
            long itemId = 0;

            if (id > 0)
            {
                var price = meridian.photobank_photo_pricesStore.All().FirstOrDefault(item => item.rel_photo_id == id);
                if (price != null)
                {
                    itemId = price.id;
                }
            }

            if (priceId > 0)
            {
                itemId = priceId;
            }

            if (itemId > 0)
            {
                var cartItem = meridian.photobank_cartStore.All().FirstOrDefault(item => item.price_id == itemId);

                if (cartItem == null)
                {
                    cartItem = new photobank_cart
                    {
                        account_id = HttpContext.UserPrincipal().id,
                        price_id = itemId
                    };

                    meridian.photobank_cartStore.Insert(cartItem);
                }
            }

            return PartialView("CartInfo", GetCartViewModel());
        }

        [HttpPost]
        public JsonResult DeleteCartItem(long id)
        {
            long accountId = HttpContext.UserPrincipal().id;
            var cartItem = meridian.photobank_cartStore.All()
                    .FirstOrDefault(item => item.account_id == accountId && item.price_id == id);
            
            if (cartItem != null)
            {
                meridian.photobank_cartStore.Delete(cartItem);
            }

            return Json(new {count = meridian.photobank_cartStore.All().Count(item => item.account_id == accountId)});
        }

        [HttpPost]
        public JsonResult CalcPrice(long licenseId, long relPhotoId, long oldLicenseId, long oldRelPhotoId)
        {
            var price = meridian.photobank_photo_pricesStore.All()
                    .FirstOrDefault(item => item.license_id == licenseId && item.rel_photo_id == relPhotoId);
            var oldPrice = meridian.photobank_photo_pricesStore.All()
                    .FirstOrDefault(item => item.license_id == oldLicenseId && item.rel_photo_id == oldRelPhotoId);

            if (price != null && oldPrice != null)
            {
                long accountId = HttpContext.UserPrincipal().id;

                var cartItem = meridian.photobank_cartStore.All()
                        .FirstOrDefault(item => item.account_id == accountId && item.price_id == oldPrice.id);
                
                if (cartItem != null)
                {
                    cartItem.price_id = price.id;
                    meridian.photobank_cartStore.Update(cartItem);
                }
            }

            return price != null
                ? Json(new {price = price.price, priceId = price.id})
                : Json(new {price = 0, priceId = 0});
        }

        [ChildActionOnly]
        public ActionResult GetPhotoSession(string action, long id = 0)
        {
            if (!Request.IsAuthenticated)
            {
                return null;
            }

            accounts photographer;

            switch (action.ToLower())
            {
                case "image":
                    photographer = meridian.photobank_photosStore.Get(id).Account;
                    break;
                case "profile":
                    photographer = meridian.accountsStore.Get(id);
                    break;
                default:
                    return null;

            }

            var account = meridian.accountsStore.Get(HttpContext.UserPrincipal().id);

            var model = new GetSessionViewModel
            {
                Email = account.email,
                Photographer = photographer
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult GetPhotoSession(GetSessionViewModel model)
        {
            var account = meridian.accountsStore.Get(HttpContext.UserPrincipal().id);
            var photographer = meridian.accountsStore.Get(model.Photographer.id);
            var mailModel = new GetSessionModel
            {
                Email = model.Email,
                Phone = model.Phone,
                Photographer = photographer,
                Text = model.Text,
                User = account
            };

            _mailer.SendGetSessionEmailMail(mailModel);
            return Json(new {message = "Заявка отправлена успешно. Фотограф свяжется с вами."});
        }
    }
}
