using Models.Entity;
using Models.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Repository
{
    public class FooterAdminRepository : IFooterAdminRepository
    {
        private FonNatureDbContext _db = null;

        public FonNatureDbContext Db { get => _db; set => _db = value; }

        public FooterAdminRepository()
        {
            _db = new FonNatureDbContext();
        }

        public Footer GetDetail(long id)
        {
            var footer = _db.Footers.Find(id);
            return footer;
        }

        public List<Footer> GetListFooter()
        {
            return _db.Footers.ToList();
        }

        public long AddFooter(Footer footer)
        {
            
            var addFooter = _db.Footers.Add(footer);
            _db.SaveChanges();
            return addFooter.id;
        }

        public bool EditFooter(Footer footer)
        {
            var footerEdit = _db.Footers.Where(x => x.id == footer.id).SingleOrDefault();
            footerEdit.text = footer.text;
            footerEdit.link = footer.link;
            footerEdit.displayOrder = footer.displayOrder;
            footerEdit.typeId = footer.typeId;
            footerEdit.Icon = footer.Icon;
            footerEdit.status = footer.status;
            _db.SaveChanges();
            return true;
        }

        public bool Delete(long id)
        {
            var footer = _db.Footers.Find(id);
            if (footer != null)
            {
                _db.Footers.Remove(footer);
                _db.SaveChanges();
            }
            return true;
        }

        public bool? ChangeStatus(long id)
        {
            if (id == 0) return false;
            var accountNeedChange = _db.Footers.Find(id);
            accountNeedChange.status = !accountNeedChange.status;
            _db.SaveChanges();
            return accountNeedChange.status;
        }

        public List<FooterCategory> GetFooterCategories()
        {
            return _db.FooterCategories.ToList();
        }
    }
}
