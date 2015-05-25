using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using smolensk.ViewModels;

namespace smolensk.Models.ViewModels
{
    public class AccountViewModel : EntityBaseViewModel
    {
        public AccountViewModel(long id) : base(id)
        {

        }

        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}