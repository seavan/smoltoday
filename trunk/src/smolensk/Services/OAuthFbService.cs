using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using smolensk.Domain;
using smolensk.Services.Interfaces;
using smolensk.common.Security;
using System.Web.Script.Serialization;

namespace smolensk.Services
{
    public class OAuthFbService : OAuthBase, IOAuth
    {
        protected override string ClientID { get { return _clientID; } }
        protected override string ClientSecretCode { get { return _clientSecretCode; } }

        private static readonly string _clientID = (string)(ConfigurationManager.AppSettings["FBClientID"]);
        private static readonly string _clientSecretCode = (string)(ConfigurationManager.AppSettings["FBClientSecretCode"]);

        public static readonly string SignInUrl = "https://" +
                                                  "www.facebook.com/dialog/oauth" +
                                                  "?client_id=" + _clientID +
                                                  "&redirect_uri=http://" +
                                                  Domain.Extensions.GetHost(true) +
                                                  "/Security/OAuthSignIn/facebook" +
                                                  "&scope=email";
        
        public void GetToken()
        {
            string url = "https://" +
                         "graph.facebook.com/oauth/access_token" +
                         "?client_id=" + ClientID +
                         "&redirect_uri=http://" +
                         Domain.Extensions.GetHost(true) +
                         "/Security/OAuthSignIn/facebook" +
                         "&client_secret=" + ClientSecretCode +
                         "&code=" + ServerCode;

            try
            {
                string answer = GetResponse(url);

                var qstr = HttpUtility.ParseQueryString(answer);
                AccessToken = qstr["access_token"];
            }
            catch (Exception)
            {

                //throw;
            }

        }
        public void GetProfile()
        {
            string url = "https://" +
                         "graph.facebook.com/me" +
                         "?access_token=" + AccessToken;

            try
            {
                string answer = GetResponse(url);

                ProfileModel profileModel = new JavaScriptSerializer().Deserialize<ProfileModel>(answer);
                UserId = profileModel.id;
                UserFirstName = profileModel.first_name;
                UserLastName = profileModel.last_name;
                UserEmail = HttpUtility.UrlDecode(profileModel.email);
            }
            catch (Exception)
            {

                //throw;
            }
        }

        [Serializable]
        public class ProfileModel
        {
            public string last_name { get; set; }
            public string first_name { get; set; }
            public string id { get; set; }
            public string email { get; set; }
        }
    }
}