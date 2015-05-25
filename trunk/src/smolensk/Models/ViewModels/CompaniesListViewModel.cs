using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using smolensk.Models.CodeModels;
using smolensk.Models.ViewModels;
using smolensk.common;

namespace smolensk.ViewModels
{
    public class CompaniesListViewModel
    {
        public CompaniesListViewModel()
        {
        }

        public SortingType Sorting { get; set; }
        public string Letter { get; set; }

        public CompanyCategoryViewModel Category { get; set; }  

        public IList<CompanyViewModel> Companies { get; set; }
        //public int TotalCompanies { get; set; }

        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }

        public AlphabetViewModel Alphabet { get; set; }
        public IList<CompanyViewModel> TopCompanies { get; set; }

        public SearchCompanyBlockViewModel SearchBlock { get; set; }

        public bool OnlyFavorite { get; set; }
        public string RouteName { get; set; }
    }
}