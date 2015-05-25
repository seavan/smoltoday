using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Web.Mvc;
using MySql.Data.MySqlClient;
using meridian.smolensk;
using meridian.smolensk.system;
using meridian.smolensk.proto;
using admin.web.common;
using smolensk.common;

namespace meridian.smolensk.controller
{
    public class PhotoBankAdminController : meridian_photobank_photos
    {
        public PhotoBankAdminController()
        {
            DefaultUploadVirtualFolder = Constants.PhotoFolder;
        }

        protected override IQueryable<photobank_photos> Filter(IQueryable<photobank_photos> _src)
        {
            if((Request["album"]!=null))
            {
                return base.Filter(_src).Where(p=>p.album_id.ToString() == Request["album"]).OrderByDescending(s => s.publish_date);
            }

            return base.Filter(_src).OrderByDescending(s => s.publish_date);
        }

        public override void Prepare(photobank_photos i)
        {
            base.Prepare(i);

           if (i.album_id > 0 && Meridian.Default.photobank_user_albumsStore.Exists(i.album_id))
           {
               i.account_id = Meridian.Default.photobank_user_albumsStore.Get(i.album_id).account_id;
           }
        }
    }
}
