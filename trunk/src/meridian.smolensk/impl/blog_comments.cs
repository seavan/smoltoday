using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using MySql.Data.MySqlClient;
using meridian.smolensk;
using meridian.smolensk.system;
using admin.db;

namespace meridian.smolensk.proto
{
    public partial class blog_comments : IDatabaseEntity, IComment
	{
        public int LeftKey
        {
            get
            {
                return left_key;
            }
            set
            {
                left_key = value;
            }
        }

        public int RightKey
        {
            get
            {
                return right_key;
            }
            set
            {
                right_key = value;
            }
        }

        public DateTime CreateDate
        {
            get
            {
                return create_date;
            }
            set
            {
                create_date = value;
                if (create_date.Year < 1800) 
                    value = DateTime.MinValue;
            }
        }

        public string BlogTitle
        {
            get
            {
                var blog = this.GetBlogCommentsBlog();
                return blog != null ? blog.title : "n/a";
            }

        }

        public string AuthorName
        {
            get
            {
                var user = GetUser();
                return user != null ? user.NameAndSurname : "n/a";
            }
        }

        public long AuthorId
        {
            get
            {
                return account_id;
            }
            set
            {
                account_id = value;
            }
        }

        public string CommentText
        {
            get
            {
                return text;
            }
            set
            {
                text = value != null ? value : "";
            }
        }

        public long ParentId
        {
            get
            {
                return parent_id;
            }
            set
            {
                parent_id = value;
            }
        }

        public long MaterialId
        {
            get
            {
                return blog_id;
            }
            set
            {
                blog_id = value;
            }
        }

        public accounts GetUser()
        {
            return this.GetBlogCommentsAccount();
        }

        public IComment GetParentComment()
        {
            return this.GetBlogChildCommentsBlog_comment();

        }

        public bool isReview { get { return false; } }


        public string MaterialProtoName
        {
            get { return b_comments_blogs != null ? b_comments_blogs.ProtoName : null; }
        }

        public Uri Link
        {
            get
            {
                return b_comments_blogs != null
                           ? new Uri(string.Format("{0}#comment_{1}", b_comments_blogs.ItemUri(), this.id), UriKind.Relative)
                           : null;
            }
        }
    }
}
