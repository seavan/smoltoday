using System;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using admin.db;
using meridian.smolensk;
using meridian.smolensk.proto;
using meridian.smolensk.system;

namespace meridian.smolensk.protoStore
{
    public partial class company_commentsStore : IDataService<company_comments>
    {
   

        void IDataService<company_comments>.Insert(company_comments item)
        {
            Insert(item);
            UpdateNestedSets(item.company_id, item.parent_id, item.level, item.left_key);
        }

        void IDataService<company_comments>.Delete(company_comments item)
        {
            Delete(item);
        }

       
        void IDataService<company_comments>.Update(company_comments item)
        {
            Persist(item);
        }

        public int UpdateNestedSets(long companyId, long parId, int level, int lk)
        {
            var comments = GetAll().Where(c => c.company_id.Equals(companyId) && c.parent_id.Equals(parId));

            int curLevel;
            int curRK;
            int curLK;
            int comCur = lk;

            foreach (var comment in comments)
            {
                ++comCur;
                curLK = comCur;

                curLevel = level + 1;

                curRK = UpdateNestedSets(companyId, comment.id, curLevel, curLK);

                comCur = curRK;

                comment.left_key = curLK;
                comment.right_key = curRK;
                comment.level = level;

                Update(comment);
            }

            ++comCur;

            return comCur;

        }

        public IEnumerable<IComment> LoadUserComments(long account_id)
        {
            return GetAll().Where(c => c.account_id == account_id);
        }
    }
}
