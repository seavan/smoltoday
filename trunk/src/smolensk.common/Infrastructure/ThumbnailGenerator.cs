using System.Web;
using ImageResizer;

namespace smolensk.common.Infrastructure
{
    public class ThumbnailGenerator
    {
        /// <summary>
        /// Синтаксис строки команд описан здесь:
        /// http://imageresizing.net/docs/basics
        /// </summary>
        public string CommandString { get; set; }
        
        public string GenerateThumbnail(string originalImagePath, string thumbnailPath)
        {
            var job = new ImageJob(originalImagePath, thumbnailPath, new ResizeSettings(CommandString), false, true);
            job.CreateParentDirectory = true;

            var result = ImageBuilder.Current.Build(job);

            return result.FinalPath;
        }

        public string GenerateThumbnail(HttpPostedFileBase file, string destination)
        {
            var job = new ImageJob(file.InputStream, destination, new ResizeSettings(CommandString), false, true);
            job.CreateParentDirectory = true;
            job.ResetSourceStream = true;

            var result = ImageBuilder.Current.Build(job);

            return result.FinalPath;
        }
    }
}