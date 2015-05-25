using System.Collections.Generic;
using admin.db;

namespace meridian.smolensk.proto
{
    public interface IAttachedPhoto
    {
        long Id { get; }
        string ThumbUrl { get; }
        string FullUrl { get; }
        bool IsMain { get; set; }
        string ProtoName { get; }
        IDatabaseEntity AttachedPhotoContainer { get; }

        bool ShowIsMain { get; }
        string EditLink { get; }
    }

 
}