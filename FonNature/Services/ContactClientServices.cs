using FonNature.Enum;
using Models.Entity;
using Models.Repository;
using System.Linq;

namespace FonNature.Services
{
    public class ContactClientServices : IContactClientServices
    {
        private readonly IContactAdminRepository _contactAdminRepository;
        private readonly ISEORepository _seoRepository;
        private readonly IBannerRepository _bannerRepository;
        public ContactClientServices(IContactAdminRepository contactAdminRepository, ISEORepository seoRepository, IBannerRepository bannerRepository)
        {
            _contactAdminRepository = contactAdminRepository;
            _seoRepository = seoRepository;
            _bannerRepository = bannerRepository;
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
            return _bannerRepository.GetList().FirstOrDefault(x => x.Location == (int)BannerLocation.Contact);
        }

    }
}