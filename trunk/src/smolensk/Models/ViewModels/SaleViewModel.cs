using System.Collections.Generic;
using meridian.smolensk.proto;
using smolensk.ViewModels;
using smolensk.Domain;
using System;

namespace smolensk.Models.ViewModels
{
    public class SaleViewModel : EntityBaseViewModel, IBreadCrumbsProvider, INavigateableItem
    {
        public SaleViewModel(long id) : base(id) { }

        public string Title { get; set; }
        public string ShortTitle { get { return TextHelper.TrimAnnounce(string.Empty, Title, 3, 25); } }
        public string Text { get; set; }
        public string Site { get; set; }
        public string Phone { get; set; }
        public string WorkTime { get; set; }
        public string Products { get; set; }
        public string SalesOffices { get; set; }
        public string Image { get; set; }
        public string ImageForMain { get; set; }

        public SaleCategoryViewModel Category { get; set; }
        public bool Unlimited { get; set; }
        public CompanyViewModel Company { get; set; }

        public ICommentable Comments { get; set; }
        public IFavorite Favorite { get; set; }

        public smolensk.Models.CodeModels.DateRange Date { get; set; }

        public string DateAsInterval
        {
            get { return Date.ToStringFormat((d) => d.ToString("dd.MM.yyyy"), true); }
        }

        public string DateAsText
        {
            get { return Date.ToString(); }
        }

        public int? Percent { get; set; }
        public int? PercentMax { get; set; }

        public string PercentLabel
        {
            get 
            {
                if (PersentValue > 30)
                    return "red";
                if (PersentValue > 15)
                    return "orange";
                return "blue";
            }
        }
        public string PersentText
        {
            get
            {
                if (!Percent.HasValue && !PercentMax.HasValue) 
                    return string.Empty;
                return string.Format("скидки {0}{1}%", PercentMax.HasValue ? "до " : "", PersentValue.ToString() );
            }
        }
        public int PersentValue
        {
            get
            {
                if (!Percent.HasValue && !PercentMax.HasValue)
                    return 0;
                return PercentMax.HasValue ? PercentMax.Value : Percent.Value;
            }
        }

        public string GetUri()
        {
            return string.Format("/Discounts/One/{0}/{1}", Id, Title.TransliterateAndClear());
        }

        public string GetHrefTitle()
        {
            return Title;
        } 

        public IEnumerable<INavigateableItem> GetBreadCrumbs()
        {
            var result = new List<INavigateableItem>();
            result.Add(new NavigateableItemDummy("", "Скидки"));
            return result;
        }
    }
}