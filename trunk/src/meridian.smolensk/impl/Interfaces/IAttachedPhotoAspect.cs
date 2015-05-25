using System.Collections.Generic;
using admin.db;

namespace meridian.smolensk.proto
{
    public interface IAttachedPhotoAspect
    {
        string FieldName { get;  }

        bool Multiple { get; }

        IDatabaseEntity GetParent();

        IEnumerable<IAttachedPhoto> GetAllPhotos();

        /// <summary>
        /// Добавить фото к объекту и вообще
        /// </summary>
        /// <param name="original">имя (гуид плюс расширение) оригинальной фотки</param>
        /// <param name="thumb">имя (гуид плюс расширение) тумбы. иногда вместо тумбы будет тоже оригинальная фотка</param>
        /// <param name="url">относительный адрес фотки оригинальной, где она хранится в стране ОЗ</param>
        /// <param name="path">физический адрес фотки оригинальной, где она хранится в стране ОЗ</param>
        /// <returns></returns>
        IAttachedPhoto AddPhoto(string original, string thumb, string url, string path, string[] param);

        /// <summary>
        /// Относительный путь (без тильды) к виртуальному каталогу, в котором лежат фотки, например:
        ///         public const string UserDataFolder = "/content/userdata/";
        ///         public const string RestaurantsDataFolder = UserDataFolder + "restaurants/";
        /// </summary>
        /// <returns></returns>
        string GetUploadDataFolder();

        void RemovePhoto(long id);

        void SetMain(long id);
    }
}