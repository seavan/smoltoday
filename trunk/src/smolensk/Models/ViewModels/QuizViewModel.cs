using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using smolensk.ViewModels;

namespace smolensk.Models.ViewModels
{
    public class QuizViewModel : EntityBaseViewModel
    {
        public QuizViewModel(long id) : base(id)  { }

        public string Title { get; set; }
        public DateTime Start { get; set; }
        public DateTime Finish { get; set; }

        public IEnumerable<QuizOptionViewModel> Options { get; set; }

        /// <summary> выбор текущего пользователя
        /// </summary>
        public long SelectedOption { get; set; }

        public bool VoteAvailable
        {
            get
            { 
                var now = DateTime.Now;
                return now >= Start && now < Finish;
            }
        }
    }
}