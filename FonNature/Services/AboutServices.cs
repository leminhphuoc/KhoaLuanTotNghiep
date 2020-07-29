using FonNature.Enum;
using Models.Entity;
using Models.Repository;
using System.Collections.Generic;
using System.Linq;

namespace FonNature.Services
{
    public class AboutServices: IAboutServices
    {
        private readonly IAboutAdminRepository _aboutAdminRepository;
        private readonly IStaffAdminRepository _staffAdminRepository;
        private readonly ISEORepository _seoRepository;
        private readonly IBannerRepository _bannerRepository;
        public AboutServices(IAboutAdminRepository aboutAdminRepository, IStaffAdminRepository staffAdminRepository,
            ISEORepository seoRepository, IBannerRepository bannerRepository)
        {
            _aboutAdminRepository = aboutAdminRepository;
            _staffAdminRepository = staffAdminRepository;
            _seoRepository = seoRepository;
            _bannerRepository = bannerRepository;
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