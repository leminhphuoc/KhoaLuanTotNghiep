using Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FonNature.Services.IServices
{
    public interface IContentCategoryAdminServices
    {
        List<ContentCategory> ListAllByName(string searchString);
        List<ContentCategory> GetContentCategory();
        long AddContentCategory(ContentCategory contentcategory);
        bool Delete(int id);
        ContentCategory GetDetail(int id);
        bool Edit(ContentCategory contentcategory);
        bool? ChangeStatus(int id);
    }
}