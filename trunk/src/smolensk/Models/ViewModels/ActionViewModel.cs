using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using smolensk.ViewModels;
using meridian.smolensk.proto;
using System.Text.RegularExpressions;
using smolensk.common;
using smolensk.Domain;
using smolensk.Mappers;

namespace smolensk.Models.ViewModels
{
    public class ActionViewModel : EntityBaseViewModel, INavigateableItem, ISocialLinks
    {
        public ActionViewModel(long id) : base(id)
        {
        }

        public string Title { get; set; }
        public string Text { get; set; }
        public int ParticipiantsCount { get; set; }
        public bool CanAddParticipiants { get; set; }
        public int AgeLimit { get; set; }
        public string AgeLimitPlus { get { return string.Format("{0}+", AgeLimit); } }
        public string NormalPhotoUrl { get; set; }
        public string ThumbnailUrl { get; set; }
        public string PhotoUrlForMain { get; set; }
        public DateTime CreateDate { get; set; }

        public ActionStatus Status { get; set; }

        public string Author { get; set; }    
        public string Producer { get; set; }  //Режисер 
        public string Statement { get; set; } //Постановка 
        public string Lecturer { get; set; }  //Лектор
        public string Performers { get; set; } //исполнители
        public int Duration { get; set; } //продолжительность
        public DateTime? Start_date { get; set; } //премьера
        public int PriceMin { get; set; } 
        public int PriceMax { get; set; } 
        public string Country { get; set; }

        public string Site { get; set; }
        public string GoogleLink { get; set; }
        public string FacebookLink { get; set; }
        public string TwitterLink { get; set; }
        public string VkLink { get; set; }
        public string MailLink { get; set; }
        public string OdnoklassnikiLink { get; set; }

        public ActionCategoryViewModel Category { get; set; }
        public IEnumerable<PlaceViewModel> Places { get; set; }
        public ScheduleFilterType ScheduleFilter { get; set; }

        public string Announce 
        { 
            get 
            {
                return TextHelper.TrimAnnounce(Title, Text, 5, 45, 34);
            } 
        }

        public IEnumerable<actions_schedule> Schedule { get; set; }
        public string GetSchedule(long placeId, DateTime day, string format)
        {
            var dts = Schedule.Where(s => s.GetPlace().id == placeId)
                .Select(s => s.datetime)
                .Where(dt => dt >= day && dt.Date.Equals(day.Date))
                .Select(dt => dt.ToString(format)).OrderBy(dt => dt);
            return string.Join(", ", dts);
        }

        public string FirstDateTitle
        {
            get
            {
                var date = new smolensk.Models.CodeModels.DateRange(Schedule.Count() > 0 ? Schedule.First().datetime : (DateTime?)null, null);
                return date.ToStringFormat(Formatter.GetNameOfDayOfMonth);
            }
        }

        public IEnumerable<string> Genres { get; set; }
        public string GenresList { get { return string.Join(", ", Genres); } }

        public PhotoScrollViewModel PhotoScroller { get; set; }

        public ICommentable Comments { get; set; }
        public IMarkable Marks { get; set; }

        public int Rating { get; set; }

        public string GetUri()
        {
            return string.Format("/Poster/Action/{0}/{1}", Id, Title.TransliterateAndClear());
        }

        public string GetHrefTitle()
        {
            return Title;
        } 
    }
}