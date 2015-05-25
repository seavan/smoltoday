using System;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using meridian.smolensk;
using meridian.smolensk.system;
using meridian.smolensk.proto;
using admin.db;
using smolensk.common;

namespace meridian.smolensk.protoStore
{
    public partial class blogsStore : Meridian.IEntityStore, IDataService<blogs>
    {
        public IEnumerable<blogs> LoadBest(int count = int.MaxValue)
        {
            return All().Where(n => n.is_thebest && !n.is_delete && n.is_publish).OrderByDescending(n => n.publish_date).Take(count);
        }

        public IEnumerable<blogs> LoadLastViews(long account_id, int count = 3)
        {
            return Meridian.Default.blog_lastviewsStore.All().Where(v => v.account_id.Equals(account_id))
                .OrderByDescending(v => v.view_date)
                .Select(v => v.GetLastViewsBlog())
                .Take(count);
        }

        public IEnumerable<blogs> LoadInteresting(DateRange rangeDate, int count = Constants.BlogsPageSize)
        {
            return All()
                .Where(b => b.is_interesting && b.publish_date >= rangeDate.fromDate && b.publish_date <= rangeDate.toDate && !b.is_delete && b.is_publish)
                .OrderByDescending(b => b.rating).Take(count);
        }

        public IEnumerable<blogs> LoadList(SortingType sortingType = SortingType.Rating, long? categoryId = null, long? authorId = null, bool showPrivate = false)
        {
            var all = All().Where(b => !b.is_delete && (b.is_publish || b.is_publish != showPrivate)).AsEnumerable();
            switch (sortingType)
            {
                case SortingType.Novelty:
                    all = all.OrderByDescending(b => b.publish_date);
                    break;

                default:
                    all = all.OrderByDescending(b => b.rating);
                    break;
            }

            if (authorId.HasValue)
                all = all.Where(b => b.account_id.Equals(authorId.Value));

            if (categoryId.HasValue)
                all = all.Where(b => b.category_id.Equals(categoryId.Value));

            return all;
        }

        public IEnumerable<blogs> LoadForMain(int count = 3)
        {
            return All().Where(n => n.is_main && !n.is_delete && n.is_publish).OrderByDescending(n => n.publish_date).Take(count);
        }

        public IEnumerable<blogs> AllVisible()
        {
            return All().Where(b => !b.is_delete && b.is_publish);
        }

        blogs IDataService<blogs>.CreateItem()
        {
            return new blogs()
            {
                publish_date = DateTime.Now,
                create_date = DateTime.Now,
                can_comment = true
            };
        }
    }
}
