using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using meridian.smolensk.proto;
using admin.web.common;
using admin.db;
using meridian.smolensk.system;

namespace smolensk.Controllers
{
    public class AccountsAdminController : BaseUniversalController<accounts>
    {
        protected override IDataService<accounts> GetService()
        {
            return Meridian.Default.accountsStore;
        }
    }
}