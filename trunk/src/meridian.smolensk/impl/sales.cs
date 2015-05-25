using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using admin.db;
using meridian.smolensk.system;
using smolensk.common;

namespace meridian.smolensk.proto
{
    public partial class sales : IDatabaseEntity, ICommentable, IFavorite, ILookupValueAspectProvider, IAttachedPhotoAspectProvider
    {
        public static sales Create()
        {
            return new sales
            {
                publish_date = DateTime.Now
            };
        }
        
        public ILookupValueAspect Getcategory_idLookupValueAspect()
        {
            return new LookupAspect("category_id", this, () => { return Meridian.Default.sale_categoriesStore.All(); }, false);
        }

        public ILookupValueAspect Getcompany_idLookupValueAspect()
        {
            return new LookupAspect("company_id", this, () => { return Meridian.Default.companiesStore.All(); });
        }

        public ILookupValueAspect Getsale_type_idLookupValueAspect()
        {
            return new LookupAspect("sale_type_id", this, () => { return Meridian.Default.sale_typesStore.All(); }, false);

        }

        public IAttachedPhotoAspect GetAttachedPhotoAspect(string fieldName)
        {
            return new OnePhotoAspect<sales>(this, fieldName, Constants.SalesDataFolder);
        }

        public bool can_comment { get { return true; } }

        public IEnumerable<IComment> GetComments()
        {
            return Meridian.Default.sales_commentsStore.GetAll().Where(c => c.sale_id == id).OrderByDescending(c => c.create_date);
        }

        public IComment AddComment(IComment comment)
        {
            sales_comments cc = new sales_comments
            {
                account_id = comment.AuthorId,
                text = comment.CommentText,
                create_date = comment.CreateDate,
                delete = comment.delete,
                left_key = comment.LeftKey,
                level = comment.level,
                sale_id = this.id,
                parent_id = comment.ParentId,
                right_key = comment.RightKey
            };
            Meridian.Default.sales_commentsStore.Insert(cc);
            Meridian.Default.sales_commentsStore.UpdateNestedSets(cc.sale_id, cc.parent_id, cc.level, cc.left_key);
            var acc = Meridian.Default.accountsStore.Get(comment.AuthorId);
            acc.comments_count += 1;
            Meridian.Default.accountsStore.Update(acc);

            return cc;
        }

        public void DeleteComment(long id)
        {
            if (Meridian.Default.sales_commentsStore.Exists(id))
            {
                var commment = Meridian.Default.sales_commentsStore.GetById(id);
                Meridian.Default.sales_commentsStore.Delete(commment);
            }
        }

        public bool isReview { get { return true; } }

        public bool IsFavorite (long account_id)
        {
            return Meridian.Default.accounts_favoritesStore.All().Any(f => f.account_id == account_id && f.sale_id == this.id);
        }

        public void AddToFavorite(long account_id)
        {
            Meridian.Default.accounts_favoritesStore.Insert(
                new accounts_favorites() { account_id = account_id, sale_id = this.id });
        }

        public void DeleteFromFavorite(long account_id)
        {
            var fs = Meridian.Default.accounts_favoritesStore.All().FirstOrDefault(f => f.account_id == account_id && f.sale_id == this.id);
            if (fs == null) return;
            Meridian.Default.accounts_favoritesStore.Delete(fs);
        }

        public Uri ItemUri()
        {
            string uri = string.Format("Discounts/One/{0}/{1}", this.id, title.TransliterateAndClear());

            return new Uri(uri, UriKind.Relative);
        }

        
    }
}
