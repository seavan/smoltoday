using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Drawing.Drawing2D;

namespace smolensk.common
{
    public static class AvatarCreator
    {
        static AvatarCreator()
        {
            m_Sizes[SMALL] = new Size(74, 74);
            m_Sizes[MID] = new Size(139, 139);
            m_Sizes[LARGE] = new Size(165, 165);
            m_Sizes[ORIG] = new Size(-1, -1);
        }

        public static void DeleteAll(string _guid, string _path)
        {
            if (!string.IsNullOrEmpty(_guid))
            {
                foreach (var pair in m_Sizes)
                {
                    try
                    {
                        File.Delete(_path + _guid + "." + pair.Key + ".jpg");
                    }
                    catch { }
                }
            }
        }

        public static void SaveAll(string _guid, string _path, Stream _input)
        {
            if (!Directory.Exists(_path))
            {
                Directory.CreateDirectory(_path);
            }

            _input.Seek(0, SeekOrigin.Begin);
            var image = Bitmap.FromStream(_input);

            foreach(var pair in m_Sizes)
            {
                var fname = _path + _guid + "." + pair.Key + ".jpg";

                if (pair.Value.Width < 0)
                {
                    image.Save(fname, ImageFormat.Jpeg);
                }
                else
                {
                    var targetBmp = new Bitmap(pair.Value.Width, pair.Value.Height);
                    Graphics dc = Graphics.FromImage(targetBmp);
                    dc.SmoothingMode = SmoothingMode.AntiAlias;
                    dc.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    dc.PixelOffsetMode = PixelOffsetMode.HighQuality;
                    dc.FillRectangle(Brushes.White, 0, 0, targetBmp.Width, targetBmp.Height);
                    float x = 0, y = 0, w = 0, h = 0;
                    if (image.Width >= image.Height)
                    {
                        x = 0;
                        w = targetBmp.Width;
                        h = image.Height * targetBmp.Width / image.Width;
                        y = (targetBmp.Height - h)/2;
                    }
                    else
                    {
                        y = 0;
                        h = targetBmp.Height;
                        w = image.Width * targetBmp.Height / image.Height;
                        x = (targetBmp.Width - w)/2;
                    }

                    dc.DrawImage(image, x, y, w, h);
                    dc.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                    targetBmp.Save(fname, ImageFormat.Jpeg);
                }
            }
        }

        public static string SaveTemp(string _path, HttpPostedFileBase _input)
        {
            var expansion = "jpg";
            var targetFName = Guid.NewGuid().ToString() + "." + expansion;

            FileStream stream = new FileStream(_path + targetFName, FileMode.Create);
            Image image = Image.FromStream(_input.InputStream);
            int nw = 0, nh = 0;
            if( image.Width > image.Height )
            {
                nw = image.Width > PREPARE_SIZE ? PREPARE_SIZE : image.Width;
                nh = image.Height * nw / image.Width;
            }
            else
            {
                nh = image.Height > PREPARE_SIZE ? PREPARE_SIZE : image.Height;
                nw = image.Width * nh / image.Height;
            }
            Image tgImage = new Bitmap(nw, nh);

            Graphics dc = Graphics.FromImage(tgImage);
            dc.SmoothingMode = SmoothingMode.AntiAlias;
            dc.InterpolationMode = InterpolationMode.HighQualityBicubic;
            dc.PixelOffsetMode = PixelOffsetMode.HighQuality;
            dc.DrawImage(image, 0, 0, nw, nh);
            tgImage.Save(stream, ImageFormat.Jpeg);
            stream.Close();

            return targetFName;
        }

        public static string CropAndSave(int _X, int _Y, int _Width, int _Height, string _name, string _path)
        {
            Rectangle cropSection = new Rectangle();
            cropSection.X = _X;
            cropSection.Y = _Y;
            cropSection.Width = _Width;
            cropSection.Height = _Height;

            Image image = Image.FromFile(_path + _name);
            Bitmap bmpSave = new Bitmap(cropSection.Width, cropSection.Height);
            bmpSave.SetResolution(image.HorizontalResolution, image.VerticalResolution);
            Graphics g = Graphics.FromImage(bmpSave);
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;

            var new_name = Guid.NewGuid().ToString() + ".jpg";
            g.DrawImage(image, 0, 0, cropSection, GraphicsUnit.Pixel);
            bmpSave.Save(_path + new_name, ImageFormat.Jpeg);
            g.Dispose();
            bmpSave.Dispose();
            image.Dispose();
            File.Delete(_path + _name);

            return new_name;
            
        }

        public static string SaveDefault(string _name, string _path)
        {
            var width = 165;
            var height = 165;

            Image image = Image.FromFile(_path + _name);
            Bitmap bmpSave = new Bitmap(width, height);
            bmpSave.SetResolution(image.HorizontalResolution, image.VerticalResolution);
            Graphics g = Graphics.FromImage(bmpSave);
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;

            RectangleF srcRect = new RectangleF();
            var coeff = width/height;

            if (image.Width > image.Height)
            {
                srcRect.Width = image.Height*coeff;
                srcRect.Height = image.Height;
            }
            else
            {
                srcRect.Height = image.Width * coeff;
                srcRect.Width = image.Width;
            }

            var new_name = Guid.NewGuid().ToString() + ".jpg";
            g.DrawImage(image, new RectangleF(0, 0, width, height), srcRect, GraphicsUnit.Pixel);
            bmpSave.Save(_path + new_name, ImageFormat.Jpeg);
            g.Dispose();
            bmpSave.Dispose();
            image.Dispose();
            File.Delete(_path + _name);

            return new_name;

        }



        private static SortedList<string, Size> m_Sizes = new SortedList<string, Size>();
        public static string MID = "mid";
        public static string SMALL = "small";
        public static string LARGE = "large";
        public static string ORIG = "orig";
        public const int PREPARE_SIZE = 1000;
    }
    
}
