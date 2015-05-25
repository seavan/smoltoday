using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using smolensk.ViewModels;
using meridian.smolensk.proto;
using System.Text.RegularExpressions;
using smolensk.Domain;

namespace smolensk.Models.ViewModels
{
    public class PlaceViewModel : EntityBaseViewModel, ISocialLinks
    {
        public PlaceViewModel(long id) : base(id)
        {
        }

        public places baseEntity { get; set; }

        public string Title { get; set; }
        public string Adress { get; set; }
        public string Text { get; set; }
        public string Price { get; set; }
        public string WorkTime { get; set; }
        public string Location { get; set; }
        

        public string Phone { get; set; }
        public string Site { get; set; }
        public string GoogleLink { get; set; }
        public string FacebookLink { get; set; }
        public string TwitterLink { get; set; }
        public string VkLink { get; set; }
        public string MailLink { get; set; }
        public string OdnoklassnikiLink { get; set; }

        public IMarkable Marks { get; set; }

        public string Announce
        {
            get
            {
                return TextHelper.TrimAnnounce(Title, Text, 2, 134, 65);
            }
        }


        public Uri GetItemUri()
        {
            string uri = string.Format("/Poster/Place/{0}/{1}", Id, Title.TransliterateAndClear());

            return new Uri(uri, UriKind.Relative);
        }
    }
}