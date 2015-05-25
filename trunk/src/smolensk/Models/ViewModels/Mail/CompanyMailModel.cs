using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using meridian.smolensk.proto;

namespace smolensk.Models.ViewModels.Mail
{
    public class CompanyMailModel
    {
        public accounts User { get; set; }
        public companies Company { get; set; }
        public string Theme { get; set; }
        public string Message { get; set; }
    }
}