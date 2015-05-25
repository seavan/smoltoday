using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Telerik.Web.Mvc;
using Telerik.Web.Mvc.UI;
using System.Data.Linq;
using admin.db;
using System.Collections;
using System.Web.Caching;
using System.IO;
using System.Reflection;

namespace admin.web.common
{

    public static class MeridianWebUtilities
    {
        public static string ReplaceDivP(string source)
        {
            return source.Replace("<div>", "<p>").Replace("</div>", "</p>");
        }

        public static string UploadFileWithExtension(HttpPostedFileBase uploadedFile, string targetPath)
        {
            var extension = Path.GetExtension(uploadedFile.FileName);
            var targetFName = Guid.NewGuid().ToString() + extension;
            using (FileStream stream = new FileStream(targetPath + targetFName, FileMode.Create))
            {
                uploadedFile.InputStream.CopyTo(stream);
            }

            return targetFName;
        }
        
    }

    public abstract class BaseUniversalController<_T> : BasicController where _T : class, IDatabaseEntity, new()
    {
        public BaseUniversalController()
        {
            ViewData["BaseController"] = GetType().Name.Replace("Controller", "");
            ValidateRequest = false;
            DefaultUploadVirtualFolder = CommonConstants.DefaultUploadVirtualFolder;
        }

        /// <summary>
        /// виртуальный путь на сервере
        /// </summary>
        protected string DefaultUploadVirtualFolder
        {
            get { return _mDefaultUploadVirtualFolder; }
            set { _mDefaultUploadVirtualFolder = value;
                if(!string.IsNullOrEmpty(_mDefaultUploadVirtualFolder))
                {
                    DefaultUploadPhysicalPath = CommonFileSystemFolders.MapPath(_mDefaultUploadVirtualFolder);

                };
            }
        }

        private string _mDefaultUploadVirtualFolder;

        /// <summary>
        /// физический путь к файлу
        /// </summary>
        protected string DefaultUploadPhysicalPath;

        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase upload)
        {
            var funcNum = Request["CKEditorFuncNum"];
            var uploadPath = DefaultUploadVirtualFolder;
            try
            {
                string name = MeridianWebUtilities.UploadFileWithExtension(upload, DefaultUploadPhysicalPath);
                if (!string.IsNullOrEmpty(name))
                {
                    string url = uploadPath + name;

                    return
                        Content("<script type='text/javascript'>window.parent.CKEDITOR.tools.callFunction(" + funcNum +
                                ", '" + url + "', '');</script>");
                }
            }
            catch (System.Exception _e)
            {

            }

            return Content("<script type='text/javascript'>window.parent.CKEDITOR.tools.callFunction(" + funcNum + ", '', 'Произошла ошибка при загрузке файла на сервер.');</script>");
        }



        public ActionResult UploadTelerik(string relation, long parentId)
        {
            var item = GetSingle(parentId);
            foreach (var f in Request.Files)
            {
                var file = Request.Files[f.ToString()];
                if (file == null)
                {
                    continue;
                }
                // Some browsers send file names with full path. This needs to be stripped.
                string name = MeridianWebUtilities.UploadFileWithExtension(file, DefaultUploadPhysicalPath);
                if (!string.IsNullOrEmpty(name))
                {
                    string url = DefaultUploadVirtualFolder + name;
                    ProcessUploadedFile(item, file, name, DefaultUploadPhysicalPath + name, url);
                }
            }
            // Return an empty string to signify success
            return Content("");
        }        

        public virtual void ProcessUploadedFile(_T _model, HttpPostedFileBase _file, string _name, string _path, string _url)
        {
            
        }


        public void InitUniqueId(bool rewrite = false)
        {
            HttpCookie cookie = Request.Cookies["zuid"];
            if (cookie == null || rewrite)
            {
                cookie = new HttpCookie("zuid", Guid.NewGuid().ToString());
                cookie.Expires = DateTime.Now.AddMinutes(20);
                cookie.Domain = AdminExtension.GetHost();
                Response.Cookies.Add(cookie);
            }
        }
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            InitUniqueId();
            base.OnActionExecuting(filterContext);
        }

        public ActionResult UploadField()
        {
            var file = Request.Files[0];
            // Some browsers send file names with full path. This needs to be stripped.
            var fileName = Path.GetFileName(file.FileName);
            var physicalPath = Path.Combine(Server.MapPath("~/Content/temp"), fileName);

            // The files are not actually saved in this demo
            file.SaveAs(physicalPath);

            return Content("");
        }

        

        public void UploadFields(_T _item)
        {
            for(int i = 0; i < Request.Files.AllKeys.Length; ++i)
            {
                var field = Request.Files.AllKeys[i];
                var file = Request.Files[field];
                var prop = _item.GetType().GetProperty(field);
                var atts = prop.GetCustomAttributes(true);
                var upload = atts.OfType<UploadAttribute>().FirstOrDefault();
                
                if( upload != null )
                {
                    if (!String.IsNullOrEmpty(upload.OriginalFileNameField))
                    {
                        var prop2 = _item.GetType().GetProperty(upload.OriginalFileNameField);
                        prop2.SetValue(_item, file.FileName, new object[] { });                    
                    }

                    var fname = Guid.NewGuid().ToString() + "." + upload.UploadExtension;
                    foreach(var d in upload.UploadDirectories)
                    {
                        var path = Server.MapPath("~" + d);
                        if(Directory.Exists(path))
                        {
                            path = (Path.Combine(path, fname));
                            upload.ParseObject(file.InputStream, file.ContentType, file.ContentLength, file.FileName, path, field);
                        }
                    }

                    prop.SetValue(_item, fname, new object[] { });                    
                }



            }
        }

        [GridAction]
        public virtual ActionResult Popup(PopupData popupData = null)
        {
            m_PopupData = popupData;
            return View(GetAll());
        }

        protected PopupData m_PopupData;

        [GridAction]
        public virtual ActionResult Index()
        {
            return View(GetAll());
        }


        [GridAction]
        public virtual ActionResult _Select(string jsData = null)
        {
            if (!String.IsNullOrEmpty(jsData))
            {
                m_PopupData = new PopupData()
                    {
                        FormData = (new JavaScriptSerializer()).Deserialize<Dictionary<string, string>>(jsData)
                    };
            }
            var items = GetAll();
            return View(new GridModel(
                items
                ));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [GridAction]
        public ActionResult _InsertChildren(string _child, long _parentId)
        {
            var item = GetSingle(_parentId);
            var obj = m_ChildCreators[_child](item);
            if (m_ChildUpdaters[_child](item, obj))
            {
                m_ChildInserters[_child](item, obj);
                Service.Update(item);
                SubmitChanges();
                item = GetSingle(_parentId);
            }
            return View(new GridModel(
                m_ChildSelectors[_child](item)
                ));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [GridAction]
        public ActionResult _UpdateChildren(long id, string _child, long _parentId)
        {
            var item = GetSingle(_parentId);
            var obj = m_ChildSelectors[_child](item).Cast<IDatabaseEntity>().Single(s => s.id.Equals(id));
            if (m_ChildUpdaters[_child](item, obj))
            {
                Service.Update(item);
                SubmitChanges();
                item = GetSingle(_parentId);
            }
            return View(new GridModel(
                m_ChildSelectors[_child](item)
                ));
        }

        [GridAction]
        public virtual ActionResult _DeleteChildren(long id, string _child, long _parentId)
        {
            var item = GetSingle(_parentId);
            m_ChildDeleters[_child](item, id);
            item = GetSingle(_parentId);
            return View(new GridModel(
                m_ChildSelectors[_child](item)
                ));
        }

        [GridAction]
        public virtual ActionResult _SelectChildren(string _child, long _parentId)
        {
            var item = GetSingle(_parentId);
            return View(new GridModel(
                m_ChildSelectors[_child](item)
                ));
        }

        public void RegisterChild(string _name, Func<_T, IEnumerable> _selector,
            Func<_T, object> _creator = null, Func<_T, object, object> _inserter = null, Func<_T, object, bool> _updater = null, Action<_T, long> _deleter = null)
        {
            m_ChildSelectors[_name] = _selector;
            m_ChildInserters[_name] = _inserter;
            m_ChildCreators[_name] = _creator;
            m_ChildUpdaters[_name] = _updater;
            m_ChildDeleters[_name] = _deleter;
        }

        private SortedList<string, Func<_T, IEnumerable>> m_ChildSelectors = new SortedList<string, Func<_T, IEnumerable>>();
        private SortedList<string, Func<_T, object, object>> m_ChildInserters = new SortedList<string, Func<_T, object, object>>();
        private SortedList<string, Func<_T, object>> m_ChildCreators = new SortedList<string, Func<_T, object>>();
        private SortedList<string, Func<_T, object, bool>> m_ChildUpdaters = new SortedList<string, Func<_T, object, bool>>();
        private SortedList<string, Action<_T, long>> m_ChildDeleters = new SortedList<string, Action<_T, long>>();


        [AcceptVerbs(HttpVerbs.Post)]
        [GridAction]
        public ActionResult _UpdateServer(int id)
        {
            if (ModelState.IsValid)
            {
                var updating = GetSingle(id);

                UpdateModel(updating);
                Prepare(updating);
                Service.Update(updating);
                SubmitChanges();
            }
            return View("Index", GetAll());
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [GridAction]
        public virtual ActionResult _Update([Bind]_T item)
        {
            if (ModelState.IsValid)
            {
                item = GetSingle(item.id);
                TryUpdateModel(item);
                Prepare(item);
                Service.Update(item);
                SubmitChanges();
            }
            return View(new GridModel(GetAll()));
        }


        [AcceptVerbs(HttpVerbs.Post)]
        [GridAction]
        public ActionResult _Insert([Bind(Exclude="id")] _T _item)
        {
            if (ModelState.IsValid)
            {
                InsertNew(_item);
            }
            return View(new GridModel(GetAll()));
        }
        
        
        [GridAction]
        public ActionResult _DeleteServer(int id)
        {
            var data = GetSingle(id);
            if (data != null)
            {
                Delete(data);
            }
            return RedirectToAction("Index");
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [GridAction]
        public virtual ActionResult _Delete()
        {
            var id = int.Parse(Request["id"]);
            var data = GetSingle(id);
            if (data != null)
            {
                Delete(data);
 

            }
            return View(new GridModel(GetAll()));
        }



        public virtual _T Create()
        {
            return Service.CreateItem();
        }

        public virtual _T GetSingle(long _id)
        {
            return Service.GetById(_id);
        }

        public virtual IEnumerable<_T> GetAll()
        {
            return Filter(Service.GetAll());
            //return GetTable().AsEnumerable();
        }

        public virtual void InsertNew(_T _item)
        {
            Prepare(_item);
            Service.Insert(_item);
            Service.Commit();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [GridAction]
        public virtual ActionResult Delete(_T _item)
        {
            PrepareDelete(_item);
            
            Service.Delete(_item);
            Service.Commit();
            return View(new GridModel(GetAll()));
        }

        public virtual void SubmitChanges()
        {
            Service.Commit();
            //model.Context.Default.SubmitChanges();
        }

        public ActionResult List()
        {
            return View(new GridModel(GetAll()));
        }

        [ValidateInput(false)]
        public ActionResult Single(long id = 0)
        {
            _T _function = Create();
            if (Request.HttpMethod == "POST")
            {
                if( id > 0 )
                {
                    _function = Service.GetById(id);
                    PrepareOld(_function);
                }
                
                if (TryUpdateModel(_function))
                {
                    UploadFields(_function);
                    Prepare(_function);
                    Service.Update(_function);
                    _function =
                        Service.GetById(_function.id);
                    AfterAll(_function);
                    return RedirectToAction("Single", new {id = _function.id});
                }
                else
                {
                    return View(_function);    
                }
                

            }

            if (id > 0)
            {
                ViewData["ObjectId"] = id;
                _function = Service.GetById(id);
            }
            else
            {

                _function = Service.CreateItem();
            }

            Prepare(_function);
            
            return View(_function);
        }

        public ActionResult SingleInline(string _parentAction = null, string _parentController = null, long _parentId = 0)
        {
            if (Request.HttpMethod == "POST")
            {
                Single();
                return RedirectToAction(_parentAction, _parentController, new { id = _parentId });
            }
            return View(new _T());
        }

        [ValidateInput(false)]
        public ActionResult View(long id)
        {
            return Single(id);
        }

        public virtual void Prepare(_T _item)
        {
        }

        public virtual void PrepareOld(_T _item)
        {
        }


        public virtual void PrepareDelete(_T _item)
        {
        }

        public virtual void AfterAll(_T _item)
        {
            
        }

        protected abstract IDataService<_T> GetService();

        protected virtual IQueryable<_T> Filter(IQueryable<_T> _src)
        {
            return _src;
        }

        public IDataService<_T> Service
        {
            get
            {
                if( m_Service == null )
                {
                    m_Service = GetService();
                }

                return m_Service;
            }
        }


     

        protected IDataService<_T> m_Service;
    }
}
