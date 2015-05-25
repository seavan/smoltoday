using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using admin.db;
using meridian.smolensk;
using meridian.smolensk.system;

namespace meridian.smolensk.proto
{
    public partial class comments_news : IDatabaseEntity, IComment
	{

        public int LeftKey
		{
			get
			{
                return left_key;
			}
			set
			{
                left_key = value != null ? value : 0;
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
                right_key = value != null ? value : 0;
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
                create_date = value != null ? value : DateTime.MinValue;
                if (create_date.Year < 1800) value = DateTime.MinValue;
			}
		}

        public string NewsTitle
        {
            get { var news = GetNewsCommentsNew();
                return news != null ? news.title : "n/a";
            }
            
        }

        public string AuthorName
        {
            get { var user = GetUser();
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
                account_id = value != null ? value : 0;
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
                parent_id = value != null ? value : 0;
			}
		}
        public long MaterialId
		{
			get
			{
                return news_id;
			}
			set
			{
                news_id = value != null ? value : 0;
			}
		}

        public accounts GetUser()
        {
            return this.GetNewsCommentsAccount();
        }

        public IComment GetParentComment()
        {
            return this.GetChildCommentsComments_new();

        }

        public bool isReview { get { return false; } }


        public string MaterialProtoName
        {
            get { return this.n_comments_news != null ? this.n_comments_news.ProtoName : null; }
        }

        public Uri Link
        {
            get
            {
                return n_comments_news != null
                           ? new Uri(string.Format("{0}#comment_{1}", n_comments_news.ItemUri(), this.id), UriKind.Relative)
                           : null;
            }
        }
    }
}
