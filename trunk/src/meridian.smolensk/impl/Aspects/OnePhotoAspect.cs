using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using meridian.smolensk.proto;
using smolensk.common;
using meridian.smolensk.system;
using admin.db;
using System.Reflection;

namespace meridian.smolensk.proto
{
    class OnePhotoAspect<T> : AttachedPhotoAspect where T: IDatabaseEntity
    {
        private T model;

        public override bool Multiple { get { return false; } }

        public OnePhotoAspect(T model, string field, string dataFolder)
            : base(field, model, dataFolder)
        {
            this.model = model; 
        }

        private PropertyInfo Field
        {
            get { return typeof(T).GetProperty(FieldName); }
        }

        private string Value 
        {
            get { return Field.GetValue(model, null).ToString(); }
            set 
            { 
                Field.SetValue(model, value, null);
                Meridian.Default.UpdateAs<IDatabaseEntity>(model.ProtoName, model.id);
            }
        }

        public override IEnumerable<IAttachedPhoto> GetAllPhotos()
        {
            return string.IsNullOrEmpty(Value) ? null :
                   new IAttachedPhoto[] { new AttachedOnePhoto(model, GetUploadDataFolder() + Value) };
        }

        public override IAttachedPhoto AddPhoto(string original, string thumb, string url, string path, string[] param)
        {
            Value = original;
            return null;
        }

        public override void RemovePhoto(long id)
        {
            Value = string.Empty;
        }

        public override void SetMain(long id) { }
    }
}
