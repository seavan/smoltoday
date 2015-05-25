using System.ComponentModel.DataAnnotations;
using meridian.smolensk.system;

namespace meridian.smolensk.proto
{
    public partial class city_prices : ILookupValueAspectProvider
    {
        public string GetIconClass()
        {
            return GetPricesCity_prices_icon() != null ? GetPricesCity_prices_icon().css_class : "";
        }
        public ILookupValueAspect Geticon_idLookupValueAspect()
        {
            return new LookupAspect("icon_id", this, () => Meridian.Default.city_prices_iconsStore.All());
        }
    }
}