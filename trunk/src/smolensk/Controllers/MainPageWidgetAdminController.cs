using System.Linq;
using System.Web.Mvc;
using meridian.smolensk.controller;
using meridian.smolensk.proto;
using smolensk.common;

namespace smolensk.Controllers
{
    public class MainPageWidgetAdminController : meridian_main_page_widgets
    {
        public override ActionResult Index()
        {
            var item = Service.GetAll().FirstOrDefault();
            if (item != null)
            {
                return RedirectToAction("Single", new {id = item.id});
            }

            return RedirectToAction("Single");
        }
    }
}