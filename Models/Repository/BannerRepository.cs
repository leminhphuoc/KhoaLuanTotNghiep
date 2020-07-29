using log4net;
using Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Models.Repository
{
    public class BannerRepository : IBannerRepository
    {
        private FonNatureDbContext _db = null;

        public FonNatureDbContext Db { get => _db; set => _db = value; }

        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public BannerRepository()
        {
            _db = new FonNatureDbContext();
        }

        public long Add(Banner banner)
        {
            try
            {
                var addedBanner = _db.Banners.Add(banner);
                Db.SaveChanges();
                log.Info($"Add Banner Success with information: {addedBanner.Id}, {addedBanner.Image}, {addedBanner.Location}");
                return addedBanner.Id;
            }
            catch(Exception e)
            {
                log.Error($"Error at Add Banner: {e.Message}");
                return 0;
            }
            
        }

        public bool Delete(long id)
        {
            try
            {
                var removeBanner = _db.Banners.Find(id);
                Db.Banners.Remove(removeBanner);
                Db.SaveChanges();
                log.Info($"Edit Banner Success with information: {removeBanner.Id}, {removeBanner.Image}, {removeBanner.Location}");
                return true;
            }
            catch (Exception e)
            {
                log.Error($"Error at Add Banner: {e.Message}");
                return false;
            }
        }

        public bool Edit(Banner editBanner)
        {
            try
            {
                var banner = _db.Banners.Find(editBanner.Id);
                banner.Image = editBanner.Image;
                banner.Location = editBanner.Location;
                Db.SaveChanges();
                log.Info($"Edit Banner Success with information: {banner.Id}, {banner.Image}, {banner.Location}");
                return true;
            }
            catch (Exception e)
            {
                log.Error($"Error at Add Banner: {e.Message}");
                return false;
            }
        }

        public Banner GetDetail(long id)
        {
            try
            {
                var banner = _db.Banners.Find(id);
                log.Info($"Get Banner Success with information: {banner.Id}, {banner.Image}, {banner.Location}");
                return banner;
            }
            catch (Exception e)
            {
                log.Error($"Error at Add Banner: {e.Message}");
                return null;
            }
        }

        public List<Banner> GetList()
        {
            try
            {
                log.Info($"Get Banners Success");
                return _db.Banners.ToList();
            }
            catch (Exception e)
            {
                log.Error($"Error at Add Banner: {e.Message}");
                return new List<Banner>();
            }
        }
    }
}
