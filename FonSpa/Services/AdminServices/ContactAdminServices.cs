using FonNature.Services.IServices;
using Models.Entity;
using Models.IRepository;
using System;
using System.Collections.Generic;

namespace FonNature.Services.Services
{
    public class ContactAdminServices : IContactAdminServices
    {
        private readonly IContactAdminRepository _contactAdminRepository;
        public ContactAdminServices(IContactAdminRepository contactAdminRepository)
        {
            _contactAdminRepository = contactAdminRepository;
        }

        public long AddContact(Contact contact)
        {
            if (contact == null) return 0;
            var addContact = _contactAdminRepository.AddContact(contact);
            var idContact = addContact;
            return idContact;
        }

        public List<Contact> GetListContact()
        {
            return _contactAdminRepository.GetListContact();
        }

        public Contact GetDetail(int id)
        {
            if (id == 0) return null;
            var contact = _contactAdminRepository.GetDetail(id);
            return contact;
        }

        public bool Edit(Contact contact)
        {
            if (contact == null) return false;
            _contactAdminRepository.EditContact(contact);
            return true;
        }

        public bool Delete(int id)
        {
            if (id == 0) return false;
            _contactAdminRepository.Delete(id);
            return true;
        }

        public bool? ChangeStatus(int id)
        {
            return _contactAdminRepository.ChangeStatus(id);
        }
    }
}