using Models.Entity;
using Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Repository
{
    public class MenuAdminRepository : IMenuAdminRepository
    {
        private FonNatureDbContext _db = null;

        public FonNatureDbContext Db { get => _db; set => _db = value; }

        public MenuAdminRepository()
        {
            _db = new FonNatureDbContext();
        }

        public Menu GetDetail(long id)
        {
            var menu = _db.Menus.Find(id);
            return menu;
        }

        public List<Menu> GetListMenu()
        {
            return _db.Menus.OrderBy(x=>x.displayOrder).ToList();
        }

        public List<Menu> GetMenusByText(string searchString)
        {
            return _db.Menus.Where(x => x.text == searchString).ToList();
        }

        public long AddMenu(Menu menu)
        {
            var addMenu = _db.Menus.Add(menu);
            _db.SaveChanges();
            return addMenu.id;
        }

        public bool EditMenu(Menu menu)
        {
            var menuEdit = _db.Menus.Where(x => x.id == menu.id).SingleOrDefault();
            menuEdit.text = menu.text;
            menuEdit.link = menu.link;
            menuEdit.displayOrder = menu.displayOrder;
            menuEdit.typeId = menu.typeId;
            menuEdit.status = menu.status;
            _db.SaveChanges();
            return true;
        }

        public bool Delete(long id)
        {
            var menu = _db.Menus.Find(id);
            if (menu != null)
            {
                _db.Menus.Remove(menu);
                _db.SaveChanges();
            }
            return true;
        }

        public bool? ChangeStatus(long id)
        {
            if (id == 0) return false;
            var accountNeedChange = _db.Menus.Find(id);
            accountNeedChange.status = !accountNeedChange.status;
            _db.SaveChanges();
            return accountNeedChange.status;
        }



        public List<MenuType> GetMenuType()
        {
            return _db.MenuTypes.ToList();
        }
    }
}
