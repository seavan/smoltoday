using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace smolensk.Models.ModelValidators.Attributes
{
    public class EMailAttribute : RegularExpressionAttribute
    {
        public EMailAttribute()
            : base("^[a-zA-Z0-9_\\+-]+(\\.[a-zA-Z0-9_\\+-]+)*@[a-zA-Z0-9-]+(\\.[a-zA-Z0-9-]+)*\\.([a-zA-Z]{2,4})$")
        {
        }

    }
}