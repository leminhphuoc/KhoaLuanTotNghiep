using log4net;
using Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Models.Repository
{
    public class PageRepository : IPageRepository
    {
        private FonNatureDbContext _db = null;

        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public FonNatureDbContext Db { get => _db; set => _db = value; }

        public PageRepository()
        {
            _db = new FonNatureDbContext();
        }

        public Page AddPage(Page pageModel)
        {
            try
            {
                var addedPage = _db.Pages.Add(pageModel);
                _db.SaveChanges();

                if (addedPage == null)
                {
                    log.Error($"{nameof(AddPage)} return null");
                    return null;
                }

                log.Info($"{nameof(AddPage)} result is {addedPage}");

                return addedPage;
            }
            catch (Exception ex)
            {
                log.Error($"Error at {nameof(AddPage)}: {ex.Message}");
                return null;
            }
        }

        public long EditPage(Page pageModel)
        {
            try
            {
                var updatePage = _db.Pages.Find(pageModel.Id);
                if (updatePage == null)
                {
                    log.Error($"{nameof(EditPage)} cannot find Page with id {updatePage.Id}");
                    return 0;
                }

                updatePage.Url = pageModel.Url;
                updatePage.Name = pageModel.Name;
                updatePage.Body = pageModel.Body;
                updatePage.MetaTitle = pageModel.MetaTitle;
                updatePage.MetaKeywords = pageModel.MetaKeywords;
                updatePage.MetaDescription = pageModel.MetaDescription;
                _db.SaveChanges();

                log.Info($"{nameof(EditPage)} success with Url : {updatePage.Url}, Name: {updatePage.Name}");

                return updatePage.Id;
            }
            catch (Exception ex)
            {
                log.Error($"Error at {nameof(EditPage)}: {ex.Message}");
                return 0;
            }
        }

        public Page GetPage(long id)
        {
            try
            {
                var page = _db.Pages.Find(id);
                if (page == null)
                {
                    log.Error($"{nameof(GetPage)} result is null or don't have item");
                    return null;
                }

                log.Info($"{nameof(GetPage)} result is {page}");

                return page;
            }
            catch (Exception ex)
            {
                log.Error($"Error at {nameof(GetPage)}: {ex.Message}");
                return null;
            }
        }

        public List<Page> GetPages()
        {
            try
            {
                var pages = _db.Pages;
                if (pages == null)
                {
                    log.Error($"{nameof(GetPages)} result is null");
                    return new List<Page>();
                }

                log.Info($"{nameof(GetPages)} result is {pages}");

                return pages.ToList();
            }
            catch (Exception ex)
            {
                log.Error($"Error at {nameof(GetPages)}: {ex.Message}");
                return new List<Page>();
            }
        }

        public bool RemovePage(long id)
        {
            try
            {
                var removePage = _db.Pages.Find(id);
                if (removePage == null)
                {
                    log.Error($"{nameof(RemovePage)} cannot find page with id {id}");
                    return false;
                }

                _db.Pages.Remove(removePage);
                _db.SaveChanges();

                log.Info($"{nameof(RemovePage)} success with id : {removePage.Id}");

                return true;
            }
            catch (Exception ex)
            {
                log.Error($"Error at {nameof(RemovePage)}: {ex.Message}");
                return false;
            }
        }

        public List<Page> SearchPage(string searchString)
        {
            try
            {
                var pages = _db.Pages.Where(x => x.Url.ToLower().Contains(searchString.ToLower()) || x.Name.ToLower().Contains(searchString.ToLower()));
                if (pages == null)
                {
                    log.Error($"{nameof(SearchPage)} result is null");
                    return new List<Page>();
                }

                log.Info($"{nameof(SearchPage)} result is {pages}");

                return pages.ToList();
            }
            catch (Exception ex)
            {
                log.Error($"Error at {nameof(SearchPage)}: {ex.Message}");
                return new List<Page>();
            }
        }

        public Page GetPageByUrl(string url)
        {
            try
            {
                var page = _db.Pages.SingleOrDefault(x => x.Url.Equals(url, StringComparison.OrdinalIgnoreCase));
                if (page == null)
                {
                    log.Error($"{nameof(GetPageByUrl)} result is null or don't have item");
                    return null;
                }

                log.Info($"{nameof(GetPageByUrl)} result is {page}");

                return page;
            }
            catch (Exception ex)
            {
                log.Error($"Error at {nameof(GetPageByUrl)}: {ex.Message}");
                return null;
            }
        }
    }
}
