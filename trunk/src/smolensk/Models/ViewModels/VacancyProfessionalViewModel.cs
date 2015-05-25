using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using smolensk.ViewModels;
using smolensk.Models.CodeModels;

namespace smolensk.Models.ViewModels
{
    public class VacancyProfessionalViewModel : EntityBaseViewModel, ISelected
    {
        public VacancyProfessionalViewModel()
            :this(0)
        {
            
        }

        public VacancyProfessionalViewModel(long id) : base(id)
        {
        }

        public string Title { get; set; }

        public VacancyProfessionalViewModel Parent { get; set; }
        public IList<VacancyProfessionalViewModel> Children { get; set; }
        public bool Selected { get; set; }
    }
}