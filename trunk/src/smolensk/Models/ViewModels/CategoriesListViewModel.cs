using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace smolensk.ViewModels
{
    public class CategoriesListViewModel
    {
        public IEnumerable<CategoryViewModel> Categories { get; set; }

        public long? SelectedCategoryId { get; set; }

        public string SetHighlight(bool highlighted)
        {
            return highlighted ? "class=\"cur\"" : string.Empty;
        }

        public DateTime Date { get; set; }
    }
}