using System.Collections.Generic;
using System.Linq;
using MvcSiteMapProvider;
using meridian.smolensk.system;

namespace smolensk.Domain.SiteMapProviders
{
    public class DiscountsSiteMapProvider : CachedSiteMapProvider
    {
        public override IEnumerable<DynamicNode> DoGet(ISiteMapNode node)
        {
            var meridian = Meridian.Default;
            var nodes = new List<DynamicNode>();

            var categories = meridian.sale_categoriesStore.All();

            var favNode = new DynamicNode
            {
                Key = "discounts_fav_0",
                Action = "Favorites",
                Controller = "Discounts",
                Title = "Избранные скидки",
                PreservedRouteParameters = new List<string> { "type", "sorting", "page", "companyId" },
                Route = "DiscountsList"
            };

            favNode.RouteValues.Add("categoryId", 0);

            nodes.Add(favNode);

            foreach (var category in categories)
            {
                var catNode = new DynamicNode
                {
                    Key = "discounts_category_" + category.id,
                    Action = "Category",
                    Controller = "Discounts",
                    Title = category.title,
                    PreservedRouteParameters = new List<string> { "type", "sorting", "page", "companyId" },
                    Route = "DiscountsList"
                };

                catNode.RouteValues.Add("categoryId", category.id);

                nodes.Add(catNode);

                favNode = new DynamicNode
                {
                    Key = "discounts_fav_" + category.id,
                    Action = "Favorites",
                    Controller = "Discounts",
                    Title = category.title,
                    PreservedRouteParameters = new List<string> { "type", "sorting", "page", "companyId" },
                    Route = "DiscountsList"
                };

                favNode.RouteValues.Add("categoryId", category.id);

                nodes.Add(favNode);

                var discounts = meridian.salesStore.All().Where(item => item.category_id == category.id);

                foreach (var discount in discounts)
                {
                    var discountNode = new DynamicNode
                    {
                        Key = "discounts_one_" + discount.id,
                        Action = "One",
                        Controller = "Discounts",
                        ParentKey = catNode.Key,
                        Title = discount.title,
                        Route = "DiscountOne",
                        PreservedRouteParameters = new List<string> { "entryName" }
                    };

                    discountNode.RouteValues.Add("id", discount.id);

                    nodes.Add(discountNode);
                }
            }

            return nodes;
        }
    }
}