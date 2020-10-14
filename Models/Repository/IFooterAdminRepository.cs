using Models.Entity;
using System.Collections.Generic;

namespace Models.Repository
{
    public interface IFooterAdminRepository
    {
        Footer GetDetail(long id);
        List<Footer> GetListFooter();
        bool? ChangeStatus(long id);
        long AddFooter(Footer footer);
        bool EditFooter(Footer footer);
        bool Delete(long id);
        List<FooterCategory> GetFooterCategories();
    }
}
