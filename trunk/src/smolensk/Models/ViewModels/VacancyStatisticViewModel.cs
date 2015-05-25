using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace smolensk.Models.ViewModels
{
    public class VacancyStatisticViewModel
    {
        public int Companies { get; set; }
        public int Resumes { get; set; }
        public int Vacancies { get; set; }
    }
}