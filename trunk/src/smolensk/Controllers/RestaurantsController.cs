using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using meridian.smolensk.proto;
using meridian.smolensk.system;
using smolensk.Domain;
using smolensk.Extensions;
using smolensk.Mappers;
using smolensk.Models.ViewModels;
using smolensk.ViewModels;
using smolensk.Services;
using smolensk.common;

namespace smolensk.Controllers
{
    public class RestaurantsController : BaseController
    {
        private Mailer mailer;

        public RestaurantsController() : base()
        {
            this.mailer = new Mailer(this);
        }

        public ActionResult Index()
        {
            var x = Url.RequestContext.HttpContext.Request;

            return RedirectToAction("List");
        }

        public ActionResult List(int? page, string entries, string letter = Constants.AnyLetter, Alphabet alphabet = Alphabet.Rus )
        {
            long[] entriesArr = null;
            if (!string.IsNullOrEmpty(entries))
            {
                entriesArr = entries.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(long.Parse)
                    .ToArray();
            }

            RestaurantsListViewModel model = Meridian.Default.ToRestaurantsListViewModel(
                page.HasValue ? page.Value : 1, entriesArr, letter);

            var routeData = new RouteValueDictionary
            {
                //{"category", model.Category != null ? (long?) model.Category.Id : null}
            };

            model.Alphabet = new AlphabetViewModel("RestaurantsList", routeData, "letter",
                                       "alphabet")
            {
                Alphabet = alphabet,
                Letter = letter,
            };

            return View(model);
        }

        public ActionResult One(long id)
        {
            RestaurantViewModel model = Meridian.Default.GetRestaurant(id);
            if (model == null)
                return new HttpNotFoundResult();

            return View("One", model);
        }

        public PartialViewResult ReserveTableDialog(long id)
        {
            var model = new ReserveTableViewModel
                            {
                                RestaurantId = id,
                            };

            return PartialView("ReserveTable", model);
        }

        [HttpPost]
        public ActionResult ReserveTable(ReserveTableViewModel model)
        {
            //TODO: перенести в Mapper
            meridian.restaurants_reserveStore.Insert(new restaurants_reserve
            {
                account_id = HttpContext.UserPrincipal() != null ? HttpContext.UserPrincipal().id : 0,
                create_date = DateTime.Now,
                contact = model.ContactName,
                phone = model.Phone,
                restaraunt_id = model.RestaurantId,
                persons_count = model.Persons,
                visit_date = model.Date
            });
            mailer.SendReserveTableMail(model);

            return null;
        }

        public ActionResult EntityMap()
        {
            List<IGeoLocation> entityList = new List<IGeoLocation>();
            entityList.AddRange(meridian.restaurantsStore.GetEntityMap());

            return PartialView("Widgets/YandexMap", entityList);
        }
    }
}
