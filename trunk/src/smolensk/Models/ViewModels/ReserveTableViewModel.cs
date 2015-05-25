using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace smolensk.Models.ViewModels
{
    public class ReserveTableViewModel
    {
        public long RestaurantId { get; set; }
        public string RestaurantTitle { get; set; }

        public DateTime Date { get; set; }

        public int Persons { get; set; }

        [Required(ErrorMessage = "*", AllowEmptyStrings = false)]
        public string Phone { get; set; }

        [Required(ErrorMessage = "*", AllowEmptyStrings = false)]
        public string ContactName { get; set; }
    }
}