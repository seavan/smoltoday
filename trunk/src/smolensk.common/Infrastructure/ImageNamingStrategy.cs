using System;

namespace smolensk.common.Infrastructure
{
    public class ImageNamingStrategy
    {
        private const string DefaultExtension = "png";
        private const string Dot = ".";

        private Guid imageId;

        public ImageNamingStrategy(Guid imageId)
        {
            this.imageId = imageId;
        }

        public string GetOriginalImageFileName(string extension)
        { 
            if (string.IsNullOrEmpty(extension))
                extension = DefaultExtension;

            string result = GetOriginalImageName();
            if (!extension.StartsWith(Dot))
                result += Dot;

            result += extension;

            return result;
        }

        public string GetOriginalImageName()
        {
            return string.Format("{0}.original", imageId.ToString());
        }

        public string GetSmallThumbnailName()
        {
            return string.Format("{0}.small", imageId.ToString());
        }

        public string GetMediumThumbnailName()
        {
            return string.Format("{0}.mid", imageId.ToString());
        }

        public string GetLargeThumbnailName()
        {
            return string.Format("{0}.large", imageId.ToString());
        }

        public string GetNormalThumbnailName()
        {
            return string.Format("{0}.normal", imageId.ToString());
        }
    }
}