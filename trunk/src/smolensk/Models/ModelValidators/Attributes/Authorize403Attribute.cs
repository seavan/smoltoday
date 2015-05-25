using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace smolensk.Models.ModelValidators.Attributes
{
    public class Authorize403Attribute : AuthorizeAttribute
    {
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            throw new HttpException(403, "Forbidden");
        }
    }
}