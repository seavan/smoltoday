using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace smolensk.Models.ViewModels
{
    public class RegionSelectorViewModel
    {
        public RegionSelectorViewModel()
        {
            RegionIdName = "region";
            CityIdName = "region2";
            ShowAnyVariant = true;
        }

        public string RegionIdName { get; set; }
        public string CityIdName { get; set; }
        public string RegionName { get; set; }
        public string CityName { get; set; }
        public long RegionId { get; set; }
        public long CityId { get; set; }
        public bool ShowAnyVariant { get; set; }
    }
}