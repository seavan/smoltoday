using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using smolensk.ViewModels;

namespace smolensk.Models.ViewModels
{
    public class QuizOptionViewModel : EntityBaseViewModel
    {
        public QuizOptionViewModel(long id) : base(id) { }

        public string Value { get; set; }
    }
}