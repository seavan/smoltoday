using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web;

namespace smolensk.common.Captcha
{
    public static class CaptchaHelper
    {
        public static string FieldNameCAPTCHA = "captcha-guid";
        /// <summary>
        /// CAPTHCHA изображение
        /// </summary>
        public static string CaptchaImage(this HtmlHelper helper, int height, int width, int charcount, string srcImg)
        {
            smolensk.common.Captcha.CaptchaImage.TextLength = charcount;
            smolensk.common.Captcha.CaptchaImage.LineNoise = LineNoiseLevel.Low;
            smolensk.common.Captcha.CaptchaImage.FontWarp = FontWarpFactor.Medium;
            smolensk.common.Captcha.CaptchaImage.BackgroundNoise = BackgroundNoiseLevel.Medium;
            CaptchaImage image = new CaptchaImage
            {
                Width = width,
                Height = height
            };

            HttpRuntime.Cache.Add(
                image.UniqueId,
                image,
                null,
                DateTime.Now.AddSeconds(smolensk.common.Captcha.CaptchaImage.CacheTimeOut),
                System.Web.Caching.Cache.NoSlidingExpiration,
                System.Web.Caching.CacheItemPriority.NotRemovable,
                null
            );

            TagBuilder inputBuilder = new TagBuilder("input");
            inputBuilder.Attributes.Add("type", "hidden");
            inputBuilder.Attributes.Add("name", FieldNameCAPTCHA);
            inputBuilder.Attributes.Add("value", image.UniqueId);


            TagBuilder imgBuilder = new TagBuilder("img");
            imgBuilder.Attributes.Add("src", string.IsNullOrEmpty(srcImg) ? "?" + FieldNameCAPTCHA + "=" + image.UniqueId : srcImg + "?" + FieldNameCAPTCHA + "=" + image.UniqueId);
            imgBuilder.Attributes.Add("alt", "CAPTCHA Image");
            imgBuilder.Attributes.Add("width", width.ToString());
            imgBuilder.Attributes.Add("height", height.ToString());

            return inputBuilder.ToString(TagRenderMode.Normal) + imgBuilder.ToString(TagRenderMode.Normal);
        }
    }

}
