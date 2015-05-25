using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using meridian.smolensk.proto;
using meridian.smolensk.system;
using smolensk.common;
using smolensk.Models.CodeModels;
using smolensk.Models.ViewModels;
using smolensk.ViewModels;

namespace smolensk.Mappers
{
    public static class RestaurantMapper
    {
        public static RestaurantsListViewModel ToRestaurantsListViewModel(this Meridian meridian, int page, long[] entries, string letter)
        {
            var model = new RestaurantsListViewModel();
            int totalRestaurants;
            var pages = GetRestaurantsPage(meridian, page, entries, letter, out totalRestaurants).ToList();

            model.CurrentPage = page;
            model.TotalPages = MappingUtils.CalculatePagesCount(totalRestaurants, Constants.RestaurantsPageSize);
            model.Restaurants = pages;
            model.EventsListsCollection = meridian.ToRestaurantsEventsListsCollection();

            model.Kitchens = meridian.GetRestaurantEntries(RestaurantEntryCategory.Kitchen, entries);
            model.AverageCosts = meridian.GetRestaurantEntries(RestaurantEntryCategory.AverageCost, entries);
            model.Discounts = meridian.GetRestaurantEntries(RestaurantEntryCategory.Discounts, entries);
            model.Specials = meridian.GetRestaurantEntries(RestaurantEntryCategory.Specials, entries);

            model.TotalRestaurants = totalRestaurants;

            return model;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="restaurant"></param>
        /// <param name="onlyDesc">Если true, то заполняет только основные поля (Id, Title и т.д). 
        /// Иначе заполняет все поля, списки событий и т.д</param>
        /// <returns></returns>
        public static RestaurantViewModel ToRestaurantViewModel(this restaurants restaurant, bool onlyDesc=false)
        {
            var meridian = Meridian.Default;

            restaurant_photos mainPhoto = meridian.restaurant_photosStore.GetMainPhoto(restaurant.id);
            
            if (mainPhoto == null)
            {
                mainPhoto = new restaurant_photos();
            }

            var model = new RestaurantViewModel(restaurant.id)
                            {
                                Address = restaurant.address,
                                HolesCount = restaurant.holes_count,
                                Phone = restaurant.phone,
                                NormalPhotoUrl = Constants.RestaurantsDataFolder + mainPhoto.normal,
                                ThumbnailUrl = Constants.RestaurantsDataFolder + mainPhoto.thumbnail,
                                Title = restaurant.title,
                                WorkTime = restaurant.work_time,
                                IsVip = restaurant.vip,
                                FeedbackEmail = restaurant.feedback_email,
                                Comments = restaurant,
                                Marks = restaurant,
                                GeoLocation = restaurant,
                                Favorite = restaurant,
                                Rating = restaurant.GetRating(),
                                CanBookTable = restaurant.can_book_table
                            };

            if (!onlyDesc)
            {
                model.Types = restaurant.GetEntries(RestaurantEntryCategory.Type);
                model.Kitchen = restaurant.GetEntries(RestaurantEntryCategory.Kitchen);
                model.AverageCost = restaurant.GetEntries(RestaurantEntryCategory.AverageCost).SingleOrDefault();

                model.Events = meridian.ToRestaurantEventsListsCollection(restaurant.id);
                model.Similar = restaurant.GetSimilarRestaurants().ToList();
                model.Description = restaurant.description;

                var entries = restaurant.GetEntries().Where(s => s.Category != null).GroupBy(s => s.Category.title).Select(
                    a => new { title = a.Key, value = String.Join(", ", a.Where(s => s.Value != null).Select(s => s.Value))});

                foreach (var e in entries)
                {
                    model.Dictionary[e.title] = e.value;
                }
                
                List<RelatedPhoto> relatedPhotos = restaurant.GetPhotos()
                    .Select(p => new RelatedPhoto
                                     {
                                         Link = Constants.RestaurantsDataFolder + p.normal,
                                         PhotoUrl = Constants.RestaurantsDataFolder + p.thumbnail,
                                         Title = "",
                                     })
                    .ToList();

                model.PhotoScroller = new PhotoScrollViewModel
                                          {
                                              PhotoHeight = 40,
                                              PhotoWidth = 56,
                                              Photos = relatedPhotos,
                                              PhotosCount = 4,
                                              //NOTE: Задается на вьюхе
                                              //Callback = "",
                                          };
            }

            return model;
        }

        public static RestaurantViewModel GetRestaurant(this Meridian meridian, long id)
        {
            if (meridian.restaurantsStore.Exists(id))
            {
                return meridian.restaurantsStore.Get(id).ToRestaurantViewModel();
            }

            return null;
        }

        private static IEnumerable<RestaurantViewModel> GetSimilarRestaurants(this restaurants restaurant, int maximum = Constants.SimilarRestaurantsMax)
        {
            Meridian meridian = Meridian.Default;

            IEnumerable<restaurants> result = meridian.restaurantsStore.All().Where(r => r.id != restaurant.id);
            //Получаем рестораны у которых общий тип.
            result = result.Where(r => r.GetEntries(RestaurantEntryCategory.Type)
                                           .Intersect(restaurant.GetEntries(RestaurantEntryCategory.Type)).Any());
            //Получаем рестораны у которых общий средний счет
            result = result.Where(r => r.GetEntries(RestaurantEntryCategory.AverageCost)
                                           .Intersect(restaurant.GetEntries(RestaurantEntryCategory.AverageCost)).Any());

            var rr = result.GroupBy(r => r.GetEntries(RestaurantEntryCategory.Kitchen)
                                             .Intersect(restaurant.GetEntries(RestaurantEntryCategory.Kitchen)).Count())
                .OrderByDescending(g => g.Key)
                .ToList();

            var list = new List<restaurants>();
            foreach (IGrouping<int, restaurants> grouping in rr)
            {
                list.AddRange(grouping);
            }

            return list.Select(l => l.ToRestaurantViewModel(true)).OrderByDescending(r => r.Rating).Take(maximum);
        }

        private static IEnumerable<RestaurantViewModel> GetRestaurantsPage(Meridian meridian, int page, long[] entries, string letter, out int totalFound)
        {
            IEnumerable<restaurants> query = meridian.restaurantsStore.All();

            query = ApplyFilter(meridian, query, entries);

            if (!String.IsNullOrEmpty(letter) && letter != Constants.AnyLetter)
            {
                var c = letter.FirstCharacterLower();
                query = query.Where(s => s.title.FirstCharacterLower() == c);
            }

            query = query.OrderByDescending(r => r.vip);

            totalFound = query.Count();

            IEnumerable<restaurants> restaurants = MappingUtils.TakePage(query, page, Constants.RestaurantsPageSize);

            return restaurants.Select(r => r.ToRestaurantViewModel()).ToList();
        }

        private static IEnumerable<restaurants> ApplyFilter(Meridian meridian, IEnumerable<restaurants> query, long[] entries)
        {
            if (entries == null || entries.Length == 0)
                return query;

            long[] kitchenEntries =
    entries.Where(i => meridian.restaurant_entriesStore.Get(i).restaurant_entry_category_id == (long)RestaurantEntryCategory.Kitchen).ToArray();

            long[] averageCostsEntries =
                entries.Where(i => meridian.restaurant_entriesStore.Get(i).restaurant_entry_category_id == (long)RestaurantEntryCategory.AverageCost).ToArray();

            long[] discountsEntries =
                entries.Where(i => meridian.restaurant_entriesStore.Get(i).restaurant_entry_category_id == (long)RestaurantEntryCategory.Discounts).ToArray();

            long[] specialsEntries =
                entries.Where(i => meridian.restaurant_entriesStore.Get(i).restaurant_entry_category_id == (long)RestaurantEntryCategory.Specials).ToArray();

            if (kitchenEntries.Length > 0)
            {
                query = query.Where(e => e.GetEntries(RestaurantEntryCategory.Kitchen)
                                             .Select(i => i.Id).Intersect(kitchenEntries).Any());
            }

            if (averageCostsEntries.Length > 0)
            {
                query = query.Where(e => e.GetEntries(RestaurantEntryCategory.AverageCost)
                                             .Select(i => i.Id).Intersect(averageCostsEntries).Any());
            }

            if (discountsEntries.Length > 0)
            {
                query = query.Where(e => e.GetEntries(RestaurantEntryCategory.Discounts)
                                             .Select(i => i.Id).Intersect(discountsEntries).Any());
            }

            if (specialsEntries.Length > 0)
            {
                query = query.Where(e => e.GetEntries(RestaurantEntryCategory.Specials)
                                             .Select(i => i.Id).Intersect(specialsEntries).Any());
            }

            return query;
        }

        public static RestaurantsReserveListViewModel GetRestaurantsReserveListViewModel(this Meridian meridian, long userId, int page = 1, int pageSize = 12)
        {
            var aStore = Meridian.Default.accountsStore;
            var rStore = Meridian.Default.restaurantsStore;

            var query = meridian.restaurants_reserveStore.All()
                .Where(r => r.account_id == userId && rStore.Exists(r.restaraunt_id))
                .OrderByDescending(r => r.create_date);
            return new RestaurantsReserveListViewModel
            {
                CurrentPage = page,
                TotalPages = MappingUtils.CalculatePagesCount(query.Count(), pageSize),
                User = aStore.Exists(userId) ? aStore.Get(userId).ToAccount() : null,
                Items = MappingUtils.TakePage(query, page, pageSize).Select(r => r.ToModel())
            };
        }

        public static RestaurantsReserveViewModel ToModel(this restaurants_reserve rr)
        { 
            var rStore = Meridian.Default.restaurantsStore;
            if (!rStore.Exists(rr.restaraunt_id)) 
                return null;

            return new RestaurantsReserveViewModel(rr.id)
            {
                CreateDate = rr.create_date,
                VisitDate = rr.visit_date,
                PersonCount = rr.persons_count,
                Phone = rr.phone,
                ContactPerson = rr.contact,
                Restaurant = rStore.Get(rr.restaraunt_id).ToRestaurantViewModel(true)
            };
        }
    }
}