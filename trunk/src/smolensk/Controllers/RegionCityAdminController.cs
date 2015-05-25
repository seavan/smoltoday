using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using meridian.smolensk.controller;
using meridian.smolensk.proto;

namespace smolensk.Controllers
{
    public class RegionCityAdminController : meridian_regions
    {
        public RegionCityAdminController()
        {

        }

        protected override System.Linq.IQueryable<regions> Filter(System.Linq.IQueryable<regions> _src)
        {
            return base.Filter(_src).OrderBy(s => s.title);
        }
    }
}
