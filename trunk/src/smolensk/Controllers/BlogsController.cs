using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using meridian.smolensk.proto;
using smolensk.Models.ModelValidators.Attributes;
using smolensk.Services;
using smolensk.common;
using smolensk.Models.ViewModels.Blogs;
using smolensk.Mappers;

namespace smolensk.Controllers
{
    public class BlogsController : BaseController
    {
        public ActionResult Index()
        {
            return View("Main");
        }

        public ActionResult List()
        {
            return View();
        }

        public ActionResult Author(long authorId)
        {
            if (!meridian.accountsStore.Exists(authorId))
                return new HttpNotFoundResult();

            return View(meridian.accountsStore.Get(authorId));
        }

        public ActionResult One(long id)
        {
            if (!meridian.blogsStore.Exists(id))
                return new HttpNotFoundResult();

            blogs blog = meridian.blogsStore.Get(id);
            if (blog.is_delete)
                return new HttpNotFoundResult();

            blog.UpdateViews(Request.IsAuthenticated ? HttpContext.UserPrincipal().id : (long?)null);

            return View(blog);
        }

        public ActionResult CategoryMenu(long? categoryId)
        {
            var list = meridian.blog_categoriesStore.All();
            foreach (var blogCategoriese in list)
            {
                blogCategoriese.IsCur = false;
            }

            var cur = list.SingleOrDefault(c => c.id == categoryId);
            if (cur != null)
                cur.IsCur = true;
            return View(list);
        }

        public ActionResult BestList()
        {
            return PartialView(meridian.blogsStore.LoadBest());
        }
        
        public ActionResult LastViewsList()
        { 
            return Request.IsAuthenticated ? PartialView(meridian.blogsStore.LoadLastViews(HttpContext.UserPrincipal().id)) : null;
        }

        public ActionResult InterestingList(DateFilterTypes dateFilter = DateFilterTypes.ToDay)
        {
            BlogsListViewModel model = new BlogsListViewModel();
            model.Blogs = meridian.blogsStore.LoadInteresting(dateFilter.ToDateRange());
            model.dateFilter = dateFilter;
            return PartialView("BaseList", model);
        }

        public ActionResult CategoryList(SortingType sortingType = SortingType.Rating, int page = 1, long? categoryId = null)
        {
            BlogsListViewModel model = new BlogsListViewModel();
            var blogs = meridian.blogsStore.LoadList(sortingType, categoryId);
            model.TotalPages = MappingUtils.CalculatePagesCount(blogs.Count(), Constants.BlogsPageSize);
            model.Blogs = MappingUtils.TakePage(blogs, page, Constants.BlogsPageSize);
            model.CurrentPage = page;
            model.sortingType = sortingType;
            model.ListType = BlogListType.Category;
            if (categoryId.HasValue && meridian.blog_categoriesStore.Exists(categoryId.Value))
                model.Category = meridian.blog_categoriesStore.Get(categoryId.Value);

            return PartialView("BaseList", model);
        }

        public ActionResult AuthorList(long authorId = 0, SortingType sortingType = SortingType.Rating, int page = 1 )
        {
            if(!meridian.accountsStore.Exists(authorId))
                return new HttpNotFoundResult();

            BlogsListViewModel model = new BlogsListViewModel();
            var blogs = meridian.blogsStore.LoadList(sortingType, (long?)null, authorId);
            model.TotalPages = MappingUtils.CalculatePagesCount(blogs.Count(), Constants.BlogsPageSize);
            model.Blogs = MappingUtils.TakePage(blogs, page, Constants.BlogsPageSize);
            model.CurrentPage = page;
            model.sortingType = sortingType;
            model.ListType = BlogListType.Author;
            model.authorId = authorId;

            return PartialView("BaseList", model);
        }
    }
}
