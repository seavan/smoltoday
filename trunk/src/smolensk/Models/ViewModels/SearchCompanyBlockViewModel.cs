using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace smolensk.Models.ViewModels
{
    public class SearchCompanyBlockViewModel
    {
        public string Query { get; set; }
        public long? CategoryId { get; set; }
        public List<CompanyCategoryViewModel> Categories { get; set; }

    }
}