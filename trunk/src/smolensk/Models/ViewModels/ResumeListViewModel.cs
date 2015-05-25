using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace smolensk.Models.ViewModels
{
    public class ResumeListViewModel
    {
        public SearchVacancyBlockViewModel SearchBlock { get; set; }
        public IList<ResumeViewModel> Resumes { get; set; }
        public int TotalResumes { get; set; }
        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }

        /// <summary>
        /// Для страницы списка резюме пользователя в кабинете
        /// </summary>
        public bool OnlyFavorites { get; set; }
    }
}