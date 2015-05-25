using System.Collections.Generic;
using MvcSiteMapProvider;
using meridian.smolensk.system;

namespace smolensk.Domain.SiteMapProviders
{
    public class PhotobankAdminSiteMapProvider : DynamicNodeProviderBase
    {
        public override IEnumerable<DynamicNode> GetDynamicNodeCollection(ISiteMapNode node)
        {
            var meridian = Meridian.Default;
            var nodes = new List<DynamicNode>();

            var albums = meridian.photobank_user_albumsStore.All();

            foreach (var album in albums)
            {
                var catNode = new DynamicNode
                {
                    Key = "photobank_album_" + album.id,
                    Action = "PhotoAlbum",
                    Controller = "Profile",
                    Title = string.Format("Альбом \"{0}\"", album.title),
                    PreservedRouteParameters = new List<string>{"page"}
                };

                catNode.RouteValues.Add("albumId", album.id);
                nodes.Add(catNode);
            }

            return nodes;
        }
    }
}