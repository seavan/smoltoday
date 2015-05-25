using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using meridian.smolensk.system;

namespace smolensk.Models.ModelValidators.Attributes
{
    public class UniqueEMailAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            string eMail = value != null ? value.ToString() : String.Empty;

            if (String.IsNullOrEmpty(eMail))
            {
                return true;
            }

            return !Meridian.Default.accountsStore.All().Any(ac => ac.email == eMail);
        }
    }
}