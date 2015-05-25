using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace smolensk.Models.ViewModels
{
    public class InformerViewModel
    {
        public int JamsDegree { get; set; }
        public string JamsDescription { get; set; }

        public decimal EuroPrice { get; set; }
        public decimal EuroChange { get; set; }

        public decimal DollarPrice { get; set; }
        public decimal DollarChange { get; set; }
    }
}