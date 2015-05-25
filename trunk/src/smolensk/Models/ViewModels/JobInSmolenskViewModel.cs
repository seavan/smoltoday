using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace smolensk.Models.ViewModels
{
    public class JobInSmolenskViewModel
    {
        public int VacanciesCount { get; set; }
        public VacancyViewModel Vacancy { get; set; }
    }
}