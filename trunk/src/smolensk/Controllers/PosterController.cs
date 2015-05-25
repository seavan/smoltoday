using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using meridian.smolensk.system;
using smolensk.common;
using smolensk.Mappers;
using smolensk.Models.ModelValidators.Attributes;
using smolensk.Services;
using DateRange = smolensk.Models.CodeModels.DateRange;
using smolensk.Domain;
using smolensk.Models.ViewModels.Mail;

namespace smolensk.Controllers
{
    public class PosterController : BaseController
    {
        [HttpPost]
        [Authorize403]
        public int AddParticipiants(long action_id)
        {
            if (canAddParticipiants(action_id))
            {
                var currentUser = HttpContext.UserPrincipal();
                var key = string.Format("action_{0}", action_id);
                var userKey = currentUser.id.ToString();

                Response.Cookies[key][userKey] = true.ToString();
                Response.Cookies[key].Expires = DateTime.Now.AddYears(100);
                return Meridian.Default.actionsStore.Get(action_id).AddParticipiant(currentUser.id);
            }
            return -1;
        }

        private bool canAddParticipiants(long action_id)
        {
            var currentUser = HttpContext.UserPrincipal();
            var key = string.Format("action_{0}", action_id);
            var userKey = currentUser!= null ? currentUser.id.ToString() : string.Empty;

            return Meridian.Default.actionsStore.Exists(action_id) && 
                   currentUser != null &&
                  (Request.Cookies[key] == null ||
                   Request.Cookies[key][userKey] == null);
        }

        private DateRange RepackDateFilter(string from, string to, ref ActionDateFilterType? dateFilter) 
        {
            DateRange range = new DateRange();
            DateTime fromDate;
            DateTime toDate;
            if (DateTime.TryParse(from, out fromDate))
                range.From = fromDate;
            if (DateTime.TryParse(to, out toDate))
            {
                if (range.HasValue && fromDate == toDate)
                    range = new DateRange(fromDate);
                else
                    range.To = toDate;
            }
            if (range.HasValue)
            {
                dateFilter = range.ToDateFilterType();
                return range;
            }
            else if (dateFilter.HasValue)
            {
                return dateFilter.Value.ToDate();
            }
            dateFilter = ActionDateFilterType.Now;
            return new DateRange(DateTime.Now);
        }

        public ActionResult Index(ActionDateFilterType? dateFilter = ActionDateFilterType.Now, string from = "", string to = "")
        {
            var dateRange = RepackDateFilter(from, to, ref dateFilter);
            var model = meridian.GetActionsList(null, null, dateRange.From, dateRange.To, false, 6);
            model.DateFilter = dateFilter;
            model.RouteName = "ActionsList";

            ViewBag.ActionsCount = ActionsMapper.GetAcionsCount((long?) null, dateRange.From, dateRange.To);
            return View(model);
        }

        public ActionResult Category(long id, ActionDateFilterType? dateFilter = ActionDateFilterType.Now, string from = "", string to = "")
        {
            var c_store = meridian.action_categoriesStore;
            if (!c_store.Exists(id)) 
                return new HttpNotFoundResult();

            var dateRange = RepackDateFilter(from, to, ref dateFilter);
            var model = meridian.GetActionsList(id, null, dateRange.From, dateRange.To, false, 3);
            model.DateFilter = dateFilter;            
            model.RouteName = "ActionsListByCategory";

            ViewBag.ActionsCount = ActionsMapper.GetAcionsCount(id, dateRange.From, dateRange.To);
            return View(model);
        }

        public ActionResult Action(long id)
        {
            var a_store = meridian.actionsStore;
            if (!a_store.Exists(id)) 
                return new HttpNotFoundResult();
            
            var model = a_store.Get(id).ToAction();
            model.CanAddParticipiants = canAddParticipiants(id);
            return View(model);
        }

        public ActionResult Place(long id)
        {
            var store = meridian.placesStore;
            if (!store.Exists(id))
                return new HttpNotFoundResult();
            var model = store.Get(id).ToPlace();
            return View(model);
        }

        public ActionResult CategoryMenu(DateRange dateRange)
        {
            if (dateRange == null || !dateRange.HasValue)
                dateRange = new DateRange(DateTime.Now.Date);

            var model = meridian.GetActionCategoriesList(false, dateRange.From, dateRange.To).ToList();
            
            //model.ForEach(c => c.Date = dateRange);
            return PartialView(model);
        }

        public ActionResult LastActions()
        {
            return PartialView(meridian.GetActionCategoriesList(false, DateTime.Now));
        }

        public ActionResult ActionsList(long id, ActionSortingType sorting = ActionSortingType.Alphabet, 
            SortingDirection sortingDir = SortingDirection.Asc, DateTime? from = null, DateTime? to = null)
        {
            return PartialView(meridian.GetActionsList(id, null, from, to, false, 0, sorting, sortingDir));
        }

        public ActionResult PlacesList(long id, PlaceSortingType sorting = PlaceSortingType.Title, 
            SortingDirection sortingDir = SortingDirection.Asc, DateTime? from = null, DateTime? to = null)
        {
            return PartialView(meridian.ToPlacesList(id, from, to, sorting, sortingDir));
        }

        public ActionResult ActionSchedule(long id, ScheduleFilterType filter = ScheduleFilterType.Today)
        {
            var dateRange = new DateRange(DateTime.Now.Date, filter.ToDayCount());
            var model = meridian.actionsStore.Get(id).ToAction(dateRange.From, dateRange.To);
            model.ScheduleFilter = filter;
            return PartialView(model);
        }

        public ActionResult PlaceSchedule(long id, ScheduleFilterType filter = ScheduleFilterType.In3Days)
        {
            var dateRange = new DateRange(DateTime.Now.Date, filter.ToDayCount());
            var model = meridian.GetActionsList(null, id, dateRange.From, dateRange.To, false, 0, ActionSortingType.Alphabet);
            return PartialView(model);
        }

        public ActionResult CinemaInfo()
        {
            return PartialView(meridian.GetMainActionsByCategory(1, 3));
        }

        public ActionResult LiveInfo()
        {
            return PartialView(meridian.GetMainActionsByCategory(3, 3));
        }

        [HttpPost]
        [Authorize403]
        public void DeleteAction(long id)
        {
            var store = meridian.actionsStore;
            if (!store.Exists(id))
                return;
            var a = store.Get(id);
            if (HttpContext.UserPrincipal().id == a.account_id)
            {
                a.delete = true;
                store.Update(a);
            }
        }

        [HttpPost]
        [Authorize403]
        public void SetStatusAction(long id, bool value)
        {
            var store = meridian.actionsStore;
            if (!store.Exists(id))
                return;
            var a = store.Get(id);
            if (HttpContext.UserPrincipal().id == a.account_id)
            {
                a.published = value;
                store.Update(a);
            }
        }

        [HttpPost]
        [Authorize403]
        public ActionResult SendMail(SimpleMailModel model)
        {
            model.FromUser = HttpContext.UserPrincipal();
            new Mailer(this).SendMessageToModerators(model);
            if (Request.UrlReferrer != null)
                return Redirect(Request.UrlReferrer.AbsoluteUri);
            else
                return RedirectToAction("Index");
        }
    }
}
