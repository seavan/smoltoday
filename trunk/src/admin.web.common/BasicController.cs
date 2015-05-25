using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Microsoft.Practices.Unity;
using admin.db;


namespace admin.web.common
{
    public class BasicController : Controller
    {
        public BasicController()
        {
            ValidateRequest = false;
        }
        [Dependency]
        public IDataStore DataStore { get; set; }
    }
}