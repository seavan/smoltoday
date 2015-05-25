using System.Web.Mvc;
using meridian.smolensk.proto;
using meridian.smolensk.system;

namespace smolensk.Controllers
{
    /// <summary>
    /// aspect for fixed (combo-written) values list
    /// </summary>
    public class IOneToManyAspectController : AspectController<ILookupValue>
    {

        public IOneToManyAspectController()
        {

        }

        private IOneToManyAspect GetProvider(string parentProto, long parentId, string field)
        {
            return Meridian.Default.GetAs<IOneToManyAspectProvider>(parentProto, parentId).GetOneToManyAspect(field);
        }

        public ActionResult Edit(string parentProto, long parentId, string field)
        {
            var provider = GetProvider(parentProto, parentId, field);
            return View(provider);
        }

        [HttpPost]
        public JsonResult Save(string parentProto, long parentId, string categoriesProto, string field)
        {
            var provider = GetProvider(parentProto, parentId, field);
            var availableValues = provider.GetAvalableValues();
            foreach (var a in availableValues)
            {
                var fname = string.Format("{0}.value.{1}", field, a.id);
                if (Request[fname] != null)
                {
                    provider.SetValue(a.id);
                }
                else
                    provider.RemoveValue(a.id);
            }
            return Json(new object());
        }
    }
}