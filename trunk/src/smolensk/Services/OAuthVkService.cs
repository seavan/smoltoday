using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Xml;
using smolensk.common.Security;
using smolensk.Models.CodeModels.Security;
using smolensk.Services.Interfaces;
using System.Text;
using System.Web.Script.Serialization;
using smolensk.Domain;

namespace smolensk.Services
{
    public class OAuthVkService : OAuthBase, IOAuth
    {
        protected override string ClientID { get { return _clientID; } }
        protected override string ClientSecretCode { get { return _clientSecretCode; } }

        private static readonly string _clientID = (string) (ConfigurationManager.AppSettings["VKClientID"]);// "3798034";// "3797459";
        private static readonly string _clientSecretCode = (string)(ConfigurationManager.AppSettings["VKClientSecretCode"]); //"t3JQBaqQshXSQRvi6owm"; //"Cqlc3l4AuGkwF7DnNYml";

        public static readonly string SignInUrl = "http://" +
                                         "api.vkontakte.ru/oauth/authorize" +
                                         "?client_id=" + _clientID +
                                         "&scope=" +
                                         "&redirect_uri=http://" +
                                                  Domain.Extensions.GetHost(true) +
                                                  "/Security/OAuthSignIn/vkontakte" +
                                         "&response_type=code";

        
        
        public void GetToken()
        {
            string url = "https://" +
                         "api.vkontakte.ru/oauth/access_token" +
                         "?client_id=" + ClientID +
                         "&client_secret=" + ClientSecretCode + 
                         "&code=" + ServerCode +
                         "&redirect_uri=http://" +
                                                  Domain.Extensions.GetHost(true) +
                                                  "/Security/OAuthSignIn/vkontakte";

            try
            {
                string answer = GetResponse(url);

                TokenModel tokenModel = new JavaScriptSerializer().Deserialize<TokenModel>(answer);
                UserId = tokenModel.user_id;
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
                         "api.vkontakte.ru/method/getProfiles.xml" +
                         "?uid=" + UserId +
                         "&access_token=" + AccessToken;// +
                         //"&fields=photo";

            try
            {
                WebRequest request = WebRequest.Create(url);
                WebResponse result = request.GetResponse();
                Stream ReceiveStream = result.GetResponseStream();

                XmlDocument doc = new XmlDocument();
                doc.Load(ReceiveStream);

                UserId = doc.DocumentElement.ChildNodes.Item(0).SelectSingleNode("uid").InnerText;
                UserFirstName = doc.DocumentElement.ChildNodes.Item(0).SelectSingleNode("first_name").InnerText;
                UserLastName = doc.DocumentElement.ChildNodes.Item(0).SelectSingleNode("last_name").InnerText;
            }
            catch (Exception)
            {
                
                //throw;
            }
            
            
        }


        [Serializable]
        public class TokenModel
        {
            public string access_token { get; set; }
            public string expires_in { get; set; }
            public string user_id { get; set; }
        }
    }
}