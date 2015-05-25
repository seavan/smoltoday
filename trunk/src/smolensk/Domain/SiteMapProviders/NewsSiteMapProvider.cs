using System.Collections.Generic;
using System.Linq;
using MvcSiteMapProvider;
using meridian.smolensk.system;

namespace smolensk.Domain.SiteMapProviders
{
    public class NewsSiteMapProvider : DynamicNodeProviderBase
    {
        public override IEnumerable<DynamicNode> GetDynamicNodeCollection(ISiteMapNode node)
        {
            var meridian = Meridian.Default;
            var nodes = new List<DynamicNode>();

            var categories = meridian.news_categoriesStore.All();

            foreach (var category in categories)
            {
                var catNode = new DynamicNode
                    {
                        Key = "news_category_" + category.id,
                        Action = "List",
                        Controller = "News",
                        Title = category.title,
                        Route = "NewsList",
                        PreservedRouteParameters = new List<string> { "page", "year", "month", "day" }
                    };

                catNode.RouteValues.Add("categoryId", category.id);
                nodes.Add(catNode);

                var news = meridian.newsStore.LoadNewsByCategory(category.id);

                foreach (var article in news)
                {
                    var newsNode = new DynamicNode
                    {
                        Key = "news_article_" + article.id,
                        ParentKey = catNode.Key,
                        Action = "Single",
                        Controller = "News",
                        Title = article.title,
                        Route = "NewsOne",
                        PreservedRouteParameters = new List<string> { "entryName" }
                    };

                    newsNode.RouteValues.Add("id", article.id);
                    nodes.Add(newsNode);

                    var newsVideoNode = new DynamicNode
                    {
                        Key = "news_article_videos_" + article.id,
                        ParentKey = newsNode.Key,
                        Action = "VideosByTheme",
                        Controller = "News",
                        Title = string.Format("Видео по теме \"{0}\"", article.title)
                    };

                    newsVideoNode.RouteValues.Add("id", article.id);
                    nodes.Add(newsVideoNode);

                    var newsImageNode = new DynamicNode
                    {
                        Key = "news_article_photos_" + article.id,
                        ParentKey = newsNode.Key,
                        Action = "ImagesByTheme",
                        Controller = "News",
                        Title = string.Format("Фотографии по теме \"{0}\"", article.title)
                    };

                    newsImageNode.RouteValues.Add("id", article.id);
                    nodes.Add(newsImageNode);
                }
            }

            return nodes;
        }
    }
}