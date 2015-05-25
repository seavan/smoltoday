using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcSiteMapProvider;
using MvcSiteMapProvider.Web.Mvc.Filters;
using meridian.smolensk.system;
using smolensk.Models.ViewModels;
using smolensk.Domain;
using smolensk.Models.ViewModels.Blogs;
using smolensk.Services;
using meridian.smolensk.proto;
using smolensk.Mappers;
using smolensk.common;
using smolensk.Extensions;
using smolensk.Models.ModelValidators.Attributes;
using smolensk.Models.ViewModels.Profile;
using smolensk.common.Infrastructure;
using meridian.smolensk.impl.Images;
using System.IO;

namespace smolensk.Controllers
{
    public class ProfileController : BaseController
    {
        public ActionResult Index()
        {
            if (!Request.IsAuthenticated)
                return RedirectToAction("Index", "Main"); //throw new HttpException(404, "Not Found");

            ViewBag.Main = true;

            return View("Profile", HttpContext.UserPrincipal());
        }

        public ActionResult User(long? userId)
        {
            if (!userId.HasValue)
                return RedirectToAction("Index");

            if (Request.IsAuthenticated && HttpContext.UserPrincipal().id == userId)
            {
                return RedirectToAction("Index");
            }

            if(meridian.accountsStore.Exists(userId.Value))
            {
                return View("Profile", meridian.accountsStore.Get(userId.Value));
            }
            
            throw new HttpException(404, "Not Found");
        }

        [Authorize403()]
        public ActionResult Messages(SortingDirection sortDirection = SortingDirection.Desc, int page = 1)
        {
            var messages = meridian.my_messagesStore.LoadUserMessages(HttpContext.UserPrincipal().id);

            if (sortDirection == SortingDirection.Desc)
            {
                messages = messages.OrderByDescending(m => m.create_date);
            }
            else
            {
                messages = messages.OrderBy(m => m.create_date);
            }

            MessagesList model = new MessagesList();
            model.TotalPages = MappingUtils.CalculatePagesCount(messages.Count(), Constants.DefaultListPageSize);
            model.Messages = MappingUtils.TakePage(messages, page, Constants.DefaultListPageSize);
            model.CurrentPage = page;
            model.sortDirection = sortDirection;

            return View(model);
        }

        [Authorize403()]
        public ActionResult Comments(SortingDirection sortDirection = SortingDirection.Desc, int page = 1)
        {
            long uId = HttpContext.UserPrincipal().id;
            List<IComment> entityList = new List<IComment>();
            entityList.AddRange(meridian.blog_commentsStore.LoadUserComments(uId));
            entityList.AddRange(meridian.actions_commentsStore.LoadUserComments(uId));
            entityList.AddRange(meridian.comments_newsStore.LoadUserComments(uId));
            entityList.AddRange(meridian.company_commentsStore.LoadUserComments(uId));
            entityList.AddRange(meridian.restaurant_commentsStore.LoadUserComments(uId));
            entityList.AddRange(meridian.sales_commentsStore.LoadUserComments(uId));

            if (sortDirection == SortingDirection.Desc)
            {
                entityList = entityList.OrderByDescending(m => m.CreateDate).ToList();
            }
            else
            {
                entityList = entityList.OrderBy(m => m.CreateDate).ToList();
            }

            CommentsList model = new CommentsList();
            model.TotalPages = MappingUtils.CalculatePagesCount(entityList.Count(), Constants.DefaultListPageSize);
            model.Comments = MappingUtils.TakePage(entityList, page, Constants.DefaultListPageSize);
            model.CurrentPage = page;
            model.sortDirection = sortDirection;

            return View(model);
        }

        [Authorize403()]
        public ActionResult Marks(SortingDirection sortDirection = SortingDirection.Desc, int page = 1)
        {
            long uId = HttpContext.UserPrincipal().id;
            List<IMarkableMaterial> entityList = new List<IMarkableMaterial>();

            entityList.AddRange(meridian.restaurant_ratingStore.LoadUserMarks(uId));
            entityList.AddRange(meridian.places_ratingStore.LoadUserMarks(uId));
            entityList.AddRange(meridian.photobank_photos_ratingStore.LoadUserMarks(uId));
            entityList.AddRange(meridian.news_marksStore.LoadUserMarks(uId));
            entityList.AddRange(meridian.blog_marksStore.LoadUserMarks(uId));
            entityList.AddRange(meridian.company_ratingStore.LoadUserMarks(uId));
            entityList.AddRange(meridian.actions_ratingStore.LoadUserMarks(uId));

            if (sortDirection == SortingDirection.Desc)
            {
                entityList = entityList.OrderByDescending(m => m.CreateDate).ToList();
            }
            else
            {
                entityList = entityList.OrderBy(m => m.CreateDate).ToList();
            }


            MarksList model = new MarksList();
            model.TotalPages = MappingUtils.CalculatePagesCount(entityList.Count(), Constants.DefaultListPageSize);
            model.Marks = MappingUtils.TakePage(entityList, page, Constants.DefaultListPageSize);
            model.CurrentPage = page;
            model.sortDirection = sortDirection;

            return View(model);
        }

        [Authorize403()]
        public ActionResult Restaurants(int page = 1)
        {
            long uId = HttpContext.UserPrincipal().id;
            var model = meridian.GetRestaurantsReserveListViewModel(uId, page);
            model.RouteName = "ProfileRestaurants";

            return View(model);
        }

        [Authorize403()]
        public ActionResult Blog()
        {
            return View(HttpContext.UserPrincipal());
        }

        [Authorize403()]
        public ActionResult BlogsList(int page = 1)
        {
            long authorId = HttpContext.UserPrincipal().id;

            BlogsListViewModel model = new BlogsListViewModel();
            var blogs = meridian.blogsStore.LoadList(SortingType.Novelty, (long?)null, authorId, true);
            model.TotalPages = MappingUtils.CalculatePagesCount(blogs.Count(), Constants.DefaultListPageSize);
            model.Blogs = MappingUtils.TakePage(blogs, page, Constants.DefaultListPageSize);
            model.CurrentPage = page;

            return PartialView(model);
        }

        [Authorize403()]
        public ActionResult PhotoBank(int page = 1)
        {
            accounts cAccounts = HttpContext.UserPrincipal();
            var oPhotos = meridian.photobank_obtainedStore.LoadUserObtainedPhotos(cAccounts.id);
            ObtainedPhotoList model = new ObtainedPhotoList();
            model.TotalPages = MappingUtils.CalculatePagesCount(oPhotos.Count(), Constants.PhotosPageSize);
            model.ObtainedPhotos = MappingUtils.TakePage(oPhotos, page, Constants.PhotosPageSize);
            model.CurrentPage = page;
            model.HasProfile = cAccounts.has_photoprofile;

            return View(model);
        }

        [Authorize403()]
        public ActionResult PhotoCreateProfile()
        {
            return View(HttpContext.UserPrincipal());
        }

        [Authorize403()]
        public ActionResult PhotoProfile()
        {
            accounts cAccounts = HttpContext.UserPrincipal();

            if (!cAccounts.has_photoprofile)
                return RedirectToAction("PhotoCreateProfile");

            return View(cAccounts);
        }

        [Authorize403()]
        public ActionResult PhotoAlbum(long albumId, int page = 1)
        {
            if (!meridian.photobank_user_albumsStore.Exists(albumId))
                return new HttpNotFoundResult();

            var album = meridian.photobank_user_albumsStore.Get(albumId);

            if (album.account_id != HttpContext.UserPrincipal().id)
                return new HttpNotFoundResult();

            return View(album);
        }

        [Authorize403()]
        public ActionResult PhotoAlbumsList(int page = 1)
        {
            long authorId = HttpContext.UserPrincipal().id;

            UserPhotoAlbumList model = new UserPhotoAlbumList();
            var albums = meridian.photobank_user_albumsStore.LoadUserAlbums(authorId);
            model.TotalPages = MappingUtils.CalculatePagesCount(albums.Count(), Constants.PhotosPageSize);
            model.Albums = MappingUtils.TakePage(albums, page, Constants.PhotosPageSize);
            model.CurrentPage = page;

            return PartialView(model);
        }

        [Authorize403()]
        public ActionResult PhotoList(long albumId, int page = 1)
        {
            if (!meridian.photobank_user_albumsStore.Exists(albumId))
                return new HttpNotFoundResult();

            var album = meridian.photobank_user_albumsStore.Get(albumId);

            if (album.account_id != HttpContext.UserPrincipal().id)
                return new HttpNotFoundResult();

            PhotosList model = new PhotosList();
            var photos = meridian.photobank_photosStore.LoadAlbumPhotos(albumId);
            model.TotalPages = MappingUtils.CalculatePagesCount(photos.Count(), Constants.PhotosPageSize);
            model.Photos = MappingUtils.TakePage(photos, page, Constants.PhotosPageSize);
            model.CurrentPage = page;
            model.albumId = albumId;

            return PartialView(model);
        }

        [Authorize403()]
        public ActionResult Actions(int page = 1) 
        {
            long uId = HttpContext.UserPrincipal().id;
            var model = meridian.GetUserActions(uId, page);
            model.RouteName = "ProfileActions";
            return View(model);
        }

        [Authorize403()]
        public ActionResult Discounts(int page = 1)
        {
            long uId = HttpContext.UserPrincipal().id;
            var model = meridian.GetSalesList(null, null, null, uId, SortingType.Value, page, Constants.DefaultListPageSize);
            model.RouteName = "ProfileDiscounts";

            return View(model);
        }

        [Authorize403()]
        public ActionResult Companies(int page = 1)
        {
            long uId = HttpContext.UserPrincipal().id;
            var model = meridian.GetCompanies(null, page, Constants.DefaultListPageSize, SortingType.Alphabet, Constants.AnyLetter, null, null, uId);
            model.RouteName = "ProfileCompanies";

            return View(model);
        }

        [Authorize403()]
        public ActionResult Adverts(int page = 1, int pageSize = Constants.AdvertsPageSize)
        {
            accounts account = HttpContext.UserPrincipal();
            
            var adverts = meridian.ad_advertismentsStore.All().Where(item => item.account_id == account.id).ToList();
            var model = AdsMapper.ToAdsListViewModel(adverts, page, pageSize);
            model.RouteName = "ProfileAdverts";

            return View(model);
        }

        [Authorize403()]
        public ActionResult FavoriteAdverts(int page = 1, int pageSize = Constants.AdvertsPageSize)
        {
            accounts account = HttpContext.UserPrincipal();

            var adverts = meridian.ad_advertismentsStore.All().GetFavorites(account.id).ToList();
            var model = AdsMapper.ToAdsListViewModel(adverts, page, pageSize);
            model.IsFavorite = true;
            model.RouteName = "ProfileFavoriteAdverts";

            return View("Adverts", model);
        }

        #region CRUD adverts
        
        [Authorize403()]
        [HttpGet]
        public ActionResult CreateAdvert()
        {
            var model = new AdViewModel
                {
                    Categories = meridian.ad_categoriesStore.All().Where(item => item.parent_id == 0).ToList(),
                    Advertisment = new ad_advertisments { account_id = HttpContext.UserPrincipal().id },
                };

            var category = meridian.ad_categoriesStore.All().FirstOrDefault(item => item.parent_id == 0);
            if (category != null)
            {
                model.Advertisment.category_id = category.Subcategories.Any()
                    ? category.Subcategories.First().id
                    : category.id;
            }

            model.Properties = AdsMapper.GetProperties(model.Advertisment.category_id);

            return View(model);
        }

        [Authorize403()]
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult CreateAdvert(AdViewModel model)
        {
            if (model.Advertisment.description.CheckEmpty())
            {
                ModelState.AddModelError("Advertisment.description", "Описание не может быть пустым");
            }

            if (ModelState.IsValid)
            {
                model.Advertisment.created_date = DateTime.Now;
                var ad = meridian.ad_advertismentsStore.Insert(model.Advertisment);
                if (model.Properties != null)
                {
                    foreach (var prop in model.Properties)
                    {
                        var adField = meridian.ad_fieldsStore.All()
                            .FirstOrDefault(item => item.ad_id == ad.id && item.description_id == prop.DescriptionId) ??
                                      new ad_fields();
                        adField.ad_id = ad.id;
                        adField.description_id = prop.DescriptionId;
                        adField.value = prop.Value;
                        adField.value_id = prop.ValueId;

                        meridian.ad_fieldsStore.Persist(adField);
                    }
                }
                
                AddAdvertImages(ad.id, model.Files);
                return RedirectToAction("Adverts");
            }

            model.Categories = meridian.ad_categoriesStore.All()
                        .Where(item => item.parent_id == 0).ToList();
            model.Properties = AdsMapper.GetProperties(meridian.ad_categoriesStore.All().First().id);

            return View(model);
        }

        [Authorize403()]
        [HttpGet]
        public ActionResult EditAdvert(long id)
        {
            ad_advertisments ad = null;
            if (meridian.ad_advertismentsStore.Exists(id))
                ad = meridian.ad_advertismentsStore.Get(id);
            else
                throw new HttpException(404, "Not Found");
            if (ad.account_id != HttpContext.UserPrincipal().id)
                throw new HttpException(404, "Not Found");

            var model = new AdViewModel
                {
                    Advertisment = ad,
                    Categories = meridian.ad_categoriesStore.All().Where(item => item.parent_id == 0).ToList(),
                    IsEdit = true
                };

            model.Properties = AdsMapper.GetProperties(model.Advertisment.category_id, model.Advertisment.id);

            return View(model);
        }

        [Authorize403()]
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult EditAdvert(AdViewModel model)
        {
            var ad = meridian.ad_advertismentsStore.Get(model.Advertisment.id);

            if (ModelState.IsValid && TryUpdateModel(ad, "Advertisment"))
            {
                meridian.ad_advertismentsStore.Update(ad);
                if (model.Properties != null)
                {
                    foreach (var prop in model.Properties)
                    {
                        var adField = meridian.ad_fieldsStore.All()
                            .FirstOrDefault(item => item.ad_id == ad.id && item.description_id == prop.DescriptionId) ??
                                      new ad_fields();
                        adField.ad_id = ad.id;
                        adField.description_id = prop.DescriptionId;
                        adField.value = prop.Value;
                        adField.value_id = prop.ValueId;

                        meridian.ad_fieldsStore.Persist(adField);
                    }
                }

                AddAdvertImages(ad.id, model.Files);

                return RedirectToAction("Adverts");
            }

            model.Categories = meridian.ad_categoriesStore.All().Where(item => item.parent_id == 0).ToList();
            model.Properties = AdsMapper.GetProperties(model.Advertisment.category_id, model.Advertisment.id);

            return View(model);
        }

        private void AddAdvertImages(long id, List<HttpPostedFileBase> files)
        {
            if (files == null)
                return;

            var now = DateTime.Now;
            string[] formats = { ".jpg", ".png", ".gif", ".jpeg" };

            var filteredFiles = files
                .Where(f => f != null && f.ContentLength > 0)
                .Where(f => formats.Contains(Path.GetExtension(f.FileName.ToLower())));

            foreach (var file in filteredFiles)
            {
                var thumbGenerator = new ThumbnailGenerator();
                ImageNamingStrategy namingStrategy = new ImageNamingStrategy(Guid.NewGuid());
                thumbGenerator.CommandString = "width=330&height=220&format=png&mode=crop";
                string photo = thumbGenerator.GenerateThumbnail(file, 
                    Path.Combine(FileSystemFolders.AdvertPhotoFolder, namingStrategy.GetNormalThumbnailName()));

                thumbGenerator.CommandString = "width=99&height=66&format=png&mode=crop";
                string preview = thumbGenerator.GenerateThumbnail(file, 
                    Path.Combine(FileSystemFolders.AdvertPhotoFolder, namingStrategy.GetSmallThumbnailName()));
                string original = UploadFileWithExtension(file, FileSystemFolders.AdvertPhotoFolder, namingStrategy.GetOriginalImageName());

                var adPhoto = new ad_photos
                {
                    ad_id = id,
                    create_date = now,
                    photo = System.IO.Path.GetFileName(photo),
                    preview = System.IO.Path.GetFileName(preview),
                    original = original
                };

                meridian.ad_photosStore.Insert(adPhoto);
            }
        }

        [HttpPost]
        public void DeleteAdvert(long id)
        {
            var advert = meridian.ad_advertismentsStore.Get(id);
            advert.Delete();
        }

        [HttpPost]
        public void DeleteAdImage(long id)
        {
            if (meridian.ad_photosStore.Exists(id))
            {
                var adPhoto = meridian.ad_photosStore.Get(id);
                adPhoto.Delete();
            }
        }

        #endregion

        public ActionResult ProfileMenu(long? userId)
        {
            if (Request.IsAuthenticated && !userId.HasValue)
                return PartialView();

            return null;
        }

        #region Vacancy | Resume

        [Authorize403()]
        public ActionResult CreateResume()
        {
            var model = meridian.GetResumeForEdit(null);
            model.IsPublish = true;
            return View("CreateResume", model);
        }

        [Authorize403()]
        public ActionResult EditResume(long id)
        {
            var model = meridian.GetResumeForEdit(id);

            if (model.User.id != HttpContext.UserPrincipal().id)
            {
                throw new HttpException(403, "Forbidden");
            }

            return View("CreateResume", model);
        }

        [Authorize403()]
        public ActionResult DeleteResume(long id)
        {
            var user = HttpContext.UserPrincipal();
            
            if (!meridian.resumesStore.Exists(id))
                return new HttpNotFoundResult();

            var resume = meridian.resumesStore.Get(id);
            if (resume.account_id != user.id)
            {
                throw new HttpException(403, "Forbidden");
            }

            meridian.resumesStore.DeleteById(id);

            return RedirectToAction("ResumeList");
        }

        [Authorize403()]
        [HttpPost]
        public ActionResult SaveResume(ResumeViewModel model)
        {
            model.User = HttpContext.UserPrincipal();
            meridian.CreateOrUpdateResume(model);
            SiteMaps.ReleaseSiteMap();

            return RedirectToAction("ResumeList", "Profile");
        }

        [Authorize403()]
        public ActionResult ResumeList(bool onlyFavorites = false, int page = 1)
        {
            var user = HttpContext.UserPrincipal();
            
            var model = meridian.GetResumePageByUser(onlyFavorites, user.id, page);

            return View("ResumeList", model);
        }

        [Authorize403()]
        [HttpPost]
        public void TogglePublishResume(long id)
        {
            if (meridian.resumesStore.Exists(id))
            {
                resumes resume = meridian.resumesStore.Get(id);
                if (resume.account_id == HttpContext.UserPrincipal().id)
                {
                    resume.is_publish = !resume.is_publish;
                    meridian.resumesStore.Persist(resume);
                }
            }
        }

        /* - - - - - - - - - - - - - - -*/

        [Authorize403()]
        public ActionResult CreateVacancy()
        {
            var model = meridian.GetVacancyForEdit(null);

            return View("CreateVacancy", model);
        }

        [Authorize403()]
        public ActionResult EditVacancy(long id)
        {
            var model = meridian.GetVacancyForEdit(id);

            if (model.User.id != HttpContext.UserPrincipal().id)
            {
                throw new HttpException(403, "Forbidden");
            }

            return View("CreateVacancy", model);
        }

        [Authorize403()]
        public ActionResult DeleteVacancy(long id)
        {
            var user = HttpContext.UserPrincipal();

            if (!meridian.vacanciesStore.Exists(id))
                return new HttpNotFoundResult();

            var resume = meridian.vacanciesStore.Get(id);
            if (resume.account_id != user.id)
            {
                throw new HttpException(403, "Forbidden");
            }

            meridian.vacanciesStore.DeleteById(id);

            return RedirectToAction("ResumeList");
        }

        [Authorize403()]
        [HttpPost]
        public ActionResult CreateVacancy(VacancyViewModel model)
        {
            if(ModelState.IsValid)
            {
                model.User = HttpContext.UserPrincipal();
                meridian.CreateOrUpdateVacancy(model);
                SiteMaps.ReleaseSiteMap();
                return RedirectToAction("VacancyList", "Profile");
            }
            else
            {
                model = meridian.PrepareVacancyModel(model);
                return View("CreateVacancy", model);
            }
            
        }

        [Authorize403()]
        public ActionResult VacancyList(bool onlyFavorites = false, int page = 1)
        {
            accounts acc = HttpContext.UserPrincipal();
            VacancyListViewModel model = Meridian.Default.GetVacanciesPageByUser(onlyFavorites, acc.id, page);
            return View("VacancyList", model);
        }

        [Authorize403()]
        [HttpPost]
        public void TogglePublishVacancy(long id)
        {
            if (meridian.vacanciesStore.Exists(id))
            {
                vacancies vacancy = meridian.vacanciesStore.Get(id);
                if (vacancy.account_id == HttpContext.UserPrincipal().id)
                {
                    vacancy.is_publish = !vacancy.is_publish;
                    meridian.vacanciesStore.Persist(vacancy);
                }
            }
        }

        #endregion

        #region Edit Data With Avatars
        [Authorize403()]
        public ActionResult EditPersonalData(accounts newData)
        {
            accounts acc = meridian.accountsStore.Get(newData.id);
            //acc.description = newData.description;
            acc.firstname = newData.firstname;
            acc.lastname = newData.lastname;
            acc.secondname = newData.secondname;
            acc.career = newData.career;
            acc.is_male = newData.is_male;
            if (newData.birthdate != null && newData.birthdate.Year >= 1900)
                acc.birthdate = newData.birthdate;
            if (!string.IsNullOrEmpty(newData.avatar))
                acc.SetAvatar(newData.avatar);

            meridian.accountsStore.Update(acc);

            ViewBag.Main = true;

            return PartialView("ProfilePartial", acc);
        }

        [Authorize403()]
        public string SaveTempImgForCrop(HttpPostedFileBase avatara, string url)
        {
            int? x1, y1, width, height;
            x1 = Request["x1"].ParseIntNull();
            y1 = Request["y1"].ParseIntNull();
            width = Request["width"].ParseIntNull();
            height = Request["height"].ParseIntNull();
            
            
            string str = TempData["skip"] as string;
            if (!string.IsNullOrEmpty(str) && bool.Parse(str))
            {
                TempData["skip"] = true;
                return null;
            }

            TempData["skip"] = true;

            try
            {
                if (avatara != null)
                {
                    var extension = Path.GetExtension(avatara.FileName);
                    if (extension.ToLower() == ".jpg" || extension.ToLower() == ".gif" || extension.ToLower() == ".png" || extension.ToLower() == ".jpeg")
                    {
                        var res = Constants.TempFolder + AvatarCreator.SaveTemp(FileSystemFolders.TempFolder, avatara);
                        TempData["skip"] = false;
                        return res;
                    }
                    else
                    {
                        TempData["skip"] = false;
                        return "Error type file!";
                    }
                }
                else if (!string.IsNullOrEmpty(url) && x1.HasValue && y1.HasValue && width.HasValue && height.HasValue)
                {
                    var res = Constants.TempFolder +
                              AvatarCreator.CropAndSave(x1.Value, y1.Value, width.Value, height.Value, url,
                                                        FileSystemFolders.TempFolder);
                    TempData["skip"] = false;
                    return res;
                }
                else if(!string.IsNullOrEmpty(url))
                {
                    var res = Constants.TempFolder +
                              AvatarCreator.SaveDefault( url,
                                                        FileSystemFolders.TempFolder);
                    TempData["skip"] = false;
                    return res;                    
                }

                TempData["skip"] = false;
                //LogException("Failed to save image for crop", new Exception("Не передан файл или координаты"));
                return "Error upload file!";
            }
            catch (Exception ex)
            {
                LogException("Failed to save image for crop", ex);

                TempData["skip"] = false;
                return "Error upload file!";
            }
        }
        #endregion

        #region Create/Edit blog
        [Authorize403()]
        public ActionResult BlogEdit(long? id)
        {
            blogs model = null;

            ViewBag.Categories = meridian.blog_categoriesStore.GetAll().Where(c => !c.is_sub).ToList();

            if (id.HasValue)
            {
               //Редактирование
               SiteMaps.Current.CurrentNode.Title = "Редактирование записи";
               if( meridian.blogsStore.Exists(id.Value))
                   model = meridian.blogsStore.Get(id.Value);
               else
                   throw new HttpException(404, "Not Found");
               if(model.is_delete)
                   throw new HttpException(404, "Not Found");
               if(model.account_id != HttpContext.UserPrincipal().id)
                   throw new HttpException(404, "Not Found");
            }
            else
            {
                //Создание
                SiteMaps.Current.CurrentNode.Title = "Новая запись";
                model = new blogs();
                model.can_comment = true;
                model.is_publish = true;
            }

            return View(model);
        }

        [Authorize403()]
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult BlogEdit(blogs blog)
        {
            ViewBag.Categories = meridian.blog_categoriesStore.GetAll().Where(c => !c.is_sub).ToList();

            if (blog.title.CheckEmpty())
                ModelState.AddModelError("title","Тема обязательна для заполнения!");
            if (blog.text.CheckEmpty())
                ModelState.AddModelError("text", "Содержимое обязательно для заполнения!");
            if(blog.account_id <= 0)
                blog.account_id = HttpContext.UserPrincipal().id;
            if (blog.account_id != HttpContext.UserPrincipal().id)
                throw new HttpException(404, "Not Found");

            if (ModelState["title"].Errors.Any() || ModelState["text"].Errors.Any())
                return View(blog);

            if (blog.id > 0)
            {
                //Редактирование
                if (meridian.blogsStore.Exists(blog.id))
                {
                    blogs s_blog = meridian.blogsStore.Get(blog.id);
                    if(s_blog.is_delete)
                        throw new HttpException(404, "Not Found");

                    s_blog.text = blog.text;
                    s_blog.title = blog.title;
                    s_blog.announce = TextHelper.CreateAnnounce(blog.text);
                    s_blog.is_publish = blog.is_publish;
                    s_blog.can_comment = blog.can_comment;
                    s_blog.category_id = blog.category_id;

                    ProcessImagesAndUpdateBlog(s_blog);
                }
                else
                {
                    throw new HttpException(404, "Not Found");
                }
            }
            else
            {
                //Создание
                blog.create_date = DateTime.Now;
                blog.publish_date = DateTime.Now;
                blog.announce = TextHelper.CreateAnnounce(blog.text);

                meridian.blogsStore.Insert(blog);

                ProcessImagesAndUpdateBlog(blog);
            }

            return RedirectToAction("Blog");
        }

        [Authorize403()]
        [HttpPost]
        public void BlogDelete(long id)
        {
            if (meridian.blogsStore.Exists(id))
            {
                blogs s_blog = meridian.blogsStore.Get(id);
                s_blog.is_delete = true;
                meridian.blogsStore.Update(s_blog);
            }
        }

        #endregion

        #region PhotoBank Edit
        [Authorize403()]
        [HttpPost]
        public ActionResult PhotoCreateProfile(accounts newData)
        {
            accounts acc = meridian.accountsStore.Get(newData.id);
            acc.description = newData.description;
            acc.website = newData.website;
            acc.address = newData.address;
            acc.company = newData.company;

            acc.has_photoprofile = true;

            meridian.accountsStore.Update(acc);
            return RedirectToAction("PhotoProfile");
        }

        [Authorize403()]
        [HttpPost]
        public ActionResult PhotoProfile(photobank_user_albums album)
        {
            if(!string.IsNullOrEmpty(album.title))
            {
                album.account_id = HttpContext.UserPrincipal().id;

                meridian.photobank_user_albumsStore.Insert(album);
            }

            return RedirectToAction("PhotoProfile");
        }

        [Authorize403()]
        public ActionResult AddNewPhoto (long albumId)
        {
            if (!meridian.photobank_user_albumsStore.Exists(albumId))
                return new HttpNotFoundResult();

            var album = meridian.photobank_user_albumsStore.Get(albumId);

            if (album.account_id != HttpContext.UserPrincipal().id)
                return new HttpNotFoundResult();

            AddNewPhotoModel model = new AddNewPhotoModel();
            model.AlbumId = albumId;
            model.Licenseses = meridian.photobank_licensesStore.GetAll();
            model.Categories = meridian.photobank_categoriesStore.GetAll();

            return PartialView(model);
        }

        [Authorize403()]
        [HttpPost]
        public ActionResult AddNewPhoto(AddNewPhotoModel model)
        {
            model.Licenseses = meridian.photobank_licensesStore.GetAll();
            model.Categories = meridian.photobank_categoriesStore.GetAll();

            if (model.Title.CheckEmpty())
                ModelState.AddModelError("Title", "Название обязательно для заполнения!");
            if (model.FileImg == null)
                ModelState.AddModelError("FileImg", "Выберите фотографию");
            if (!ModelState.IsValid)
                return PartialView(model);

            photobank_photos newPhoto = new photobank_photos();
            newPhoto.account_id = HttpContext.UserPrincipal().id;
            newPhoto.title = model.Title;
            newPhoto.publish_date = DateTime.Now;
            newPhoto.album_id = model.AlbumId;
            newPhoto.category_id = model.CategoryId;

            photobank_related_photos newRelPhoto = new photobank_related_photos();
            newRelPhoto.filename = model.FileImg.FileName;
            int w;
            int h;
            newRelPhoto.photo = PhotoBankCreator.SaveOriginal(model.FileImg, out w, out h);
            newRelPhoto.width = w;
            newRelPhoto.height = h;
            newRelPhoto.original = true;

            newPhoto.preview = PhotoBankCreator.CreatePreview(newRelPhoto.photo);
            newPhoto.preview_square = PhotoBankCreator.CreateSquarePreview(newRelPhoto.photo);
            newPhoto.preview_main = PhotoBankCreator.CreateMainPreview(newRelPhoto.photo);

            meridian.photobank_photosStore.Insert(newPhoto);
            newRelPhoto.photo_id = newPhoto.id;

            meridian.photobank_related_photosStore.Insert(newRelPhoto);

            photobank_photo_prices pr = new photobank_photo_prices();
            pr.license_id = model.LicenseId;
            pr.price = model.Price;
            pr.rel_photo_id = newRelPhoto.id;

            meridian.photobank_photo_pricesStore.Insert(pr);

            SiteMaps.ReleaseSiteMap();

            return new AjaxAwareAuthRedirectResult(String.Format("/Profile/PhotoAlbum/{0}", model.AlbumId));
        }

        [Authorize403()]
        public ActionResult AddRelPhoto(long albumId, long parentId = 0)
        {
            if (!meridian.photobank_user_albumsStore.Exists(albumId))
                return new HttpNotFoundResult();

            var album = meridian.photobank_user_albumsStore.Get(albumId);

            if (album.account_id != HttpContext.UserPrincipal().id)
                return new HttpNotFoundResult();

            if (!meridian.photobank_photosStore.Exists(parentId))
                return new HttpNotFoundResult();

            AddNewPhotoModel model = new AddNewPhotoModel();
            var parent = meridian.photobank_photosStore.Get(parentId);
            model.AlbumId = albumId;
            model.ParentId = parentId;
            model.CategoryTitle = parent.Category.title;
            model.Title = parent.title;
            model.Licenseses = meridian.photobank_licensesStore.GetAll();

            return PartialView(model);
        }

        [Authorize403()]
        [HttpPost]
        public ActionResult AddRelPhoto(AddNewPhotoModel model)
        {
            model.Licenseses = meridian.photobank_licensesStore.GetAll();
            model.CategoryTitle = meridian.photobank_photosStore.Get(model.ParentId).Category.title;
            
            if (model.FileImg == null)
                ModelState.AddModelError("FileImg", "Выберите фотографию");
            if (!ModelState.IsValid)
                return PartialView(model);

            photobank_related_photos newRelPhoto = new photobank_related_photos();
            newRelPhoto.filename = model.FileImg.FileName;
            int w;
            int h;
            newRelPhoto.photo = PhotoBankCreator.SaveOriginal(model.FileImg, out w, out h);
            newRelPhoto.width = w;
            newRelPhoto.height = h;
            newRelPhoto.original = false;
            newRelPhoto.photo_id = model.ParentId;

            meridian.photobank_related_photosStore.Insert(newRelPhoto);

            photobank_photo_prices pr = new photobank_photo_prices();
            pr.license_id = model.LicenseId;
            pr.price = model.Price;
            pr.rel_photo_id = newRelPhoto.id;

            meridian.photobank_photo_pricesStore.Insert(pr);

            return new AjaxAwareAuthRedirectResult(String.Format("/Profile/PhotoAlbum/{0}", model.AlbumId));
        }

        #endregion

        [Authorize403()]
        public ActionResult AdvertFields(long categoryid, long adid)
        {
            var model = new AdViewModel
                {
                    Properties = AdsMapper.GetProperties(categoryid, adid)
                };

            return View(model);
        }

        private void ProcessImagesAndUpdateBlog(blogs blog)
        {
            // создаем и настраиваем обработчик картинок
            BlogsImageMarkupProcessorSettings imageProcessorSettings = ServiceLocator.Instance.Locate<BlogsImageMarkupProcessorSettings>();
            UrlBuilder urlBuilder = ServiceLocator.Instance.Locate<UrlBuilder>();
            BlogsImageHandler imageHandler = new BlogsImageHandler(Meridian.Default, urlBuilder, blog.id);
            BlogsImageMarkupProcessor imageMarkupProcessor = new BlogsImageMarkupProcessor(imageHandler);
            imageMarkupProcessor.ListThumbnailGenerator = imageProcessorSettings.ListThumbnailGenerator;
            imageMarkupProcessor.NormalThumbnailGenerator = imageProcessorSettings.NormalThumbnailGenerator;
            imageMarkupProcessor.ImagesPhysicalPath = ControllerContext.HttpContext.Server.MapPath(imageProcessorSettings.ImagesVirtualPath);

            // создаем преобразователь текста и передаем ему обработчик картинок
            HtmlDomTransformer transformer = new HtmlDomTransformer();
            transformer.MarkupProcessorChain = imageMarkupProcessor;
            blog.text = transformer.Transform(blog.text);

            meridian.blogsStore.Update(blog);
        }


    }
}
