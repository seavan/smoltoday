using System;
using System.Drawing;
using System.Net;

using System.Threading;
using MySql.Data.MySqlClient;

namespace meridian.smolensk.system
{
    public class WebcamThreadWorker : ThreadWorker
    {
        public WebcamThreadWorker(string _path)
        {
            FilePath = _path;
        }

        public string FilePath { get; set; }

        public override void DoJob()
        {
            base.DoJob();

            try
            {
                var baseUrl = "http://79.133.86.82/image.jpg?x=";
                var timeStamp = DateTime.Now.Ticks.ToString();

                var url = baseUrl + timeStamp;

                WebRequest requestPic = WebRequest.Create(baseUrl);

                WebResponse responsePic = requestPic.GetResponse();

                Image webImage = Image.FromStream(responsePic.GetResponseStream()); // Error

                webImage.Save(FilePath);

            }
            catch (Exception)
            {
                
            }
           

            Thread.Sleep(5000);
        }
    }
}