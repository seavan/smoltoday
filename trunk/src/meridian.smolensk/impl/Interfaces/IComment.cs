using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace meridian.smolensk.proto
{
    public interface IComment
    {
        int LeftKey { get; set; }
        int RightKey { get; set; }
        int level { get; set; }
        string CommentText { get; set; }
        DateTime CreateDate { get; set; }
        long MaterialId { get; set; }
        string MaterialProtoName { get;  }
        long AuthorId { get; set; }
        long id { get; set; }
        long ParentId { get; set; }
        bool delete { get; set; }

        string ProtoName { get; }
        bool isReview { get; }

        accounts GetUser();
        IComment GetParentComment();

        Uri Link { get;}
    }
}
