using Models.Entity;
using System.Collections.Generic;

namespace FonNature.Services
{
    public interface IMenuTypeSerivces
    {
        List<MenuType> ListAllByName(string searchString);
        List<MenuType> GetMenuType();
        long AddMenuType(MenuType menutype);
        MenuType GetDetail(int id);
        bool Edit(MenuType menutype);
        bool Delete(int id);
        List<Menu> ListMenu();
    }
}
