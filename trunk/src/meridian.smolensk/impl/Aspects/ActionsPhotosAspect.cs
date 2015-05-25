using System.Collections.Generic;
using System.Linq;
using admin.db;
using meridian.smolensk.system;
using smolensk.common;

namespace meridian.smolensk.proto
{
    public class ActionsPhotosAspect : AttachedPhotoAspect
    {
        private actions model;

        public ActionsPhotosAspect(actions model)
            : base("Photos", model, Constants.ActionsDataFolder)
        {
            this.model = model;
        }

        public override IEnumerable<IAttachedPhoto> GetAllPhotos()
        {
            return model.Photos;
        }

        public override IAttachedPhoto AddPhoto(string original, string thumb, string url, string path, string[] param)
        {
            var p = model.AddPhotos(new actions_photos()
                {
                    action_id = model.id,
                    is_main = false,
                    normal = original,
                    thumbnail = thumb
                }, true);

            SetMain();
            return p;
        }

        public override void RemovePhoto(long id)
        {
            model.RemovePhotos(model.GetPhotos().Single(s => s.Id.Equals(id)), true);
            SetMain();
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

        private void SetMain()
        {
            var photos = GetAllPhotos();
            if (photos.Count() == 1)
                SetMain(photos.First().Id);
        }
    }
}