using Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FonNature.Services.IClientServices
{
    public interface IBlogServices
    {
        List<Content> ListAll(string searchString);
        List<ContentCategory> ListContentCategory();
        List<Content> ListRecentBlog();
        Content GetDetail(long id);
        List<Content> ListAllByCategory(string searchString, int idCategory);
    }
}
