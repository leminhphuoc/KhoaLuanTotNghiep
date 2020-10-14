using Models.Entity;
using System.Collections.Generic;

namespace Models.Repository
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

