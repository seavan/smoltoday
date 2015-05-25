using System.Linq;
using meridian.smolensk.controller;
using meridian.smolensk.proto;

namespace smolensk.Controllers
{
    public class AdvertsCategoryAdminController : meridian_ad_categories
    {
        public AdvertsCategoryAdminController()
        {

        }

        protected override System.Linq.IQueryable<ad_categories> Filter(System.Linq.IQueryable<ad_categories> _src)
        {
            return base.Filter(_src).OrderBy(s => s.title);
        }

   
    }
}