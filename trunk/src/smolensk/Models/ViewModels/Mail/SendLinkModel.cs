using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace smolensk.Models.ViewModels.Mail
{
    public class SendLinkModel
    {
        public SendLinkModel()
        {
        }

        public SendLinkModel(string link)
        {
            this.Link = link;
        }

        public string Link { get; set; }
    }
}