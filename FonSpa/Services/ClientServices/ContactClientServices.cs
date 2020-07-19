using FonNature.Enum;
using FonNature.Services.IServices;
using Models.Entity;
using Models.Repository;
using System.Linq;

namespace FonNature.Services.Services
{
    public class ContactClientServices : IContactClientServices
    {
        private readonly ContactAdminRepository _contactAdminRepository;
        private readonly SEORepository _seoRepository;
        private readonly BannerRepository _bannerRepository;
        public ContactClientServices()
        {
            _contactAdminRepository = ContactAdminRepository.getInstance();
            _seoRepository = SEORepository.getInstance();
            _bannerRepository = BannerRepository.getInstance();
        }
        public SEO GetSeo()
        {
            return _seoRepository.GetSEO(5);
        }

        public Contact GetContact()
        {
            var contact = _contactAdminRepository.GetContact();
            return contact;
        }

        public Banner GetBanner()
        {
            return _bannerRepository.GetList().SingleOrDefault(x => x.Location == (int)BannerLocation.Contact);
        }

    }
}