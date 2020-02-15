using FonNature.Services.IServices;
using Models.Entity;
using Models.IRepository;
using System.Collections.Generic;

namespace FonNature.Services.Services
{
    public class ContactClientServices : IContactClientServices
    {
        private readonly IContactAdminRepository _contactAdminRepository;
        public ContactClientServices(IContactAdminRepository contactAdminRepository)
        {
            _contactAdminRepository = contactAdminRepository;
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