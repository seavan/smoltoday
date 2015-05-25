using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using smolensk.ViewModels;

namespace smolensk.Models.ViewModels
{
    public class SaleCategoryViewModel : EntityBaseViewModel
    {
        public SaleCategoryViewModel(long id) : base(id) { }

        public string Title { get; set; }
    }
}