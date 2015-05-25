using System.Collections.Generic;
using System.Linq;
using admin.db;
using meridian.smolensk.system;
using smolensk.common;

namespace meridian.smolensk.proto
{
    public class CompaniesPhotosAspect : AttachedPhotoAspect
    {
        public CompaniesPhotosAspect(companies model)
            : base("Photos", model, Constants.CompaniesDataFolder)
        {
            this.model = model;
        }

        private companies model;


        public override IEnumerable<IAttachedPhoto> GetAllPhotos()
        {
            return model.Photos;
        }

        public override IAttachedPhoto AddPhoto(string original, string thumb, string url, string path, string[] param)
        {
            return model.AddPhotos(new company_photos()
                {
                    company_id = model.id,
                    is_main = false,
                    normal = original,
                    thumbnaill = thumb
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