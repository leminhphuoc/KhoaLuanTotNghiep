using Models.Entity;
using Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Repository
{
    public class FooterCategoryAdminRepository : IFooterCategoryAdminRepository
    {
        private FonNatureDbContext _db = null;

        public FonNatureDbContext Db { get => _db; set => _db = value; }

        public FooterCategoryAdminRepository()
        {
            _db = new FonNatureDbContext();
        }

        public FooterCategory GetDetail(long id)
        {
            var footercategory = _db.FooterCategories.Find(id);
            return footercategory;
        }

        public List<FooterCategory> GetListFooterCategory()
        {
            return _db.FooterCategories.ToList();
        }

        public long AddFooterCategory(FooterCategory footercategory)
        {
            var AddFooterCategory = _db.FooterCategories.Add(footercategory);
            _db.SaveChanges();
            return AddFooterCategory.id;
        }

        public bool EditFooterCategory(FooterCategory footercategory)
        {
            var FooterCategoryEdit = _db.FooterCategories.Where(x => x.id == footercategory.id).SingleOrDefault();
            FooterCategoryEdit.name = footercategory.name;
            _db.SaveChanges();
            return true;
        }

        public bool Delete(long id)
        {
            var footercategory = _db.FooterCategories.Find(id);
            if (footercategory != null)
            {
                _db.FooterCategories.Remove(footercategory);
                _db.SaveChanges();
            }
            return true;
        }

        public List<FooterCategory> ListSearchFooterCategory(string searchString)
        {
            if (searchString == null) return null;

            var listFooterCategory = _db.FooterCategories.Where(x => x.name.ToUpper() == searchString.ToUpper());
            return listFooterCategory.ToList();
        }

        public bool CheckExits(string name)
        {
            var footercategory = _db.FooterCategories.Where(x => x.name == name).SingleOrDefault();
            if (footercategory != null) return true;
            return false;
        }
    }
}
