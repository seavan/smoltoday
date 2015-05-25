using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcSiteMapProvider;
using meridian.smolensk.system;

namespace smolensk.Domain.SiteMapProviders
{
    public class RestaurantsSiteMapProvider: DynamicNodeProviderBase
    {
        public override IEnumerable<DynamicNode> GetDynamicNodeCollection(ISiteMapNode node)
        {
            var meridian = Meridian.Default;
            var nodes = new List<DynamicNode>();

            var restaurants = meridian.restaurantsStore.All();

            foreach (var restaurant in restaurants)
            {
                var catNode = new DynamicNode
                    {
                        Key = "restaurants_rest_" + restaurant.id,
                        Action = "One",
                        Controller = "Restaurants",
                        Title = restaurant.title,
                        Route = "RestaurantOne",
                        PreservedRouteParameters = new List<string> { "entryName" }
                    };

                catNode.RouteValues.Add("id", restaurant.id);
                nodes.Add(catNode);
            }

            return nodes;
        }
    }
}