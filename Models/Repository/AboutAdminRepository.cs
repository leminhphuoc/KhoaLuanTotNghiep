using Models.Entity;
using Models.Repository;
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
            about.Category = 2;
            var addAbout = _db.Abouts.Add(about);
            _db.SaveChanges();
            return addAbout.Id;
        }

        public bool EditAbout(About about)
        {
            var aboutEdit = _db.Abouts.Where(x => x.Id == about.Id).SingleOrDefault();
            aboutEdit.Name = about.Name;
            aboutEdit.Description = about.Description;
            aboutEdit.Image = about.Image;
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
            return true;
        }

        public List<About> ListSearchAbout(string searchString)
        {
            if (searchString == null) return null;

            var listAbout = _db.Abouts.Where(x => x.Name.ToUpper() == searchString.ToUpper());
            return listAbout.ToList();
        }

        public bool CheckExits(string name)
        {
            var about = _db.Abouts.Where(x => x.Name == name).SingleOrDefault();
            if (about != null) return true;
            return false;
        }
    }
}
