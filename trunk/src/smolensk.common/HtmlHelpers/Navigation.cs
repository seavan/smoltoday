using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.UI;

namespace smolensk.common.HtmlHelpers
{
    public static class Navigation
    {
        /// <summary>Кнопка для переключения типа фильтра/сортировки
        /// </summary>
        public static MvcHtmlString FilterTypeSelectorLink<T>(this HtmlHelper helper, T? current, T expected, 
                                                              string routeName, object routeValues, string sortingKeyName,
                                                              string caption = null, string selector = null, bool isAjax = false) where T : struct
        {
            // TODO: Есть ли способ сделать это без boxing/unboxing?
            var expectedValue = (Enum)(object)expected;
            caption = String.IsNullOrEmpty(caption) ? expectedValue.GetDescription() : caption;

            var liBuilder = new TagBuilder("li");
            var aBuilder = new TagBuilder("a");
            var spanBuilder = new TagBuilder("span");
            spanBuilder.InnerHtml = caption;
            aBuilder.Attributes["title"] = caption;

            var urlHelper = new UrlHelper(helper.ViewContext.RequestContext);

            var routes = routeValues as RouteValueDictionary ?? new RouteValueDictionary(routeValues);
            routes[sortingKeyName] = expected;
            var url = urlHelper.RouteUrl(routeName, routes);

            if (current.HasValue && Convert.ToInt32(expected) == Convert.ToInt32(current.Value))
                aBuilder.AddCssClass("cur");
            else
                aBuilder.Attributes["href"] = !isAjax ? url : string.Format("javascript:updateBlock('{0}','{1}')", selector, url);

            aBuilder.InnerHtml = spanBuilder.ToString(TagRenderMode.Normal);
            liBuilder.InnerHtml = aBuilder.ToString(TagRenderMode.Normal);

            return MvcHtmlString.Create(liBuilder.ToString(TagRenderMode.Normal));
        }

        /// <summary>Сортиуемая колонка
        /// </summary>
        public static MvcHtmlString SortingColumn<T>(this HtmlHelper helper, T? current, T expected, SortingDirection dir,
                                                     string routeName, object routeValues, string sortingKeyName, string sortingDirKeyName,
                                                     string caption = null, string selector = null) where T : struct
        {
            // TODO: Есть ли способ сделать это без boxing/unboxing?
            var expectedValue = (Enum)(object)expected;
            caption = String.IsNullOrEmpty(caption) ? expectedValue.GetDescription() : caption;

            var thBuilder = new TagBuilder("th");
            var spanBuilder = new TagBuilder("span");
            spanBuilder.InnerHtml = caption;

            var isCurrent = current.HasValue && Convert.ToInt32(expected) == Convert.ToInt32(current.Value);
            var urlHelper = new UrlHelper(helper.ViewContext.RequestContext);

            var routes = new RouteValueDictionary(routeValues);
            routes[sortingKeyName] = expected;
            routes[sortingDirKeyName] = isCurrent && dir == SortingDirection.Asc ? SortingDirection.Desc : SortingDirection.Asc;
            var url = urlHelper.RouteUrl(routeName, routes);

            if (isCurrent)
            {
                thBuilder.AddCssClass("cur");
                thBuilder.AddCssClass(dir == SortingDirection.Asc ? "down" : "up");
            }
            thBuilder.Attributes["onclick"] = string.Format("javascript:updateBlock('{0}','{1}')", selector, url);

            thBuilder.InnerHtml = spanBuilder.ToString(TagRenderMode.Normal);

            return MvcHtmlString.Create(thBuilder.ToString(TagRenderMode.Normal));
        }

        /// <summary>выпадающий спивок для переключения типа фильтра/сортировки
        /// </summary>
        public static MvcHtmlString FilterTypeSelector<T>(this HtmlHelper helper, T? current, IEnumerable<T> expectedList, 
                                                     string routeName, object routeValues, string sortingKeyName,
                                                     IEnumerable<string> captionList = null) where T : struct
        {
            var urlHelper = new UrlHelper(helper.ViewContext.RequestContext);
            var routes = new RouteValueDictionary(routeValues);
            routes.Remove(sortingKeyName);
            var url = urlHelper.RouteUrl(routeName, routes);

            var formBuilder = new TagBuilder("form");
            formBuilder.Attributes["action"] = url;

            var selectBuilder = new TagBuilder("select");           
            selectBuilder.Attributes["id"] = sortingKeyName;
            selectBuilder.Attributes["name"] = sortingKeyName;
            selectBuilder.Attributes["onchange"] = "javascript:submit();";

            var i = 0;
            foreach (var expected in expectedList)
            {
                var expectedValue = (Enum)(object)expected;
                var caption = captionList == null || String.IsNullOrEmpty(captionList.ElementAt(i)) ? 
                    expectedValue.GetDescription() : captionList.ElementAt(i);
                i++;

                var optionBuilder = new TagBuilder("option");
                optionBuilder.InnerHtml = caption;
                optionBuilder.Attributes["value"] = expected.ToString();

                //routes[sortingKeyName] = expected;
                //var url = urlHelper.RouteUrl(routeName, routes);

                if (current.HasValue && Convert.ToInt32(expected) == Convert.ToInt32(current.Value))
                    optionBuilder.Attributes["selected"] = "selected";
                //else
                //    optionBuilder.Attributes["onclick"] =  string.Format("javascript:window.location = '{0}'", url);

                selectBuilder.InnerHtml += optionBuilder.ToString(TagRenderMode.Normal);
            }
            formBuilder.InnerHtml = selectBuilder.ToString(TagRenderMode.Normal);
            return MvcHtmlString.Create(formBuilder.ToString(TagRenderMode.Normal));
        }
    }
}
