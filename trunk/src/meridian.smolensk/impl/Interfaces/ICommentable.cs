using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace meridian.smolensk.proto
{
    public interface ICommentable
    {
        IEnumerable<IComment> GetComments();
        IComment AddComment(IComment comment);
        void DeleteComment(long id);
        string ProtoName { get; }
        long id { get; }
        bool isReview { get; }
        bool can_comment { get; }
    }
}
