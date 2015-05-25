using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using admin.db;
using admin.web.common;
using meridian.smolensk.proto;
using meridian.smolensk.system;

namespace smolensk.Controllers
{
    public class IAttachedPhotoAspectController : AspectController<IAttachedPhoto>
    {
        IAttachedPhotoAspectProvider GetModel(string protoName, long id)
        {
            return Meridian.Default.GetAs<IAttachedPhotoAspectProvider>(protoName, id);
        }

        public ActionResult ImageEdit(long id, string protoName, string fieldName)
        {
            if (id <= 0)
            {
                return new JsonResult();
            }
            ViewData["fieldName"] = fieldName;
            var photos = GetModel(protoName, id).GetAttachedPhotoAspect(fieldName).GetAllPhotos();
            return View(photos);
        }

        public ActionResult GalleryEditList(long id, string protoName, string fieldName)
        {
            if (id <= 0)
            {
                return new JsonResult();
            }
            ViewData["fieldName"] = fieldName;
            var photos = GetModel(protoName, id).GetAttachedPhotoAspect(fieldName).GetAllPhotos();
            return View(photos);
        }

        public ActionResult UploadTelerik(string protoName, long id, string fieldName)
        {
            var item = GetModel(protoName, id).GetAttachedPhotoAspect(fieldName);
            foreach (var f in Request.Files)
            {
                var file = Request.Files[f.ToString()];
                if (file == null)
                {
                    continue;
                }
                // Some browsers send file names with full path. This needs to be stripped.

                Image image = Image.FromStream(file.InputStream);
                string[] param = new string[] { file.FileName, image.Width.ToString(), image.Height.ToString() };
                file.InputStream.Seek(0, SeekOrigin.Begin);
                
                var virtualPath = "~" + item.GetUploadDataFolder();
                var physicalPath = Server.MapPath(virtualPath);
                string name = MeridianWebUtilities.UploadFileWithExtension(file, physicalPath);
                if (!string.IsNullOrEmpty(name))
                {
                    var fullName = Path.Combine(physicalPath, name);
                    var fullUrl = Path.Combine(item.GetUploadDataFolder(), name);
                    ProcessUploadedFile(item, file, name, fullName, fullUrl, param);
                }
            }
            // Return an empty string to signify success
            return Content("");
        }        

        public void ProcessUploadedFile(IAttachedPhotoAspect model, System.Web.HttpPostedFileBase file, string name, string path, string url, string[] param)
        {
            model.AddPhoto(name, name, url, path, param);
        }

        [HttpPost]
        public void RemovePhoto(string protoName, long id, string fieldName, long photoId)
        {
            var model = GetModel(protoName, id).GetAttachedPhotoAspect(fieldName);
            model.RemovePhoto(photoId);
        }

        [HttpPost]
        public void SetMain(string protoName, long id, string fieldName, long photoId)
        {
            var model = GetModel(protoName, id).GetAttachedPhotoAspect(fieldName);
            model.SetMain(photoId);
            
        }
    }
}
