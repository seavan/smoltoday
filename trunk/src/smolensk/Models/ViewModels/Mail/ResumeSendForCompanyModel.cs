using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using meridian.smolensk.proto;

namespace smolensk.Models.ViewModels.Mail
{
    public class ResumeSendForCompanyModel
    {
        public accounts User { get; set; }
        public companies Company { get; set; }
        public IList<ResumeViewModel> Resume { get; set; }
        public long ResumeId { get; set; }
    }
}