using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using meridian.smolensk.proto;

namespace smolensk.Extensions
{
    public static class IExtension
    {
        public static string CommentMaterialType(this IComment iComment)
        {
            switch (iComment.MaterialProtoName)
            {
                case "news":
                    return "Новости";
                case "blogs":
                    return "Блоги";
                case "companies":
                    return "Компании";
                case "actions":
                    return "Объявления";
                case "restaurants":
                    return "Рестораны";
                case "sales":
                    return "Скидки";
                default:
                    return "Комментарии";
            }
        }

        public static string MarkMaterialType(this IMarkableMaterial iMark)
        {
            switch (iMark.ProtoName)
            {
                case "news_marks":
                    return "Новости";
                case "blog_marks":
                    return "Блоги";
                case "company_rating":
                    return "Компании";
                case "actions_rating":
                    return "Объявления";
                case "restaurant_rating":
                    return "Рестораны";
                case "places_rating":
                    return "Места";
                case "photobank_photos_rating":
                    return "Фотобанк";
                default:
                    return "Оценки";
            }
        }
    }
}