using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using smolensk.ViewModels;
using smolensk.common;

namespace smolensk.Models.ViewModels
{
    public class VacancyEntryViewModel : EntityBaseViewModel
    {
        public VacancyEntryViewModel()
            :this(0)
        {
            
        }

        public VacancyEntryViewModel(long id)
            : base(id)
        {
        }

        public string Title { get; set; }
        public VacancyEntryCategory Category { get; set; }
        public bool Selected { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return ((VacancyEntryViewModel)obj).Id == Id;
        }

        public override int GetHashCode()
        {
            return (int) Id;
        }
    }
}