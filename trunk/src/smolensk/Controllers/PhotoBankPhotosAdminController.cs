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

namespace meridian.smolensk.controller
{
    public partial class PhotoBankPhotosAdminController : meridian_photobank_related_photos
	{
		public PhotoBankPhotosAdminController()
		{
		}

        [HttpPost]
        public JsonResult SaveLicense(long idPhoto, long idLic, string price)
        {
            photobank_photo_prices lic;

            if(Meridian.Default.photobank_photo_pricesStore.All().Any(p=>p.rel_photo_id == idPhoto))
            {
                lic = Meridian.Default.photobank_photo_pricesStore.All().First(p => p.rel_photo_id == idPhoto);
            }
            else
            {
                lic = new photobank_photo_prices();
                lic.rel_photo_id = idPhoto;
            }

            lic.license_id = idLic;

            try
            {
                lic.price = double.Parse(price);
            }
            catch {}

            Meridian.Default.photobank_photo_pricesStore.Persist(lic);

            return Json(new object());
        }
	}
}
