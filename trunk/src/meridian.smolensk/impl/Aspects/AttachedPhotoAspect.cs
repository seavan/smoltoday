using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using admin.db;

namespace meridian.smolensk.proto
{
    public abstract class AttachedPhotoAspect : Aspect, IAttachedPhotoAspect
    {
        private string dataFolder;

        public virtual bool Multiple { get { return true; } }

        public AttachedPhotoAspect(string fieldName, IDatabaseEntity parent, string dataFolder)
            : base(fieldName, parent)
        {
            this.dataFolder = dataFolder;
        }

        public abstract IEnumerable<IAttachedPhoto> GetAllPhotos();
        public abstract IAttachedPhoto AddPhoto(string original, string thumb, string url, string path, string[] param);

        public string GetUploadDataFolder()
        {
            return dataFolder;
        }

        public abstract void RemovePhoto(long id);

        public abstract void SetMain(long id);
    }
}
