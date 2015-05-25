using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace smolensk.common.HtmlHelpers
{
    public static class Helpers
    {
        /// <summary>
        /// Проверяет наличие ошибок валидации в модели
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="_helper"></param>
        /// <param name="_expression"></param>
        /// <returns></returns>
        internal static bool ModelHasErrors<TModel, TValue>(HtmlHelper<TModel> _helper,
                                                            Expression<Func<TModel, TValue>> _expression)
        {
            string fieldName = ExpressionHelper.GetExpressionText(_expression);
            string modelName = _helper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(fieldName);

            ModelState modelState = _helper.ViewData.ModelState[modelName];

            ModelErrorCollection modelErrors = (modelState == null) ? null : modelState.Errors;

            // если были ошибки валидации
            return ((modelErrors != null) && (modelErrors.Count > 0));
        }

        /// <summary>
        /// Читает описание енума из атрибута Description, если он есть. Атрибут DisplayName к элементам
        /// енума, к сожалению, не применим.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string GetDescription(this Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes =
                  (DescriptionAttribute[])fi.GetCustomAttributes(
                  typeof(DescriptionAttribute), false);

            return (attributes.Length > 0) ? attributes[0].Description : value.ToString();
        }

        /// <summary>
        /// Получить идентификатор контрола, связанного с элементом модели
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="_helper"></param>
        /// <param name="_expression"></param>
        /// <returns></returns>
        public static string IdFor<TModel, TValue>(this HtmlHelper<TModel> _helper,
                                                                   Expression<Func<TModel, TValue>> _expression)
        {
            string htmlFieldName = ExpressionHelper.GetExpressionText(_expression);
            return _helper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldId(htmlFieldName);
        }


        public static List<SelectListItem> TrueFalseListForSelection<TModel>(this HtmlHelper<TModel> _helper, string falseText = "Нет", string trueText = "Да")
        {
            return new List<SelectListItem>()
                       {
                           new SelectListItem() {Value = "False", Text = falseText},
                           new SelectListItem() {Value = "True", Text = trueText}
                       };
        }
    }
}