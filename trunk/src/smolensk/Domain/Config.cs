using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace smolensk.Domain
{
    public static class Config
    {
        public static int CountMinNews
        {
            get
            {
                return !string.IsNullOrEmpty(ConfigurationManager.AppSettings["CountMinNews"])
                           ? int.Parse(ConfigurationManager.AppSettings["CountMinNews"])
                           : 3;
            }
        }
    }
}