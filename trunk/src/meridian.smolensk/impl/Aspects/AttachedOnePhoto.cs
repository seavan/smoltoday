using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using meridian.smolensk.proto;
using admin.db;

namespace meridian.smolensk.proto
{
    public class AttachedOnePhoto : IAttachedPhoto
    {
        private IDatabaseEntity model;
        private string url;

        public AttachedOnePhoto(IDatabaseEntity model, string url)
        {
            this.model = model;
            this.url = url;
        }

        public long Id
        {
            get { return 0; }
        }

        public string ThumbUrl
        {
            get { return url; }
        }

        public string FullUrl
        {
            get { return url; }
        }

        public bool IsMain { get; set; }

        public string ProtoName
        {
            get { throw new System.NotImplementedException(); }
        }

        public IDatabaseEntity AttachedPhotoContainer
        {
            get { return model; }
        }

        public bool ShowIsMain
        {
            get { return false; }
        }

        public string EditLink
        {
            get { return null; }
        }
    }
}
