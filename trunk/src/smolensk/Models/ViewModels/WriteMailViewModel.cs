using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace smolensk.Models.ViewModels
{
    public class WriteMailViewModel
    {
        public long CompanyId { get; set; }
        public string Theme { get; set; }
        public string Message { get; set; }
    }
}