using Models.Entity;
using Models.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Repository
{
    public class AboutAdminRepository : IAboutAdminRepository
    {
        private FonNatureDbContext _db = null;

        public FonNatureDbContext Db { get => _db; set => _db = value; }

        public AboutAdminRepository()
        {
            _db = new FonNatureDbContext();
        }

        public About GetDetail(long id)
        {
            var about = _db.Abouts.Find(id);
            return about;
        }

        public List<About> GetListAbout()
        {
            return _db.Abouts.ToList();
        }

        public long AddAbout(About about)
        {
            about.createdDate = DateTime.Now;
            var addAbout = _db.Abouts.Add(about);
            _db.SaveChanges();
            return addAbout.id;
        }

        public bool EditAbout(About about)
        {
            var aboutEdit = _db.Abouts.Where(x => x.id == about.id).SingleOrDefault();
            aboutEdit.name = about.name;
            aboutEdit.Title = about.Title;
            aboutEdit.description = about.description;
            aboutEdit.detail = about.detail;
            aboutEdit.image = about.image;
            aboutEdit.modifiedDate = DateTime.Now;
            aboutEdit.status = about.status;
            _db.SaveChanges();
            return true;
        }

        public bool Delete(long id)
        {
            var about = _db.Abouts.Find(id);
            if (about != null)
            {
                _db.Abouts.Remove(about);
                _db.SaveChanges();
            }
            return true;
        }

        public bool? ChangeStatus(long id)
        {
            if (id == 0) return false;
            var accountNeedChange = _db.Abouts.Find(id);
            accountNeedChange.status = !accountNeedChange.status;
            _db.SaveChanges();
            return accountNeedChange.status;
        }

        public List<About> ListSearchAbout(string searchString)
        {
            if (searchString == null) return null;

            var listAbout = _db.Abouts.Where(x => x.name.ToUpper() == searchString.ToUpper());
            return listAbout.ToList();
        }

        public bool CheckExits(string name)
        {
            var about = _db.Abouts.Where(x => x.name == name).SingleOrDefault();
            if (about != null) return true;
            return false;
        }
    }
}
