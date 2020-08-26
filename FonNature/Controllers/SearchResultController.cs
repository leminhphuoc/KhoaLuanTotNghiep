using FonNature.Services;
using PagedList;
using System.Web.Mvc;

namespace FonNature.Controllers
{
    [RoutePrefix("search")]
    [Route("{action=SearchResults}")]
    public class SearchResultController : Controller
    {
        private readonly ISearchService _searchService;
        public SearchResultController(ISearchService searchService)
        {
            _searchService = searchService;
        }
        // GET: SearchResult
        public ActionResult SearchResults(int? page, string searchString = null)
        {
            var searchResults = _searchService.GetResults(searchString);
            ViewBag.Tittle = "Trang tìm kiếm";
            int pageSize = 9;
            int pageNumber = (page ?? 1);
            var searchResultPaged = searchResults.ToPagedList(pageNumber, pageSize);
            return View(searchResultPaged);
        }
    }
}