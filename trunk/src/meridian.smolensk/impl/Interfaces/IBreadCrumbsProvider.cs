using System.Collections.Generic;

namespace meridian.smolensk.proto
{
    public interface IBreadCrumbsProvider
    {
        IEnumerable<INavigateableItem> GetBreadCrumbs();
    }
}