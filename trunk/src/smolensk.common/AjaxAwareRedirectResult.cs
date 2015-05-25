using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace smolensk.common
{
    public class AjaxAwareRedirectResult : RedirectResult
    {
        public AjaxAwareRedirectResult(string url)
            : base(url)
        {
        }

        public override void ExecuteResult(ControllerContext context)
        {
            if (context.RequestContext.HttpContext.Request.IsAjaxRequest())
            {
                string destinationUrl = UrlHelper.GenerateContentUrl(Url, context.HttpContext);

                JavaScriptResult result = new JavaScriptResult()
                {
                    Script = "window.location='" + destinationUrl + "';"
                };
                result.ExecuteResult(context);
            }
            else
                base.ExecuteResult(context);
        }
    }

    public class AjaxAwareAuthRedirectResult : RedirectResult
    {
        public AjaxAwareAuthRedirectResult(string url)
            : base(url)
        {
        }

        public override void ExecuteResult(ControllerContext context)
        {
            //if (context.RequestContext.HttpContext.Request.IsAjaxRequest())
            //{
                string destinationUrl = UrlHelper.GenerateContentUrl(Url, context.HttpContext);

                //JavaScriptResult result = new JavaScriptResult()
                //{
                //    Script = String.Format("<ajaxScript>window.authRedirect ? window.authRedirect('{0}') : window.location='{0}';</ajaxScript>", destinationUrl)
                //};
                //result.ExecuteResult(context);

            ContentResult result = new ContentResult();
            result.Content = HttpUtility.HtmlEncode(String.Format("<ajaxScript>window.location='{0}'</ajaxScript>", destinationUrl));
            result.ExecuteResult(context);
            //}
            //else
            //    base.ExecuteResult(context);
        }
    }
}