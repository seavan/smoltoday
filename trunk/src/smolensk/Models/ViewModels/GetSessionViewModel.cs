using System.ComponentModel.DataAnnotations;
using meridian.smolensk.proto;

namespace smolensk.Models.ViewModels
{
    public class GetSessionViewModel
    {
        public accounts Photographer { get; set; }
        [Display(Name="Электронная почта")]
        public string Email { get; set; }
        [Display(Name = "Телефон")]
        public string Phone { get; set; }
        [Display(Name = "Комментарий")]
        [Required]
        public string Text { get; set; }
    }
}