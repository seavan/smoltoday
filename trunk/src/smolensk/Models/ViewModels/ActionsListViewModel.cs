using System.Collections.Generic;
using smolensk.common;
using smolensk.Mappers;
using DateRange = smolensk.Models.CodeModels.DateRange;

namespace smolensk.Models.ViewModels
{
    public class ActionsListViewModel 
    {
        public ActionCategoryViewModel Category { get; set; }
        public IEnumerable<ActionViewModel> Actions { get; set; }

        public string RouteName { get; set; }

        public ActionDateFilterType? DateFilter { get; set; }
        public DateRange Date { get; set; }

        public ActionSortingType? Sorting { get; set; }
        public SortingDirection sortingDirection { get; set; }

        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }

        public string DateTitle
        {
            get
            {
                return !DateFilter.HasValue ? Date.ToString() : string.Empty;
            }
        }
    }
}