using FonNature.Services.IServices;
using Models.Entity;
using Models.IRepository;

namespace FonNature.Services.Services
{
    public class ContactAdminServices : IContactAdminServices
    {
        private readonly IContactAdminRepository _contactAdminRepository;
        public ContactAdminServices(IContactAdminRepository contactAdminRepository)
        {
            _contactAdminRepository = contactAdminRepository;
        }


        public Contact GetContact()
        {
            return _contactAdminRepository.GetContact();
        }


        public bool Edit(Contact contact)
        {
            if (contact == null) return false;
            _contactAdminRepository.EditContact(contact);
            return true;
        }
    }
}