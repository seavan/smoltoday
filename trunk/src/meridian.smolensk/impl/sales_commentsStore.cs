using System.Collections.Generic;
using System.Linq;
using meridian.smolensk.proto;

namespace meridian.smolensk.protoStore
{
    public partial class sales_commentsStore
    {
        public int UpdateNestedSets(long saleId, long parId, int level, int lk)
        {
            var comments = GetAll().Where(c => c.sale_id.Equals(saleId) && c.parent_id.Equals(parId));

            int curLevel;
            int curRK;
            int curLK;
            int comCur = lk;

            foreach (var comment in comments)
            {
                ++comCur;
                curLK = comCur;

                curLevel = level + 1;

                curRK = UpdateNestedSets(saleId, comment.id, curLevel, curLK);

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
