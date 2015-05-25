using System.Collections.Generic;
using System.Linq;
using admin.db;
using meridian.smolensk.system;
using smolensk.common;

namespace meridian.smolensk.proto
{
    public class AdvertsPhotosAspect : AttachedPhotoAspect
    {
        public AdvertsPhotosAspect(ad_advertisments model)
            : base("Photos", model, Constants.AdvertsDataFolder)
        {
            this.model = model;
        }

        private ad_advertisments model;


        public override IEnumerable<IAttachedPhoto> GetAllPhotos()
        {
            return model.Photos;
        }

        public override IAttachedPhoto AddPhoto(string original, string thumb, string url, string path, string[] param)
        {
            return model.AddPhotos(new ad_photos()
                {
                    ad_id = model.id,
                    //is_main = false,
                    photo = original,
                    preview = thumb
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