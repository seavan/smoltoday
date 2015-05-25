using System.Collections.Generic;
using smolensk.common;
using smolensk.Mappers;

namespace smolensk.Models.ViewModels
{
    public class PlacesListViewModel
    {
        public ActionCategoryViewModel Category { get; set; }
        public IEnumerable<PlaceViewModel> Places { get; set; }

        public smolensk.Models.CodeModels.DateRange Date { get; set; }
        public PlaceSortingType? Sorting { get; set; }
        public SortingDirection sortingDirection { get; set; }
    }
}