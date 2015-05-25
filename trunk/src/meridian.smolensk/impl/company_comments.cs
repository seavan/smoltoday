using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using meridian.smolensk;
using meridian.smolensk.system;
using admin.db;

namespace meridian.smolensk.proto
{
    public partial class company_comments : IDatabaseEntity, IComment
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
                return company_id;
            }
            set
            {
                company_id = value != null ? value : 0;
            }
        }

        public accounts GetUser()
        {
            try
            {
                return Meridian.Default.accountsStore.GetById(this.account_id);
            }
            catch (Exception)
            {

                return null;
            }

        }

        public IComment GetParentComment()
        {
            try
            {
                return Meridian.Default.company_commentsStore.GetById(this.parent_id);

            }
            catch (Exception)
            {

                return null;
            }

        }


        public bool isReview { get { return true; } }

        public string MaterialProtoName
        {
            get { return this.co_comments_companies != null ? this.co_comments_companies.ProtoName : null; }
        }

        public string CompanyTitle
        {
            get
            {
                var news = co_comments_companies;
                return news != null ? news.title : "n/a";
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

        public Uri Link
        {
            get
            {
                return co_comments_companies != null
                           ? new Uri(string.Format("{0}#comment_{1}", co_comments_companies.ItemUri(), this.id), UriKind.Relative)
                           : null;
            }
        }
        
    }
}
