using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using smolensk.Models.ViewModels;
using meridian.smolensk.proto;
using meridian.smolensk.system;
using smolensk.common;

namespace smolensk.Mappers
{
    public enum PlaceSortingType
    {
        Title,
        Adress
    }
    
    public static class PlaceMapper
    {
        public static int ToDayCount(this ScheduleFilterType filter)
        {
            switch (filter)
            {
                case ScheduleFilterType.Today:
                    return 1;
                case ScheduleFilterType.In3Days:
                    return 3;
                case ScheduleFilterType.InWeek:
                    return 7;
                case ScheduleFilterType.In2Weeks:
                    return 14;
                default:
                    throw new NotImplementedException(string.Format("Неизвестный фильтр {0}", filter));
            }
        }

        public static ScheduleFilterType? ToDayCount(this int dayCount)
        {
            foreach (ScheduleFilterType filter in Enum.GetValues(typeof(ScheduleFilterType)))
                if (filter.ToDayCount().Equals(dayCount))
                    return filter;
            return null;
        }
        
        public static PlaceViewModel ToPlace(this places p)
        {
            return new PlaceViewModel(p.id) 
            { 
                Adress = p.adress, 
                Title = p.title,
                Text = p.text, 
                Price = p.price, 
                WorkTime = p.work_time,
                Phone = p.phone,
                Site = p.site,
                FacebookLink = p.facebook_link, 
                GoogleLink = p.google_link,
                TwitterLink = p.twitter_link, 
                MailLink = p.mail_link,
                OdnoklassnikiLink = p.odnoklassniki_link,
                VkLink = p.vk_link,
                
                Location = p.location,
                baseEntity = p
            };
        }

        public static PlacesListViewModel ToPlacesList(this Meridian meridian, long? category_id = null,
            DateTime? from = null, DateTime? to = null,
            PlaceSortingType sorting = PlaceSortingType.Title, SortingDirection sortDir = SortingDirection.Asc)
        {
            var actionsListModel = meridian.GetActionsList(category_id, null, from, to);

            var model = new PlacesListViewModel()
            {
                Category = actionsListModel.Category,
                Date = actionsListModel.Date,
                Sorting = sorting,
                sortingDirection = sortDir
            };
            var places = actionsListModel.Actions.SelectMany(a => a.Places).Distinct(new PlaceComparer());
            switch (sorting)
            {
                case PlaceSortingType.Title:
                    places = places.OrderBy(p => p.Title);
                    break;
                case PlaceSortingType.Adress:
                    places = places.OrderBy(p => p.Adress);
                    break;
            }
            places = sortDir != SortingDirection.Asc ? places.Reverse() : places;
            model.Places = places;
            return model;
        }
    }

    class PlaceComparer : IEqualityComparer<PlaceViewModel>
    {
        public bool Equals(PlaceViewModel x, PlaceViewModel y)
        {
            return x != null && y != null && x.Id == y.Id;
        }

        public int GetHashCode(PlaceViewModel x)
        {
            return x != null ? (int)x.Id : 0;
        }
    }
}