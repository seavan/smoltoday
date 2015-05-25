using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace smolensk.Models.ViewModels
{
    public class SearchVacancyBlockViewModel
    {
        public string Query { get; set; }
        /// <summary>
        /// 1 - Vacancy, 2 - Resume
        /// </summary>
        public int SearchType { get; set; }

        public int ProfessionId { get; set; }
        public IList<VacancyProfessionalViewModel> Professionals { get; set; }

        public int SelectedSalaryId { get; set; }
        public static int[] Salaries = new[]
                                           {
                                               0, 15000, 25000, 40000, 60000
                                           };
        public int Compensation1
        {
            get { return SelectedSalaryId == -1 ? 0 : Salaries[SelectedSalaryId]; }
        }

        public int Compensation2
        {
            get
            {
                return SelectedSalaryId == -1
                           ? 0
                           : SelectedSalaryId == Salaries.Length - 1
                                 ? 0
                                 : Salaries[SelectedSalaryId + 1];
            }
        }
    }
}