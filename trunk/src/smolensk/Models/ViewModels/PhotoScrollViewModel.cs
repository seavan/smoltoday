using System.Collections.Generic;
using smolensk.Models.CodeModels;

namespace smolensk.Models.ViewModels
{
    /// <summary>
    /// Модель для отображения прокручиваемых фотографий
    /// <remarks>пример использования в smolensk.Mappers.PhotoMapper (метод ToPhotoViewModel)</remarks>
    /// </summary>
    public class PhotoScrollViewModel
    {
        /// <summary>
        /// Выводимые фотографии
        /// </summary>
        public List<RelatedPhoto> Photos { get; set; }
        /// <summary>
        /// Ширина фотографии
        /// </summary>
        public int PhotoWidth { get; set; }
        /// <summary>
        /// Высота фотографии
        /// </summary>
        public int PhotoHeight { get; set; }
        /// <summary>
        /// Количество фотографий в отображаемом ряду
        /// </summary>
        public int PhotosCount { get; set; }
        /// <summary>
        /// Callback функция, вызываемая при клике на изображении
        /// в качестве входного параметра принимает изображение, на которое щелкнули,
        /// Если Callback не задан изображение оборачивается в тег A с href = Link у фотографии (класс RelatedPhoto)
        /// </summary>
        public string Callback { get; set; }
        /// <summary>
        /// Отображать скроллер, если количество фоток больше, чем указанное значение
        /// </summary>
        public int ShowPhotosCount { get; set; }

        /// <summary>
        /// Дополнительные параметры при желании для других вьюх
        /// </summary>
        public string Args { get; set; }

        public PhotoScrollViewModel()
        {
            Photos = new List<RelatedPhoto>();
            PhotosCount = 4;
            ShowPhotosCount = 0;
        }
    }
}