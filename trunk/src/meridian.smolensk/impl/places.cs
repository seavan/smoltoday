using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using meridian.smolensk.system;

namespace meridian.smolensk.proto
{
    public partial class places : IMarkable, IGeoLocation, ILookupValue
    {
        public void SetMark(IMark mark)
        {
            var m_mark = Meridian.Default.places_ratingStore.All()
                .FirstOrDefault(m => m.account_id.Equals(mark.AuthorId) && m.place_id.Equals(this.id));

            if (m_mark == null)
            {
                m_mark = new places_rating
                {
                    account_id = mark.AuthorId,
                    create_date = mark.CreateDate,
                    rating = mark.CMark,
                    place_id = this.id
                };

                Meridian.Default.places_ratingStore.Insert(m_mark);
            }
            else
            {
                m_mark.rating = mark.CMark;
                m_mark.create_date = mark.CreateDate;
                Meridian.Default.places_ratingStore.Update(m_mark);
            }
        }

        public int GetRating()
        {
            var marks = Meridian.Default.places_ratingStore.All().Where(m => m.place_id.Equals(this.id));

            int count = marks.Count();
            if (count <= 0)
                return 0;

            return (int)Math.Floor((double)(marks.Sum(m => m.rating) / marks.Count()));
        }

        public int GetCountMarks()
        {
            var marks = Meridian.Default.places_ratingStore.All().Where(m => m.place_id.Equals(this.id));
            int count = marks.Count();
            return count <= 0 ? 0 : count;
        }
        public Uri ItemUri()
        {
            string uri = string.Format("/Poster/Place/{0}", this.id);

            return new Uri(uri, UriKind.Relative);
        }

        #region IGeoLocation Implementation
        public string GeoLocationCoordinates { get { return this.coordinates; } }
        public string GeoLocationTitle { get { return this.title; } }
        public string GeoLocationDescription { get { return this.adress; } }
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
            return "Места";
        }
        #endregion


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
