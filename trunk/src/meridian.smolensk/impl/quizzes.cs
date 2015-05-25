using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using meridian.smolensk.system;

namespace meridian.smolensk.proto
{
    public partial class quizzes
    {
        public quiz_options GetSelectedOption(long userId)
        {
            var qo_store = Meridian.Default.quiz_optionsStore;
            return Meridian.Default.quiz_resultsStore.All()
                .Where(r => r.quiz_id == id && r.account_id == userId && qo_store.Exists(r.quiz_option_id))
                .Select(r => qo_store.Get(r.quiz_option_id)).FirstOrDefault();
        }
    }
}
