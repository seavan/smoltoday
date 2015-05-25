using admin.web.common;
using meridian.smolensk.controller;
using meridian.smolensk.proto;
using meridian.smolensk.system;
using System.Linq;
using System.Web.Mvc;
using System.Web;
using System.IO;
using System;
using smolensk.common;

namespace smolensk.Controllers
{
    public class NewsAdminController : meridian_news
    {
        public NewsAdminController()
        {
            DefaultUploadVirtualFolder = Constants.NewsDataFolder;
        }
        
        protected override System.Linq.IQueryable<news> Filter(System.Linq.IQueryable<news> _src)
        {
            return base.Filter(_src).OrderByDescending(s => s.publish_date);
        }
        
        public override void Prepare(news _item)
        {
            base.Prepare(_item);
            _item.text = MeridianWebUtilities.ReplaceDivP(_item.text);
        }
    }
}