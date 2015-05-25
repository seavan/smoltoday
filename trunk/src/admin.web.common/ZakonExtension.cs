using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace System.Web
{
    public static class AdminExtension
    {
        public static string GetHost(bool _port = false)
        {
            //var hname =  _request.ServerVariables["HTTP_HOST"];
            var hname = HttpContext.Current.Request.ServerVariables["HTTP_HOST"];

            var tmp = hname.Contains("debug.") ? "debug." : string.Empty;

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

            return tmp + hname;
        }
    }
}

namespace System
{
    public static class CustomTempDataAdmin
    {
        private static Dictionary<string, object> _tempData;

        private static string GeKeyWithtSalt(string _key)
        {
            var cookie = HttpContext.Current.Request.Cookies["zuid"];

            if (cookie == null)
            {
                //throw new Exception("cookie zuid null");
                return _key;
            }

            var zuid = cookie.Value;
            return _key += "." + zuid;
        }

        public static void Data(string _key, object _val)
        {
            //_key = CustomTempDataAdmin.GeKeyWithtSalt(_key);

            if (_tempData == null)
            {
                _tempData = new Dictionary<string, object>();
            }
            if (!string.IsNullOrEmpty(_key) && _val != null)
            {
                _tempData[_key] = _val;
            }

        }
        public static object Data(string _key)
        {
            if (_tempData == null || string.IsNullOrEmpty(_key)) return null;

            //_key = CustomTempDataAdmin.GeKeyWithtSalt(_key);

            if (_tempData.Keys.Contains(_key))
            {
                object tmp = _tempData[_key];
                _tempData.Remove(_key);
                return tmp;
            }
            return null;
        }
    }
}
