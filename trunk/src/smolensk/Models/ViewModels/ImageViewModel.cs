using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace smolensk.ViewModels
{
    public class ImageViewModel : EntityBaseViewModel
    {
        public ImageViewModel(long id) : base(id)
        {
            Description = string.Empty;
            Alt = string.Empty;
        }

        /// <summary>
        /// Превью размером 80x80
        /// </summary>
        public Picture SmallThumbnail { get; set; }

        /// <summary>
        /// Превью размером 141x94
        /// </summary>
        public Picture MediumThumbnail { get; set; }

        /// <summary>
        /// Превью размером 463х296
        /// </summary>
        public Picture LargeThumbnail { get; set; }

        /// <summary>
        /// Картинка, ограниченная размерами 800х800
        /// </summary>
        public Picture NormalThumbnail { get; set; }

        /// <summary>
        /// Оригинальное изображение
        /// </summary>
        public Picture OriginalImage { get; set; }

        /// <summary>
        /// Описание и copyright
        /// </summary>
        public string Description { get; set; }

        public string Alt { get; set; }

        public string GetSafeDescription()
        {
            return this.Description ?? string.Empty;
        }
    }
}