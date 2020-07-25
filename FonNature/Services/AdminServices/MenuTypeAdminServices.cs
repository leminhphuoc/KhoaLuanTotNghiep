using FonNature.Services.IServices;
using HelperLibrary;
using Models.Entity;
using Models.IRepository;
using System;
using System.Collections.Generic;


namespace FonNature.Services.Services
{
    public class MenuTypeAdminServices : IMenuTypeSerivces
    {
        private readonly IMenuTypeAdminRepository _menuTypeAdminRepository;
        public MenuTypeAdminServices(IMenuTypeAdminRepository menuTypeAdminRepository)
        {
            _menuTypeAdminRepository = menuTypeAdminRepository;
        }

        public List<MenuType> ListAllByName(string searchString)
        {
            if (searchString == null || searchString == "")
            {
                return _menuTypeAdminRepository.GetListMenuType();
            }
            else
            {
                searchString = Helper.RemoveSign4VietnameseString(searchString);
                var ListMenuType = _menuTypeAdminRepository.ListSearchMenuType(searchString);
                return ListMenuType;
            }
        }

        public List<MenuType> GetMenuType()
        {
            return _menuTypeAdminRepository.GetListMenuType();
        }

        public long AddMenuType(MenuType menutype)
        {
            if (menutype == null) return 0;
            var addMenuType = _menuTypeAdminRepository.AddMenuType(menutype);
            var idMenuType = addMenuType;
            return idMenuType;
        }

        public MenuType GetDetail(int id)
        {
            if (id == 0) return null;
            var menutype = _menuTypeAdminRepository.GetDetail(id);
            return menutype;
        }

        public bool Edit(MenuType menutype)
        {
            if (menutype == null) return false;
            var editmenuType = _menuTypeAdminRepository.EditMenuType(menutype);
            return editmenuType;
        }

        public bool Delete(int id)
        {
            if (id == 0) return false;
            var deleteSuccess = _menuTypeAdminRepository.Delete(id);
            return deleteSuccess;
        }

        public List<Menu> ListMenu()
        {
            return _menuTypeAdminRepository.ListMenu();
        }
    }
}