using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using meridian.smolensk.system;
using smolensk.Mappers;
using smolensk.common;
using smolensk.Services;
using System.Web.Routing;
using smolensk.Models.ModelValidators.Attributes;

namespace smolensk.Controllers
{
    public class DiscountsController : BaseController
    {
        public ActionResult Index(SaleType type = SaleType.DiscountsOnCard, SortingType sorting = SortingType.Novelty, int page = 1)
        {
            var model = meridian.GetSalesList(type, null, null, null, sorting, page);
            model.RouteName = "DiscountsList";
            model.Title = "Скидки и акции";

            return View("DiscountsList", model);
        }

        public ActionResult Category(long? categoryId, SaleType type = SaleType.DiscountsOnCard, SortingType sorting = SortingType.Novelty, int page = 1)
        {
            if (!categoryId.HasValue || categoryId.Value == 0)
                return RedirectToAction("Index");

            var model = meridian.GetSalesList(type, categoryId, null, null, sorting, page);
            model.RouteName = "DiscountsList";
            model.Title = "Скидки - " + model.Category.Title;

            return View("DiscountsList", model);
        }

        public ActionResult Favorites(long? categoryId, SaleType type = SaleType.DiscountsOnCard, SortingType sorting = SortingType.Novelty, int page = 1)
        {
            var currentUser = HttpContext.UserPrincipal();
            if (currentUser == null)
                return new HttpNotFoundResult();

            var model = meridian.GetSalesList(type, categoryId, null, currentUser.id, sorting, page);
            model.RouteName = "DiscountsList";
            model.Title = "Избранные скидки";
            model.IsFavorite = true;

            return View("DiscountsList", model);
        }

        public ActionResult Company(long? companyId = null, long? categoryId = null, 
            SaleType type = SaleType.DiscountsOnCard, SortingType sorting = SortingType.Novelty, int page = 1)
        {
            var s = meridian.companiesStore;
            if (!companyId.HasValue || !s.Exists(companyId.Value))
                return new HttpNotFoundResult();

            var model = meridian.GetSalesList(type, categoryId, companyId, null, sorting, page);
            model.Company = s.Get(companyId.Value).ToCompanyViewModel(true);
            model.RouteName = "DiscountsList";
            model.Title = "Скидки - " + model.Company.Title;

            return View("DiscountsList", model);
        }

        public ActionResult One(long id)
        {
            if (!meridian.salesStore.Exists(id))
                return new HttpNotFoundResult();

            var model = meridian.salesStore.Get(id).ToSaleViewModel();

            return View(model);
        }

        public ActionResult CategoryMenu(long? categoryId)
        {
            return PartialView(meridian.GetSalesCategoriesList(categoryId));
        }

        public ActionResult BestSales()
        {
            return PartialView(meridian.GetBestSales());
        }
    }
}
