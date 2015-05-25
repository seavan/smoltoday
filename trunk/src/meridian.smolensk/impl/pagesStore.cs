using System.Linq;
using meridian.smolensk.proto;

namespace meridian.smolensk.protoStore
{
    public partial class pagesStore
    {
        public pages GetStaticPageByUrl(string url)
        {
            if (string.IsNullOrEmpty(url))
            {
                return null;
            }
            url = url.Trim('/');
            return All().FirstOrDefault(x => string.Compare(x.alias.Trim('/'), url, true) == 0);
        }
    }
}