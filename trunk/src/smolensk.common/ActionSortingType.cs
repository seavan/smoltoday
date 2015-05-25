using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace smolensk.common
{
    public enum SortingDirection
    {
        Desc,
        Asc
    }

    public enum ActionSortingType
    {
        New,
        Alphabet,
        AgeLimit,
        Genre,
        Place,
        Time
    }

    public enum PlaceSortingType
    {
        Title,
        Adress
    }
}
