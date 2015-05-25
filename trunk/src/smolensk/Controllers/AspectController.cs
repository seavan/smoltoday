using System.Web.Mvc;
using admin.db;
using meridian.smolensk.system;

namespace smolensk.Controllers
{
    public class AspectController<I> : Controller where I : class
    {
        [HttpPost]
        public void Delete(string proto, long id)
        {
            Meridian.Default.DeleteAs<I>(proto, id);
        }

        protected void Update(string proto, long id)
        {
            Meridian.Default.UpdateAs<I>(proto, id);
        }

        protected I Get(string proto, long id)
        {
            return Meridian.Default.GetAs<I>(proto, id);
        }


    }
}