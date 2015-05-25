using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using smolensk.ViewModels;
using meridian.smolensk.proto;
using meridian.smolensk.system;
using smolensk.Domain;

namespace smolensk.Mappers
{
    public static class NewsMapper
    {
        public static NewsListViewModel CreateListViewModel(Meridian meridian, IEnumerable<news> news)
        {
            return new NewsListViewModel()
            {
                Items = ToListItems(meridian, news).ToArray()
            };
        }

        public static IEnumerable<SingleNewsViewModel> ToListItems(Meridian meridian, IEnumerable<news> news)
        {
            return news.Select(n => CreateSingleNewsItem(meridian, n));
        }

        public static IEnumerable<CategoryViewModel> ToListItems(Meridian meridian, IEnumerable<news_categories> news_categories)
        {
            return news_categories.Select(n => CreateCategory(meridian, n));
        }

        public static CategoryViewModel CreateCategory(Meridian meridian, news_categories news_categories)
        {
            CategoryViewModel result = new CategoryViewModel(news_categories.id);

            result.Title = news_categories.title;
            result.CssClass = news_categories.css_class;

            return result;
        }

        public static CategoriesListViewModel CreateCategoryList(Meridian meridian, IEnumerable<news_categories> categories)
        {
            return new CategoriesListViewModel()
            {
                Categories = ToListItems(meridian, categories)
            };
        } 

        public static SingleNewsViewModel CreateSingleNewsItem(Meridian meridian, news news, bool takeRelated = true)
        {
            SingleNewsViewModel result = new SingleNewsViewModel(news.id);

            result.Title = news.title;
            result.Lead = news.lead_title;
            result.Text = string.IsNullOrEmpty(news.processed_text) ? news.text : news.processed_text;
            result.AuthorAsText = news.author_as_text;
            result.Announce = string.IsNullOrEmpty(news.announce) ? TextHelper.CreateAnnounce(result.Text) : news.announce;
            result.CommentsCount = news.comment_count;
            if (meridian.news_categoriesStore.Exists(news.category_id))
            {
                result.Category = CategoryMapper.ToViewModel(meridian.news_categoriesStore.Get(news.category_id));

                if (takeRelated)
                    result.RelatedNews =
                        news.GetRelatedNews().Select(s => NewsMapper.CreateSingleNewsItem(meridian, s, false)).ToList();

            }
            result.PublishDate = news.publish_date;
            result.Rating = news.rating;
            result.ViewsCount = news.views;
            result.Pictures = ImageMapper.ToImages(news.id);
            result.baseEntity = news;

            return result;
        }
    }
}