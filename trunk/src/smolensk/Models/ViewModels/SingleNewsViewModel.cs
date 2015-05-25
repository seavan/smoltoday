using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using meridian.smolensk.proto;
using smolensk.Domain;

namespace smolensk.ViewModels
{
    public class SingleNewsViewModel : EntityBaseViewModel, INavigateableItem, IBreadCrumbsProvider
    {
        public SingleNewsViewModel(long id) : base(id)
        {
            RelatedNews = new List<SingleNewsViewModel>();
        }

        public string Title { get; set; }
        public string Lead { get; set; }
        public string Announce { get; set; }
        public string Text { get; set; }
        public DateTime PublishDate { get; set; }
        public int Rating { get; set; }
        public int ViewsCount { get; set; }
        public int CommentsCount { get; set; }
        public CategoryViewModel Category { get; set; }
        public ICollection<ImageViewModel> Pictures { get; set; }
        public List<SingleNewsViewModel> RelatedNews { get; set; }

        public string AuthorAsText { get; set; }

        /*public ICommentable Comments { get; set; }
        public IMarkable Marks { get; set; }*/

        public news baseEntity { get; set; }

        public string AnnounceTrimmed(int rowMaxNumber = 5, int rowMaxLength = 34, int titleRowMaxLengt = 22)
        {
            return TextHelper.TrimAnnounce(Title, Announce, rowMaxNumber, rowMaxLength, titleRowMaxLengt);
        }

        public bool HasPicture
        {
            get { return Pictures != null && Pictures.Count > 0; }
        }

        public static string GetClassSegment()
        {
            return "News/";
        }

        public string GetItemUriBase(string anchor)
        {
            return string.Format("/{1}Single/{0}/{2}{3}", Id, GetClassSegment(), Title.TransliterateAndClear(), anchor);
        }

        public Uri GetItemUri()
        { 
            string uri = GetItemUriBase("#menuTop");

            return new Uri(uri, UriKind.Relative);
        }

        public Uri GetCommentsUri()
        {
            string uri = GetItemUriBase("#comments");

            return new Uri(uri, UriKind.Relative);
        }

        public string FormatFullPublishDate()
        {
            return Formatter.FormatLongDateTime(PublishDate);
        }

        public string FormatRecentPublishDate()
        {
            return Formatter.FormatRecentDate(this.PublishDate, DateTime.Now);
        }

        public string GetUri()
        {
            return GetItemUri().ToString();
        }

        public string GetHrefTitle()
        {
            return Title;
        }

        public IEnumerable<INavigateableItem> GetBreadCrumbs()
        {
            var result = new List<INavigateableItem>();

            result.Add(new NavigateableItemDummy(GetClassSegment(), "Новости"));

            if (this.Category != null)
            {
                result.Add(this.Category);    
            }

            //result.Add(this);

            return result;
        }
    }
}