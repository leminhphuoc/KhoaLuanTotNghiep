using FonNature.Enum;
using FonNature.Services.IClientServices;
using Models.Entity;
using Models.Repository;
using System.Collections.Generic;
using System.Linq;

namespace FonNature.Services.ClientServices
{
    public class AboutServices: IAboutServices
    {
        private readonly AboutAdminRepository _aboutAdminRepository;
        private readonly StaffAdminRepository _staffAdminRepository;
        private readonly SEORepository _seoRepository;
        private readonly BannerRepository _bannerRepository;
        public AboutServices()
        {
            _aboutAdminRepository = AboutAdminRepository.getInstance();
            _staffAdminRepository = StaffAdminRepository.getInstance();
            _seoRepository = SEORepository.getInstance();
            _bannerRepository = BannerRepository.getInstance();
        }

        public SEO GetSeo()
        {
            return _seoRepository.GetSEO(4);
        }

        public About GetAbout(int id)
        {
            if (id == 0) return null;
            return _aboutAdminRepository.GetDetail(id);
        }

        public List<About> GetAboutsTestimonials()
        {
            return _aboutAdminRepository.GetListAbout().Where(x=>x.Category == (int)AboutType.Testimonial).ToList();
        }

        public About GetAboutMain()
        {
            return _aboutAdminRepository.GetListAbout().FirstOrDefault(x => x.Category == (int)AboutType.OurCompany);
        }

        public List<Staff> GetStaffs()
        {
            return _staffAdminRepository.GetListStaff().Where(x => x.status == true && x.ShowOnHome == true).OrderBy(x => x.createdDate).Take(3).ToList();
        }

        public Banner GetBanner()
        {
            return _bannerRepository.GetList().SingleOrDefault(x => x.Location == (int)BannerLocation.AboutUs);
        }
    }
}