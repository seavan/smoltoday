using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using meridian.smolensk.proto;
using smolensk.Mappers;
using smolensk.Models.CodeModels;
using meridian.smolensk.system;

namespace smolensk.Models.ViewModels
{
    public class SearchVacancyOrResumeViewModel
    {
        /// <summary>
        /// 'v' or 'r'
        /// </summary>
        public string Type { get; set; }

        public string Keywords { get; set; }
        public bool InTitle { get; set; }
        public bool InDescription { get; set; }
        public bool InCompanyTitle { get; set; }

        public List<long> Professionals { get; set; }
        public long RegionId { get; set; }
        public long CityId { get; set; }
        public long EducationId { get; set; }

        public int Compensation1 { get; set; }
        public int Compensation2 { get; set; }
        public bool HideWithoutSalary { get; set; }

        public int Age1 { get; set; }
        public int Age2 { get; set; }
        public bool HideWithoutAge { get; set; }

        public bool HideForNational { get; set; }
        public long ExperienceId { get; set; }
        public long CitizenshipId { get; set; }
        public List<long> WorkTypeIds { get; set; }
        public List<long> WorkModeIds { get; set; }

        //TODO: Льготы
        public List<long> FacilityIds { get; set; }
        public List<long> FacilityValueIds { get; set; }

        public long OwnershipId { get; set; }
        public bool UseOwnership { get; set; }
        public bool OwnerExtInform { get; set; }

        public bool HideAgents { get; set; }
        public bool HideDisabled { get; set; }
        public VacancySortingType Sorting { get; set; }
        public VacancyPrintType Print { get; set; }
        public int PageSize { get; set; }

        public bool IsEmpty { get { return Type == null; } }

        public bool IsVacancy { get { return Type == "v"; } }

        public IList<VacancyProfessionalViewModel> ProfessionalsList { get; set; }
        public IEnumerable<SelectListItem> EducationsList { get; set; }
        public IList<VacancyEntryViewModel> Experiences { get; set; }
        public IList<VacancyEntryViewModel> Citizenships { get; set; }
        public IList<VacancyEntryViewModel> WorkTypes { get; set; }
        public IList<VacancyEntryViewModel> WorkModes { get; set; }
        public IEnumerable<SelectListItem> OwnershipsList { get; set; }
        public IList<vacancy_facilities> Facilities { get; set; }
    }
}