using Models.Entity;
using System.Collections.Generic;

namespace Models.Repository
{
    public interface IMenuTypeAdminRepository
    {
        MenuType GetDetail(long id);
        List<MenuType> GetListMenuType();
        long AddMenuType(MenuType menutype);
        bool EditMenuType(MenuType menutype);
        bool Delete(long id);
        List<MenuType> ListSearchMenuType(string searchString);
        bool CheckExits(string name);
        List<Menu> ListMenu();
    }
}
