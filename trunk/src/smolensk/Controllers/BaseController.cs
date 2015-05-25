using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using meridian.smolensk.system;
using smolensk.common;
using log4net;
using System.Reflection;

namespace smolensk.Controllers
{
    public abstract class BaseController : Controller
    {
        protected static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        protected Meridian meridian;

        public BaseController()
        {
            meridian = Meridian.Default;
        }

        public void InitUniqueId(bool rewrite = false)
        {
            HttpCookie cookie = Request.Cookies["suid"];
            if (cookie == null || rewrite)
            {
                cookie = new HttpCookie("suid", Guid.NewGuid().ToString());
                cookie.Expires = DateTime.Now.AddMinutes(20);
                //cookie.Domain = ZakonExtension.GetHost();
                Response.Cookies.Add(cookie);
            }
        }

        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase upload)
        {
            var funcNum = Request["CKEditorFuncNum"];
            try
            {
                string name = UploadFileWithExtension(upload, FileSystemFolders.TempFolder);
                if (!string.IsNullOrEmpty(name))
                {
                    string url = Constants.TempFolder + name;

                    return
                        Content("<script type='text/javascript'>window.parent.CKEDITOR.tools.callFunction(" + funcNum +
                                ", '" + url + "', '');</script>");
                }
            }
            catch (Exception ex)
            {
                LogException("Upload failed", ex);
            }

            return Content("<script type='text/javascript'>window.parent.CKEDITOR.tools.callFunction(" + funcNum + ", '', 'Произошла ошибка при загрузке файла на сервер.');</script>");
        }

        public static string UploadFileWithExtension(HttpPostedFileBase uploadedFile, string targetFolder, string desiredName = null)
        {
            var extension = Path.GetExtension(uploadedFile.FileName);
            if (string.IsNullOrEmpty(desiredName))
                desiredName = Guid.NewGuid().ToString();

            var targetFilename = desiredName + extension;
            using (FileStream stream = new FileStream(Path.Combine(targetFolder, targetFilename), FileMode.Create))
            {
                uploadedFile.InputStream.CopyTo(stream);
            }

            return targetFilename;
        }

        protected static void LogException(string message, Exception ex)
        {
            log.Error(message, ex);
        }
    }
}