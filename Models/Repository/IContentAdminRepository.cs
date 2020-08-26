using Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Repository
{
    public interface IContentAdminRepository
    {
        Content GetDetail(long id);
        List<Content> GetListContent();
        bool? ChangeStatus(long id);
        long AddContent(Content content);
        bool EditContent(Content content);
        bool Delete(long id);
        List<ContentCategory> GetContentCategories();
        List<Content> ListSearchContent(string searchString);
    }
}
