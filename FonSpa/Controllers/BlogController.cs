using FonNature.Services.IClientServices;
using PagedList;
using System.Collections.Generic;
using System.Web.Mvc;

namespace FonNature.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogServices _blogServices;
        public BlogController(IBlogServices blogServices)
        {
            _blogServices = blogServices;
        }
        // GET: Blog
        public ActionResult Index(int? page, string searchString = null)
        {
            ViewBag.Tittle = "Blog";
            ViewBag.ListContentCategory = _blogServices.ListContentCategory();
            ViewBag.RecentBlog = _blogServices.ListRecentBlog();
            ViewBag.BlogList = _blogServices.ListAll(null);
            var blogList = _blogServices.ListAll(searchString);
            int pageSize = 4;
            int pageNumber = (page ?? 1);
            var blogListPaged = blogList.ToPagedList(pageNumber, pageSize);
            var seo = _blogServices.GetSeo();
            ViewBag.MetaTitle = seo.MetaTitle ?? string.Empty;
            ViewBag.MetaDescription = seo.SeoDescription ?? string.Empty;
            ViewBag.MetaKeyword = seo.SeoKeyWord ?? string.Empty;
            return View(blogListPaged);
        }


        public ActionResult ListByCategory(int? page, string searchString = null, int idCategory = 0)
        {
            ViewBag.Tittle = "Blog";
            ViewBag.ListContentCategory = _blogServices.ListContentCategory();
            ViewBag.RecentBlog = _blogServices.ListRecentBlog();
            ViewBag.BlogList = _blogServices.ListAll(null);
            var blogList = _blogServices.ListAllByCategory(searchString,idCategory);
            int pageSize = 4;
            int pageNumber = (page ?? 1);
            var blogListPaged = blogList.ToPagedList(pageNumber, pageSize);
            return View(blogListPaged);
        }

        public ActionResult Detail(long id)
        {
            ViewBag.Tittle = "Blog Detail";
            ViewBag.ListContentCategory = _blogServices.ListContentCategory();
            ViewBag.RecentBlog = _blogServices.ListRecentBlog();
            ViewBag.BlogsList = _blogServices.ListAll(null);
            var blog = _blogServices.GetDetail(id);
            return View(blog);
        }

    }
}