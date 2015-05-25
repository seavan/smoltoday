using System.Linq;
using System.Web.Mvc;
using meridian.smolensk.controller;
using meridian.smolensk.proto;
using meridian.smolensk.system;
using smolensk.common;

namespace smolensk.Controllers
{
    public class RestaurantsPhotoAdminController : meridian_restaurant_photos
    {
        public RestaurantsPhotoAdminController()
        {
            DefaultUploadVirtualFolder = Constants.RestaurantsDataFolder;
        }

    }
}