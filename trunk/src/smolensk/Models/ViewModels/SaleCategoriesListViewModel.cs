using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace smolensk.Models.ViewModels
{
    public class SaleCategoriesListViewModel
    {
        public IEnumerable<SaleCategoryViewModel> Categories { get; set; }

        public long? SelectedCategoryId { get; set; }

        public string SetHighlight(bool highlighted)
        {
            return highlighted ? "class=\"cur\"" : string.Empty;
        }
    }
}