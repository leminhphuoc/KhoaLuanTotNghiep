using FonNature.Services.IServices;
using Models.Entity;
using Models.IRepository;

namespace FonNature.Services.Services
{
    public class ContactClientServices : IContactClientServices
    {
        private readonly IContactAdminRepository _contactAdminRepository;
        private readonly ISEORepository _seoRepository;
        public ContactClientServices(IContactAdminRepository contactAdminRepository , ISEORepository seoRepository)
        {
            _contactAdminRepository = contactAdminRepository;
            _seoRepository = seoRepository;
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

    }
}