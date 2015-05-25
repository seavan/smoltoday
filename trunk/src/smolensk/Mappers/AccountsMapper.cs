using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using smolensk.Models.ViewModels;
using meridian.smolensk.system;
using meridian.smolensk.proto;
using smolensk.common;

namespace smolensk.Mappers
{
    public static class AccountsMapper
    {
        public static IEnumerable<AccountViewModel> GetModerators(this Meridian meridian)
        {
            return GetAccountsByType(meridian, SmolenskRoles.Moderator);
        }


        public static IEnumerable<AccountViewModel> GetAccountsByType(this Meridian meridian, SmolenskRoles role)
        {
            return meridian.accountsStore.All()
                .Where(r => r.role_id == (long)role)
                .Select(r => r.ToAccount());
        }

        public static AccountViewModel ToAccount(this accounts acc)
        {
            return new AccountViewModel(acc.id)
                       {
                           Email = acc.email,
                           FirstName = acc.firstname,
                           LastName = acc.lastname,
                       };
        }
    }
}