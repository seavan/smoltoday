using System;
using System.Linq;
using System.Web.Mvc;
using admin.db;
using meridian.smolensk.proto;
using meridian.smolensk.system;
using System.Globalization;
using System.Collections.Generic;

namespace smolensk.Controllers
{
    /// <summary>
    /// aspect for fixed (combo-written) values list
    /// </summary>
    public class IScheduleAspectController : AspectController<IDatabaseEntity>
    {

        public IScheduleAspectController()
        {

        }

        private IScheduleAspect GetProvider(string parentProto, long parentId, string field)
        {
            return Meridian.Default.GetAs<IScheduleAspectProvider>(parentProto, parentId).GetScheduleAspect(field);
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
            var availableValues = provider.GetAvalablePlaces();
            foreach (var a in availableValues)
            {
                provider.ClearSchedule(a.id);
                var cont = true;
                int i = 1;
                while (cont)
                {
                    var fnameDate = string.Format("{0}.{1}.date.{2}", field, a.id, i);
                    var fnameTime = string.Format("{0}.{1}.time.{2}", field, a.id, i);
                    i++;
                    if (Request[fnameDate] == null)
                        cont = false;
                    else
                    {
                        var val = Request[fnameDate].Trim();
                        DateTime date = DateTime.MinValue;
                        if (!DateTime.TryParse(val, out date))
                            continue;

                        foreach (var d in ParseTime(date, Request[fnameTime]))
                            provider.SetSchedule(a.id, d);
                    }
                }
            } 
            return Json(new object());
        }

        private IEnumerable<DateTime> ParseTime(DateTime date, string value)
        {
            var list = new List<DateTime>();
            var d = date.Date;
            if (value != null && !String.IsNullOrEmpty(value.Trim()))
            {
                var items = value.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var item in items)
                {
                    var parts = item.Trim().Split(':');
                    int hour = 0;
                    int minute = 0;
                    if (parts.Length > 1 && int.TryParse(parts[0], out hour) && int.TryParse(parts[1], out minute)
                        && hour >= 0 && hour < 24 && minute >= 0 && minute < 60)
                    {
                        list.Add(d.AddHours(hour).AddMinutes(minute));
                    }
                }
            }
            else
                list.Add(d);
            return list;
        }
    }
}