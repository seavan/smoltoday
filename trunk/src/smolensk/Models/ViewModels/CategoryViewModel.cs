using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using meridian.smolensk.proto;

namespace smolensk.ViewModels
{
    public class CategoryViewModel : EntityBaseViewModel, INavigateableItem
    {
        private string cssClass;

        public CategoryViewModel(long id) : base(id)
        {
        }

        public string Title { get; set; }

        public string CssClass
        {
            get
            {
                if (string.IsNullOrEmpty(cssClass))
                    return "default";

                return cssClass;
            }

            set
            {
                cssClass = value;
            }
        }

        public Uri GetViewCategoryUri()
        {
            return new Uri("/News/Category/" + Id, UriKind.Relative);
        }

        public string GetUri()
        {
            return GetViewCategoryUri().ToString();
        }

        public string GetHrefTitle()
        {
            return Title;
        }
    }
}