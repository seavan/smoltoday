using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using smolensk.common;

namespace smolensk.Models.ViewModels
{
    public class SearchAdViewModel
    {
        [Display(Name = "Поиск по объявлениям")]
        public string Q { get; set; }
        public List<SelectListItem> Categories { get; set; }
        public int Category { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }

        public SearchAdViewModel()
        {
            Page = 1;
            PageSize = Constants.PageSize;
            Q = string.Empty;
        }
    }
}