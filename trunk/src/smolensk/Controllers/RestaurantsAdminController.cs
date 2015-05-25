using System.Linq;
using System.Text;
using System.Web.Mvc;
using admin.web.common;
using meridian.smolensk.controller;
using meridian.smolensk.proto;
using meridian.smolensk.system;
using smolensk.common;
using yandex.services;
using yandex.services.Maps;

namespace smolensk.Controllers
{
    public class RestaurantsAdminController : meridian_restaurants
    {
        

        public RestaurantsAdminController()
        {
            DefaultUploadVirtualFolder = Constants.RestaurantsDataFolder;
        }

        protected override System.Linq.IQueryable<restaurants> Filter(System.Linq.IQueryable<restaurants> _src)
        {
            return base.Filter(_src).OrderByDescending(s => s.id);
        }

        public ActionResult GalleryEditList(long restaurantId)
        {
            var photos = Meridian.Default.restaurantsStore.Get(restaurantId).Photos;
            return View(photos);
        }

        public override void ProcessUploadedFile(restaurants _model, System.Web.HttpPostedFileBase _file, string _name, string _path, string _url)
        {
            base.ProcessUploadedFile(_model, _file, _name, _path, _url);
            _model.AddPhotos(new restaurant_photos()
                {
                    normal = _name,
                    thumbnail = _name
                }, true);
        }

        public string GetCoordinates(string address)
        {
            var api = new Api(smolensk.common.Constants.YandexKey);
            var point = api.GetCoordinatesString(api.NormalizeAddress(address, "Смоленск"));

            return point;
        }

        public override void Prepare(meridian.smolensk.proto.restaurants i)
        {
            base.Prepare(i);

            if (!string.IsNullOrEmpty(i.address))
            {
                var coords = GetCoordinates(i.address);

                if (!string.IsNullOrEmpty(coords))
                {
                    i.coordinates = coords;
                }
            }
        }

        public string RebindGeo()
        {
            Response.ContentType = "text/plain";
            var result = new StringBuilder();

            var toParse = GetAll().Where(s => !string.IsNullOrEmpty(s.address.Trim())).ToArray();

            foreach (var i in toParse)
            {
                var coords = GetCoordinates(i.address);

                if (!string.IsNullOrEmpty(coords))
                {
                    result.AppendFormat("{0}:{1}\r\n", i.address, coords);
                    i.coordinates = coords;
                    this.Service.Update(i);
                }
                else
                {
                    result.AppendFormat("{0}:{1}\r\n", i.address, "not found");
                }
            }

            return result.ToString();
            //return Redirect("/CompaniesAdmin");
        }
    }
}