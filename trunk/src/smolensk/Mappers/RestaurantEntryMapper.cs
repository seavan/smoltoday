using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using meridian.smolensk.proto;
using meridian.smolensk.system;
using smolensk.common;
using smolensk.ViewModels;

namespace smolensk.Mappers
{
    public static class RestaurantEntryMapper
    {
        public static RestaurantEntryViewModel ToRestaurantEntryViewModel(this restaurant_entries rEntry)
        {
            var model = new RestaurantEntryViewModel(rEntry.id)
                            {
                                Title = rEntry.title,
                                Category = (RestaurantEntryCategory) rEntry.restaurant_entry_category_id,
                            };

            return model;
        }

        public static IList<RestaurantEntryViewModel> GetRestaurantEntries(this Meridian meridian, RestaurantEntryCategory category, long[] selected)
        {
            IEnumerable<restaurant_entries> query = meridian.restaurant_entriesStore.GetBy((long) category);

            var list = query.Select(e => e.ToRestaurantEntryViewModel()).ToList();

            if (selected != null && selected.Length != 0)
            {
                foreach (var entry in list)
                {
                    entry.Selected = selected.Contains(entry.Id);
                }
            }

            return list;
        }

        public static IEnumerable<RestaurantEntryViewModel> GetEntries(this restaurants restaurant, RestaurantEntryCategory category = RestaurantEntryCategory.Nothing)
        {
            Meridian meridian = Meridian.Default;

            var query = restaurant.Entries.Where(s => s.GetEntriesValuesRestaurant_entrie() != null).Select(s => s.GetEntriesValuesRestaurant_entrie());

            if (category != RestaurantEntryCategory.Nothing)
            {
                query = query.Where(r => r.restaurant_entry_category_id == (long)category);
            }

            return query.Select(r => r.ToRestaurantEntryViewModel());
        }

        public static string EnumerateToString(this IEnumerable<RestaurantEntryViewModel> enums)
        {
            return string.Join(", ", enums.Select(e => e.Title));
        }
    }
}