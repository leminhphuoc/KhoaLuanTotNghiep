using Models.Entity;
using System.Collections.Generic;

namespace Models.Repository
{
    public interface IPageRepository
    {
        List<Page> GetPages();
        Page GetPage(long id);
        Page AddPage(Page pageModel);
        long EditPage(Page pageModel);
        bool RemovePage(long id);
        List<Page> SearchPage(string searchString);
        Page GetPageByUrl(string url);
    }
}
