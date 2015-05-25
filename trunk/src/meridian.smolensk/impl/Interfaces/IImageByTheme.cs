using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace meridian.smolensk.proto
{
    public interface IImageByTheme
    {
        long id { get; }
        string ProtoName { get; }
        string title { get; }
        Uri GetItemThemeUri();
        Uri GetImgItemThemeUri();
        Uri GetImgThumbnailItemThemeUri();
    }
    public class IImageByThemeComparer : IEqualityComparer<IImageByTheme>
    {
        public bool Equals(IImageByTheme x, IImageByTheme y)
        {
            return (x.id == y.id);
        }

        public int GetHashCode(IImageByTheme obj)
        {
            return obj.id.GetHashCode();
        }
    }
}
