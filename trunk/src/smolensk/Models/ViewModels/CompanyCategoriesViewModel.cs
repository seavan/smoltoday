using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using meridian.smolensk.proto;

namespace smolensk.Models.ViewModels
{
    public class CompanyCategoriesViewModel : EntitiesListBaseViewModel<CompanyViewModel>
    {
        public IList<CompanyCategoryViewModel> Categories { get; set; }
        public AlphabetViewModel Alphabet { get; set; }
        public SearchCompanyBlockViewModel SearchBlock { get; set; }
    }
}