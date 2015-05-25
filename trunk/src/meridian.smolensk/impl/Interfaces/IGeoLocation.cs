using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace meridian.smolensk.proto
{
    public interface IGeoLocation
    {
        [Description("Широта")]
        double GetLatitude();

        [Description("Долгота")]
        double GetLongitude();

        Uri GetGeoLocationUri();

        [Description("Долгота,Широта")]
        string GeoLocationCoordinates { get; }

        string GeoLocationTitle { get; }
        string GeoLocationDescription { get; }

        string GetGeoLocationCategoryName();

    }
}
