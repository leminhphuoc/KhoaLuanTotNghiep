using Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
