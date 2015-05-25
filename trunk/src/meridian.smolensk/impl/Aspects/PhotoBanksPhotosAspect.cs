using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using admin.db;
using meridian.smolensk.proto;
using meridian.smolensk.system;
using smolensk.common;

namespace meridian.smolensk.impl.Aspects
{
    public class PhotoBanksPhotosAspect : AttachedPhotoAspect
    {
        public PhotoBanksPhotosAspect(photobank_photos model)
            : base("Photos", model, Constants.PhotoFolder)
        {
            this.model = model;
        }

        private photobank_photos model;


        public override IEnumerable<IAttachedPhoto> GetAllPhotos()
        {
            return model.Photos;
        }

        public override IAttachedPhoto AddPhoto(string saveName, string originalName, string url, string path, string[] param)
        {
            photobank_related_photos result = model.AddPhotos(new photobank_related_photos()
                {
                    photo_id = model.id,
                    original = !model.GetPhotos().Any(p => p.original),
                    photo = saveName,
                    filename = param[0],
                    width = int.Parse(param[1]),
                    height = int.Parse(param[2])
                }, true);
            
            result.AddPrices(new photobank_photo_prices()
            {
                rel_photo_id = result.id,
                license_id = Meridian.Default.photobank_licensesStore.All().Any() ? Meridian.Default.photobank_licensesStore.All().First().id : 0
            }, true);

            if (result.original)
            {
                model.preview = PhotoBankCreator.CreatePreview(result.photo);
                model.preview_square = PhotoBankCreator.CreateSquarePreview(result.photo);
                model.preview_main = PhotoBankCreator.CreateMainPreview(result.photo);

                Meridian.Default.photobank_photosStore.Update(model);
            }

            return result;
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
                p.original = p.id == id;
                Meridian.Default.UpdateAs<IDatabaseEntity>(p.ProtoName, p.id);
            }
        }
    }
}
