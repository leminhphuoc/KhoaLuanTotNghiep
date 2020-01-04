using Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.IRepository
{
    public interface IMenuAdminRepository
    {
        Menu GetDetail(long id);
        List<Menu> GetListMenu();
        bool? ChangeStatus(long id);
        long AddMenu(Menu menu);
        bool EditMenu(Menu menu);
        bool Delete(long id);
        List<MenuType> GetMenuType();
        List<Menu> GetMenusByText(string searchString);
    }
}

