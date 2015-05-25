using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using meridian.smolensk.proto;
using smolensk.Models.CodeModels;

namespace smolensk.Models.ViewModels
{
    public class VacancyCompanySearchViewModel
    {
        public long RegionId { get; set; }
        public long CityId { get; set; }
        public bool AllCompanies { get; set; }
        public string Filter { get; set; }

        public AlphabetViewModel Alphabet { get; set; }

        public List<companies> Companies { get; set; }
    }
}