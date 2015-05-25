using admin.web.common;
using meridian.smolensk.controller;
using meridian.smolensk.proto;
using meridian.smolensk.system;
using System.Linq;

namespace smolensk.Controllers
{
    public class NewsCategoryAdminController : meridian_news_categories
    {
        protected override IQueryable<news_categories> Filter(IQueryable<news_categories> _src)
        {
            return base.Filter(_src).OrderBy(s => s.order_id);
        }
    }
}