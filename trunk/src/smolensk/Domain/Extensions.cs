using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace smolensk.Domain
{
    public static class Extensions
    {
        public static string GetHost(bool _port = false)
        {
            var hname = HttpContext.Current.Request.ServerVariables["HTTP_HOST"];

            var cnt = hname.Count(c => c == '.');

            while (cnt > 1)
            {
                var ii = hname.IndexOf('.');
                hname = hname.Remove(0, ii + 1);
                cnt--;
            }

            var colon = hname.IndexOf(':');
            if (colon != -1)
            {
                hname = hname.Remove(colon, hname.Length - colon);
            }
            var uhname = HttpContext.Current.Request["SERVER_PORT"];
            var port = 80;
            int.TryParse(uhname, out port);
            if ((port != 80) && _port)
            {
                hname += ":" + port;
            }

            return hname;
        }
    }
}