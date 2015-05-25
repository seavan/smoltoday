using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.IO;
using System.Text;

namespace smolensk.common.Security
{
    public abstract class OAuthBase
    {
        protected abstract string ClientID { get; }
        protected abstract string ClientSecretCode { get; }

        protected string AccessToken { get; set; }

        public string UserId { get; set; }
        public string UserEmail { get; set; }
        public string ServerCode { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }

        protected string GetResponse(string url)
        {
            string answer = string.Empty;
            WebRequest request = WebRequest.Create(url);
            using (WebResponse result = request.GetResponse())
            {
                Stream ReceiveStream = result.GetResponseStream();
                using (StreamReader sr = new StreamReader(ReceiveStream, Encoding.UTF8))
                    answer = sr.ReadToEnd();
            }

            return answer;
        }
    }
}