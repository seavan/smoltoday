using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace smolensk.Models.ViewModels
{
    public class VacancyListViewModel
    {
        public SearchVacancyBlockViewModel SearchBlock { get; set; }
        public IList<VacancyViewModel> Vacancies { get; set; }
        public int TotalVacancies { get; set; }
        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }

        /// <summary>
        /// Для страницы списка вакансий пользователя в кабинете
        /// </summary>
        public bool OnlyFavorites { get; set; }
    }
}