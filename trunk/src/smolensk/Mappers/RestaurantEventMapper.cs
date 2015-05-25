using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using meridian.smolensk.proto;
using smolensk.ViewModels;
using meridian.smolensk.system;

namespace smolensk.Mappers
{
    using DayOfWeek = Models.DayOfWeek;
    using smolensk.Domain;

    public static class RestaurantEventMapper
    {
        public static IList<RestaurantEventsListViewModel> ToRestaurantEventsListsCollection(this Meridian meridian, long restaurantId)
        {
            List<RestaurantEventViewModel> events = meridian.restaurant_eventsStore.All()
                .Where(r => r.restaurant_id == restaurantId)
                .OrderBy(r => r.date)
                .Select(r => r.ToRestaurantEvent())
                .ToList();

            if (events.Count == 0)
            {
                return new List<RestaurantEventsListViewModel>();
            }

            DateTime boundaryLeft = events.First().Date.Date;
            DateTime boundaryRight = GetLastDayOfQuad(events.Last().Date);
            
            var eventsListsCollection = new List<RestaurantEventsListViewModel>();
            for (int d = 0; d < boundaryRight.Subtract(boundaryLeft).TotalDays+1; d++)
            {
                DateTime date = boundaryLeft.AddDays(d);

                eventsListsCollection.Add(new RestaurantEventsListViewModel
                                              {
                                                  Day = GetDayOfWeek(date),
                                                  Events = events.Where(e=>e.Date.Date == date).ToList(),
                                              });
            }

            return eventsListsCollection;
        }

        public static IList<RestaurantEventsListViewModel> ToRestaurantsEventsListsCollection(this Meridian meridian)
        {
            DateTime boundaryLeft = DateTime.Now.Date;
            boundaryLeft = GetFirstDayOfWeek(boundaryLeft);

            List<RestaurantEventViewModel> events = meridian.restaurant_eventsStore.All()
                .Where(r => r.date >= boundaryLeft && meridian.restaurantsStore.Exists(r.restaurant_id))
                .OrderBy(r=>r.date)
                .Select(r => r.ToRestaurantEvent())
                .ToList();

            if (events.Count == 0)
            {
                return new List<RestaurantEventsListViewModel>();
            }

            DateTime boundaryRight = GetLastDayOfWeek(events.Last().Date);

            var eventsListsCollection = new List<RestaurantEventsListViewModel>();
            for (int d = 0; d < boundaryRight.Subtract(boundaryLeft).TotalDays+1; d++)
            {
                DateTime date = boundaryLeft.AddDays(d);

                eventsListsCollection.Add(new RestaurantEventsListViewModel
                                              {
                                                  Day = GetDayOfWeek(date),
                                                  Events = events.Where(e => e.Date.Date == date).ToList(),
                                              });
            }

            return eventsListsCollection;
        }

        public static RestaurantEventViewModel ToRestaurantEvent(this restaurant_events restEvent)
        {
            Meridian meridian = Meridian.Default;

            var model = new RestaurantEventViewModel(restEvent.id)
                            {
                                Date = restEvent.date,
                                ShortDescription = restEvent.short_desc,
                                Title = restEvent.title,
                                Restaurant = meridian.restaurantsStore.Get(restEvent.restaurant_id).ToRestaurantViewModel(true),
                            };

            return model;
        }

        private static DateTime GetFirstDayOfWeek(DateTime date)
        {
            while (date.DayOfWeek != System.DayOfWeek.Monday)
            {
                date = date.Date.AddDays(-1);
            }

            return date;
        }

        private static DateTime GetLastDayOfWeek(DateTime date)
        {
            while (date.DayOfWeek != System.DayOfWeek.Sunday)
            {
                date = date.Date.AddDays(1);
            }

            return date;
        }

        private static DayOfWeek GetDayOfWeek(DateTime date)
        {
            var result = new DayOfWeek
                             {
                                 Date = date,
                                 DayOfMonth = Formatter.GetNameOfDayOfMonth(date),
                                 IsHoliday = date.DayOfWeek == System.DayOfWeek.Saturday
                                             || date.DayOfWeek == System.DayOfWeek.Sunday,
                                 Title = Formatter.GetNameOfDayOfWeek(date),
                             };

            return result;
        }

        private static DateTime GetLastDayOfQuad(DateTime date)
        {
            DateTime current = DateTime.Now.Date;
            int diff = 4-(int) (date.Date.Subtract(current).TotalDays+1)%4;
            return date.AddDays(diff);
        }
    }
}