using Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Models.Repository
{
    public class BannerRepository
    {
        private FonNatureDbContext _db = null;

        public FonNatureDbContext Db { get => _db; set => _db = value; }

        private static BannerRepository instance = new BannerRepository();

        private BannerRepository()
        {
            _db = new FonNatureDbContext();
        }

        public static BannerRepository getInstance()
        {
            return instance;
        }

        public long Add(Banner banner)
        {
            try
            {
                var addedBanner = Db.Banners.Add(banner);
                Db.SaveChanges();
                return addedBanner.Id;
            }
            catch(Exception e)
            {
                return 0;
            }
            
        }

        public bool Delete(long id)
        {
            try
            {
                var removeBanner = Db.Banners.Find(id);
                Db.Banners.Remove(removeBanner);
                Db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Edit(Banner editBanner)
        {
            try
            {
                var banner = Db.Banners.Find(editBanner.Id);
                banner.Image = editBanner.Image;
                banner.Location = editBanner.Location;
                Db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public Banner GetDetail(long id)
        {
            try
            {
                var banner = Db.Banners.Find(id);
                return banner;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public List<Banner> GetList()
        {
            try
            {
                return Db.Banners.ToList();
            }
            catch (Exception e)
            {
                return new List<Banner>();
            }
        }
    }
}
