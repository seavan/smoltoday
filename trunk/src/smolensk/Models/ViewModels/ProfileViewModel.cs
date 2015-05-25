using System.Linq;
using meridian.smolensk.proto;
using meridian.smolensk.system;

namespace smolensk.Models.ViewModels
{
    public class ProfileViewModel
    {
        public accounts Profile { get; set; }
        public PhotoListViewModel PhotosList { get; set; }

        public int PhotosCount
        {
            get { return Profile.PhotosCount; }
        }

        public int ViewsCount
        {
            get { return Profile.ViewsPhotosCount; }
        }

        public int DownloadCount
        {
            get { return Profile.DownloadPhotosCount; }
        }
    }
}