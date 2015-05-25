using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using meridian.smolensk.proto;
using smolensk.common;

namespace smolensk.Models.ViewModels.Blogs
{
    public class BlogsListViewModel
    {
        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }
        public BlogListType ListType { get; set; }
        public DateFilterTypes dateFilter { get; set; }
        public SortingType sortingType { get; set; }
        public IEnumerable<blogs> Blogs { get; set; }
        public blog_categories Category { get; set; }
        public long? authorId { get; set; }

        public BlogsListViewModel()
        {
            TotalPages = 1;
            CurrentPage = 1;
            ListType = BlogListType.Main;
            dateFilter = DateFilterTypes.ToDay;
            sortingType = SortingType.Rating;
        }
    }

    public enum BlogListType
    {
        /// <summary>
        /// Интересное на главной
        /// </summary>
        [Description("Интересное")]
        Main = 1,
        /// <summary>
        /// Записи в блоге автора
        /// </summary>
        [Description("Записи в блоге")]
        Author = 2,
        /// <summary>
        /// Выбранная категория
        /// </summary>
        [Description("Все категории")]
        Category = 3,
    }
}