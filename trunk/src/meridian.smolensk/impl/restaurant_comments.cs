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
    public partial class restaurant_comments : IDatabaseEntity, IComment
    {
        public string RestaurantTitle
        {
            get { return GetRestaurantsCommentsRestaurant() != null ? GetRestaurantsCommentsRestaurant().title : ""; }
        }
        public string AuthorName
        {
            get { return GetUser() != null ? GetUser().NameAndSurname : ""; }
        }

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
                return restaurant_id;
            }
            set
            {
                restaurant_id = value != null ? value : 0;
            }
        }

        public accounts GetUser()
        {
            return GetRestaurantsCommentsAccount();
        }

        public IComment GetParentComment()
        {
            try
            {
                return Meridian.Default.restaurant_commentsStore.GetById(this.parent_id);

            }
            catch (Exception)
            {

                return null;
            }

        }


        public bool isReview { get { return true; } }


        public string MaterialProtoName
        {
            get { return this.r_comments_restaurants != null ? this.r_comments_restaurants.ProtoName : null; }
        }

        public Uri Link
        {
            get
            {
                return r_comments_restaurants != null
                           ? new Uri(string.Format("{0}#comment_{1}", r_comments_restaurants.ItemUri(), this.id), UriKind.Relative)
                           : null;
            }
        }
    }
}
