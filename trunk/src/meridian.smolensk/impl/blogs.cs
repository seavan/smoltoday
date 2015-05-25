using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using MySql.Data.MySqlClient;
using meridian.smolensk;
using meridian.smolensk.system;
using admin.db;

namespace meridian.smolensk.proto
{
    public partial class blogs : IDatabaseEntity, ICommentable, IMarkable, ILookupValueAspectProvider
	{
        public ILookupValueAspect Getcategory_idLookupValueAspect()
        {
            return new LookupAspect("category_id", this, () => Meridian.Default.blog_categoriesStore.All());
        }

        public ILookupValueAspect Getaccount_idLookupValueAspect()
        {
            return new LookupAspect("account_id", this, () => Meridian.Default.accountsStore.All().OrderBy(s => s.ShortName));
        }

        public IEnumerable<IComment> GetComments()
        {
            return this.GetBlogComments().OrderBy(c => c.create_date); //Meridian.Default.blog_commentsStore.GetAll().Where(c => c.blog_id.Equals(this.id)).OrderBy(c => c.create_date);
        }

        public IComment AddComment(IComment comment)
        {
            blog_comments cc = new blog_comments
            {
                account_id = comment.AuthorId,
                text = comment.CommentText,
                create_date = comment.CreateDate,
                delete = comment.delete,
                left_key = comment.LeftKey,
                level = comment.level,
                blog_id = this.id,
                parent_id = comment.ParentId,
                right_key = comment.RightKey
            };
            Meridian.Default.blog_commentsStore.Insert(cc);
            Meridian.Default.blog_commentsStore.UpdateNestedSets(cc.blog_id, cc.parent_id, cc.level, cc.left_key);
            var acc = Meridian.Default.accountsStore.Get(comment.AuthorId);
            acc.comments_count += 1;
            Meridian.Default.accountsStore.Update(acc);

            this.comment_count = Meridian.Default.blog_commentsStore.All().Where(m => m.blog_id.Equals(this.id)).Count();
            Meridian.Default.blogsStore.Update(this);

            return cc;
        }

        public void DeleteComment(long id)
        {
            if (Meridian.Default.blog_commentsStore.Exists(id))
            {
                var commment = Meridian.Default.blog_commentsStore.GetById(id);
                Meridian.Default.blog_commentsStore.Delete(commment);
            }
        }

        public void SetMark(IMark mark)
        {
            blog_marks m_mark = Meridian.Default.blog_marksStore.All().FirstOrDefault(m => m.account_id.Equals(mark.AuthorId) && m.blog_id.Equals(this.id));

            if (m_mark == null)
            {
                m_mark = new blog_marks()
                {
                    account_id = mark.AuthorId,
                    create_date = mark.CreateDate,
                    mark = mark.CMark,
                    blog_id = this.id
                };

                Meridian.Default.blog_marksStore.Insert(m_mark);
            }
            else
            {
                m_mark.mark = mark.CMark;
                m_mark.create_date = mark.CreateDate;
                Meridian.Default.blog_marksStore.Update(m_mark);
            }



            this.rating = GetRating();
            Meridian.Default.blogsStore.Update(this);

        }

        public int GetRating()
        {
            int count = this.GetBlogMarks().Count();
            if (count <= 0)
                return 0;

            return (int)Math.Floor((double)(this.GetBlogMarks().Sum(m => m.mark) / count));
        }

        [ScaffoldColumn(false)]
        public bool isReview { get { return false; } }

        public int GetCountMarks()
        {
            return this.GetBlogMarks().Count();
        }
        
        public accounts GetUser()
        {
            return GetUserBlogsAccount();
        }

        public string CategoryName()
        {
            return this.GetCategoryBlogBlog_categorie() != null ? this.GetCategoryBlogBlog_categorie().title : "вне категорий";
        }
        public string UserName()
        {
            return this.GetUser() != null ? this.GetUser().NameAndSurname : "n/a";
        }
        public string UserCareer()
        {
            return this.GetUser() != null ? this.GetUser().career : string.Empty;
        }

        public void UpdateViews(long? account_id)
        {
            this.views += 1;
            Meridian.Default.blogsStore.Update(this);

            if (account_id.HasValue)
            {
                blog_lastviews r_view;
                var user = Meridian.Default.accountsStore.Get(account_id.Value);
                var ra_views = user.GetLastViewsBlogs(); // Список всех просмотренных акком блогов

                if(ra_views.Any(v=>v.blog_id == this.id)) //Среди просмотренных акком есть текущий блог - обновить дату
                {
                    r_view = ra_views.First(v => v.blog_id == this.id);
                    r_view.view_date = DateTime.Now;
                    Meridian.Default.blog_lastviewsStore.Update(r_view);
                }
                else if(ra_views.Count() >= 4) //Если число просмотренных акком 3 и более - берём с наименьшей датой и пересохраняем для текущей записи
                {
                    r_view = ra_views.OrderBy(v => v.view_date).First();
                    r_view.view_date = DateTime.Now;
                    r_view.blog_id = this.id;
                    Meridian.Default.blog_lastviewsStore.Update(r_view);
                }
                else //Если не смотрели и у акка не более 4х в истории - создаём новую
                {
                    r_view = new blog_lastviews
                                 {
                                     account_id = account_id.Value,
                                     blog_id = this.id,
                                     view_date = DateTime.Now
                                 };
                    Meridian.Default.blog_lastviewsStore.Insert(r_view);
                }
            }
        }

        public Uri ItemUri()
        {
            string uri = string.Format("/Blogs/One/{0}/{1}", this.id, this.title.TransliterateAndClear());

            return new Uri(uri, UriKind.Relative);
        }
	}
}
