using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using meridian.smolensk.proto;
using smolensk.common;

namespace smolensk.Models.ViewModels.Profile
{
    public class MessagesList
    {
        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }
        public SortingDirection sortDirection { get; set; }
        public IEnumerable<my_messages> Messages { get; set; }

        public MessagesList()
        {
            TotalPages = 1;
            CurrentPage = 1;
            sortDirection = SortingDirection.Desc;
        }
    }
}