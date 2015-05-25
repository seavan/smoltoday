using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using meridian.smolensk.proto;
using smolensk.Models.ViewModels;
using meridian.smolensk.system;

namespace smolensk.Mappers
{
    public static class QuizMapper
    {
        public static QuizViewModel ToModel(this quizzes q, long account_id = 0)
        {
            var selected = q.GetSelectedOption(account_id);
            return new QuizViewModel(q.id)
            {
                Title = q.title,
                Start = q.datetime_start,
                Finish = q.datetime_finish,
                Options = Meridian.Default.quiz_optionsStore.All()
                                        .Where(o => o.quiz_id == q.id)
                                        .OrderBy(o => o.order)
                                        .Select(o => o.ToModel()),
                SelectedOption = selected != null ? selected.id: 0
            };
        }

        public static QuizOptionViewModel ToModel(this quiz_options qo)
        {
            return new QuizOptionViewModel(qo.id)
            { 
                Value = qo.value
            };
        }

        public static QuizViewModel GetCurrentQuiz(this Meridian m, long accountId = 0)
        {
            var quiz = m.quizzesStore.GetCurrent();
            if (quiz != null)
                return quiz.ToModel(accountId);
            return null;
        }
    }
}