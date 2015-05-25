using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using smolensk.Models.ViewModels;

namespace smolensk.Extensions
{
    public static class HtmlHelperExtensions
    {
        public static MvcHtmlString SimpleCheckBox(this HtmlHelper htmlHelper,
            string name, object value = null, bool selected = false, object htmlAttributes = null)
        {
            var input = new TagBuilder("input");
            input.Attributes.Add("type", "checkbox");
            input.Attributes.Add("name", name);

            if (value != null)
            {
                input.Attributes.Add("value", value.ToString());
            }

            if (selected)
            {
                input.Attributes.Add("checked", "checked");
            }

            if (htmlAttributes != null)
            {
                input.MergeAttributes(new RouteValueDictionary(htmlAttributes), true);
            }

            return MvcHtmlString.Create(input.ToString());
        }

        //public static MvcHtmlString PrintProfessionals(this HtmlHelper htmlHelper, IEnumerable<VacancyProfessionalViewModel> skills, string separator = "/")
        //{
        //    var sb = new StringBuilder();
        //    foreach (var root in skills)
        //    {
        //        sb.Append()
        //        for (int i = 0; i < root.Children.Count; i++)
        //        {
                    
        //        }
        //    }
        //}
    }
}