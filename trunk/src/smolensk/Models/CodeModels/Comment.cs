using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using meridian.smolensk.proto;
using meridian.smolensk.system;

namespace smolensk.Models.CodeModels
{
    public class Comment : IComment
    {
        public int LeftKey { get; set; }
        public int RightKey { get; set; }
        public int level { get; set; }
        public string CommentText { get; set; }
        public DateTime CreateDate { get; set; }
        public long MaterialId { get; set; }
        public long AuthorId { get; set; }
        public long id { get; set; }
        public long ParentId { get; set; }
        public bool delete { get; set; }
        public string MaterialProtoName { get; set; }
        public Uri Link { get; set; }

        public accounts GetUser()
        {
            return Meridian.Default.accountsStore.GetById(AuthorId);
        }

        public virtual IComment GetParentComment()
        {
            return null;
        }

        public string ProtoName { get; set; }
        public bool isReview { get; set; }

        public Comment()
        {
            CreateDate = DateTime.Now;
            LeftKey = 0;
            RightKey = 0;
            level = 0;
            delete = false;
        }
    }
}