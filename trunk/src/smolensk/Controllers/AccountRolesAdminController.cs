using admin.db;
using admin.web.common;
using meridian.smolensk.proto;
using meridian.smolensk.system;
using System.Linq;

namespace smolensk.Controllers
{
    public class AccountRolesAdminController : BaseUniversalController<account_roles>
    {
        protected override IDataService<account_roles> GetService()
        {
            return Meridian.Default.account_rolesStore;
        }
    }
}