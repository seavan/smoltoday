using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using smolensk.common.Security;
using smolensk.Services.Interfaces;
using smolensk.Domain;
using System.Web.Script.Serialization;

namespace smolensk.Services
{
    public class OAuthGpService : OAuthBase, IOAuth
    {
        protected override string ClientID { get { return _clientID; } }
        protected override string ClientSecretCode { get { return _clientSecretCode; } }

        private static readonly string _clientID = (string)(ConfigurationManager.AppSettings["GPClientID"]);
        private static readonly string _clientSecretCode = (string)(ConfigurationManager.AppSettings["GPClientSecretCode"]);


        public static readonly string SignInUrl = "https://" +
                                                  "accounts.google.com/o/oauth2/auth" +
                                                  "?client_id=" + _clientID +
                                                  "&redirect_uri=http://" +
                                                  Domain.Extensions.GetHost(true) +
                                                  "/Security/OAuthSignIn/googleplus" +
                                                  "&response_type=code" +
                                                  "&scope=https://www.googleapis.com/auth/userinfo.email https://www.googleapis.com/auth/userinfo.profile";

        private string TokenType { get; set; }

        public void GetToken()
        {
            string url = "https://" +
                         "accounts.google.com/o/oauth2/token" +
                         "?client_id=" + ClientID +
                         "&redirect_uri=http://" +
                         Domain.Extensions.GetHost(true) +
                         "/Security/OAuthSignIn/googleplus" +
                         "&client_secret=" + ClientSecretCode +
                         "&code=" + ServerCode +
                         "&grant_type=authorization_code";

            string query = "client_id=" + ClientID +
                         "&redirect_uri=" + HttpUtility.UrlEncode("http://" + Domain.Extensions.GetHost(true) + "/Security/OAuthSignIn/googleplus", Encoding.UTF8) +
                         "&client_secret=" + ClientSecretCode +
                         "&code=" + ServerCode +
                         "&grant_type=authorization_code";

            try
            {
                WebRequest request = WebRequest.Create("https://accounts.google.com/o/oauth2/token");
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";

                byte[] sentData = Encoding.UTF8.GetBytes(query);

                request.ContentLength = sentData.Length;
                Stream sendStream = request.GetRequestStream();
                sendStream.Write(sentData, 0, sentData.Length);
                sendStream.Close();

                WebResponse result = request.GetResponse();
                Stream ReceiveStream = result.GetResponseStream();
                StreamReader sr = new StreamReader(ReceiveStream, Encoding.UTF8);
                string answer = sr.ReadToEnd();
                sr.Close();
                result.Close();

                TokenModel tokenModel = new JavaScriptSerializer().Deserialize<TokenModel>(answer);
                TokenType = tokenModel.token_type;
                AccessToken = tokenModel.access_token;
            }
            catch (Exception)
            {
                //throw;
            }


        }
        public void GetProfile()
        {
            string url = "https://" +
                         "www.googleapis.com/oauth2/v1/userinfo" +
                         "?access_token=" + AccessToken;

            try
            {
                string answer = GetResponse(url);

                ProfileModel profileModel = new JavaScriptSerializer().Deserialize<ProfileModel>(answer);
                UserId = profileModel.id;
                UserFirstName = profileModel.given_name;
                UserLastName = profileModel.family_name;
                UserEmail = profileModel.email;

            }
            catch(Exception)
            {
                
            }
        }

        [Serializable]
        public class TokenModel
        {
            public string access_token { get; set; }
            public string expires_in { get; set; }
            public string token_type { get; set; }
        }

        [Serializable]
        public class ProfileModel
        {
            public string family_name { get; set; }
            public string given_name { get; set; }
            public string id { get; set; }
            public string email { get; set; }
        }
    }
}