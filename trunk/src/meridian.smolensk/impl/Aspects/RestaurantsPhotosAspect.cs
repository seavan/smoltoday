using System.Collections.Generic;
using System.Linq;
using admin.db;
using meridian.smolensk.system;
using smolensk.common;

namespace meridian.smolensk.proto
{
    public class RestaurantsPhotosAspect : AttachedPhotoAspect
    {
        public RestaurantsPhotosAspect(restaurants model)
            : base("Photos", model, Constants.RestaurantsDataFolder)
        {
            this.model = model;
        }

        private restaurants model;


        public override IEnumerable<IAttachedPhoto> GetAllPhotos()
        {
            return model.Photos;
        }

        public override IAttachedPhoto AddPhoto(string original, string thumb, string url, string path, string[] param)
        {
            return model.AddPhotos(new restaurant_photos()
                {
                    restaurtan_id = model.id,
                    is_main = false,
                    normal = original,
                    thumbnail = thumb
                }, true);
        }

        public override void RemovePhoto(long id)
        {
            model.RemovePhotos(model.GetPhotos().Single(s => s.Id.Equals(id)), true);
        }

        public override void SetMain(long id)
        {
            var photos = model.GetPhotos().ToArray();

            foreach (var p in photos)
            {
                p.is_main = p.id == id;
                Meridian.Default.UpdateAs<IDatabaseEntity>(p.ProtoName, p.id);
            }
        }
    }
}