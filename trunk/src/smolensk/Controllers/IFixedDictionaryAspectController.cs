using System.Web.Mvc;
using admin.db;
using meridian.smolensk.proto;
using meridian.smolensk.system;

namespace smolensk.Controllers
{
    /// <summary>
    /// aspect for fixed (combo-written) values list
    /// </summary>
    public class IFixedDictionaryAspectController : AspectController<IDictionaryValue>
    {

        public IFixedDictionaryAspectController()
        {
            
        }

        private IDictionaryValuesAspect GetProvider(string parentProto, long parentId, string field)
        {
            return Meridian.Default.GetAs<IDictionaryValuesAspectProvider>(parentProto, parentId).GetDictionaryValuesAspect(field);
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
            var allCats = provider.GetCategories();
            foreach (var cat in allCats)
            {
                if (cat.MultiValue)
                {
                    var availableValues = cat.GetAllValues();

                    foreach (var a in availableValues)
                    {
                        var fname = string.Format("{0}.{1}.value.{2}", field, cat.id, a.ValueId);

                        if (cat.Selectable)
                        {
                            var cname = string.Format("{0}.{1}.value_c", field, cat.id);

                            if (Request[fname] != null && Request[cname] != null)
                            {
                                provider.SetValue(cat.id, a.ValueId, string.Empty);
                            }
                            else
                                provider.RemoveValue(cat.id, a.ValueId);
                        }
                        else
                        {
                            if (Request[fname] != null)
                            {
                                provider.SetValue(cat.id, a.ValueId, string.Empty);
                            }
                            else
                                provider.RemoveValue(cat.id, a.ValueId);
                        }
                       
                        

                    }
                }
                else
                {
                    var fname = string.Format("{0}.{1}.value", field, cat.id);

                    if (Request[fname] != null)
                    {
                        var val = cat.FreeValue ? 0 : long.Parse(Request[fname]);
                        bool isSelect = true;

                        if (cat.Selectable)
                        {
                            var cname = string.Format("{0}_c", fname);
                            isSelect = Request[cname] != null;
                        }

                        if ((val != 0 || (val == 0 && cat.FreeValue)) && isSelect)
                            provider.SetValue(cat.id, val, Request[fname]);
                        else
                            provider.RemoveValue(cat.id);
                    }            
                }

            }
            //var parent = GetProvider();
            //parent.Get()
            return Json(new object());
        }
    }
}