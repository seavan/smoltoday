using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Principal;
using System.Web.Script.Serialization;
using admin.db;
using meridian.smolensk.system;
using System.Linq;
using smolensk.common;
using System.Collections.Generic;
using System.Data.Linq;

namespace meridian.smolensk.proto
{
    public partial class accounts : IDatabaseEntity, IPrincipal, IIdentity, ILookupValue
    {

        public bool IsActivated
        {
            get { return activation_guid == default(Guid); }
        }
        public string ShortName
        {
            get { return String.Format("{0} {1}", lastname, firstname); }
        }
        public string FullName
        {
            get { return String.Format("{0} {1} {2}", lastname, firstname, secondname); }
        }

        public string NameAndSurname
        {
            get { return string.Format("{0} {1}", firstname, lastname); }
        }
        
        public Uri ProfileUrl
        {
            get { return new Uri(String.Format("/Profile/User/{0}", id), UriKind.Relative); }
        }

        [ScriptIgnore]
        public IIdentity Identity
        {
            get { return this; }
        }

        public bool IsInRole(string role)
        {
            return false;
        }

        public string AuthenticationType
        {
            get { return "Forms"; }
        }

        public bool IsAuthenticated
        {
            get { return true; }
        }

        public string Name
        {
            get { return ShortName; }
        }

        public int CommentsCount
        {
            get { return NewsComments.Count() + RestaurantsComments.Count() + CompanyComments.Count() + BlogComments.Count(); }
        }


        public string lookup_title
        {
            get { return String.Format("{0}, {1}, {2}", ShortName, email, id); }
        }



        public int lookup_value_level
        {
            get { return 0; }
        }

        public bool lookup_value_disabled
        {
            get { return false; }
        }

        public IEnumerable<blogs> BlogsUser
        {
            get { return UserBlogs.Where(b => !b.is_delete); }
        }

        #region AvatarUrls
        public string AvatarUrlSmall
        {
            get
            {
                return AvatarUrl(AvatarCreator.SMALL);
            }
        }
        public string AvatarUrlMid
        {
            get
            {
                return AvatarUrl(AvatarCreator.MID);
            }
        }

        public string AvatarUrlLarge
        {
            get
            {
                return AvatarUrl(AvatarCreator.LARGE);
            }
        }

        public string AvatarUrlOriginal
        {
            get
            {
                return AvatarUrl(AvatarCreator.ORIG);
            }
        }

        private string AvatarUrl(string size)
        {
            return string.IsNullOrEmpty(this.avatar)
                           ? string.Format(Consts.AvatarUrlFormat, String.Format("emptyAvatar.{0}.jpg", size))
                           : string.Format(Consts.AvatarUrlFormat, String.Format("{0}/{1}.{2}.jpg", this.id, this.avatar, size));
        }
        #endregion


        #region ForPhotoBank
        public int PhotosCount
        {
            get { return Meridian.Default.photobank_photosStore.All().Count(item => item.account_id == this.id); }
        }

        public int ViewsPhotosCount
        {
            get { return Meridian.Default.photobank_photosStore.All().Where(item => item.account_id == this.id).Sum(item => item.view_count); }
        }

        public int DownloadPhotosCount
        {
            get { return Meridian.Default.photobank_photosStore.All().Where(item => item.account_id == this.id).Sum(item => item.download_count); }
        }
        #endregion

        /// <summary>
        /// Возвращает список опубликованных резюме
        /// </summary>
        /// <returns></returns>
        public IEnumerable<resumes> GetPublishResumes()
        {
            return GetResumes().Where(p => p.is_publish);
        }
    }
}
