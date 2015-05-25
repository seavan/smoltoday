using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace admin.db
{
    public class HideEditAttribute : Attribute
    {
    }

    public class UploadAttribute : Attribute, IUploadAttributeParser
    {
        public UploadAttribute()
        {
            OriginalFileNameField = null;
        }

        public string OriginalFileNameField { get; set; }

        public int MaxWidth { get; set; }

        public int MaxHeight { get; set; }

        public string[] UploadDirectories { get; set; }

        public string UploadExtension { get; set; }


        #region IUploadAttributeParser Members

        public virtual void ParseObject(System.IO.Stream _input, string _contentType, long _contentLength, string _fileName, string _targetFileName, string _fieldName)
        {
            
        }

        #endregion
    }

    public class DefaultFileUploadAttribute : UploadAttribute
    {
        public DefaultFileUploadAttribute()
        {
            UploadDirectories = new string[] { "/Content/temp", "../community/Content/entriesattachments" };
            UploadExtension = "dat";
        }

        public override void ParseObject(System.IO.Stream _input, string _contentType, long _contentLength, string _fileName, string _targetFileName, string _fieldName)
        {
            FileStream stream = new FileStream(_targetFileName, FileMode.CreateNew);
            var res = new byte[_input.Length];
            _input.Seek(0, SeekOrigin.Begin);
            _input.Read(res, 0, res.Length);
            stream.Write(res, 0, res.Length);
            stream.Close();
        }
    }

    public class DefaultImageUploadAttribute : UploadAttribute
    {



        protected ImageFormat Format;
        public override void ParseObject(System.IO.Stream _input, string _contentType, long _contentLength, string _fileName, string _targetFileName, string _fieldName)
        {
            Image image = Image.FromStream(_input);
            if ((MaxHeight > 0) || (MaxWidth > 0))
            {
                double coeffX = (double)(MaxWidth > 0 ? MaxWidth : image.Width) / image.Width;
                double coeffY = (double)(MaxHeight > 0 ? MaxHeight : image.Height) / image.Height;
                double coeff = Math.Min(coeffX, coeffY);
                int tgw = (int)(image.Width * coeff);
                int tgh = (int)(image.Height * coeff);
                var tgimage = new Bitmap(tgw, tgh);
                using (Graphics dc = Graphics.FromImage(tgimage))
                {
                    dc.DrawImage(image, 0, 0, tgw, tgh);
                }
                image = tgimage;

            }
            image.Save(_targetFileName, Format);
        }

        public DefaultImageUploadAttribute()
        {
            Format = ImageFormat.Png;
            UploadDirectories = new string[] { "/Content/images", "/Content/temp" };
        }
    }

    public class PngImageUploadAttribute : DefaultImageUploadAttribute
    {
        public PngImageUploadAttribute()
        {
            Format = ImageFormat.Png;
            UploadExtension = "png";
        }
    }

    public class JpgImageUploadAttribute : DefaultImageUploadAttribute
    {
        public JpgImageUploadAttribute()
        {
            Format = ImageFormat.Jpeg;
            UploadExtension = "jpg";
        }
    }

    public class LibPdfUploadAttribute : DefaultFileUploadAttribute
    {
        public LibPdfUploadAttribute()
        {
            UploadExtension = "libzakonru.pdf";
        }
    }
}