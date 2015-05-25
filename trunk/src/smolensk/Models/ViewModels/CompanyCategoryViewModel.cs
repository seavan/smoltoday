using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using smolensk.ViewModels;

namespace smolensk.Models.ViewModels
{
    public class CompanyCategoryViewModel : EntityBaseViewModel
    {
        public CompanyCategoryViewModel(long id) : base(id)
        {
        }

        public string Title { get; set; }
        public string Icon { get; set; }
        public string IconUrl { get; set; }
        public int CountOfCompanies { get; set; }
        public int Popularity { get; set; }

        public CompanyCategoryViewModel Parent { get; set; }
        public List<CompanyCategoryViewModel> Children { get; set; }

        public bool IsRoot { get { return Parent == null; } }

        public int GetCalculatedCompanies()
        {
            return Children.Sum(c => c.CountOfCompanies) + CountOfCompanies;
        }
    }
}