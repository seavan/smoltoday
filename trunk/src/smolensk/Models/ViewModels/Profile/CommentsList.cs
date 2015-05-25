using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using meridian.smolensk.proto;
using smolensk.common;

namespace smolensk.Models.ViewModels.Profile
{
    public class CommentsList
    {
        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }
        public SortingDirection sortDirection { get; set; }
        public IEnumerable<IComment> Comments { get; set; }

        public CommentsList()
        {
            TotalPages = 1;
            CurrentPage = 1;
            sortDirection = SortingDirection.Desc;
        }
    }
}