using System.Collections.Generic;
using System.Linq;
using MvcSiteMapProvider;
using meridian.smolensk.system;

namespace smolensk.Domain.SiteMapProviders
{
    public class AdvertsSiteMapProvider : DynamicNodeProviderBase
    {
        public override IEnumerable<DynamicNode> GetDynamicNodeCollection(ISiteMapNode node)
        {
            var meridian = Meridian.Default;
            var nodes = new List<DynamicNode>();

            var categories = meridian.ad_categoriesStore.All().Where(item => item.parent_id == 0);

            foreach (var category in categories)
            {
                var catNode = new DynamicNode
                    {
                        Key = "ad_category_" + category.id,
                        Action = "Category",
                        Controller = "Adverts",
                        Title = category.title
                    };

                catNode.RouteValues.Add("id", category.id);
                nodes.Add(catNode);
                
                if (category.Subcategories.Any())
                {
                    foreach (var subcategory in category.Subcategories)
                    {
                        var subNode = new DynamicNode
                            {
                                Key = "ad_category_" + subcategory.id,
                                ParentKey = catNode.Key,
                                Action = "Category",
                                Controller = "Adverts",
                                Title = subcategory.title
                            };

                        subNode.RouteValues.Add("id", subcategory.id);
                        nodes.Add(subNode);

                        var ads = meridian.ad_advertismentsStore.All().Where(item => item.category_id == subcategory.id);

                        foreach (var advert in ads)
                        {
                            var adNode = new DynamicNode
                            {
                                Key = "ad_advertisment_" + advert.id,
                                ParentKey = subNode.Key,
                                Action = "One",
                                Controller = "Adverts",
                                Title = advert.title,
                                Route = "AdvertOne",
                                PreservedRouteParameters = new List<string> { "entryName" }
                            };

                            adNode.RouteValues.Add("id", advert.id);
                            nodes.Add(adNode);
                        }
                    }
                }
            }

            return nodes;
        }
    }
}