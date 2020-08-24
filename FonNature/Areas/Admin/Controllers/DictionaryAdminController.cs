using FonNature.Filter;
using Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models.Entity;
using PagedList;

namespace FonNature.Areas.Admin.Controllers
{
    [AuthData]
    public class DictionaryAdminController : Controller
    {
        private readonly IDictionaryRepository _repository;
        public DictionaryAdminController(IDictionaryRepository repository)
        {
            _repository = repository;
        }
        // GET: Admin/DictionaryAdmin
        public ActionResult Dictionaries(int? page, string searchString = null)
        {
            var dictionaries = _repository.GetDictionaries();

            if (!string.IsNullOrEmpty(searchString))
            {
                dictionaries = _repository.SearchDictionary(searchString);
            }

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            var pagedDictionaries = dictionaries.ToPagedList(pageNumber, pageSize);
            ViewBag.SearchString = searchString ?? string.Empty;
            return View(pagedDictionaries);
        }
    }
}