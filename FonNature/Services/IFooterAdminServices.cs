using Models.Entity;
using System.Collections.Generic;

namespace FonNature.Services
{
    public interface IFooterAdminServices
    {
        List<FooterCategory> GetFooterCategory();
        long AddFooter(Footer footer);
        bool Delete(int id);
        Footer GetDetail(int id);
        bool Edit(Footer footer);
        bool? ChangeStatus(int id);
        List<Footer> GetListFooter();
    }
}