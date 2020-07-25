using Models.Entity;
using System.Collections.Generic;

namespace FonNature.Services.IClientServices
{
    public interface IBlogServices
    {
        List<Content> ListAll(string searchString);
        List<ContentCategory> ListContentCategory();
        List<Content> ListRecentBlog();
        Content GetDetail(long id);
        List<Content> ListAllByCategory(string searchString, int idCategory);
        SEO GetSeo();
        Banner GetBanner();
    }
}
