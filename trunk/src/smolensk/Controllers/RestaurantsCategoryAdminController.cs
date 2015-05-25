using System.Linq;
using System.Web.Mvc;
using meridian.smolensk.controller;
using meridian.smolensk.proto;
using meridian.smolensk.system;
using smolensk.common;

namespace smolensk.Controllers
{
    public class RestaurantsCategoryAdminController : meridian_restaurant_entry_categories
    {
        public RestaurantsCategoryAdminController()
        {

        }

        protected override System.Linq.IQueryable<restaurant_entry_categories> Filter(System.Linq.IQueryable<restaurant_entry_categories> _src)
        {
            return base.Filter(_src).OrderBy(s => s.title);
        }

   
    }
}