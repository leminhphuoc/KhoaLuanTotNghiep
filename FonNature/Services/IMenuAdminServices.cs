using Models.Entity;
using System.Collections.Generic;

namespace FonNature.Services
{
    public interface IMenuAdminServices
    {
        List<MenuType> GetMenuTypes();
        long AddMenu(Menu menu);
        bool Delete(int id);
        Menu GetDetail(int id);
        bool Edit(Menu menu);
        bool? ChangeStatus(int id);
        List<Menu> ListMenuByText(string searchString);
    }
}