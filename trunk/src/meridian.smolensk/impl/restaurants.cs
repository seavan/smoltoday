using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Collections.Generic;
using System.Xml.Serialization;
using MySql.Data.MySqlClient;
using admin.db;
using meridian.smolensk;
using meridian.smolensk.system;
using System.Web.Script.Serialization;
using smolensk.common;

namespace meridian.smolensk.proto
{
    public partial class restaurants : IDatabaseEntity, ICommentable, IMarkable, IDictionaryValuesAspectProvider, IGeoLocation, IAttachedPhotoAspectProvider, IFavorite, ILookupValue
	{
        public IEnumerable<IComment> GetComments()
        {
            return Meridian.Default.restaurant_commentsStore.GetAll().Where(c => c.restaurant_id.Equals(this.id)).OrderBy(c => c.create_date);
        }

        public bool can_comment { get { return true; } }

        public IComment AddComment(IComment comment)
        {
            restaurant_comments cc = new restaurant_comments
            {
                account_id = comment.AuthorId,
                text = comment.CommentText,
                create_date = comment.CreateDate,
                delete = comment.delete,
                left_key = comment.LeftKey,
                level = comment.level,
                restaurant_id = this.id,
                parent_id = comment.ParentId,
                right_key = comment.RightKey
            };
            Meridian.Default.restaurant_commentsStore.Insert(cc);
            Meridian.Default.restaurant_commentsStore.UpdateNestedSets(cc.restaurant_id, cc.parent_id, cc.level, cc.left_key);

            //this.comment_count = Meridian.Default.restaurant_commentsStore.All().Where(m => m.restaurant_id.Equals(this.id)).Count();
            //Meridian.Default.restaurantsStore.Update(this);
            var acc = Meridian.Default.accountsStore.Get(comment.AuthorId);
            acc.comments_count += 1;
            Meridian.Default.accountsStore.Update(acc);

            return cc;
        }

        public void DeleteComment(long id)
        {
            if (Meridian.Default.restaurant_commentsStore.Exists(id))
            {
                var commment = Meridian.Default.restaurant_commentsStore.GetById(id);
                Meridian.Default.restaurant_commentsStore.Delete(commment);
            }
        }

        public void SetMark(IMark mark)
        {
            restaurant_rating m_mark = Meridian.Default.restaurant_ratingStore.All().FirstOrDefault(m => m.account_id.Equals(mark.AuthorId) && m.restaurant_id.Equals(this.id));

            if (m_mark == null)
            {
                m_mark = new restaurant_rating
                {
                    account_id = mark.AuthorId,
                    create_date = mark.CreateDate,
                    rating = mark.CMark,
                    restaurant_id = this.id
                };

                Meridian.Default.restaurant_ratingStore.Insert(m_mark);
            }
            else
            {
                m_mark.rating = mark.CMark;
                m_mark.create_date = mark.CreateDate;
                Meridian.Default.restaurant_ratingStore.Update(m_mark);
            }



            //this.rating = GetRating();
            //Meridian.Default.restaurantsStore.Update(this);

        }

        public int GetRating()
        {
            var marks = Meridian.Default.restaurant_ratingStore.All().Where(m => m.restaurant_id.Equals(this.id));

            int count = marks.Count();
            if (count <= 0)
                return 0;

            return (int)Math.Floor((double)(marks.Sum(m => m.rating) / marks.Count()));
        }

        public bool isReview { get { return true; } }

        public int GetCountMarks()
        {
            var marks = Meridian.Default.restaurant_ratingStore.All().Where(m => m.restaurant_id.Equals(this.id));
            int count = marks.Count();
            return count <= 0 ? 0 : count;
        }


        public IDictionaryValuesAspect GetDictionaryValuesAspect(string _fieldName)// GetEntriesDictionaryValuesAspect()
        {
            return new DictionaryAspect<restaurant_entry_categories, restaurants_entries>(
                this,
                "Entries",
                () => Meridian.Default.restaurant_entry_categoriesStore.All(),
                () => this.Entries,
                (a, b) =>
                    {
                        var entries = Entries.Where(s => b != 0 ? s.ValueId.Equals(b) : s.Category != null && s.Category.id.Equals(a)).ToArray();
                        foreach (var e in entries) this.RemoveEntries(e, true);
                    },
                (a, b, c) =>
                    {
                        var existing = Entries.Where(s => s.Category != null && s.Category.id == a).ToArray();

                        if (existing.Count() >= 1)
                        {
                            var category = existing.First().Category;

                            if (category.MultiValue)
                            {
                                if (existing.Any(s => s.ValueId.Equals(b)))
                                {
                                    return;
                                }
                            }
                            else
                            {
                                for (int i = 1; i < existing.Length; ++i)
                                {
                                    RemoveEntries(existing[i], true);
                                }
                                existing[0].ValueId = b;

                                return;
                            }


                        }
                        
                        this.AddEntries(new restaurants_entries()
                            {
                                restaurant_id = id,
                                entry_id = b
                            }, true);
                    }
                );
        }
        public Uri ItemUri()
        {
            string uri = string.Format("/Restaurants/One/{0}/{1}", this.id, title.TransliterateAndClear());

            return new Uri(uri, UriKind.Relative);
        }

        #region IGeoLocation Implementation
        public string GeoLocationCoordinates { get {return this.coordinates; } }
        public string GeoLocationTitle { get { return string.IsNullOrEmpty(this.map_title) ? this.title : this.map_title; } }
        public string GeoLocationDescription { get { return this.map_description; } }
        public Uri GetGeoLocationUri()
        {
            return new Uri(String.Format("{0}{1}", ItemUri(), "#menuTop"), UriKind.Relative);
        }
        public double GetLatitude()
        {
            if(string.IsNullOrEmpty(this.coordinates)) return 0;

            string[] coords = this.coordinates.Split(',');
            if(coords.Count()>1)
            {
                return double.Parse(coords[1].Trim());
            }
            return 0;

        }
        public double GetLongitude()
        {
            if (string.IsNullOrEmpty(this.coordinates)) return 0;

            string[] coords = this.coordinates.Split(',');

            return double.Parse(coords[0].Trim());
        }
        public string GetGeoLocationCategoryName()
        {
            return "Кафе, рестораны";
        }
        #endregion

      

        public IAttachedPhotoAspect GetAttachedPhotoAspect(string _fieldName)
        {
            return new RestaurantsPhotosAspect(this);
        }

        public bool IsFavorite(long account_id)
        {
            return Meridian.Default.accounts_favoritesStore.All().Any(f => f.account_id == account_id && f.restaurant_id == this.id);
        }

        public void AddToFavorite(long account_id)
        {
            Meridian.Default.accounts_favoritesStore.Insert(
                new accounts_favorites() { account_id = account_id, restaurant_id = this.id });
        }

        public void DeleteFromFavorite(long account_id)
        {
            var fs = Meridian.Default.accounts_favoritesStore.All().FirstOrDefault(f => f.account_id == account_id && f.restaurant_id == this.id);
            if (fs == null) return;
            Meridian.Default.accounts_favoritesStore.Delete(fs);
        }


        public int lookup_value_level
        {
            get { return 0; }
        }

        public bool lookup_value_disabled
        {
            get { return false; }
        }
        public string lookup_title
        {
            get { return title; }
        }
    }
}
