using System.Linq;
using System.Web.Mvc;
using meridian.smolensk.controller;
using meridian.smolensk.proto;
using meridian.smolensk.system;
using smolensk.common;
using System;
using System.Net;
using System.IO;
using System.Collections.Generic;
using HtmlAgilityPack;
using System.Collections.Specialized;
using smolensk.common.Infrastructure;
using System.Web;
using System.Text.RegularExpressions;
using System.Threading;
using log4net;
using System.Reflection;

namespace smolensk.Controllers
{
    public class AdvertsAdminController : meridian_ad_advertisments
    {
        private const int RequestTimeout = 5 * 60 * 1000;
        private const char Dash = '-';
        private const string RabotaReferer = "http://smolensk.rabota.ru/";

        private static readonly Regex NonDigitRegex = new Regex(@"[^\d]");
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public AdvertsAdminController()
        {
        }

        public ActionResult ImportRealty()
        {
            // получим страницу с однушками
            string oneRoomHome = GetPage(new Uri("http://smolensk.irr.ru/real-estate/apartments-sale/search/rooms=1/currency=RUR/page_len60/hasimages=1/"));
            ParseApartmentList(oneRoomHome);

            string twoRoomHome = GetPage(new Uri("http://smolensk.irr.ru/real-estate/apartments-sale/search/rooms=2/currency=RUR/page_len60/hasimages=1/"));
            ParseApartmentList(twoRoomHome);

            string threeRoomHome = GetPage(new Uri("http://smolensk.irr.ru/real-estate/apartments-sale/search/rooms=3/currency=RUR/page_len60/hasimages=1/"));
            ParseApartmentList(threeRoomHome);

            return ReportOk();
        }

        public ActionResult ImportVacancies()
        {
            for (int i = 0; i < 6; i++)
            {
                string listPage = GetPage(BuildVacanciesListUri(i));
                var urls = ParseVacancyUrls(listPage);
                ParseVacancies(urls);
            }

            return ReportOk();
        }

        private void ParseVacancies(IEnumerable<Uri> urls)
        {
            foreach (var url in urls)
            {
                try
                {
                    ParseSingleVacancy(url);
                    WaitRandomSeconds();
                }
                catch (Exception ex)
                {
                    log.DebugFormat("Failed to parse vacancy '{0}'", url);
                    log.DebugFormat(ex.ToString());
                }
            }
        }

        private void ParseSingleVacancy(Uri url)
        {
            string page = GetPage(url, RabotaReferer);

            HtmlDocument document = new HtmlDocument();
            document.LoadHtml(page);

            var vacancy = new vacancies();
            vacancy.account_id = 1;
            vacancy.city_id = 1;
            vacancy.work_city_id = 1;
            vacancy.work_region_id = 1;
            vacancy.created = DateTime.Now;
            vacancy.edited = vacancy.created;
            vacancy.is_publish = true;
            vacancy.url = url.ToString();

            var vacancyNode = document.DocumentNode.SelectSingleNode("//div[@class='list_kval pd_h']");
            var requirements = new List<string>();
            var duties = new List<string>();
            var conditions = new List<string>();
            List<string> currentList = null;
            foreach (var node in vacancyNode.ChildNodes)
            {
                if (node.NodeType == HtmlNodeType.Text)
                    continue;

                if (node.Name.ToLower().Equals("strong"))
                {
                    string text = Cleanup(node.InnerText).ToLower();
                    if (text.Contains("требования"))
                        currentList = requirements;
                    else if (text.Contains("обязанности"))
                        currentList = duties;
                    else if (text.Contains("условия"))
                        currentList = conditions;
                    else
                        currentList = null;
                }

                if (node.Name.ToLower().Equals("p"))
                    currentList = null;

                if (node.Name.ToLower().Equals("ul") && currentList != null)
                {
                    var items = node.SelectNodes("li");
                    foreach (var item in items)
                    {
                        string itemText = Cleanup(item.InnerText);
                        if (!string.IsNullOrEmpty(itemText))
                            currentList.Add(itemText);
                    }
                    currentList = null;
                }
            }

            // не смогли распознать вакансию
            if (requirements.Count + duties.Count + conditions.Count == 0)
                return;

            vacancy.requirements = string.Join(Environment.NewLine, requirements);
            vacancy.responsibility = string.Join(Environment.NewLine, duties);
            vacancy.terms = string.Join(Environment.NewLine, conditions);

            //компания
            var company = ExtractCompany(document);

            vacancy.company_id = company.id;
            Meridian.Default.vacanciesStore.Persist(vacancy);

            ExtractPosition(document, vacancy);
            ExtractSalary(document, vacancy);
            ExtractExperience(document, vacancy);
            ExtractEducation(document, vacancy);
            ExtractWorkHours(document, vacancy); // график работы

            var nodes = vacancyNode.SelectNodes("//div[@class='offerTree']");
            if (nodes != null)
            {
                foreach (var rootFieldNode in nodes)
                {
                    var categoryNode = rootFieldNode.SelectSingleNode("p[@class='text_14 bold']/a");
                    string categoryName = Cleanup(categoryNode.InnerText);

                    var parentField = Meridian.Default.vacancy_professionalsStore.All().FirstOrDefault(p => p.title.ToLower().Equals(categoryName.ToLower()));
                    if (parentField == null)
                        parentField = new vacancy_professionals() { title = categoryName };

                    AddProfessionalField(vacancy, parentField);

                    var childFieldNodes = rootFieldNode.SelectNodes("p[@class='text_12']");
                    if (childFieldNodes != null)
                    {
                        foreach (var childFieldNode in childFieldNodes)
                        {
                            categoryName = Cleanup(childFieldNode.InnerText);

                            var childField = Meridian.Default.vacancy_professionalsStore.All()
                                .FirstOrDefault(p => p.parent_id == parentField.id && p.title.ToLower().Equals(categoryName.ToLower()));
                            if (childField == null)
                                childField = new vacancy_professionals() { title = categoryName, parent_id = parentField.id };

                            AddProfessionalField(vacancy, childField);
                        }
                    }
                }
            }

            var companyNode = document.DocumentNode.SelectSingleNode("//div[@class='mb_10 fright w240']/div[@class='bg_act br_5 p16']");
            var tempNode = companyNode.SelectSingleNode("p[@class='mb_10']");
            if (tempNode != null)
                vacancy.contact_person = Cleanup(tempNode.InnerText);

            nodes = companyNode.SelectNodes("//div[@class='phoneItem']");
            if (nodes != null)
            {
                if (nodes.Count > 0)
                    vacancy.contact_phone = Cleanup(nodes[0].InnerText);
            }

            Meridian.Default.vacanciesStore.Persist(vacancy);
        }

        private void WaitRandomSeconds()
        {
            Random rnd = new Random();
            int seconds = rnd.Next(5, 20);
            Thread.Sleep(seconds * 1000);
        }

        private void AddProfessionalField(vacancies vacancy, vacancy_professionals field)
        {
            Meridian.Default.vacancy_professionalsStore.Persist(field);

            var v = new vacancies_professionals() { vacancy_id = vacancy.id, professional_id = field.id };
            vacancy.AddProfressionals(v, true);
        }

        private void ExtractWorkHours(HtmlDocument document, vacancies vacancy)
        {
            var workhours = new Dictionary<string, long>() 
            {
                { "свободный", 17 },
                { "удаленная работа", 18}
            };

            var entry = Meridian.Default.vacancy_entriesStore.Get(15); // полный день

            var node = document.DocumentNode.SelectSingleNode("(//td[@class='pb10 pl20'])[2]/p[@class='bold']");
            if (node != null)
            {
                long id;
                if (workhours.TryGetValue(Cleanup(node.InnerText).ToLower(), out id))
                    entry = Meridian.Default.vacancy_entriesStore.Get(id); 
            }

            AddVacancyField(vacancy, entry);
        }

        private void AddVacancyField(vacancies vacancy, vacancy_entries entry)
        {
            var v = new vacancies_entries() { vacancy_id = vacancy.id, vacancy_entry_id = entry.id };
            vacancy.AddEntries(v, true);
        }

        private void ExtractEducation(HtmlDocument document, vacancies vacancy)
        {
            var educations = new Dictionary<string, long>()
            {
                { "среднее специальное", 23},
                { "высшее", 21}
            };

            var entry = Meridian.Default.vacancy_entriesStore.Get(20); // не имеет значения

            var node = document.DocumentNode.SelectSingleNode("(//td[@class='pb10 pl20'])[1]/p[@class='bold']");
            if (node != null)
            {
                long id;
                if (educations.TryGetValue(Cleanup(node.InnerText).ToLower(), out id))
                    entry = Meridian.Default.vacancy_entriesStore.Get(id); 
            }

            AddVacancyField(vacancy, entry);
        }

        private void ExtractExperience(HtmlDocument document, vacancies vacancy)
        {
            var experiences = new Dictionary<string, long>()
            {
                { "до 2 лет", 3 }, // от года до 3х    
                { "2-3 года", 3 }, // от года до 3х
                { "3-5 лет", 4 }
            };

            var node = document.DocumentNode.SelectSingleNode("//td[@class='pl22']/p[@class='bold']");

            var entry = Meridian.Default.vacancy_entriesStore.Get(2); // опыт не имеет значения
            if (node != null)
            {
                long id;
                if (experiences.TryGetValue(Cleanup(node.InnerText).ToLower(), out id))
                    entry = Meridian.Default.vacancy_entriesStore.Get(id);
            }

            AddVacancyField(vacancy, entry);
        }

        private void ExtractSalary(HtmlDocument document, vacancies vacancy)
        {
            var node = document.DocumentNode.SelectSingleNode("//p[@class='title_20 mt_10 mb_20 fleft']");

            string salaryText = node.InnerText.Replace("руб.", string.Empty);
            //от 14 800 руб.
            if (salaryText.StartsWith("от"))
            {
                vacancy.compensation1 = ParseSalary(salaryText);
            }
            //10 000 - 20 000 руб.
            else if (salaryText.Contains(Dash))
            {
                string[] salaries = salaryText.Split(Dash);
                if (salaries.Length == 2)
                {
                    vacancy.compensation1 = ParseSalary(salaries[0]);
                    vacancy.compensation2 = ParseSalary(salaries[1]);
                }
            }
        }

        private int ParseSalary(string salaryText)
        {
            string strippedNumbers = NonDigitRegex.Replace(salaryText, string.Empty);

            return int.Parse(strippedNumbers);
        }

        private void ExtractPosition(HtmlDocument document, vacancies vacancy)
        {
            var node = document.DocumentNode.SelectSingleNode("//p[@class='title_30']");

            vacancy.title = Cleanup(node.InnerText);
        }

        private companies ExtractCompany(HtmlDocument document)
        {
            var node = document.DocumentNode.SelectSingleNode("//div[@class='mb_10 fright w240']/div[@class='bg_act br_5 p16']/div/a");
            string name = node.InnerText.Trim();

            int lastCommaIndex = name.LastIndexOf(',');
            company_ownerships ownership = null;
            if (lastCommaIndex > 0)
            {
                string ownershipName = Cleanup(name.Substring(lastCommaIndex + 1));
                name = name.Remove(lastCommaIndex);

                ownership = Meridian.Default.company_ownershipsStore.All().FirstOrDefault(o => o.title.ToLower().Equals(ownershipName.ToLower()));
            }

            var result = Meridian.Default.companiesStore.All().FirstOrDefault(c => c.title.ToLower().Equals(name.ToLower()));
            if (result != null)
                return result;

            var companyUrl = new Uri(GetLinkAddress(node), UriKind.Absolute);
            var companyPage = GetPage(companyUrl, RabotaReferer);

            result = ParseCompany(companyPage, name, ownership);

            return result;
        }

        private companies ParseCompany(string companyPage, string defaultName, company_ownerships ownership)
        {
            HtmlDocument document = new HtmlDocument();
            document.LoadHtml(companyPage);

            var result = new companies();

            result.title = ExtractCompanyTitle(document).Trim();
            if (string.IsNullOrEmpty(result.title))
                result.title = defaultName;

            result.description = ExtractCompanyDescription(document).Trim();
            result.address = ExtractCompanyAddress(document).Trim();
            result.phones = ExtractCompanyPhones(document).Trim();
            result.publish_date = DateTime.Now;
            result.www = ExtractCompanySite(document).Trim();

            if (ownership != null)
                result.ownership_id = ownership.id;

            string categoryName = string.Empty;
            var node = document.DocumentNode.SelectSingleNode("//div[@id='tree3']/p[@class='text_12 bold']");
            if (node != null)
                categoryName = Cleanup(node.InnerText);

            string subcategoryName = string.Empty;
            node = document.DocumentNode.SelectSingleNode("//div[@id='tree3']/div[@class='treeList pb10']/p[@class='treeItem']");
            if (node != null)
                subcategoryName = Cleanup(node.InnerText);

            result.category_id = 78; // без спецподготовки / все
            if (!string.IsNullOrEmpty(categoryName))
            {
                var category = Meridian.Default.company_categoriesStore.All().FirstOrDefault(cc => cc.title.ToLower().Equals(categoryName.ToLower()));
                if (category == null)
                {
                    category = new company_categories();
                    category.name = categoryName;

                    Meridian.Default.company_categoriesStore.Persist(category);
                }

                result.category_id = category.id;

                if (!string.IsNullOrEmpty(subcategoryName))
                {
                    category = Meridian.Default.company_categoriesStore.All().FirstOrDefault(cc => cc.parent == category.id && cc.title.ToLower().Equals(subcategoryName.ToLower()));
                    if (category == null)
                    {
                        category = new company_categories();
                        category.name = subcategoryName;
                        category.parent = result.category_id;

                        Meridian.Default.company_categoriesStore.Persist(category);
                    }

                    result.category_id = category.id;
                }
            }

            Meridian.Default.companiesStore.Insert(result);

            return result;
        }

        private string ExtractCompanyTitle(HtmlDocument document)
        {
            var node = document.DocumentNode.SelectSingleNode("//div[@class='title_18']");
            if (node == null)
                return string.Empty;

            return HttpUtility.HtmlEncode(node.InnerText);
        }

        private string ExtractCompanyDescription(HtmlDocument document)
        {
            var node = document.GetElementbyId("eInfoDesc_0");

            if (node == null)
                return string.Empty;

            return HttpUtility.HtmlEncode(node.InnerHtml);
        }

        private string ExtractCompanyAddress(HtmlDocument document)
        {
            var nodes = document.DocumentNode.SelectNodes("//div[@class='phoneNum']/p[@class='mb_10']");
            if (nodes != null)
            {
                foreach (var node in nodes)
                {
                    var span = node.SelectSingleNode("span");
                    if (span.InnerText.ToLower().Contains("адрес"))
                        return Cleanup(node.InnerText.Replace("Адрес", string.Empty));
                }
            }

            return string.Empty;
        }

        private string ExtractCompanyPhones(HtmlDocument document)
        {
            var list = new List<string>();
            var nodes = document.DocumentNode.SelectNodes("//div[@class='phoneItem']");
            if (nodes != null)
            {
                foreach (var node in nodes)
		            list.Add(Cleanup(node.InnerText));
            }

            return string.Join(", ", list);
        }

        private string ExtractCompanySite(HtmlDocument document)
        {
            var node = document.DocumentNode.SelectSingleNode("//div[@class='phoneNum']/p[@class='mb_10']/noindex/a[@href!='#']");
            if (node != null)
                return GetLinkAddress(node);

            return string.Empty;
        }

        private static ActionResult ReportOk()
        {
            var result = new ContentResult();
            result.Content = "Done";

            return result;
        }

        private IEnumerable<Uri> ParseVacancyUrls(string listPageHtml)
        {
            HtmlDocument document = new HtmlDocument();
            document.LoadHtml(listPageHtml);

            var result = new List<Uri>(40);
            var links = document.DocumentNode.SelectNodes("//div[@class='inset_vac']/div/a[@class='bold text_14']");
            foreach (var node in links)
            {
                string href = GetLinkAddress(node);
                if (!string.IsNullOrEmpty(href))
                    result.Add(new Uri(href, UriKind.Absolute));
            }

            return result;
        }

        private Uri BuildVacanciesListUri(int page)
        { 
            return new Uri("http://smolensk.rabota.ru/v3_searchVacancyByParamsResults.html?" + 
                "wt=f&c=258&cu=2&p=30&sm=103&d=desc&cs=t&or=t&pp=40&fv=f&pt=1379102400&usl=f&krl%5B0%5D=362&rc=224&sub=f&start=" + page * 40);
        }

        private void ParseApartmentList(string listPageHtml)
        {
            var advertLinks = ExtractLinksFromListPage(listPageHtml);
            foreach (var link in advertLinks)
                ParseSingleApartment(link);
        }

        private void ParseSingleApartment(Uri pageLink)
        {
            var meridian = Meridian.Default;

            string pageHtml = GetPage(pageLink);
            HtmlDocument document = new HtmlDocument();
            document.LoadHtml(pageHtml);

            string contactPerson = ExtractContactPersonAdverts(document).Trim();
            string description = ExtractDescription(document).Trim();
            string address = ExtractAddress(document).Trim();
            string price = ExtractPrice(document).Trim();

            var fieldCollection = ParseFields(document);

            string roomsCount = fieldCollection["Комнат в квартире:"];
            string area = fieldCollection["Общая площадь:"];
            string title = BuildTitle(roomsCount, address);
            if (meridian.ad_advertismentsStore.All().Any(a => a.title.Equals(title)))
                return;

            var advert = new ad_advertisments()
            {
                account_id = 1,
                category_id = 14, // недвижимость/квартиры
                created_date = DateTime.Now,
                title = title,
                description = description,
                price = double.Parse(price),
                name = contactPerson,
                url = pageLink.ToString()
            };

            var advertTypeSaleField = new ad_fields()
            { 
                ad_id = advert.id,
                description_id = 9, // тип предложения
                value_id = 17 // продажа
            };

            bool isSecondary = pageLink.PathAndQuery.Contains("/secondary/");
            var realtyTypeDescriptionField = new ad_fields()
            {
                ad_id = advert.id,
                description_id = 12, // тип недвижки
                value_id = isSecondary ? 19 : 18 // вторичка/первичка
            };

            var addressField = new ad_fields()
            {
                ad_id = advert.id,
                description_id = 10,
                value = address
            };

            var areaField = new ad_fields()
            {
                ad_id = advert.id,
                description_id = 11,
                value = area
            };

            var buildingTypeField = new ad_fields()
            {
                ad_id = advert.id,
                description_id = 13,
                value_id = 21 // панельный
            };

            var roomDictionary = new Dictionary<string, long>()
            {
                {"1" , 25L},
                {"2" , 26L},
                {"3" , 27L}
            };
            
            var roomsCountField = new ad_fields()
            {
                ad_id = advert.id,
                description_id = 14,
                value_id = roomDictionary[roomsCount]
            };

            Meridian.Default.ad_advertismentsStore.Persist(advert);
            advert.AddAdFields(advertTypeSaleField, true);
            advert.AddAdFields(realtyTypeDescriptionField, true);
            advert.AddAdFields(addressField, true);
            advert.AddAdFields(areaField, true);
            advert.AddAdFields(buildingTypeField, true);
            advert.AddAdFields(roomsCountField, true);

            ParseImages(document, advert.id);
        }

        private void ParseImages(HtmlDocument document, long advertId)
        {
            var images = new List<ad_photos>();
            var imageNodes = document.DocumentNode.SelectNodes("//ul[@class='slider_pagination overview']/li/a/img");
            ImageDownloader downloader = new ImageDownloader();
            ThumbnailGenerator listGenerator = new ThumbnailGenerator();
            listGenerator.CommandString = "width=99&height=66&mode=crop&anchor=middlecenter";
            ThumbnailGenerator photoGenerator = new ThumbnailGenerator();
            photoGenerator.CommandString = "width=330&height=220&mode=crop&anchor=middlecenter";
            foreach (var node in imageNodes)
            {
                string thumbnailUrl = node.GetAttributeValue("src", "");
                string fullImageUrl = thumbnailUrl.Replace("-small", "-view");
                Uri imageUri = new Uri(fullImageUrl, UriKind.Absolute);

                try
                {
                    ImageNamingStrategy strategy = new ImageNamingStrategy(Guid.NewGuid());
                    string imagesVirtualFolder = "~" + Constants.AdvertsDataFolder;
                    string imagesPhysicalFolder = Server.MapPath(imagesVirtualFolder);
                    string extension = Path.GetExtension(imageUri.AbsolutePath);

                    string originalFileName = strategy.GetOriginalImageFileName(extension);
                    string originalFilePath = Path.Combine(imagesPhysicalFolder, originalFileName);
                    downloader.DownloadImage(new Uri(fullImageUrl), originalFilePath);

                    var photo = new ad_photos();
                    photo.ad_id = advertId;
                    photo.create_date = DateTime.Now;
                    photo.original = originalFileName;
                    photo.photo = Path.GetFileName(photoGenerator.GenerateThumbnail(originalFilePath, Path.Combine(imagesPhysicalFolder, strategy.GetMediumThumbnailName())));
                    photo.preview = Path.GetFileName(listGenerator.GenerateThumbnail(originalFilePath, Path.Combine(imagesPhysicalFolder, strategy.GetSmallThumbnailName())));

                    images.Add(photo);
                }
                catch (WebException)
                { 
                    //молча качаем картинки дальше
                }
            }

            foreach (var image in images)
                Meridian.Default.ad_photosStore.Persist(image);
        }

        private string ExtractPrice(HtmlDocument document)
        {
            string result = document.DocumentNode.SelectSingleNode("//div[@class='credit_cost']").InnerText;

            return result.Replace(".", "").Replace("руб", "");
        }

        private string BuildTitle(string roomsCount, string address)
        {
            string title = "Однокомнатная квартира";
            if (roomsCount.Equals("2"))
                title = "Двухкомнатная квартира";
            else if (roomsCount.Equals("3"))
                title = "Трехкомнатная квартира";

            if (!string.IsNullOrEmpty(address))
                title += ", " + address;

            return title;
        }

        private NameValueCollection ParseFields(HtmlDocument document)
        {
            NameValueCollection result = new NameValueCollection();
            var liNodes = document.DocumentNode.SelectNodes("//div[@class='additional-features']/ul[@class='form_info form_info_short']/li");
            foreach (var node in liNodes)
            {
                var pNodes = node.SelectNodes("p");
                string name = pNodes[0].InnerText;
                string value = pNodes[1].InnerText;

                result.Add(name.Trim(), value.Replace("кв.м", "").Trim());
            }

            return result;
        }

        private string ExtractAddress(HtmlDocument document)
        {
            var node = document.DocumentNode.SelectSingleNode("//a[@class='address_link']");
            if (node != null)
                return node.InnerText.Replace("Смоленск, ", "");

            return string.Empty;
        }

        private string ExtractDescription(HtmlDocument document)
        {
            return document.DocumentNode.SelectSingleNode("//div[@class='content_left']/p[@class='text']").InnerText;
        }

        private string ExtractContactPersonAdverts(HtmlDocument document)
        {
            var node = document.GetElementbyId("contact_phones");
            if (node != null)
            {
                string data = node.InnerText;
                string[] parts = data.Split('—');

                if (parts.Length > 1)
                    return parts[0].Replace("+XXXXXXXXXXX", "").Replace("+X(XXX)XXX-XX-XX", "").Replace(",", "").Trim();
            }

            return "Не указано";
        }

        private IEnumerable<Uri> ExtractLinksFromListPage(string listPageHtml)
        {
            HtmlDocument document = new HtmlDocument();
            document.LoadHtml(listPageHtml);

            var result = new List<Uri>(60);
            HtmlNodeCollection anchors = document.DocumentNode.SelectNodes("//div[@class='add_list add_type4 ']/a[@class='add_pic']");
            foreach (var node in anchors)
            {
                string uri = GetLinkAddress(node);
                result.Add(new Uri(uri));
            }

            return result;
        }

        private static string GetLinkAddress(HtmlNode anchor)
        {
            return anchor.GetAttributeValue("href", string.Empty);
        }

        private static string Cleanup(string value)
        {
            return value.Replace("&nbsp;", string.Empty).Trim();
        }

        private string GetPage(Uri imageUri, string referer = null)
        {
            WebResponse response = MakeRequest(imageUri, referer);

            using (StreamReader reader = new StreamReader(response.GetResponseStream(), true))
            {
                return reader.ReadToEnd();
            }
        }

        private WebResponse MakeRequest(Uri pageUri, string referer)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(pageUri);
            request.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 6.0; WOW64; SLCC1; .NET CLR 2.0.50727; .NET CLR 3.0.04506; InfoPath.2; .NET CLR 3.5.21022)";
            request.Accept = "Accept: image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, application/x-shockwave-flash, application/msword, application/xaml+xml, application/vnd.ms-xpsdocument, application/x-ms-xbap, application/x-ms-application, */*";
            request.Timeout = RequestTimeout;
            if (referer != null)
                request.Referer = referer;

            return request.GetResponse();
        }
   
    }
}