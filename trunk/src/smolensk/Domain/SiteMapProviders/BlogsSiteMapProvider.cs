using System;
using System.Collections.Generic;
using System.Linq;
using MvcSiteMapProvider;
using meridian.smolensk.system;
using smolensk.common;

namespace smolensk.Domain.SiteMapProviders
{
    public class BlogsSiteMapProvider : DynamicNodeProviderBase
    {
        public override IEnumerable<DynamicNode> GetDynamicNodeCollection(ISiteMapNode node)
        {
            var meridian = Meridian.Default;
            var nodes = new List<DynamicNode>();

            foreach (var sortingType in Enum.GetNames(typeof(SortingType)))
            {
                var sortEnum = Enum.Parse(typeof (SortingType), sortingType);
                var sortNode = new DynamicNode
                {
                    Key = string.Format("blog_all_categories_{0}", sortingType),
                    Action = "List",
                    Controller = "Blogs",
                    Title = "Все категории"
                };

                sortNode.RouteValues.Add("sortingType", sortEnum);
                nodes.Add(sortNode);
            }

            var categories = meridian.blog_categoriesStore.All();
  
            foreach (var category in categories)
            {
                var catNode = new DynamicNode
                    {
                        Key = "blog_category_" + category.id,
                        Action = "List",
                        Controller = "Blogs",
                        Title = category.title,
                        PreservedRouteParameters = new List<string> { "sortingType", "page" }
                    };

                catNode.RouteValues.Add("categoryId", category.id);
                nodes.Add(catNode);

                var blogs = meridian.blogsStore.All().Where(item => item.category_id == category.id && !item.is_delete);

                foreach (var blog in blogs)
                {
                    var blogNode = new DynamicNode
                    {
                        Key = "blogs_blog_" + blog.id,
                        ParentKey = catNode.Key,
                        Action = "One",
                        Controller = "Blogs",
                        Title = blog.title,
                        Route = "BlogOne",
                        PreservedRouteParameters = new List<string> { "entryName" }
                    };

                    blogNode.RouteValues.Add("id", blog.id);
                    nodes.Add(blogNode);
                }
            }

            //блоги авторов (урлы /Blogs/Author/xx)
            var accountIds = meridian.blogsStore.All().Where(item => !item.is_delete).Select(item => item.account_id).Distinct();

            foreach (var accountId in accountIds)
            {
                var account = meridian.accountsStore.Get(accountId);

                var accountNode = new DynamicNode
                {
                    Key = "blogs_profile_" + account.id,
                    Action = "Author",
                    Controller = "Blogs",
                    Title = string.Format("Блоги автора {0}", account.ShortName),
                    Route = "BlogsAuthorList"
                };

                accountNode.RouteValues.Add("authorId", account.id);
                nodes.Add(accountNode);

                foreach (var sortingType in Enum.GetNames(typeof(SortingType)))
                {
                    accountNode = new DynamicNode
                    {
                        Key = string.Format("blogs_profile_{0}_{1}", sortingType, account.id),
                        Action = "Author",
                        Controller = "Blogs",
                        Title = string.Format("Блоги автора {0}", account.ShortName),
                        Route = "BlogsAuthorList"
                    };

                    accountNode.RouteValues.Add("authorId", account.id);
                    accountNode.RouteValues.Add("sortingType", sortingType);
                    nodes.Add(accountNode);
                }
            }

            return nodes;
        }
    }
}