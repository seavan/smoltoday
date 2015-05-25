using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using meridian.smolensk.proto;

namespace smolensk.Models.ViewModels.Mail
{
    public class NoResumeMailModel
    {
        public accounts User { get; set; }
        public string CompanyTitle { get; set; }
        public vacancies Vacancy { get; set; }
        
        [Required(ErrorMessage = "*", AllowEmptyStrings = false)]
        public string Theme { get; set; }
        [Required(ErrorMessage = "*", AllowEmptyStrings = false)]
        public string Message { get; set; }
    }
}