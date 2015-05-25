using System.Web;
using System.Web.Routing;
using meridian.smolensk.system;

namespace smolensk.Extensions
{
    public class StaticRouteConstraint : IRouteConstraint
    {
        public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
        {
            if (routeDirection == RouteDirection.IncomingRequest && values["url"] != null)
            {
                return Meridian.Default.pagesStore.GetStaticPageByUrl(values["url"].ToString()) != null;
            }

            return false;
        }
    }
}