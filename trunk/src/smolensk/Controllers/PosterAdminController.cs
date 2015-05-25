using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web.Mvc;
using HtmlAgilityPack;
using meridian.smolensk.controller;
using meridian.smolensk.proto;
using meridian.smolensk.system;
using smolensk.common;
using smolensk.common.Infrastructure;

namespace smolensk.Controllers
{
    public class PosterAdminController : meridian_actions
    {
        public PosterAdminController()
        {
            //DefaultUploadVirtualFolder = Constants.NewsDataFolder;
        }

        public ActionResult Import()
        {
            string imagesPhysicalFolder = Server.MapPath("~" + Constants.ActionsDataFolder);
            string path =  Path.Combine(imagesPhysicalFolder, "Афиша", "data.htm");
            ParseAllCategory(path);

            var result = new ContentResult();
            result.Content = "Done";

            return result;
        }

        #region Parse
        private void ParseAllCategory(string filePath)
        {
            HtmlDocument document = new HtmlDocument();
            document.Load(filePath);

            foreach (var tableNode in document.DocumentNode.SelectNodes("//table"))
                ParseOneCategory(tableNode, Path.GetDirectoryName(filePath));
        }

        private void ParseOneCategory(HtmlNode node, string directoryForImage)
        {
            //категория
            var category = ParseCategory(node);
            if (category == null)
                return;
            category = Meridian.Default.action_categoriesStore.Persist(category);

            places currentPlace = null;
            foreach (var trNode in node.SelectNodes(".//tr"))
            {
                if (trNode.SelectSingleNode("td[@colspan]") != null)
                {
                    //место
                    currentPlace = ParsePlace(trNode);
                    if (currentPlace != null)
                        currentPlace = Meridian.Default.placesStore.Persist(currentPlace);
                }
                else
                {
                    //мероприятие
                    var action = ParseAction(trNode, category.id);
                    if (action == null)
                        continue;
                    action.category_id = category.id;
                    bool isNew = action.id <= 0;
                    action = Meridian.Default.actionsStore.Persist(action);

                    var actionPlace = Meridian.Default.actions_placesStore.Insert( new actions_places 
                    { 
                        place_id = currentPlace.id, 
                        action_id = action.id
                    });

                    //расписание
                    foreach (var dt in ParseSchedule(trNode))
                    { 
                        Meridian.Default.actions_scheduleStore.Insert(new actions_schedule 
                        {
                             datetime = dt,
                             action_place_id = actionPlace.id
                        });
                    }
                    
                    if (isNew)
                    {
                        //жанры
                        foreach (var g in ParseGenres(trNode, category.id))
                        {
                            var genre = Meridian.Default.genresStore.Persist(g);
                            Meridian.Default.actions_genresStore.Insert(new actions_genres
                            {
                                genre_id = genre.id,
                                action_id = action.id
                            });
                        }

                        //фото
                        var imageCode = ClearText(textInSingleNode(trNode, "td[5]"));
                        if (!string.IsNullOrEmpty(imageCode))
                            //var actionFileName = Regex.Replace(action.title, @"[\/:*?<>|""\r\n]", string.Empty);
                            foreach (var imagePath in Directory.GetFiles(
                                        Path.Combine(directoryForImage, category.title), string.Format("{0}*", imageCode)))
                            {
                                Meridian.Default.actions_photosStore.Insert(CreateImage(imagePath, action, category));                       
                            }
                    }
                }
            }
        }

        private action_categories ParseCategory(HtmlNode node)
        {
            var title = textInSingleNode(node, "preceding-sibling::*[2]");
            if (string.IsNullOrEmpty(title))
                return null;
            return FindCategory(title);
        }

        private places ParsePlace(HtmlNode node)
        {
            var title = textInSingleNode(node, ".//p");
            if (string.IsNullOrEmpty(title))
                return null;
            
            var place = FindPlace(title);

            var nodes = node.SelectNodes(".//p[position() > 1]");
            if (nodes != null)
            {
                var placeInfo = nodes.SelectMany(n => n.InnerHtml.Split(new string[] { "<br>" }, StringSplitOptions.RemoveEmptyEntries));

                place.adress = ClearText(placeInfo.FirstOrDefault(i => i.ToLower().Contains("адрес")));
                place.location = ClearText(placeInfo.FirstOrDefault(i => i.ToLower().Contains("проезд")));
                place.phone = ClearText(placeInfo.FirstOrDefault(i => i.ToLower().Contains("телефон")));
                place.work_time = ClearText(placeInfo.FirstOrDefault(i => !i.ToLower().Contains("адрес")
                                                                       && !i.ToLower().Contains("проезд")
                                                                       && !i.ToLower().Contains("телефон")));
            }
            return place;
        }

        private actions ParseAction(HtmlNode node, long categoryId)
        {
            var title = textInSingleNode(node, "td/p");
            if (string.IsNullOrEmpty(title))
                return null;

            var action = FindAction(title);            

            //для кино
            if (categoryId == 1)
            {
                action.country = textInSingleNode(node, "td/p[3]");
                action.duration = ParseInt(textInSingleNode(node, "td/p[4]"));
                action.age_limit = ParseInt(textInSingleNode(node, "td/p[5]"));
            }
            //для театра и детей
            if (categoryId == 2 || categoryId == 10)
            {
                var author = textInSingleNode(node, "td/p[2]");
                var authorAndGenre = author.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                if (authorAndGenre.Length > 0)
                    action.author = authorAndGenre[0];
            }

            //общая часть
            action.text = textInSingleNode(node, "td[2]/p");
            var nodes = node.SelectNodes("td[2]/p[position() > 1]");
            if (nodes != null)
            {
                var actionInfo = nodes.SelectMany(n => n.InnerHtml.Split(new string[] { "<br>" }, StringSplitOptions.RemoveEmptyEntries));
                action.producer = ClearText(actionInfo.FirstOrDefault(i => i.ToLower().Contains("режиссер")));
                action.performers = ClearText(actionInfo.FirstOrDefault(i => i.ToLower().Contains("в ролях")));
            }

            action.approve = true;
            action.published = true;
            action.publish_date = DateTime.Now;

            //пока так
            if (categoryId <= 3)
            {
                action.is_top = true;
                action.is_main = true;
                action.is_main_category = true;
            }
            
            return action;
        }

        private IEnumerable<DateTime> ParseSchedule(HtmlNode node)
        {
            var list = new List<DateTime>();
            int length = 0;
            var date = ParseDate(node.SelectSingleNode("td[3]").InnerText, out length);
            var times = node.SelectSingleNode("td[4]").InnerText
                .Split(new string[] { " ", "\r\n" },StringSplitOptions.RemoveEmptyEntries)
                .Select(t => ParseTime(t));
            if (date != DateTime.MinValue)
                for (var i = date; i <= date.AddDays(length); i = i.AddDays(1))
                    foreach (var t in times)
                        list.Add(i.Add(t));
            return list;
        }

        private IEnumerable<genres> ParseGenres(HtmlNode node, long categoryId)
        {
            var list = new List<genres>();            
            if (categoryId == 1)
            {
                var title = textInSingleNode(node, "td/p[2]");
                list.Add(FindGenre(title));                    
            }
            else if (categoryId == 2 || categoryId == 10)
            {
                var title = textInSingleNode(node, "td/p[2]");
                var authorAndGenre = title.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                if (authorAndGenre.Length > 1)
                    list.Add(FindGenre(authorAndGenre[1]));
            }
            else
            {
                var nodes = node.SelectNodes("td/p[2]");
                if (nodes != null)
                    list.AddRange(nodes.Select(n => FindGenre(n.InnerText)));
            }
            return list;
        }

        private actions_photos CreateImage(string imagePath, actions a, action_categories c)
        {
            ThumbnailGenerator cinemaMainGenerator = new ThumbnailGenerator();
            cinemaMainGenerator.CommandString = "width=82&height=114&mode=crop&anchor=middlecenter";
            ThumbnailGenerator liveMainGenerator = new ThumbnailGenerator();
            liveMainGenerator.CommandString = "width=310&height=114&mode=crop&anchor=middlecenter";

            ThumbnailGenerator listGenerator = new ThumbnailGenerator();
            listGenerator.CommandString = "width=200&height=112&mode=crop&anchor=middlecenter";
            ThumbnailGenerator photoGenerator = new ThumbnailGenerator();
            photoGenerator.CommandString = "width=650&height=420&mode=crop&anchor=middlecenter";

            ImageNamingStrategy strategy = new ImageNamingStrategy(Guid.NewGuid());
            string imagesVirtualFolder = "~" + Constants.ActionsDataFolder;
            string imagesPhysicalFolder = Server.MapPath(imagesVirtualFolder);
            string extension = Path.GetExtension(imagePath);

            string originalFileName = strategy.GetOriginalImageFileName(extension);
            string originalFilePath = Path.Combine(imagesPhysicalFolder, originalFileName);

            System.IO.File.Copy(imagePath, originalFilePath);
            var photo = new actions_photos();
            photo.action_id = a.id;
            photo.normal = Path.GetFileName(photoGenerator.GenerateThumbnail(originalFilePath, Path.Combine(imagesPhysicalFolder, strategy.GetNormalThumbnailName()))); ;
            photo.thumbnail = Path.GetFileName(listGenerator.GenerateThumbnail(originalFilePath, Path.Combine(imagesPhysicalFolder, strategy.GetSmallThumbnailName())));
            photo.is_main = true;

            if (c.id == 1)
                a.image_for_main = Path.GetFileName(cinemaMainGenerator.GenerateThumbnail(originalFilePath, Path.Combine(imagesPhysicalFolder, strategy.GetMediumThumbnailName()))); 
            else if (c.id == 3)
                a.image_for_main = Path.GetFileName(liveMainGenerator.GenerateThumbnail(originalFilePath, Path.Combine(imagesPhysicalFolder, strategy.GetMediumThumbnailName()))); 

            return photo;
        }
        #endregion

        private action_categories FindCategory(string title)
        {
            var text = title.ToLower().Trim();
            var cStore = Meridian.Default.action_categoriesStore;
            var category = cStore.All().Where(c => c.title.ToLower() == text).FirstOrDefault();
            if (category == null)
                category = new action_categories 
                { 
                    title = ToNormalCase(text), 
                    order_id = cStore.All().Max(c => c.order_id) + 1 
                };
            return category;
        }

        private genres FindGenre(string title)
        { 
            var text = title.ToLower().Trim();
            var gStore = Meridian.Default.genresStore;
            var genres = gStore.All().Where(g => g.title.ToLower() == text).FirstOrDefault();
            if (genres == null)
                genres = new genres { title = ToNormalCase(text) };
            return genres;
        }

        private places FindPlace(string title)
        {
            var text = title.ToLower().Trim();
            var pStore = Meridian.Default.placesStore;
            var places = pStore.All().Where(p => p.title.ToLower().Trim() == text).FirstOrDefault();
            if (places == null)
                places = new places { title = title };
            return places;
        }

        private actions FindAction(string title)
        {
            var text = title.ToLower().Trim();
            var aStore = Meridian.Default.actionsStore;
            var action = aStore.All().Where(p => p.title.ToLower().Trim() == text).FirstOrDefault();
            if (action == null)
                action = new actions { title = title };
            return action;
        }

        private string textInSingleNode(HtmlNode node, string xpath)
        {
            var sNode = node.SelectSingleNode(xpath);
            return sNode!= null ? sNode.InnerText : string.Empty;
        }

        private int ParseInt(string text)
        {
            var number = Regex.Match(text, @"\d+");
            return number.Success ? int.Parse(number.Value) : 0;
        }

        private DateTime ParseDate(string text, out int length)
        {
            //возможные варианты.
            //1 октября
            //1-2 октября
            //1 и 2 октября
            //с 1 по 2 октября
            //с 1 сентября по 2 октября
            //постоянно (?!)
            
            length = 1;
            var months = new string[] { "января", "февраля", "марта", "апреля", "мая", "июня", 
                                        "июля", "августа", "сентября", "октября", "ноября", "декабря" };
            
            text = ClearText(text).ToLower();
            var search = Regex.Matches(text, @"\d+");
            if (search.Count == 0)
                return DateTime.MinValue;

            bool isPeriod = search.Count > 1;
            
            List<int> listMonths = new List<int>();
            for (var i = 0; i < months.Length; i++)
                if (text.Contains(months[i]))
                    listMonths.Add(i + 1);

            if (listMonths.Count == 0)
                return DateTime.MinValue;

            var from = new DateTime(DateTime.Now.Year, listMonths.Min(), int.Parse(search[0].Value));

            if (isPeriod)
            {
                var to = new DateTime(DateTime.Now.Year, listMonths.Max(), int.Parse(search[1].Value));
                length = to.Subtract(from).Days;
            }
            return from;
        }

        private TimeSpan ParseTime(string text)
        {
            //возможные варианты.
            //18:30
            //По графику работы (?!)
            CultureInfo ruRu = new CultureInfo("ru-RU");
            DateTime result = DateTime.MinValue;
            text = text.Trim();
            DateTime.TryParseExact(text, "HH:mm", ruRu, DateTimeStyles.AllowWhiteSpaces, out result);
            return result.TimeOfDay;
        }

        private string ClearText(string text)
        {
            if (string.IsNullOrEmpty(text))
                return string.Empty;
            //убрать все теги
            text = Regex.Replace(text, "<[^>]*?>", string.Empty, RegexOptions.IgnoreCase);
            //убрать все переносы строки
            text = text.Replace("\r\n", string.Empty);
            //убрать слово до двоеточия
            text = Regex.Replace(text, "^.*?:", string.Empty, RegexOptions.IgnoreCase);

            return text.Trim();
        }

        private string ToNormalCase(string text)
        {
            text = text.ToLower().Trim();
            if (string.IsNullOrEmpty(text))
                return string.Empty;

            return text.Substring(0, 1).ToUpper() + text.Substring(1, text.Length - 1);
        }

    } 
}