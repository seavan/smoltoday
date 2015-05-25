using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using admin.db;
using meridian.smolensk.proto;
using smolensk.Models.CodeModels;
using smolensk.ViewModels;
using smolensk.common;

namespace smolensk.Models.ViewModels
{
    public class ResumeViewModel : EntityBaseViewModel
    {
        public ResumeViewModel() :this(0)
        {
        }

        public ResumeViewModel(long id) : base(id)
        {
        }

        public DateTime Created { get; set; }
        public DateTime Edited { get; set; }
        public resumes DbEntity { get; set; }
        public accounts User { get; set; }

        public string Post { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public Sex Sex { get; set; }
        public int Salary { get; set; }
        public string PhotoUrl { get; set; }
        public HttpPostedFileBase PhotoFile { get; set; }

        public IList<VacancyProfessionalViewModel> Professionals { get; set; }
        public List<vacancy_facilities> Facilities { get; set; }
        public DictionaryElement WorkRegion { get; set; }
        public DictionaryElement WorkCity { get; set; }
        public VacancyEntryViewModel Education { get; set; }
        public string Languages { get; set; }
        public VacancyEntryViewModel Experience { get; set; }
        /// <summary>
        /// График работы
        /// </summary>
        public List<VacancyEntryViewModel> WorkMode { get; set; }
        /// <summary>
        /// Тип занятости
        /// </summary>
        public List<VacancyEntryViewModel> WorkType { get; set; }

        public VacancyEntryViewModel FamilyStatus { get; set; }
        public int Children { get; set; }
        public VacancyEntryViewModel Citizenship { get; set; }

        public string SuccessDescription { get; set; }
        public string AboutMySelf { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        /// <summary>
        /// Добавочный
        /// </summary>
        public string Phone2 { get; set; }

        public string Email { get; set; }

        public List<resume_works> Works { get; set; }
        public List<resume_educations> Educations { get; set; }
        public List<resume_trainings> Trainings { get; set; }
        public string[] Links { get; set; }

        public bool IsPublish { get; set; }

        public string GetTitle()
        {
            int age = (int) (DateTime.Now.Subtract(BirthDate).TotalDays/365);
            return string.Format("{0}, {1}, {2}", FirstName,
                                 GetYearsTitle(age),
                                 Sex == Sex.Мужской ? "муж" : "жен");
        }

        public string GetRegion()
        {
            return string.Format("{0}, {1}", WorkRegion.Value, WorkCity.Value);
        }

        public Uri GetItemUri()
        {
            string uri = string.Format("/Vacancy/Resume/{0}/{1}", Id, GetTitle().TransliterateAndClear());

            return new Uri(uri, UriKind.Relative);
        }

        public string GetExpTitle()
        {
            return Experience.Title;
        }

        public string GetEducationTitle()
        {
            var sb = new StringBuilder();
            sb.Append(Education.Title);
            if (!string.IsNullOrEmpty(Languages))
                sb.AppendFormat(", знает {1}", Languages);

            return sb.ToString();
        }

        public string GetWorkModeTitle()
        {
            return string.Join(", ", WorkMode.Select(m => m.Title));
        }

        public string GetFullName()
        {
            string formatToAppend = " {0}";
            var sb = new StringBuilder();
            sb.Append(LastName);

            if (!string.IsNullOrEmpty(FirstName))
                sb.AppendFormat(formatToAppend, FirstName);

            if (!string.IsNullOrEmpty(MiddleName))
                sb.AppendFormat(formatToAppend, MiddleName);

            return sb.ToString();
        }

        public string GetShortName()
        {
            string formatToAppend = " {0}.";
            var builder = new StringBuilder(LastName);
            if (!string.IsNullOrEmpty(FirstName))
                builder.AppendFormat(formatToAppend, FirstName[0]);

            if (!string.IsNullOrEmpty(MiddleName))
                builder.AppendFormat(formatToAppend, MiddleName[0]);

            return builder.ToString();
        }

        public string GetAgeTitle()
        {
            int age = (int) (DateTime.Now.Subtract(BirthDate).TotalDays/365);

            return GetYearsTitle(age);
        }

        public string GetPhone()
        {
            if (string.IsNullOrEmpty(Phone2))
                return Phone;

            return string.Format("{0} {1}", Phone, Phone2);
        }

        private static string GetYearsTitle(int y)
        {
            var t1 = y%10;
            var t2 = y%100;
            if (t1 == 1 && t2 != 11)
            {
                return y.ToString() + " год";
            }
            if (t1 >= 2 && t1 <= 4 && (t2 < 10 || t2 >= 20))
            {
                return y.ToString() + " года";
            }

            return y.ToString() + " лет";
        }

        private static string GetMonthesTitle(int m)
        {
            var t1 = m % 10;
            if (t1 == 1)
            {
                return m.ToString() + " месяц";
            }
            if (t1 >= 2 && t1 <= 4)
            {
                return m.ToString() + " месяца";
            }

            return m.ToString() + " месяцев";
        }

        public IEnumerable<SelectListItem> EducationsList { get; set; }
        public IEnumerable<SelectListItem> FamilyStatusesList { get; set; }
        public IEnumerable<SelectListItem> CitizenshipsList { get; set; }
        public IEnumerable<SelectListItem> WorkTypesList { get; set; }
        public IEnumerable<SelectListItem> EducationLevelsList { get; set; }
        public IEnumerable<SelectListItem> LearningFormsList { get; set; }
        public IEnumerable<SelectListItem> ExperiencesList { get; set; }
    }
}