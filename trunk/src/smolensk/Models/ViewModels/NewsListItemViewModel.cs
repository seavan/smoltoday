using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace smolensk.ViewModels
{
    public class NewsListItemViewModel : EntityBaseViewModel
    {
        public NewsListItemViewModel(long id) : base(id)
        {
        }

        public string Title { get; set; }
        public string Announce { get; set; }
        public DateTime PublishDate { get; set; }
        public int Rating { get; set; }
        public int ViewsCount { get; set; }
        public int CommentsCount { get; set; }
        public ICollection<ImageViewModel> Pictures { get; set; }

        public bool HasPicture
        {
            get { return Pictures != null && Pictures.Count > 0; }
        }

        public Uri GetItemUri()
        { 
            string uri = string.Format("/News/One/{0}", Id);

            return new Uri(uri, UriKind.Relative);
        }

        public string FormatPublishDate(DateTime current)
        {
            int daysDelta = (current.Date - PublishDate.Date).Days;

            if (daysDelta == 0)
                return PublishDate.ToString("HH:mm");

            if (daysDelta == 1)
                return string.Format("Вчера в {0:HH:mm}", PublishDate);

            return PublishDate.ToString("dd.MM.yyyy");
        }

        public string FormatPublishDate()
        {
            return FormatPublishDate(DateTime.Now);
        }
    }
}