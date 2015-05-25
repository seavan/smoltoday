using System.Drawing;
using admin.web.common;
using meridian.smolensk.controller;
using meridian.smolensk.system;
using smolensk.common;
using System.Web.Mvc;
using meridian.smolensk.proto;

namespace smolensk.Controllers
{
    public class PhotoBankCategoryAdminController : meridian_photobank_categories
    {
        public ActionResult UploadCover(long id)
        {
            if (Meridian.Default.photobank_categoriesStore.Exists(id))
            {
                foreach (var f in Request.Files)
                {
                    var file = Request.Files[f.ToString()];
                    if (file != null)
                    {
                        string name = MeridianWebUtilities.UploadFileWithExtension(file, FileSystemFolders.PhotoFolder);

                        if (!string.IsNullOrEmpty(name))
                        {
                            string f_name = PhotoBankCreator.SavePreview(name, PhotoBankCreator.PRE);
                            PhotoBankCreator.DeleteImg(name);

                            if (!string.IsNullOrEmpty(f_name))
                            {
                                var cat = Meridian.Default.photobank_categoriesStore.Get(id);
                                cat.photo = f_name;
                                Meridian.Default.photobank_categoriesStore.Update(cat);
                            }
                        }
                        break;
                    }
                }
            }
            return Content("");
        }
    }
}
