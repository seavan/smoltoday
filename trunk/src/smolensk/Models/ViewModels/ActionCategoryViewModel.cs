using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using smolensk.ViewModels;
using smolensk.Models.CodeModels;

namespace smolensk.Models.ViewModels
{
    public class ActionCategoryViewModel : EntityBaseViewModel
    {
        public ActionCategoryViewModel(long id) : base(id)
        {
        }

        public string Title { get; set; }

        public IEnumerable<ActionViewModel> LastActions { get; set; }
        public int ActionsCount { get; set; }
        public DateRange Date { get; set; }
    }
}