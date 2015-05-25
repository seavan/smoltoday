using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace smolensk.common.HtmlHelpers
{
    public static class LabelHelpers
    {
        /// <summary>
        /// label, привязаный к определенному элементу модели с возможностью задавать HTML-атрибуты
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="_helper"></param>
        /// <param name="_expression"></param>
        /// <param name="_innerText"></param>
        /// <param name="_htmlAttributes"></param>
        /// <returns></returns>
        public static MvcHtmlString LabelFor<TModel, TValue>(this HtmlHelper<TModel> _helper,
                                                                   Expression<Func<TModel, TValue>> _expression,
                                                                   object _htmlAttributes = null,
                                                                   string _innerText = null)
        {
            ModelMetadata metadata = ModelMetadata.FromLambdaExpression(_expression, _helper.ViewData);
            string htmlFieldName = ExpressionHelper.GetExpressionText(_expression);

            string labelText = _innerText ?? metadata.DisplayName ?? metadata.PropertyName
                                          ?? htmlFieldName.Split('.').Last();

            if (String.IsNullOrEmpty(labelText))
            {
                return MvcHtmlString.Empty;
            }

            var tag = new TagBuilder("label");
            tag.MergeAttributes(new RouteValueDictionary(_htmlAttributes));
            if (!tag.Attributes.ContainsKey("for"))
                tag.Attributes.Add("for", _helper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldId(htmlFieldName));
            tag.SetInnerText(labelText);

            return MvcHtmlString.Create(tag.ToString(TagRenderMode.Normal));
        }

        /// <summary>
        /// Контейнерный label с возможностью задавать HTML-атрибуты
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="htmlAttributes"></param>
        /// <returns></returns>
        public static MvcContainer BeginLabel(this HtmlHelper helper, object htmlAttributes)
        {
            return helper.BeginContainer("label", htmlAttributes);
        }

        /// <summary>
        /// Контейнерный label, привязаный к определенному элементу модели с возможностью задавать HTML-атрибуты
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="_helper"></param>
        /// <param name="_expression"></param>
        /// <param name="_htmlAttributes"></param>
        /// <returns></returns>
        public static MvcContainer BeginLabelFor<TModel, TValue>(this HtmlHelper<TModel> _helper,
                                                                   Expression<Func<TModel, TValue>> _expression,
                                                                   object _htmlAttributes = null,
                                                                   InsertAt _insertion = InsertAt.End,
                                                                   string _caption = null)
        {
            ModelMetadata metadata = ModelMetadata.FromLambdaExpression(_expression, _helper.ViewData);
            string htmlFieldName = ExpressionHelper.GetExpressionText(_expression);

            string labelText = _caption ?? metadata.DisplayName ?? metadata.PropertyName ?? htmlFieldName.Split('.').Last();

            var tag = new TagBuilder("label");
            tag.MergeAttributes(new RouteValueDictionary(_htmlAttributes));

            tag.Attributes.Add("for", _helper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldId(htmlFieldName));

            _helper.ViewContext.HttpContext.Response.Write(tag.ToString(TagRenderMode.StartTag));
            return new MvcContainer(_helper.ViewContext.HttpContext.Response, "label", labelText, _insertion);
        }
    }
}