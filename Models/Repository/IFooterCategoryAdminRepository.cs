﻿using Models.Entity;
using System.Collections.Generic;

namespace Models.Repository
{
    public interface IFooterCategoryAdminRepository
    {
        FooterCategory GetDetail(long id);
        List<FooterCategory> GetListFooterCategory();
        long AddFooterCategory(FooterCategory footercategory);
        bool EditFooterCategory(FooterCategory footercategory);
        bool Delete(long id);
        List<FooterCategory> ListSearchFooterCategory(string searchString);
        bool CheckExits(string name);
    }
}
