using System.Web;

namespace admin.web.common
{
    public class CommonConstants
    {
        public const string DefaultUploadVirtualFolder = "/content/upload/";


    }

    public class CommonFileSystemFolders
    {

        public static string DefaultUploadPhysicalPath
        {
            get { return MapPath(CommonConstants.DefaultUploadVirtualFolder); }
        }


        public static string MapPath(string virtualPath)
        {
            return HttpContext.Current.Server.MapPath(MakePathRooted(virtualPath));
        }




        public static string MakePathRooted(string path)
        {
            return "~" + path;
        }
    }

}