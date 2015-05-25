using System.Collections.Generic;
using System.Linq;
using MvcSiteMapProvider;
using meridian.smolensk.system;

namespace smolensk.Domain.SiteMapProviders
{
    public class CachedSiteMapProvider  : DynamicNodeProviderBase
    {
        private static SortedList<string, IEnumerable<DynamicNode>> CacheCollection = new SortedList<string, IEnumerable<DynamicNode>>();

        public override IEnumerable<DynamicNode> GetDynamicNodeCollection(ISiteMapNode node)
        {
            if (CacheCollection.IndexOfKey(GetType().Name) == -1)
            {
                CacheCollection[GetType().Name] = DoGet(node);
            }

            return CacheCollection[GetType().Name];
        }

        public virtual IEnumerable<DynamicNode> DoGet(ISiteMapNode node)
        {
            return new List<DynamicNode>();
        }
    }

    public class CompaniesSiteMapProvider : CachedSiteMapProvider
    {
        public override IEnumerable<DynamicNode> DoGet(ISiteMapNode node)
        {
            var meridian = Meridian.Default;
            var nodes = new List<DynamicNode>();

            var categories = meridian.company_categoriesStore.All().Where(item => item.parent == 0);

            foreach (var category in categories)
            {
                var catNode = new DynamicNode
                    {
                        Key = "companies_category_" + category.id,
                        Action = "List",
                        Controller = "Companies",
                        Title = category.title,
                        Route = "CompaniesList",
                        PreservedRouteParameters = new List<string> { "sorting", "letter", "alphabet", "page", "pageSize" }
                    };

                catNode.RouteValues.Add("category", category.id);
                nodes.Add(catNode);

                var companies = meridian.companiesStore.All().Where(item => item.category_id == category.id && !string.IsNullOrEmpty(item.title));

                foreach (var company in companies)
                {
                    var companyNode = new DynamicNode
                        {
                            Key = "companies_company_" + company.id,
                            ParentKey = catNode.Key,
                            Action = "One",
                            Controller = "Companies",
                            Title = company.title,
                            Route = "CompanyOne",
                            PreservedRouteParameters = new List<string> { "entryName" }
                        };

                    companyNode.RouteValues.Add("id", company.id);
                    nodes.Add(companyNode);
                }

                if (category.Children.Any())
                {
                    foreach (var subcategory in category.Children)
                    {
                        var subNode = new DynamicNode
                            {
                                Key = "companies_category_" + subcategory.id,
                                ParentKey = catNode.Key,
                                Action = "List",
                                Controller = "Companies",
                                Title = subcategory.title,
                                Route = "CompaniesList",
                                PreservedRouteParameters = new List<string> { "sorting", "letter", "alphabet", "page", "pageSize" }
                            };

                        subNode.RouteValues.Add("category", subcategory.id);
                        nodes.Add(subNode);

                        companies = meridian.companiesStore.All().Where(item => item.category_id == subcategory.id && !string.IsNullOrEmpty(item.title));

                        foreach (var company in companies)
                        {
                            var companyNode = new DynamicNode
                                {
                                    Key = "companies_company_" + company.id,
                                    ParentKey = subNode.Key,
                                    Action = "One",
                                    Controller = "Companies",
                                    Title = company.title,
                                    Route = "CompanyOne",
                                    PreservedRouteParameters = new List<string> { "entryName" }
                                };

                            companyNode.RouteValues.Add("id", company.id);
                            nodes.Add(companyNode);
                        }
                    }
                }
            }

            return nodes;
        }
    }
}