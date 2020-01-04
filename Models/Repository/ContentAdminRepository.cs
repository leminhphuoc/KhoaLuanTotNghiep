using Models.Entity;
using Models.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Repository
{
    public class ContentAdminRepository : IContentAdminRepository
    {
        private FonNatureDbContext _db = null;

        public FonNatureDbContext Db { get => _db; set => _db = value; }

        public ContentAdminRepository()
        {
            _db = new FonNatureDbContext();
        }

        public Content GetDetail(long id)
        {
            var content = _db.Contents.Find(id);
            return content;
        }

        public List<Content> GetListContent()
        {
            return _db.Contents.ToList();
        }

        public long AddContent(Content content)
        {
            
            content.createdDate = DateTime.Now;
            var addContent = _db.Contents.Add(content);
            _db.SaveChanges();
            return addContent.id;
        }

        public bool EditContent(Content content)
        {
            var contentEdit = _db.Contents.Where(x => x.id == content.id).SingleOrDefault();
            contentEdit.name = content.name;
            contentEdit.metatitle = content.metatitle;
            contentEdit.description = content.description;
            contentEdit.image = content.image;
            contentEdit.categoryID = content.categoryID;
            contentEdit.detail = content.detail;
            contentEdit.modifiedDate = DateTime.Now;
            contentEdit.topHot = content.topHot;
            contentEdit.status = content.status;
            _db.SaveChanges();
            return true;
        }

        public bool Delete(long id)
        {
            var content = _db.Contents.Find(id);
            if (content != null)
            {
                _db.Contents.Remove(content);
                _db.SaveChanges();
            }
            return true;
        }

        public bool? ChangeStatus(long id)
        {
            if (id == 0) return false;
            var accountNeedChange = _db.Contents.Find(id);
            accountNeedChange.status = !accountNeedChange.status;
            _db.SaveChanges();
            return accountNeedChange.status;
        }

        public List<ContentCategory> GetContentCategories()
        {
            return _db.ContentCategories.ToList();
        }

        public List<Content> ListSearchContent(string searchString)
        {
            return _db.Contents.Where(x => x.name.ToUpper() == searchString.ToUpper()).ToList();
        }

    }
}
