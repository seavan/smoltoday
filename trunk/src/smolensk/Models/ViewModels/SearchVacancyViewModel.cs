using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using meridian.smolensk.proto;

namespace smolensk.Models.ViewModels
{
    public class SearchVacancyViewModel
    {
        public SearchVacancyBlockViewModel SearchBlock { get; set; }
        public IList<VacancyViewModel> WeekVacancies { get; set; }
        public IList<companies> WorkInCompanies { get; set; }
    }
}