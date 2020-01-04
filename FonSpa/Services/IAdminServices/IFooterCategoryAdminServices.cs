using Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace FonNature.Services.IServices
{
    public interface IFooterCategoryAdminServices
    {
        List<FooterCategory> ListAllByName(string searchString);
        List<FooterCategory> GetFooterCategory();
        long AddFooterCategory(FooterCategory footercategory);
        bool Delete(int id);
        FooterCategory GetDetail(int id);
        bool Edit(FooterCategory footercategory);
    }
}