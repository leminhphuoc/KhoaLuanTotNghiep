using Models.Entity;
using System.Collections.Generic;

namespace FonNature.Services
{
    public interface IContentCategoryAdminServices
    {
        List<ContentCategory> ListAllByName(string searchString);
        List<ContentCategory> GetContentCategory();
        long AddContentCategory(ContentCategory contentCategory);
        bool Delete(int id);
        ContentCategory GetDetail(int id);
        bool Edit(ContentCategory contentCategory);
        bool? ChangeStatus(int id);
    }
}