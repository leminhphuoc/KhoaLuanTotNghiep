using Models.Entity;
using Models.Repository;

namespace FonNature.Services
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