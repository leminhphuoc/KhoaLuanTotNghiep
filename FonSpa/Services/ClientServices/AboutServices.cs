using FonNature.Enum;
using FonNature.Services.IClientServices;
using Models.Entity;
using Models.IRepository;
using System.Collections.Generic;
using System.Linq;

namespace FonNature.Services.ClientServices
{
    public class AboutServices: IAboutServices
    {
        private readonly IAboutAdminRepository _aboutAdminRepository;
        private readonly IStaffAdminRepository _staffAdminRepository;
        private readonly ISEORepository _seoRepository;
        public AboutServices(IAboutAdminRepository aboutAdminRepository, IStaffAdminRepository staffAdminRepository,
            ISEORepository seoRepository)
        {
            _aboutAdminRepository = aboutAdminRepository;
            _staffAdminRepository = staffAdminRepository;
            _seoRepository = seoRepository;
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

    }
}