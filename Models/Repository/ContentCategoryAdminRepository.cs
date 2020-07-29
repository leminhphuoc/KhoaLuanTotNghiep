using Models.Entity;
using Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Repository
{
    public class ContentCategoryAdminRepository : IContentCategoryAdminRepository
    {
        private FonNatureDbContext _db = null;

        public FonNatureDbContext Db { get => _db; set => _db = value; }

        public ContentCategoryAdminRepository()
        {
            _db = new FonNatureDbContext();
        }

        public ContentCategory GetDetail(long id)
        {
            var contentcategogry = _db.ContentCategories.Find(id);
            return contentcategogry;
        }

        public List<ContentCategory> GetListContentCategory()
        {
            return _db.ContentCategories.ToList();
        }

        public long AddContentCategory(ContentCategory contentcategory)
        {
            contentcategory.createdDate = DateTime.Now;
            var AddContentCategory = _db.ContentCategories.Add(contentcategory);
            _db.SaveChanges();
            return AddContentCategory.id;
        }

        public bool EditContentCategory(ContentCategory contentcategory)
        {
            var ContentCategoryEdit = _db.ContentCategories.Where(x => x.id == contentcategory.id).SingleOrDefault();
            ContentCategoryEdit.name = contentcategory.name;
            ContentCategoryEdit.metatitle = contentcategory.metatitle;
            ContentCategoryEdit.parentID = contentcategory.parentID;
            ContentCategoryEdit.displayOrder = contentcategory.displayOrder;
            ContentCategoryEdit.modifiedDate = DateTime.Now;
            ContentCategoryEdit.status = contentcategory.status;
            ContentCategoryEdit.showOnHome = contentcategory.showOnHome;
            _db.SaveChanges();
            return true;
        }

        public bool Delete(long id)
        {
            var contentcategory = _db.ContentCategories.Find(id);
            if (contentcategory != null)
            {
                _db.ContentCategories.Remove(contentcategory);
                _db.SaveChanges();
            }
            return true;
        }

        public bool? ChangeStatus(long id)
        {
            if (id == 0) return false;
            var accountNeedChange = _db.ContentCategories.Find(id);
            accountNeedChange.status = !accountNeedChange.status;
            _db.SaveChanges();
            return accountNeedChange.status;
        }

        public List<ContentCategory> ListSearchContentCategory(string searchString)
        {
            if (searchString == null) return null;

            var listContentCategory = _db.ContentCategories.Where(x => x.name.ToUpper() == searchString.ToUpper());
            return listContentCategory.ToList();
        }

        public bool CheckExits(string name)
        {
            var contentcategory = _db.ContentCategories.Where(x => x.name == name).SingleOrDefault();
            if (contentcategory != null) return true;
            return false;
        }
    }
}
