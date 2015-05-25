using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using meridian.smolensk.impl.Interfaces;
using meridian.smolensk.system;
using admin.db;

namespace meridian.smolensk.proto
{
    public partial class companies : IDatabaseEntity, ICommentable, IMarkable, IViewableMaterial, ICommentableMaterial, 
        IPopularityMaterial, IGeoLocation, ILookupValueAspectProvider, IFavorite, ILookupValue, IAttachedPhotoAspectProvider,
        IOneToManyAspectProvider
    {
        public static companies Create()
        {
            return new companies() 
            {
                publish_date = DateTime.Now
            };
        }

        public bool can_comment { get { return true; } }
        public IEnumerable<company_kind_activities> GetKidsOfActivities()
        {
            var meridian = Meridian.Default;

            return GetKinds()
                .Select(k => meridian.company_kind_activitiesStore.Get(k.kind_activitiy_id)).ToArray();
        }

        public company_categories GetCategory()
        {
            return this.ca_companies_company_categories;
        }


        public company_photos GetPhotoLogo()
        {
            return this.Photos.OrderByDescending(s => s.is_main).FirstOrDefault();
        }

        public IEnumerable<IComment> GetComments()
        {
            return GetRootComments().OrderBy(c => c.create_date);
        }

        public IComment AddComment(IComment comment)
        {
            company_comments cc = new company_comments
            {
                account_id = comment.AuthorId,
                text = comment.CommentText,
                create_date = comment.CreateDate,
                delete = comment.delete,
                left_key = comment.LeftKey,
                level = comment.level,
                company_id = this.id,
                parent_id = comment.ParentId,
                right_key = comment.RightKey
            };
            Meridian.Default.company_commentsStore.Insert(cc);
            Meridian.Default.company_commentsStore.UpdateNestedSets(cc.company_id, cc.parent_id, cc.level, cc.left_key);

            //this.comment_count = Meridian.Default.restaurant_commentsStore.All().Where(m => m.restaurant_id.Equals(this.id)).Count();
            //Meridian.Default.restaurantsStore.Update(this);
            var acc = Meridian.Default.accountsStore.Get(comment.AuthorId);
            acc.comments_count += 1;
            Meridian.Default.accountsStore.Update(acc);

            return cc;
        }

        public void DeleteComment(long id)
        {
            if (Meridian.Default.company_commentsStore.Exists(id))
            {
                var commment = Meridian.Default.company_commentsStore.GetById(id);
                Meridian.Default.company_commentsStore.Delete(commment);
            }
        }

        public void SetMark(IMark mark)
        {
            company_rating m_mark = Meridian.Default.company_ratingStore.All().FirstOrDefault(m => m.account_id.Equals(mark.AuthorId) && m.company_id.Equals(this.id));

            if (m_mark == null)
            {
                m_mark = new company_rating
                {
                    account_id = mark.AuthorId,
                    create_date = mark.CreateDate,
                    rating = mark.CMark,
                    company_id = this.id
                };

                Meridian.Default.company_ratingStore.Insert(m_mark);
            }
            else
            {
                m_mark.rating = mark.CMark;
                m_mark.create_date = mark.CreateDate;
                Meridian.Default.company_ratingStore.Update(m_mark);
            }



            //this.rating = GetRating();
            //Meridian.Default.restaurantsStore.Update(this);

        }

        public int GetRating()
        {
            var marks = GetRatings().ToList();

            int count = marks.Count;
            if (count <= 0)
                return 0;

            return (int)Math.Floor((double)(marks.Sum(m => m.rating) / count));
        }

        public bool isReview { get { return true; } }

        public int GetCountMarks()
        {
            var marks = Meridian.Default.company_ratingStore.All().Where(m => m.company_id.Equals(this.id));
            int count = marks.Count();
            return count <= 0 ? 0 : count;
        }

        public int GetPopularityByVacancies()
        {
            return GetActualVacancies().Sum(v => v.ViewsCount);
        }

        public int CountOfActualVacancies()
        {
            return GetActualVacancies().Count();
        }

        public IEnumerable<vacancies> GetActualVacancies()
        {
            return GetVacancies().Where(v => v.IsActual);
        }

        public Uri ItemUri()
        {
            string uri = string.Format("/Companies/One/{0}/{1}", this.id, title.TransliterateAndClear());

            return new Uri(uri, UriKind.Relative);
        }
        public Uri ItemVacancyUri()
        {
            string uri = string.Format("/Vacancy/Company/{0}/{1}", this.id, title.TransliterateAndClear());

            return new Uri(uri, UriKind.Relative);
        }

        #region Implementation of IViewableMaterial

        public int ViewsCount
        {
            get { return (int)views_count; }
            set { views_count = value; }
        }

        public void IncrementViewsCount()
        {
            ViewsCount++;
            Meridian.Default.companiesStore.Update(this);
        }

        #endregion

        #region Implementation of ICommentableMaterial

        public int GetCommentsCount()
        {
            return this.co_comments.Count;
            /* return Meridian.Default.company_commentsStore.GetAll()
                .Count(c => c.company_id == id); */
        }

        #endregion

        #region Implementation of IPopularityMaterial

        public int GetPopularity()
        {
            return ViewsCount + GetCommentsCount();
        }

        #endregion

        #region IGeoLocation Implementation
        public string GeoLocationCoordinates { get { return this.coordinates; } }
        public string GeoLocationTitle { get { return string.IsNullOrEmpty(this.map_title) ? this.title : this.map_title; } }
        public string GeoLocationDescription { get { return this.map_description; } }
        public Uri GetGeoLocationUri()
        {
            return new Uri(String.Format("{0}{1}", ItemUri(), "#menuTop"), UriKind.Relative);
        }
        public double GetLatitude()
        {
            if (string.IsNullOrEmpty(this.coordinates)) return 0;

            string[] coords = this.coordinates.Split(',');
            if (coords.Count() > 1)
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
            return "Компании";
        }
        #endregion

        public ILookupValueAspect Getcategory_idLookupValueAspect()
        {
            return new LookupAspect("category_id", this, () =>
                {
                    var categories = Meridian.Default.company_categoriesStore.All();
                    var parentCategories = categories.Where(s => s.GetChildrenCompany_categorie() == null);
                    var res = new List<ILookupValue>();

                    foreach (var pc in parentCategories)
                    {
                        res.Add(pc);
                        res.AddRange(pc.Children);
                    }

                    return res;
                });
        }

        public ILookupValueAspect Getownership_idLookupValueAspect()
        {
            return new LookupAspect("ownership_id", this, () =>
                {
                    return Meridian.Default.company_ownershipsStore.All();
                });
        }

        public bool IsFavorite(long account_id)
        {
            return Meridian.Default.accounts_favoritesStore.All().Any(f => f.account_id == account_id && f.company_id == this.id);
        }

        public void AddToFavorite(long account_id)
        {
            Meridian.Default.accounts_favoritesStore.Insert(
                new accounts_favorites() { account_id = account_id, company_id = this.id });
        }

        public void DeleteFromFavorite(long account_id)
        {
            var fs = Meridian.Default.accounts_favoritesStore.All().FirstOrDefault(f => f.account_id == account_id && f.company_id == this.id);
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

        public IAttachedPhotoAspect GetAttachedPhotoAspect(string fieldName)
        {
            return new CompaniesPhotosAspect(this);
        }

        public IOneToManyAspect GetOneToManyAspect(string fieldName)
        {
            switch (fieldName)
            {
                case "Kinds":
                    return GetKindsOfActivitiesAspect();

                default:
                    throw new InvalidOperationException(string.Format("Unable to find aspect for field '{0}'", fieldName));
            }
        }

        private IOneToManyAspect GetKindsOfActivitiesAspect()
        {
            return new OneToManyAspect<company_kind_activities>(this,
                "Kinds", Meridian.Default.company_kind_activitiesStore.All,
                () => 
                {
                    var store = Meridian.Default.company_kind_activitiesStore;
                    return this.Kinds.Where(ca => store.Exists(ca.kind_activitiy_id)).Select(ca => store.Get(ca.kind_activitiy_id));
                },
                (activityKindId) =>
                {
                    if (!this.Kinds.Any(ca => ca.kind_activitiy_id.Equals(activityKindId)))
                    {
                        var association = new companies_kind_activities() { company_id = this.id, kind_activitiy_id = activityKindId };
                        this.AddKinds(association, true);
                    }
                },
                (activityKindId) =>
                {
                    var recordsToRemove = this.Kinds.Where(ca => ca.kind_activitiy_id.Equals(activityKindId)).ToArray();
                    foreach (var record in recordsToRemove)
                        this.RemoveKinds(record, true);
                });
        }
    }
}
