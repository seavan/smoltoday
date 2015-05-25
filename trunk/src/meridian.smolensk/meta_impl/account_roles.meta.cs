using System.ComponentModel.DataAnnotations;

namespace meridian.smolensk.proto
{
    internal class account_roles_meta
    {
        [Editable(false)]
        public long id { get; set; }

        [Display(Name = "Наименование")]
        public string name { get; set; }
    }
}