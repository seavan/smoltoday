using admin.db;
using smolensk.ViewModels;

namespace smolensk.Models.ViewModels
{
    public class StaticPageViewModel : EntityBaseViewModel
    {
        public StaticPageViewModel(IDatabaseEntity page) : base(page)
        {
            
        }

        public string Title { get; set; }
        public string Content { get; set; }
    }
}