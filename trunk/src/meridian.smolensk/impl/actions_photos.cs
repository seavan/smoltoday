using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using smolensk.common;

namespace meridian.smolensk.proto
{
    public partial class actions_photos : IAttachedPhoto
    {
        public long Id
        {
            get { return id; }
        }

        public string ThumbUrl
        {
            get { return Constants.ActionsDataFolder + this.normal; }
        }

        public string FullUrl
        {
            get { return Constants.ActionsDataFolder + this.normal; }
        }


        public bool IsMain
        {
            get { return is_main; }
            set { is_main = value; }
        }


        public IEnumerable<IAttachedPhoto> SiblingsInclusive
        {
            get
            {
                return new IAttachedPhoto[] { this }.AsEnumerable();
            }
        }


        public admin.db.IDatabaseEntity AttachedPhotoContainer
        {
            get { return aphoto_actions_actions; }
        }

        public bool ShowIsMain
        {
            get { return true; }
        }

        public string EditLink
        {
            get { return null; }
        }
    }
}
