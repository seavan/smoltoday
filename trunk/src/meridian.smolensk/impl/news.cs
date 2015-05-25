using System;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using meridian.smolensk;
using meridian.smolensk.system;
using admin.db;
using System.ComponentModel.DataAnnotations;
using smolensk.common;

namespace meridian.smolensk.proto
{
    public partial class news : IDatabaseEntity, ICommentable, IMarkable, IMainSlider
	{
        public bool can_comment { get { return true; } }
        IEnumerable<string> GetTags()
        {
            return String.IsNullOrEmpty(tags) ? new string[] {} : tags.ToLower().Split(',');
        }
        public string[] GetTagsArray()
        {
            return GetTags().ToArray();
        }

        public IEnumerable<IComment> GetComments()
        {
            // refer to meridian comments
            return this.GetNewsComments().OrderByDescending(c=>c.create_date);
        }

        public IComment AddComment(IComment comment)
        {
            comments_news cc = new comments_news
                                   {
                                       account_id = comment.AuthorId,
                                       text = comment.CommentText,
                                       create_date = comment.CreateDate,
                                       delete = comment.delete,
                                       left_key = comment.LeftKey,
                                       level = comment.level,
                                       news_id = this.id,
                                       parent_id = comment.ParentId,
                                       right_key = comment.RightKey
                                   };
            Meridian.Default.comments_newsStore.Insert(cc);
            Meridian.Default.comments_newsStore.UpdateNestedSets(cc.news_id, cc.parent_id, cc.level, cc.left_key);

            this.comment_count = Meridian.Default.comments_newsStore.All().Where(m => m.news_id.Equals(this.id)).Count();
            Meridian.Default.newsStore.Update(this);

            var acc = Meridian.Default.accountsStore.Get(comment.AuthorId);
            acc.comments_count += 1;
            Meridian.Default.accountsStore.Update(acc);

            return cc;
        }

        public void DeleteComment(long id)
        {
            if(Meridian.Default.comments_newsStore.Exists(id))
            {
                var commment = Meridian.Default.comments_newsStore.GetById(id);
                Meridian.Default.comments_newsStore.Delete(commment);
            }
        }
        
        public void SetMark(IMark mark)
        {
            news_marks m_mark = Meridian.Default.news_marksStore.All().FirstOrDefault(m => m.account_id.Equals(mark.AuthorId) && m.news_id.Equals(this.id));

            if (m_mark == null)
            {
                m_mark = new news_marks
                             {
                                 account_id = mark.AuthorId,
                                 create_date = mark.CreateDate,
                                 mark = mark.CMark,
                                 news_id = this.id
                             };

                Meridian.Default.news_marksStore.Insert(m_mark);
            }
            else
            {
                m_mark.mark = mark.CMark;
                m_mark.create_date = mark.CreateDate;
                Meridian.Default.news_marksStore.Update(m_mark);
            }



            this.rating = GetRating();
            Meridian.Default.newsStore.Update(this);

        }

        public int GetRating()
        {
            var marks = Meridian.Default.news_marksStore.All().Where(m => m.news_id.Equals(this.id));

            int count = marks.Count();
            if (count <= 0)
                return 0;

            return (int)Math.Floor( (double)(marks.Sum(m => m.mark) / marks.Count()) );
        }

        public bool isReview { get { return false; } }

        public int GetCountMarks()
        {
            var marks = Meridian.Default.news_marksStore.All().Where(m => m.news_id.Equals(this.id));
            int count = marks.Count();
            return count <= 0 ? 0 : count;
        }

        public Uri ItemUri()
        {
            string uri = string.Format("/News/Single/{0}/{1}", this.id, this.title.TransliterateAndClear());

            return new Uri(uri, UriKind.Relative);
        }

        public IEnumerable<news> GetRelatedNews(int count = 3)
        {
            return Meridian.Default.newsStore.LoadNewsByCategory(this.category_id)
                .Where(s => s.id != this.id)
                .OrderByDescending(s => s.id)
                .Take(count);
        }

        #region Implementation IMainSlider
        public Uri ItemMainUri
        {
            get { return new Uri(string.Format("{0}{1}", ItemUri().ToString(), "#menuTop"), UriKind.Relative); }
        }

        public Uri GetImgItemMainUri()
        {
            var img = Meridian.Default.news_imagesStore.LoadImages(this.id).FirstOrDefault();
            if (img == null)
                return null;

            UrlBuilder urlBuilder = new UrlBuilder();
            return urlBuilder.BuildNewsImageUri(this.id, img.normal_thumbnail);
        }
        #endregion

        public IEnumerable<IImageByTheme> GetImagesByTheme(int skip = 0, bool withPhotoBank = true, int count = 16)
        {
            string[] baseTags = GetTagsArray();
            List<IImageByTheme> listImg = new List<IImageByTheme>();
            List<IImageByTheme> listPhoto = new List<IImageByTheme>();
            foreach (var baseTag in baseTags)
            {
                listImg.AddRange(Meridian.Default.news_imagesStore.LoadImagesByTheme(baseTag));

                if(withPhotoBank)
                {
                    listPhoto.AddRange(Meridian.Default.photobank_photo_tagsStore.LoadPhotosByTheme(baseTag));
                }
            }

            listImg = listImg.Distinct(new IImageByThemeComparer()).ToList();
            listPhoto = listPhoto.Distinct(new IImageByThemeComparer()).ToList();
            listImg.AddRange(listPhoto.AsEnumerable());

            return listImg.Skip(skip).Take(count);
        }

        public void IncrementViews()
        {
            lock (this)
            {
                this.views++;
            }
        }

        public IEnumerable<IImageByTheme> GetVideosByTheme(int skip = 0, int count = 12)
        {
            string[] baseTags = GetTagsArray();
            
            List<IImageByTheme> listVideo = new List<IImageByTheme>();
            foreach (var baseTag in baseTags)
            {
                listVideo.AddRange(Meridian.Default.news_videosStore.LoadVideosByTheme(baseTag));
            }

            return listVideo.Distinct(new IImageByThemeComparer()).Skip(skip).Take(count);
        }
    }
}
