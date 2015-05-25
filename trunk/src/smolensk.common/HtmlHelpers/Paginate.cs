using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace smolensk.common.HtmlHelpers
{
    public static class Paginate
    {
        /// <summary>
        /// Максимальное количество ссылок на страницы
        /// </summary>
        //private readonly int MAX_PAGES = 7;

        public static MvcHtmlString Pager(this HtmlHelper helper, int currentPage, int pagesCount, string routeName,
                                          object routeValues, string pageKeyName, int maxPages = 7, int round = 3)
        {
            // 1 или 0 страниц - ничего не рисуем
            if (pagesCount < 2) return null;

            var container = new TagBuilder("div");
            container.AddCssClass("pager");

            var urlHelper = new UrlHelper(helper.ViewContext.RequestContext);

            var innerContainterHtml = new StringBuilder();

            var routes = new RouteValueDictionary(routeValues);
            var tempSRoute = new Dictionary<string, List<string>>();
            var tRoute = new RouteValueDictionary();
            foreach (var route in routes.Keys)
            {
                if (routes[route] is IEnumerable<string>)
                {
                    //routes[route] = new List<string>();
                    tempSRoute.Add(route, routes[route] as List<string>);
                }
                else
                {
                    tRoute.Add(route, routes[route]);
                }
            }
            routes = tRoute;

            //Всегда рисуем первую страницу
            TagBuilder page1 = new TagBuilder("a");
            page1.AddCssClass("button");
            if (currentPage == 1)
            {
                page1.AddCssClass("cur");
                page1.Attributes.Add("href","#");
                page1.InnerHtml = String.Format("{0}", currentPage);
            }
            else
            {
                routes[pageKeyName] = 1;
                string url = urlHelper.RouteUrl(routeName, routes);
                int counterR = 0;
                foreach (var rr in tempSRoute.Keys)
                {
                    counterR = 0;
                    foreach (var el in tempSRoute[rr])
                    {
                        url += "&" + rr + "[" + counterR + "]=" + el;
                        ++counterR;
                    }
                }
                page1.Attributes.Add("href", url);
                page1.InnerHtml = String.Format("{0}", 1);
            }
            innerContainterHtml.Append(page1.ToString(TagRenderMode.Normal));

            int con = 0;
            int count = 0;

            //Высчитываем количество элементов в общем списке
            //Рисуем, если надо, пропуски в списке страниц
            if (pagesCount == maxPages)
            {
                con = 2;
                count = pagesCount - 1;
            }
            else if (currentPage < maxPages)
            {
                con = 2;
                if ((currentPage + round) >= pagesCount || pagesCount == (maxPages - 1))
                {
                    count = pagesCount - 1;
                }
                else
                {
                    if (pagesCount >= (maxPages + 1))
                    {
                        count = maxPages; // _currentPage + ROUND;
                    }
                    else
                    {
                        count = currentPage + round;
                    }
                }
            }
            else if (currentPage <= (pagesCount - (maxPages - 1)))
            {
                con = currentPage - round > 2 ? currentPage - round : 2;
                count = currentPage + round;
                if (currentPage - round > 2)
                    innerContainterHtml.Append("<a class=\"button\" href='#'>...</a>");
            }
            else
            {
                if (currentPage + (maxPages - 1) > pagesCount)
                {
                    con = pagesCount - (maxPages - 1);
                }
                //con = _currentPage - ROUND;
                count = pagesCount - 1;
                if (con > 2)
                    innerContainterHtml.Append("<a class=\"button\" href='#'>...</a>");
            }

            //Рисуем основную часть списка
            int j = 0;
            for (j = con; j <= count; j++)
            {
                TagBuilder page = new TagBuilder("a");
                page.AddCssClass("button");
                if (j == currentPage)
                {
                    page.AddCssClass("cur");
                    page.InnerHtml = String.Format("{0}", j);
                }
                else
                {
                    //RouteValueDictionary routes = new RouteValueDictionary(_routeValues);
                    routes[pageKeyName] = j;
                    string url = urlHelper.RouteUrl(routeName, routes);
                    int counterR = 0;
                    foreach (var rr in tempSRoute.Keys)
                    {
                        counterR = 0;
                        foreach (var el in tempSRoute[rr])
                        {
                            url += "&" + rr + "[" + counterR + "]=" + el;
                            ++counterR;
                        }
                    }
                    page.Attributes.Add("href", url);
                    page.InnerHtml = String.Format("{0}", j);
                }
                innerContainterHtml.Append(page.ToString(TagRenderMode.Normal));
            }

            //Если надо, рисуем пропуск в списке
            if ((currentPage <= (pagesCount - (maxPages - 1)) || currentPage + round == pagesCount - 2) && (pagesCount != (maxPages - 1) && pagesCount != maxPages) && (count + 1 != pagesCount))
            {
                innerContainterHtml.Append("<a class=\"button\" url='#'>...</a>");
            }


            //Всегда рисуем последнюю страницу
            TagBuilder pageLast = new TagBuilder("a");
            pageLast.AddCssClass("button");
            if (currentPage == pagesCount)
            {
                pageLast.AddCssClass("cur");
                pageLast.InnerHtml = String.Format("{0}", pagesCount);
            }
            else
            {
                //RouteValueDictionary routes = new RouteValueDictionary(_routeValues);
                routes[pageKeyName] = pagesCount;
                string url = urlHelper.RouteUrl(routeName, routes);
                int counterR = 0;
                foreach (var rr in tempSRoute.Keys)
                {
                    counterR = 0;
                    foreach (var el in tempSRoute[rr])
                    {
                        url += "&" + rr + "[" + counterR + "]=" + el;
                        ++counterR;
                    }
                }
                pageLast.Attributes.Add("href", url);
                pageLast.InnerHtml = String.Format("{0}", pagesCount);
            }
            innerContainterHtml.Append(pageLast.ToString(TagRenderMode.Normal));
            
            container.InnerHtml = innerContainterHtml.ToString();

            return MvcHtmlString.Create(container.ToString(TagRenderMode.Normal));
        }
    }
}