using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Drawing;
using System.Web;

using smolensk.common;
using meridian.smolensk.proto;

namespace smolensk.Extensions
{
    public static class ImageHelper
    {
        public static Bitmap CreateTextImage(string text, int width=100, int height=20, int fontSize=13)
        {
            var bmp = new Bitmap(width, height);
            Graphics g = Graphics.FromImage(bmp);
            g.FillRectangle(Brushes.White, 0, 0, width, height);
            g.DrawString(text, SystemFonts.DefaultFont, Brushes.Black, 2, (height - fontSize)/2);
            return bmp;
        }

        public static void SetAvatar(this accounts acc, string avatarName)
        {
            string oldAvatar = acc.avatar;
            acc.avatar = _SaveAvatar(avatarName, oldAvatar, acc.id.ToString());
        }
        private static string _SaveAvatar(string avatarName, string oldAvatar, string pathSlice, bool deleteOld = true)
        {
            if (!string.IsNullOrEmpty(avatarName) && avatarName != oldAvatar)
            {
                var guid = Guid.NewGuid().ToString();
                string tempAvatarPath = String.Format("{0}{1}", FileSystemFolders.TempFolder, avatarName);
                string avatarsFolder = String.Format("{0}{1}/", FileSystemFolders.AvatarsFolder, pathSlice);
                using (FileStream fs = new FileStream(tempAvatarPath, FileMode.Open, FileAccess.Read))
                {
                    AvatarCreator.SaveAll(guid, avatarsFolder, fs);
                }
                File.Delete(tempAvatarPath);
                    
                if (!string.IsNullOrWhiteSpace(oldAvatar) && deleteOld)
                    AvatarCreator.DeleteAll(oldAvatar, avatarsFolder);

                return guid;
            }

            return avatarName;
        }

        /// <summary>
        /// Возвращает имя файла
        /// </summary>
        /// <param name="file"></param>
        /// <param name="photoUrl"> </param>
        /// <returns></returns>
        public static string SaveResumePhoto(HttpPostedFileBase file, string photoUrl=null)
        {
            if (!string.IsNullOrEmpty(photoUrl))
            {
                string fname = Path.GetFileName(photoUrl);
                string physPath = Path.Combine(FileSystemFolders.ResumeFolder, fname);
                if (File.Exists(physPath))
                {
                    File.Delete(physPath);
                }
            }

            string fn = SavePostedFile(file, FileSystemFolders.ResumeFolder);
            return fn;
        }

        /// <summary>
        /// Возвращает имя файла под которым он сохранен
        /// </summary>
        /// <param name="file"></param>
        /// <param name="folder"></param>
        /// <returns></returns>
        private static string SavePostedFile(HttpPostedFileBase file, string folder)
        {
            string ext = Path.GetExtension(file.FileName);
            string fn = Guid.NewGuid().ToString("N") + ext;
            string path = Path.Combine(folder, fn);
            file.SaveAs(path);

            return fn;
        }
    }
}