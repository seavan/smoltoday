using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using smolensk.Models.ModelValidators.Attributes;
using smolensk.Services;
using meridian.smolensk.system;
using smolensk.Mappers;
using meridian.smolensk.proto;

namespace smolensk.Controllers
{
    public class QuizController : BaseController
    {
        public ActionResult Current()
        {
            var currentUser = HttpContext.UserPrincipal();
            var model = Meridian.Default.GetCurrentQuiz(currentUser != null ? currentUser.id : 0);
            return View(model);
        }

        [HttpPost]
        [Authorize403]
        public ActionResult Vote(long quiz, long option)
        {
            var currentUser = HttpContext.UserPrincipal();
            if (Meridian.Default.quizzesStore.Exists(quiz) && Meridian.Default.quiz_optionsStore.Exists(option))
                Meridian.Default.quiz_resultsStore.Insert(new quiz_results
                {
                    account_id = currentUser.id, 
                    quiz_id = quiz, 
                    quiz_option_id = option
                });
            return View("Index");
        }
    }
}
