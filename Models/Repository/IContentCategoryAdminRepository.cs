﻿using Models.Entity;
using System.Collections.Generic;

namespace Models.Repository
{
    public interface IContentCategoryAdminRepository
    {
        ContentCategory GetDetail(long id);
        List<ContentCategory> GetListContentCategory();
        bool? ChangeStatus(long id);
        long AddContentCategory(ContentCategory contentcategory);
        bool EditContentCategory(ContentCategory contentcategory);
        bool Delete(long id);
        List<ContentCategory> ListSearchContentCategory(string searchString);
        bool CheckExits(string name);
    }
}
