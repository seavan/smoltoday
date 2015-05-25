using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace smolensk.common.HtmlHelpers
{
    public static class ContainerHelpers
    {
        /// <summary>
        /// Begins a container block using the specified tag.  Writes directly to the response.  Expected to be used within a using block.
        /// </summary>
        /// <param name="helper">HtmlHelper object from a View.</param>
        /// <param name="tag">The container tag (div, span, hN, etc.)</param>
        /// <returns>An MvcContainer that writes the closing tag when it is disposed.</returns>
        public static MvcContainer BeginContainer(this HtmlHelper helper, string tag)
        {
            return BeginContainer(helper, tag, null);
        }

        /// <summary>
        /// Begins a container block using the specified tag.  Writes directly to the response.  Expected to be used within a using block.
        /// </summary>
        /// <param name="helper">HtmlHelper object from a View.</param>
        /// <param name="tag">The container tag (div, span, hN, etc.)</param>
        /// <param name="htmlAttributes">HTML attribute to apply to the tag.</param>
        /// <returns>An MvcContainer that writes the closing tag when it is disposed.</returns>
        public static MvcContainer BeginContainer(this HtmlHelper helper, string tag, object htmlAttributes)
        {
            var builder = new TagBuilder(tag);

            builder.MergeAttributes(new RouteValueDictionary(htmlAttributes));

            helper.ViewContext.HttpContext.Response.Write(builder.ToString(TagRenderMode.StartTag));

            return new MvcContainer(helper.ViewContext.HttpContext.Response, tag);
        }

        /// <summary>
        /// div, содержащий элементы управления
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="_helper"></param>
        /// <param name="_expression"></param>
        /// <param name="_htmlAttributes"></param>
        /// <returns></returns>
        public static MvcContainer BeginControlHolder<TModel, TValue>(this HtmlHelper<TModel> _helper,
                                                                      Expression<Func<TModel, TValue>> _expression,
                                                                      object _htmlAttributes = null)
        {
            string fieldName = ExpressionHelper.GetExpressionText(_expression);

            var builder = new TagBuilder("div");
            // Генериреум id в виде - Idконтрола_field
            builder.Attributes["id"] = _helper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldId(fieldName) + "_field";

            builder.MergeAttributes(new RouteValueDictionary(_htmlAttributes), true);

            // если были ошибки валидации
            if (Helpers.ModelHasErrors(_helper, _expression))
            {
                builder.AddCssClass("error");
            }

            _helper.ViewContext.HttpContext.Response.Write(builder.ToString(TagRenderMode.StartTag));
            return new MvcContainer(_helper.ViewContext.HttpContext.Response, "div");
        }

        /// <summary>
        /// div, содержащий сообщения об ошибках
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="_helper"></param>
        /// <param name="_expression"></param>
        /// <param name="_htmlAttributes"></param>
        /// <returns></returns>
        public static MvcContainer BeginErrorsHolder<TModel, TValue>(this HtmlHelper<TModel> _helper,
                                                                      Expression<Func<TModel, TValue>> _expression,
                                                                      object _htmlAttributes = null)
        {
            string fieldName = ExpressionHelper.GetExpressionText(_expression);

            var builder = new TagBuilder("div");

            // Генериреум id в виде - Idконтрола_errors
            builder.Attributes["id"] = _helper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldId(fieldName) + "_errors";

            builder.MergeAttributes(new RouteValueDictionary(_htmlAttributes), true);

            // ошибки отсутствуют
            if (!Helpers.ModelHasErrors(_helper, _expression))
            {
                if (builder.Attributes.ContainsKey("style"))
                {
                    builder.Attributes["style"] += "; display: none";
                }
                else
                {
                    builder.Attributes["style"] = "display: none";
                }
            }

            _helper.ViewContext.HttpContext.Response.Write(builder.ToString(TagRenderMode.StartTag));
            return new MvcContainer(_helper.ViewContext.HttpContext.Response, "div");
        }

    }
}