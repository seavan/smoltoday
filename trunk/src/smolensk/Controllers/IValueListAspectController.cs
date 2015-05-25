using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using admin.db;
using meridian.smolensk.proto;
using meridian.smolensk.system;

namespace smolensk.Controllers
{
    /// <summary>
    /// aspect for fixed (combo-written) values list
    /// </summary>
    public class IValueListAspectController : AspectController<IValueListItem>
    {

        public IValueListAspectController()
        {
            
        }

        private IValueListAspect GetProvider(string parentProto, long parentId, string field)
        {
            return Meridian.Default.GetAs<IValueListAspectProvider>(parentProto, parentId).GetValueListAspect(field);
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
            var allVals = provider.GetAllValues().ToArray();
            var result = new SortedList<string, string>();
            foreach (var val in allVals)
            {
                var fname = string.Format("{0}.{1}", field, val.id);
                var resultField = string.Format("{0}.result", fname);
                if (Request[fname] != null)
                {
                    var newVal = Request[fname];
                    var valItem = Get(provider.ProtoName, val.id);
                    if (!string.IsNullOrEmpty(newVal))
                    {
                        valItem.Value = newVal;
                        Meridian.Default.UpdateAs<IValueListItem>(provider.ProtoName, val.id);
                        result[resultField] = "ok";
                    }
                    else
                    {
                        if (val.IsUsed)
                        {
                            result[resultField] =
                                "Значение используется. Удалите значение из объектов, которые его используют, чтобы удалить его";
                        }
                        else
                        {
                            Meridian.Default.DeleteAs<IValueListItem>(provider.ProtoName, val.id);    
                        }
                        
                    }
                }
            }

            var newField = string.Format("{0}.new", field);
            var index = 0;
            while (Request[newField] != null)
            {
                var newVal = Request[newField];

                if (!string.IsNullOrEmpty(newVal))
                {
                    provider.Create(newVal);
                }

                newField = string.Format("{0}.new.{1}", field, index++);
            }

            return Json(result);
            // fix broken
            //var parent = GetProvider();
            //parent.Get()
        }


    }
}