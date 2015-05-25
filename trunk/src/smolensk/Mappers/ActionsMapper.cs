using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using meridian.smolensk.proto;
using meridian.smolensk.system;
using smolensk.common;
using smolensk.Models.CodeModels;
using smolensk.Models.ViewModels;
using DateRange = smolensk.Models.CodeModels.DateRange;

namespace smolensk.Mappers
{
    public enum ActionSortingType
    {
        Novelty,
        Alphabet,
        AgeLimit,
        Genre,
        Place,
        Time
    }

    public enum ActionDateFilterType
    {
        [Description("Сегодня")]
        Now,
        [Description("Завтра")]
        Tomorrow,
        [Description("Послезавтра")]
        AfterTomorrow
    }

    public enum ActionStatus
    { 
        /// <summary>
        /// создано
        /// </summary>
        Create = 0,
        /// <summary>
        /// прошло модерацию
        /// </summary>
        Approve = 1,
        /// <summary>
        /// скрыто пользователем
        /// </summary>
        Hide = 2,
        /// <summary>
        /// удалено
        /// </summary>
        Delete = 3
    }

    public static class ActionsMapper
    {
        public static DateRange ToDate(this ActionDateFilterType dateFilter)
        {
            var now = DateTime.Now.Date;
            switch (dateFilter)
            { 
                case ActionDateFilterType.Now:
                    return new DateRange(now); 
                case ActionDateFilterType.Tomorrow:
                    return new DateRange(now.AddDays(1).Date); 
                case ActionDateFilterType.AfterTomorrow:
                    return new DateRange(now.AddDays(2).Date); 
                default:
                    throw new NotImplementedException(string.Format("Неизвестный фильтр даты {0}", dateFilter));
            }
        }

        public static ActionDateFilterType? ToDateFilterType(this DateRange date)
        {
            foreach (ActionDateFilterType filter in Enum.GetValues(typeof(ActionDateFilterType)))
                if (filter.ToDate().Equals(date))
                    return filter;
            return null;
        }

        public static ActionStatus GetActionStatus(this actions a)
        {
            if (a.delete)
                return ActionStatus.Delete;
            if (!a.approve)
                return ActionStatus.Create;
            if (a.approve && !a.published)
                return ActionStatus.Hide;
            return ActionStatus.Approve; 
        }

        public static ActionViewModel ToAction(this actions a, DateTime? from = null, DateTime? to = null)
        {
            var meridian = Meridian.Default;
            var p_store = meridian.placesStore;
            var mainPhoto = meridian.actions_photosStore.GetMainPhoto(a.id);

            var model = new ActionViewModel(a.id) 
            { 
                Title = a.title,
                Text = a.text,
                AgeLimit = a.age_limit, 
                Author = a.author, 
                Producer = a.producer, 
                Country = a.country, 
                Duration = a.duration, 
                Lecturer = a.lecturer, 
                Performers = a.performers,
                Statement = a.statement, 
                PriceMax = a.price_max,
                PriceMin = a.price_min,
                Status = a.GetActionStatus(),
                CreateDate = a.publish_date,
                Start_date = a.start_date.Equals(DateTime.MinValue) ? (DateTime?)null : a.start_date,
                Site = a.site, 
                GoogleLink = a.google_link, 
                FacebookLink = a.facebook_link, 
                TwitterLink = a.twitter_link, 
                VkLink = a.vk_link, 
                MailLink = a.mail_link, 
                OdnoklassnikiLink = a.odnoklassniki_link,
                ParticipiantsCount = a.participiants_count,
                PhotoUrlForMain = Constants.ActionsDataFolder + a.image_for_main,
                Comments = a,                
                Marks = a,
                Rating = a.GetRating(),
                Schedule = a.GetShcedule(from, to),
                Category = ActionCategoryMapper.GetCategory(a.category_id),                 
                Genres = a.GetGenres().Select(g => g.title), 
                Places = a.GetPlaces().Select(p => p.ToPlace())
            };
            if (mainPhoto != null)
            { 
                model.NormalPhotoUrl = Constants.ActionsDataFolder + mainPhoto.normal;
                model.ThumbnailUrl = Constants.ActionsDataFolder + mainPhoto.thumbnail;
            }

            List<RelatedPhoto> relatedPhotos = meridian.actions_photosStore.GetPhotos(a.id)
                .Select(p => new RelatedPhoto
                {
                    Link = Constants.ActionsDataFolder + p.normal,
                    PhotoUrl = Constants.ActionsDataFolder + p.thumbnail,
                    Title = "",
                })
                .ToList();

            model.PhotoScroller = new PhotoScrollViewModel
                                    {
                                        PhotoHeight = 40,
                                        PhotoWidth = 56,
                                        Photos = relatedPhotos,
                                        PhotosCount = 4,
                                    };
            return model;
        }

        public static ActionsListViewModel GetActionsList(this Meridian meridian, long? category_id = null, long? place_id = null,
            DateTime? from = null, DateTime? to = null, bool onlyTop = false, int count = 0,
            ActionSortingType sorting = ActionSortingType.Novelty, SortingDirection sortingDir = SortingDirection.Asc)
        { 
            var model = new ActionsListViewModel();
            model.Category = ActionCategoryMapper.GetCategory(category_id);
            model.Date = new DateRange(from, to);
            var list = GetAllVisible(meridian)
                .FilterByCategory(category_id)
                .FilterByPlace(place_id)
                .FilterByDate(from, to)
                .GetOnlyTop(onlyTop)
                .Sorting(sorting, sortingDir, from, to);
            if (count > 0)
                list = list.Take(count);
            model.Actions = list.Select(a => a.ToAction(from, to));
            model.Sorting = sorting;
            model.sortingDirection = sortingDir;
            return model;
        }

        public static IEnumerable<actions> FilterByCategory(this IEnumerable<actions> query, long? category_id)
        {
            if (!category_id.HasValue || category_id.Value == 0) return query;
            return query.Where(a => a.category_id == category_id.Value);
        }

        public static IEnumerable<actions> FilterByPlace(this IEnumerable<actions> query, long? place_id)
        {
            if (!place_id.HasValue || place_id.Value == 0) return query;
            return query.Where(a => a.GetPlaces().Any(p => p.id == place_id.Value));
        }

        public static IEnumerable<actions> FilterByDate(this IEnumerable<actions> query, DateTime? from, DateTime? to)
        {
            return query.Where(a => a.GetShcedule(from, to).Any());
        }

        public static IEnumerable<actions> GetOnlyTop(this IEnumerable<actions> query, bool onlyTop)
        {
            return onlyTop ? query.Where(a => a.is_top) : query;
        }

        public static IEnumerable<actions> Sorting(this IEnumerable<actions> query, 
            ActionSortingType? sorting = ActionSortingType.Novelty, SortingDirection sortingDir = SortingDirection.Asc,
            DateTime? from = null, DateTime? to = null)
        {
            if (!sorting.HasValue)
                return query;
            IEnumerable<actions> q = query.ToArray();
            switch(sorting)
            {
                case ActionSortingType.Novelty :
                    q = query.OrderByDescending(a => a.publish_date);
                    break;
                case ActionSortingType.Alphabet:
                    q = query.OrderBy(a => a.title);
                    break;
                case ActionSortingType.AgeLimit:
                    q = query.OrderBy(a => a.age_limit);
                    break;
                case ActionSortingType.Genre: //TODO: как сортировать?
                    q = query.OrderBy(a => a.GetGenres().FirstOrDefault().title);
                    break;
                case ActionSortingType.Time:
                    q = query.OrderBy(a => a.GetShcedule(from, to).FirstOrDefault().datetime);
                    break;
                case ActionSortingType.Place: //TODO: как сортировать?
                    q = query.OrderBy(a => a.GetPlaces().FirstOrDefault().title);
                    break;
            }
            return sortingDir != SortingDirection.Asc ? q.Reverse() : q;
        }

        public static IEnumerable<actions> GetAllVisible(Meridian meridian)
        {
            return meridian.actionsStore.All().Where(a => !a.delete && a.approve && a.published);
        }

        private static IEnumerable<actions> GetByUser(Meridian meridian, long user_id)
        {
            return meridian.actionsStore.All().Where(a => a.account_id == user_id && !a.delete);
        }

        public static IEnumerable<ActionViewModel> GetLastActions(this Meridian meridian, long? category_id, DateTime? from = null, DateTime? to = null, int count = 5)
        {
            return meridian.GetActionsList(category_id, null, from, to, false, count).Actions;
        }

        public static int GetAcionsCount(long? category_id, DateTime? from = null, DateTime? to = null)
        {
            return GetAllVisible(Meridian.Default)
                .FilterByCategory(category_id)
            .FilterByDate(from, to).Count();
        }

        public static IEnumerable<ActionViewModel> GetMainActionsByCategory(this Meridian meridian, long? category_id, int count = 3)
        {
            var list = GetAllVisible(meridian)
                .FilterByCategory(category_id)
                .Where(a => a.is_main_category)
                .Where(a => !string.IsNullOrEmpty(a.image_for_main))
                .Sorting();

            if (count > 0)
                list = list.Take(count);

            return list.Select(a => a.ToAction());
        }

        public static ActionsListViewModel GetUserActions(this Meridian meridian, long user_id, int page = 1, int pageSize = 12)
        {
            var model = new ActionsListViewModel();            
            var list = GetByUser(meridian, user_id).Sorting();

            model.Actions = MappingUtils.TakePage(list, page, pageSize).Select(a => a.ToAction());
            model.TotalPages = MappingUtils.CalculatePagesCount(list.Count(), pageSize);
            model.CurrentPage = page;

            return model;
        }
    }
}