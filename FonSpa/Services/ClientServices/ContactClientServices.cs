using FonNature.Services.IServices;
using Models.Entity;
using Models.IRepository;
using System.Collections.Generic;

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

        public List<Contact> GetContacts()
        {
            var listContact = _contactAdminRepository.GetListContact();
            var listContactDisplay = new List<Contact>();
            foreach(Contact contact in listContact)
            {
                if(contact.status == true)
                {
                    listContactDisplay.Add(contact);
                }
            }
            return listContactDisplay;
        }

    }
}