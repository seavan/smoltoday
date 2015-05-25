using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using admin.db;
using meridian.smolensk.proto;

namespace meridian.smolensk.protoStore
{
    public partial class accountsStore : IDataService<accounts>
    {
    
        public accounts GetAccountsByLogin(string email)
        {
            return All().FirstOrDefault(a => a.email == email);
        }
    }
}
