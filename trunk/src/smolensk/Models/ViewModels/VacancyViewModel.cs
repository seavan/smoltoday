using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using smolensk.Models.CodeModels;
using smolensk.ViewModels;
using smolensk.common;
using meridian.smolensk.proto;
using smolensk.Models.ModelValidators.Attributes;

namespace smolensk.Models.ViewModels
{
    public class VacancyViewModel : EntityBaseViewModel, IValidatableObject
    {
        public VacancyViewModel()
            :base(0)
        {
            
        }
        public VacancyViewModel(long id) : base(id)
        {
        }

        public bool IsPublish { get; set; }
        public DateTime Created { get; set; }
        public DateTime Edited { get; set; }

        public accounts User { get; set; }

        [Required(ErrorMessage = "Укажите название")]
        public string Title { get; set; }

        public CompanyViewModel Company { get; set; }
        public DictionaryElement City { get; set; }

        [Required(ErrorMessage = "Укажите контактное лицо")]
        public string ContactPerson { get; set; }
        [Required(ErrorMessage = "Укажите контактный телефон")]
        public string ContactPhone { get; set; }

        public string ContactPhone2 { get; set; }
        public int? Compensation1 { get; set; }
        public int? Compensation2 { get; set; }
        public int? Age1 { get; set; }
        public int? Age2 { get; set; }
        public Sex? Sex { get; set; }
        /// <summary>
        /// Описание
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Обязанности
        /// </summary>
        public string Responsibility { get; set; }
        /// <summary>
        /// Требования
        /// </summary>
        public string Requirements { get; set; }
        /// <summary>
        /// Условия
        /// </summary>
        public string Terms { get; set; }
        public DictionaryElement WorkRegion { get; set; }
        public DictionaryElement WorkCity { get; set; }
        public string WorkAddress { get; set; }
        public string WorkPhone { get; set; }
        public string WorkPhone2 { get; set; }

        public int CountVacancies { get; set; }
        public bool ShowInBanner { get; set; }

        public IFavorite Favorite { get; set; }

        public List<VacancyEntryViewModel> Experience { get; set; }
        public List<VacancyEntryViewModel> Citizenship { get; set; }
        public List<VacancyEntryViewModel> WorkType { get; set; }
        /// <summary>
        /// График работы
        /// </summary>
        public List<VacancyEntryViewModel> WorkMode { get; set; }
        public VacancyEntryViewModel Education { get; set; }

        [NeedOneAttribute(ErrorMessage = "Укажитие как минимум одну профессиональную область")]
        public IList<VacancyProfessionalViewModel> Professionals { get; set; }

        public List<vacancy_facilities> Facilities { get; set; }

        public IEnumerable<VacancyViewModel> Similar { get; set; }

        public string GetCompensationTitle(string currency=" р.")
        {
            if (Compensation1.HasValue && Compensation2.HasValue)
            {
                return string.Format("{0} - {1}{2}", Compensation1, Compensation2, currency);
            }

            if (Compensation1.HasValue)
            {
                return string.Format("{0}{1}", Compensation1, currency);
            }

            return "По договоренности";
        }

        public bool ShouldDisplayPreferences
        {
            get
            {
                return Age1.HasValue || Age2.HasValue || Sex.HasValue;
            }
        }

        public string GetAgeTitle()
        {
            if (Age1.HasValue && Age2.HasValue)
            {
                return string.Format("от {0} до {1}", Age1, Age2);
            }

            if (Age1.HasValue)
            {
                return string.Format("от {0}", Age1);
            }

            if (Age2.HasValue)
            {
                return string.Format("до {0}", Age2);
            }

            return "Не имеет значения";
        }

        public string GetSexTitle()
        {
            if (Sex.HasValue)
            {
                if (Sex == common.Sex.Мужской)
                {
                    return "мужчина";
                }

                return "женщина";
            }

            return "";
        }

        public Uri GetItemUri()
        {
            string uri = string.Format("/Vacancy/Vacancy/{0}/{1}", Id, Title.TransliterateAndClear());

            return new Uri(uri, UriKind.Relative);
        }

        public string GetContactPhone()
        {
            if (string.IsNullOrEmpty(ContactPhone))
            {
                return string.Empty;
            }

            if (string.IsNullOrEmpty(ContactPhone2))
            {
                return ContactPhone;
            }

            return string.Format("{0} {1}", ContactPhone, ContactPhone2);
        }

        public string GetHideContactPhone()
        {
            if (string.IsNullOrEmpty(ContactPhone) || ContactPhone.Length < 3)
            {
                return "Не указан";
            }

            return ContactPhone.Substring(0, 3);
        }

        public static string Enumerate(IEnumerable<VacancyEntryViewModel> list)
        {
            return string.Join(", ", list.Select(l => l.Title));
        }

        public IEnumerable<SelectListItem> EducationsList { get; set; }
        public IEnumerable<SelectListItem> CompaniesList { get; set; }


        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrEmpty(Company.Title))
                yield return new ValidationResult("Необходимо указать компанию", new List<string>() { "Company.Title" });
            if (!string.IsNullOrEmpty(Company.Title) && Company.Title.Length <= 2)
                yield return new ValidationResult("Слишком короткое название", new List<string>() { "Company.Title" });
            if (!string.IsNullOrEmpty(Company.Title) && Company.Title.Length > 2)
                yield return ValidationResult.Success;
            
        }
    }
}