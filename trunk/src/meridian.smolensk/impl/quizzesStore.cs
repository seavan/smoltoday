using System.Linq;
using meridian.smolensk.proto;
using meridian.smolensk.system;

namespace meridian.smolensk.protoStore
{
    public partial class quizzesStore
    {
        public quizzes GetCurrent()
        {
            return Meridian.Default.quizzesStore.All()
                .Where(q => q.is_main)
                .OrderByDescending(q => q.datetime_publish)
                .FirstOrDefault();
        }
    }
}
