using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using meridian.smolensk.proto;
using meridian.smolensk.system;

namespace smolensk.Mappers
{
    public static class CommentsMapper
    {
        public static string GetCommentTitle(this IComment comment)
        {
            companies company = Meridian.Default.companiesStore.Get(comment.MaterialId);

            return company.title;
        }
    }
}