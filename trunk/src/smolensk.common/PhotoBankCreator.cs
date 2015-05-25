using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using admin.web.common;
using System.Drawing.Drawing2D;

namespace smolensk.common
{
    public static class PhotoBankCreator
    {

        public static Size PRE;
        public static Size SPRE;
        public static Size MAIN;

        static PhotoBankCreator()
        {
            PRE = new Size(200, 130);
            SPRE = new Size(108, 108);
            MAIN = new Size(473, 299);
        }
        

        public static string CreatePreview(string originalFileName)
        {
            return SavePreview(originalFileName, PRE);
        }

        public static string CreateSquarePreview(string originalFileName)
        {
            return SavePreview(originalFileName, SPRE);
        }

        public static string CreateMainPreview(string originalFileName)
        {
            return SavePreview(originalFileName, MAIN);
        }

        public static string SavePreview(string originalFileName, Size _size)
        {
            string origPath = String.Format("{0}{1}", FileSystemFolders.PhotoFolder, originalFileName);            
            var targetFName = Guid.NewGuid().ToString() + ".jpg";
            FileStream _input = new FileStream(origPath, FileMode.Open, FileAccess.Read);

            _input.Seek(0, SeekOrigin.Begin);
            var image = Bitmap.FromStream(_input);
                
            var targetBmp = new Bitmap(_size.Width, _size.Height);
            Graphics dc = Graphics.FromImage(targetBmp);
            dc.FillRectangle(Brushes.White, 0, 0, targetBmp.Width, targetBmp.Height);
            dc.SmoothingMode = SmoothingMode.AntiAlias;
            dc.InterpolationMode = InterpolationMode.HighQualityBicubic;
            dc.PixelOffsetMode = PixelOffsetMode.HighQuality;

            float x = 0, y = 0, w = 0, h = 0;
            if (image.Width >= image.Height)
            {
                x = 0;
                w = targetBmp.Width;
                h = (image.Height * targetBmp.Width) / image.Width;
                y = 0;

                if(h < targetBmp.Height)
                {
                    w = (targetBmp.Height * image.Width) / image.Height;
                    h = targetBmp.Height;
                    x = (targetBmp.Width - w) / 2;
                }
            }
            else
            {
                y = 0;
                h = targetBmp.Height;
                w = image.Width * targetBmp.Height / image.Height;
                x = 0;

                if(w < targetBmp.Width)
                {
                    h = (targetBmp.Width*image.Height)/image.Width;
                    w = targetBmp.Width;
                    y = (targetBmp.Height - h) / 2;
                }
            }

            dc.DrawImage(image, x, y, w, h);
            
            targetBmp.Save(String.Format("{0}{1}", FileSystemFolders.PhotoFolder, targetFName), ImageFormat.Jpeg);
                
            _input.Close();

            return targetFName;
        }

        public static string SaveOriginal(HttpPostedFileBase _input, out int width, out int height)
        {
            Image image = Image.FromStream(_input.InputStream);
            width = image.Width;
            height = image.Height;
            _input.InputStream.Seek(0, SeekOrigin.Begin);

            string _path = FileSystemFolders.PhotoFolder;
            var extension = Path.GetExtension(_input.FileName);
            var targetFName = Guid.NewGuid().ToString();

            if (extension.ToLower() == ".jpg" || extension.ToLower() == ".jpeg")
            {
                targetFName += extension;
                image.Save(String.Format("{0}{1}", _path, targetFName));
            }
            else
            {
                targetFName += ".jpg";
                FileStream stream = new FileStream(_path + targetFName, FileMode.Create);
                Image tgImage = new Bitmap(image.Width, image.Height);
                Graphics dc = Graphics.FromImage(tgImage);
                dc.DrawImage(image, 0, 0, image.Width, image.Height);
                dc.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                tgImage.Save(stream, ImageFormat.Jpeg);
                stream.Close();
            }
            
            return targetFName;
        }

        public static bool DeleteImg(string originalFileName)
        {
            string origPath = String.Format("{0}{1}", FileSystemFolders.PhotoFolder, originalFileName);
            if(File.Exists(origPath))
            {
                try
                {
                    File.Delete(origPath);
                }
                catch
                {
                    return false;
                }
                return true;
            }
            return false;
        }
        
    }
    
}
