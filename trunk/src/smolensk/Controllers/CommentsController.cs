using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using meridian.smolensk.proto;
using smolensk.Models.ModelValidators.Attributes;
using smolensk.Services;
using smolensk.Models.CodeModels;

namespace smolensk.Controllers
{
    public class CommentsController : BaseController
    {
        [HttpPost]
        [Authorize403]
        public ActionResult AddComment(Comment comment)
        {
            comment.CommentText = comment.CommentText.Length > 300 ? comment.CommentText.Substring(0, 300) : comment.CommentText;
            comment.CommentText = comment.CommentText.Replace("\n", "<br/>");
            comment.AuthorId = HttpContext.UserPrincipal().id;
            
            return View("CommentOne", meridian.GetAs<ICommentable>(comment.ProtoName, comment.MaterialId).AddComment(comment));
        }

    }
}
