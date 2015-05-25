using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using meridian.smolensk.proto;
using meridian.smolensk.system;
using smolensk.Models.CodeModels;
using smolensk.ViewModels;

namespace smolensk.Models.ViewModels
{
    public class CompanyViewModel : EntityBaseViewModel, IDescriptable
    {
        public CompanyViewModel()
            :base(0)
        {
        }

        public CompanyViewModel(long id) : base(id)
        {
        }

        public string Title { get; set; }
        public string WorkTime { get; set; }
        public string Address { get; set; }
        public string Www { get; set; }
        public string Email { get; set; }
        public string Phones { get; set; }
        public string Leader { get; set; }
        public string Description { get; set; }
        public DateTime PublishDate { get; set; }
        public string PublishDateStr { get; set; }
        public string LogoUrl { get; set; }

        public CompanyCategoryViewModel Category { get; set; }
        public List<DictionaryElement> KindsOfActivities { get; set; }
        public List<FileElement> Files { get; set; }
        public List<RelatedPhoto> Photos { get; set; }

        public AlphabetViewModel Alphabet { get; set; }

        public long PaidOrder { get; set; }
        public bool IsPaid { get; set; }

        public long StableOrder { get; set; }
        public bool IsStable { get; set; }

        public ICommentable Comments { get; set; }
        public IMarkable Marks { get; set; }
        public IGeoLocation GeoLocation { get; set; }
        public IFavorite Favorite { get; set; }

        public int Rating { get; set; }

        public IList<CompanyViewModel> TopCompanies { get; set; }

        public List<VacancyViewModel> Vacancies { get; set; }

        /// <summary>
        /// Виды деятельности
        /// </summary>
        public string ViewOfActions { get; set; }

        public string GetShortDescription()
        {
            if (Description.Length < 500)
            {
                return Description;
            }

            int i = Description.IndexOf(' ', 500);
            if (i == -1)
            {
                return Description;
            }

            return Description.Substring(0, i);
        }

        public int GetShortDescriptionLength()
        {
            if (Description.Length < 500)
            {
                return Description.Length;
            }

            int i = Description.IndexOf(' ', 500);
            if (i == -1)
            {
                return Description.Length;
            }

            return i;
        }

        public Uri GetItemUri()
        {
            string uri = string.Format("/Companies/One/{0}/{1}", Id, Title.TransliterateAndClear());

            return new Uri(uri, UriKind.Relative);
        }
        public Uri GetItemVacancyUri()
        {
            string uri = string.Format("/Vacancy/Company/{0}/{1}", Id, Title.TransliterateAndClear());

            return new Uri(uri, UriKind.Relative);
        }
    }
}