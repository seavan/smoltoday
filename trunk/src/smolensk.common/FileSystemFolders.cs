using admin.web.common;

namespace smolensk.common
{
    public class FileSystemFolders : CommonFileSystemFolders
    {
        public static string NewsImagesFolder
        {
            get { return MapPath(Constants.NewsDataFolder); }
        }
        public static string TempFolder
        {
            get { return MapPath(Constants.TempFolder); }
        }
        public static string AvatarsFolder
        {
            get { return MapPath(Constants.AvatarsFolder); }
        }

        public static string ResumeFolder
        {
            get { return MapPath(Constants.ResumeFolder); }
        }

        public static string VacancyFolder
        {
            get { return MapPath(Constants.VacanciesFolder); }
        }
        public static string PhotoFolder
        {
            get { return MapPath(Constants.PhotoFolder); }
        }
        public static string AdvertPhotoFolder
        {
            get { return MapPath(Constants.AdvertsDataFolder); }
        }
    }
}