using System.Collections.Generic;
using System.Linq;
using MvcSiteMapProvider;
using meridian.smolensk.system;

namespace smolensk.Domain.SiteMapProviders
{
    public class PosterSiteMapProvider : DynamicNodeProviderBase
    {
        public override IEnumerable<DynamicNode> GetDynamicNodeCollection(ISiteMapNode node)
        {
            var meridian = Meridian.Default;
            var nodes = new List<DynamicNode>();

            var categories = meridian.action_categoriesStore.All();

            foreach (var category in categories)
            {
                var catNode = new DynamicNode
                {
                    Key = "poster_category_" + category.id,
                    Action = "Category",
                    Controller = "Poster",
                    Title = category.title,
                    Route = "ActionsListByCategory",
                    PreservedRouteParameters = new List<string> { "dateFilter" }
                };

                catNode.RouteValues.Add("id", category.id);
                nodes.Add(catNode);

                var actions = meridian.actionsStore.All().Where(item => item.category_id == category.id);
                
                foreach (var action in actions)
                {
                    var actionNode = new DynamicNode
                    {
                        Key = "poster_action_" + action.id,
                        ParentKey = catNode.Key,
                        Action = "Action",
                        Controller = "Poster",
                        Title = action.title,
                        PreservedRouteParameters = new List<string>{ "entryName" }
                    };

                    actionNode.RouteValues.Add("id", action.id);
                    nodes.Add(actionNode);
                }
            }

            var places = meridian.placesStore.All();

            foreach (var place in places)
            {
                var placeNode = new DynamicNode
                {
                    Key = "poster_place_" + place.id,
                    Action = "Place",
                    Controller = "Poster",
                    Title = place.title,
                    PreservedRouteParameters = new List<string> { "entryName" }
                };

                placeNode.RouteValues.Add("id", place.id);
                nodes.Add(placeNode);
            }

            return nodes;
        }
    }
}