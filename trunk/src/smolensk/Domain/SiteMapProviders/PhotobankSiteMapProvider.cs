using System.Collections.Generic;
using System.Linq;
using MvcSiteMapProvider;
using meridian.smolensk.system;

namespace smolensk.Domain.SiteMapProviders
{
    public class PhotobankSiteMapProvider : DynamicNodeProviderBase
    {
        public override IEnumerable<DynamicNode> GetDynamicNodeCollection(ISiteMapNode node)
        {
            var meridian = Meridian.Default;
            var nodes = new List<DynamicNode>();

            var categories = meridian.photobank_categoriesStore.All();

            foreach (var category in categories)
            {
                var catNode = new DynamicNode
                {
                    Key = "photobank_category_" + category.id,
                    Action = "Category",
                    Controller = "Photobank",
                    Title = category.title
                };

                catNode.RouteValues.Add("id", category.id);
                nodes.Add(catNode);

                var photos = meridian.photobank_photosStore.All().Where(item => item.category_id == category.id);

                foreach (var photo in photos)
                {
                    var photoNode = new DynamicNode
                    {
                        Key = "photobank_photo_" + photo.id,
                        ParentKey = catNode.Key,
                        Action = "Image",
                        Controller = "Photobank",
                        Title = photo.title,
                        PreservedRouteParameters = new List<string>{"entryName"}
                    };

                    photoNode.RouteValues.Add("id", photo.id);
                    nodes.Add(photoNode);
                }
            }

            //получение всех авторов фоток
            var accountIds = meridian.photobank_photosStore.All().Select(item => item.account_id).Distinct();

            foreach (var accountId in accountIds)
            {
                var account = meridian.accountsStore.Get(accountId);
                var accountNode = new DynamicNode
                {
                    Key = "photobank_profile_" + account.id,
                    Action = "Profile",
                    Controller = "Photobank",
                    Title = string.Format("Портфолио фотографа {0}", account.ShortName)
                };

                accountNode.RouteValues.Add("id", account.id);
                nodes.Add(accountNode);
            }

            return nodes;
        }
    }
}