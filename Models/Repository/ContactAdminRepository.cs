using Models.Entity;
using Models.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Repository
{
    public class ContactAdminRepository : IContactAdminRepository
    {
        private FonNatureDbContext _db = null;

        public FonNatureDbContext Db { get => _db; set => _db = value; }

        public ContactAdminRepository()
        {
            _db = new FonNatureDbContext();
        }

        public Contact GetContact()
        {
            return _db.Contacts.FirstOrDefault();
        }

        public bool EditContact(Contact contact)
        {
            var contactEdit = _db.Contacts.FirstOrDefault();
            contactEdit.Address = contact.Address;
            contactEdit.Email = contact.Email;
            contactEdit.MobilePhone = contact.MobilePhone;
            _db.SaveChanges();
            return true;
        }
    }
}
