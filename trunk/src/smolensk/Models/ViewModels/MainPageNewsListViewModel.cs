using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CuttingEdge.Conditions;

namespace smolensk.ViewModels
{
    public class MainPageNewsListViewModel
    {
        public MainPageNewsListViewModel(NewsListViewModel model, int itemIndex)
        {
            Condition.Requires(model, "model").IsNotNull();

            NewsList = model;
            CurrentItemIndex = itemIndex;
        }

        public NewsListViewModel NewsList { get; set; }
        public int CurrentItemIndex { get; set; }
    }
}