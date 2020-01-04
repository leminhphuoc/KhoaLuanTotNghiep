using Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.IRepository
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
