using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using meridian.smolensk.proto;
using smolensk.Domain;
using smolensk.common;

namespace smolensk.Extensions
{
    public static class blogExtension
    {
        public static string PublishDate(this blogs blog)
        {
            return blog.publish_date.ToString("dd MMMM yyyy", CultureInfo.GetCultureInfo("ru-RU"));
        }
        public static string PublishDateWithTime(this blogs blog)
        {
            return blog.publish_date.ToString("dd MMMM yyyy в HH:mm", CultureInfo.GetCultureInfo("ru-RU"));
        }

        public static string BestAnnounce(this blogs blog)
        {
            return TextHelper.TrimAnnounce(blog.title, blog.announce, 5, 45, 29);
        }
        public static string ListAnnounce(this blogs blog)
        {
            return TextHelper.TrimAnnounce(blog.title, blog.announce, 5, 28, 20);
        }
        
        public static Uri GetCategoryUri(this blogs blog)
        {
            string uri = string.Format("/Blogs/List/{0}/{1}/{2}", SortingType.Rating, 1, blog.GetCategoryBlogBlog_categorie() != null ? blog.GetCategoryBlogBlog_categorie().id : 0);

            return new Uri(uri, UriKind.Relative);
        }
        public static Uri GetAuthorUri(this blogs blog)
        {
            string uri = blog.GetUser() != null ? string.Format("/Blogs/Author/{0}", blog.GetUser().id) : "#";

            return new Uri(uri, UriKind.Relative);
        }

        public static Uri GetCategoryUri (this blog_categories blogCategories)
        {
            string uri = string.Format("/Blogs/List/{0}/{1}/{2}", SortingType.Rating, 1, blogCategories.id);
            return new Uri(uri, UriKind.Relative);
        }
        public static string HighlightMenu(this blog_categories blogCategories)
        {
            return blogCategories.IsCur ? "class=\"cur\"" : string.Empty;
        }

        private static string EmptyThumbnailImageName = "emptyThumbnailImage.png";
        private static string ImageBasePath = "/content/userdata/blogs";

        public static string GetThumbnailImage(this blogs blog)
        {
            if (blog.ImagesBlog.Count() > 0)
            {
                return string.Format("{0}/{1}/{2}", ImageBasePath, blog.id, blog.ImagesBlog.First().list_thumbnail);
            }
            else
            {
                return string.Format("{0}/{1}", ImageBasePath, EmptyThumbnailImageName);
            }
        }
    }
}