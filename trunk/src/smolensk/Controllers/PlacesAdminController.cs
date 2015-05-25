using meridian.smolensk.controller;
using smolensk.common;
using yandex.services.Maps;

namespace smolensk.Controllers
{
    public class PlacesAdminController : meridian_places
    {

        public string GetCoordinates(string address)
        {
            var api = new Api(Constants.YandexKey);
            var point = api.GetCoordinatesString(api.NormalizeAddress(address, "Смоленск"));
            return point;
        }

        public override void Prepare(meridian.smolensk.proto.places i)
        {
            base.Prepare(i);

            if (!string.IsNullOrEmpty(i.adress))
            {
                var coords = GetCoordinates(i.adress);

                if (!string.IsNullOrEmpty(coords))
                {
                    i.coordinates = coords;
                }
            }
        }
    }
}