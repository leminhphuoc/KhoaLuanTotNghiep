using FonNature.Services.IServices;
using Models.Entity;
using Models.Repository;

namespace FonNature.Services.Services
{
    public class ContactAdminServices : IContactAdminServices
    {
        private readonly ContactAdminRepository _contactAdminRepository;
        public ContactAdminServices()
        {
            _contactAdminRepository = ContactAdminRepository.getInstance();
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