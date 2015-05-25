using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using meridian.smolensk.system;

namespace meridian.smolensk.proto
{
    public partial class actions_comments : IComment
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
                return action_id;
            }
            set
            {
                action_id = value;
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
                return Meridian.Default.actions_commentsStore.GetById(this.parent_id);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool isReview { get { return true; } }

        public string MaterialProtoName
        {
            get { return Meridian.Default.actionsStore.Exists(action_id) ? Meridian.Default.actionsStore.Get(action_id).ProtoName : null; }
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
                return Meridian.Default.actionsStore.Exists(action_id)
                           ? new Uri(string.Format("{0}#comment_{1}", Meridian.Default.actionsStore.Get(action_id).ItemMainUri, this.id), UriKind.Relative)
                           : null;
            }
        }
    }
}
