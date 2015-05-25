using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using meridian.smolensk.proto;
using smolensk.Models.CodeModels;
using smolensk.Models.ModelValidators.Attributes;
using smolensk.Services;

namespace smolensk.Controllers
{
    public class MarksController : BaseController
    {
        [HttpPost]
        [Authorize403]
        public void SetMark(Mark mark)
        {
            mark.AuthorId = HttpContext.UserPrincipal().id;
            meridian.GetAs<IMarkable>(mark.ProtoName, mark.MaterialId).SetMark(mark);
        }

    }
}
