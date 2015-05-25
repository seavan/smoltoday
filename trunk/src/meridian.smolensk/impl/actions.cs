using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using admin.db;
using meridian.smolensk.proto;
using meridian.smolensk.system;
using smolensk.common;

namespace meridian.smolensk.proto
{

    public partial class actions : IDatabaseEntity, ICommentable, IMarkable, IMainSlider, ILookupValueAspectProvider,
        IAttachedPhotoAspectProvider, IOneToManyAspectProvider, IScheduleAspectProvider
    {
        public static actions Create() 
        {
            return new actions
            {
                published = true, 
                publish_date = DateTime.Now
            };
        }
        
        public bool can_comment { get { return true; } }
        public IEnumerable<genres> GetGenres()
        {
            return this.GetActionGenre().Where(s => s.GetGenreGenre() != null).Select(s => s.GetGenreGenre());
        }

        public IEnumerable<actions_places> GetActionsPlaces()
        {
            return this.ActionPlace
                .Where(p => p.GetActionPlacePlace() != null);
        }

        public IEnumerable<places> GetPlaces()
        {
            return GetActionsPlaces().Select(p => p.GetActionPlacePlace());
        }

        public IEnumerable<actions_schedule> GetShcedule(DateTime? from = null, DateTime? to = null)
        {
            var ids = GetActionsPlaces().Select(a => a.id);
            return Meridian.Default.actions_scheduleStore.All()
                .Where(s => ids.Contains(s.action_place_id))
                .Where(s => (from.HasValue ? s.datetime >= from : true))
                .Where(s => (to.HasValue ? s.datetime <= to : true))
                .OrderBy(s => s.GetPlace().title)
                .ThenBy(s => s.datetime);
        }

        public IEnumerable<IComment> GetComments()
        {
            return this.ActionComment.OrderByDescending(c => c.create_date);
            //                Meridian.Default.actions_commentsStore.GetAll().Where(c => c.action_id == id).OrderByDescending(c => c.create_date);
        }

        public IComment AddComment(IComment comment)
        {
            actions_comments cc = new actions_comments
            {
                account_id = comment.AuthorId,
                text = comment.CommentText,
                create_date = comment.CreateDate,
                delete = comment.delete,
                left_key = comment.LeftKey,
                level = comment.level,
                action_id = this.id,
                parent_id = comment.ParentId,
                right_key = comment.RightKey
            };
            Meridian.Default.actions_commentsStore.Insert(cc);
            Meridian.Default.actions_commentsStore.UpdateNestedSets(cc.action_id, cc.parent_id, cc.level, cc.left_key);
            var acc = Meridian.Default.accountsStore.Get(comment.AuthorId);
            acc.comments_count += 1;
            Meridian.Default.accountsStore.Update(acc);
            return cc;
        }

        public int AddParticipiant(long user_id)
        {
            this.participiants_count++;
            Meridian.Default.actionsStore.Update(this);
            return participiants_count;
        }

        public void DeleteComment(long id)
        {
            if (Meridian.Default.actions_commentsStore.Exists(id))
            {
                var commment = Meridian.Default.actions_commentsStore.GetById(id);
                Meridian.Default.actions_commentsStore.Delete(commment);
            }
        }

        public void SetMark(IMark mark)
        {
            actions_rating m_mark = Meridian.Default.actions_ratingStore.All()
                .FirstOrDefault(m => m.account_id.Equals(mark.AuthorId) && m.action_id.Equals(this.id));

            if (m_mark == null)
            {
                m_mark = new actions_rating
                {
                    account_id = mark.AuthorId,
                    create_date = mark.CreateDate,
                    rating = mark.CMark,
                    action_id = this.id
                };

                Meridian.Default.actions_ratingStore.Insert(m_mark);
            }
            else
            {
                m_mark.rating = mark.CMark;
                m_mark.create_date = mark.CreateDate;
                Meridian.Default.actions_ratingStore.Update(m_mark);
            }

            this.rating = GetRating();
            Meridian.Default.actionsStore.Update(this);
        }

        public int GetRating()
        {
            var marks = Meridian.Default.actions_ratingStore.All().Where(m => m.action_id.Equals(this.id));

            int count = marks.Count();
            if (count <= 0)
                return 0;

            return (int)Math.Floor((double)(marks.Sum(m => m.rating) / marks.Count()));
        }

        public int GetCountMarks()
        {
            var marks = Meridian.Default.actions_ratingStore.All().Where(m => m.action_id.Equals(this.id));
            int count = marks.Count();
            return count <= 0 ? 0 : count;
        }

        public bool isReview { get { return true; } }

        private Uri _ItemUri()
        {
            string uri = string.Format("/Poster/Action/{0}/{1}", this.id, this.title.TransliterateAndClear());

            return new Uri(uri, UriKind.Relative);
        }
        public Uri ItemMainUri
        {
            get { return _ItemUri(); }
        }
        public Uri GetImgItemMainUri()
        {
            var img = Meridian.Default.actions_photosStore.GetMainPhoto(this.id);
            if (img == null)
                return null;

            UrlBuilder urlBuilder = new UrlBuilder();
            return urlBuilder.BuildActionImageUri(this.id, img.normal);
        }

        public IEnumerable<IGeoLocation> GetGeoLocations()
        {
            foreach (var p in GetPlaces())
                if (!string.IsNullOrEmpty(p.coordinates))
                    yield return new ActionGeoLocation(this, p);
        }

        public class ActionGeoLocation : IGeoLocation
        {
            public actions action { get; private set; }
            public places place { get; private set; }

            public ActionGeoLocation(actions a, places p)
            {
                action = a;
                place = p;
            }

            public double GetLongitude()
            {
                return place.GetLongitude();
            }
            public double GetLatitude()
            {
                return place.GetLatitude();
            }
            public string GeoLocationCoordinates { get { return place.GeoLocationCoordinates; } }
            public string GeoLocationTitle { get { return string.IsNullOrEmpty(action.map_title) ? action.title : action.map_title; } }
            public string GeoLocationDescription { get { return action.map_description; } }
            public Uri GetGeoLocationUri()
            {
                return new Uri(String.Format("{0}{1}", action._ItemUri(), "#menuTop"), UriKind.Relative);
            }
            public string GetGeoLocationCategoryName()
            {
                return action.GetActionCategoryAction_categorie() != null
                           ? action.GetActionCategoryAction_categorie().title
                           : string.Empty;
            }
        }

        public ILookupValueAspect Getcategory_idLookupValueAspect()
        {
            return new LookupAspect("category_id", this, () => Meridian.Default.action_categoriesStore.All(), false);
        }

        public ILookupValueAspect Getaccount_idLookupValueAspect()
        {
            return new LookupAspect("account_id", this, () => Meridian.Default.accountsStore.All().OrderBy(s => s.ShortName));
        }



        public ILookupValueAspect GetLookupValueAspect(string _fieldName)
        {
            switch (_fieldName)
            {
                case "category_id":
                    return Getcategory_idLookupValueAspect();
                case "account_id":
                    return Getaccount_idLookupValueAspect();
            }

            return null;
        }

        public IAttachedPhotoAspect GetAttachedPhotoAspect(string fieldName)
        {
            switch (fieldName)
            {
                case "Photos":
                    return new ActionsPhotosAspect(this);
                case "image_for_main":
                    return new OnePhotoAspect<actions>(this, fieldName, Constants.ActionsDataFolder); 
            }
            return null;
        }

        public IOneToManyAspect GetOneToManyAspect(string _fieldName)
        {
            switch (_fieldName)
            {
                case "ActionGenre":
                    return new OneToManyAspect<genres>(this, "ActionGenre",
                                                               Meridian.Default.genresStore.All,
                                                               this.GetGenres,
                                                               (genre) =>
                                                               {
                                                                   if (!this.GetGenres().Any(s => s.id.Equals(genre)))
                                                                   {
                                                                       this.AddActionGenre(new actions_genres()
                                                                           {
                                                                               action_id = this.id,
                                                                               genre_id = genre
                                                                           }, true);
                                                                   }

                                                               }
                                                               ,
                                                               (genre)
                                                               =>
                                                               {
                                                                   var genres =
                                                                       GetActionGenre()
                                                                           .Where(s => s.genre_id.Equals(genre)).ToArray();
                                                                   foreach (var g in genres)
                                                                   {
                                                                       this.RemoveActionGenre(g, true);
                                                                   }

                                                               });
                case "ActionPlace":
                    return new OneToManyAspect<places>(this, "ActionPlace",
                                                               Meridian.Default.placesStore.All,
                                                               this.GetPlaces,
                                                               (place) =>
                                                               {
                                                                   if (!this.GetPlaces().Any(s => s.id.Equals(place)))
                                                                   {
                                                                       this.AddActionPlace(new actions_places()
                                                                       {
                                                                           action_id = this.id,
                                                                           place_id = place
                                                                       }, true);
                                                                   }

                                                               }
                                                               ,
                                                               (place)
                                                               =>
                                                               {
                                                                   var places =
                                                                       GetActionPlace()
                                                                           .Where(s => s.place_id.Equals(place)).ToArray();
                                                                   foreach (var g in places)
                                                                   {
                                                                       this.RemoveActionPlace(g, true);
                                                                   }

                                                               });


            }

            return null;
        }

        public string ActionSchedule { get; set; }

        public IScheduleAspect GetScheduleAspect(string _fieldName)
        {
            return new ScheduleAspect(this, "ActionSchedule",
                () =>
                    {
                        return
                            this.GetActionsPlaces()
                                .Where(s => s.GetActionPlacePlace() != null)
                                .Select(s => new LookupValueDummy()
                                    {
                                        id = s.id,
                                        lookup_title = s.GetActionPlacePlace().title
                                    });
                    },
                () =>
                    {
                        var result = new SortedList<long, List<DateTime>>();
                        foreach (var p in GetActionsPlaces())
                        {
                            var item = new List<DateTime>();
                            result[p.id] = item;
                            item.AddRange(
                                    p.GetSchedule().Select(s => s.datetime)
                                );
                        }
                        return result;
                    },
                    (action_place, date) =>
                        {
                            var place = GetActionsPlaces().Where(s => s.id.Equals(action_place)).FirstOrDefault();
                            if (place != null)
                            {
                                var schedule = place.Schedule.ToArray();
                                if (schedule.Any(s => s.datetime == date))
                                {
                                    return;
                                }
                                place.AddSchedule(new actions_schedule()
                                    {
                                        action_place_id = place.id,
                                        datetime = date
                                    }, true);
                            }
                        },
                        
                        (action_place) =>
                            {
                                var place = GetActionsPlaces().Where(s => s.id.Equals(action_place)).FirstOrDefault();
                                if (place != null)
                                {
                                    var schedule = place.Schedule.ToArray();
                                    foreach (var s in schedule)
                                    {
                                        place.RemoveSchedule(s, true);
                                    }
                                }
                            });
        }
    }
}
