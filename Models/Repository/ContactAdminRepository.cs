using Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Repository
{
    public class ContactAdminRepository
    {
        private FonNatureDbContext _db = null;

        public FonNatureDbContext Db { get => _db; set => _db = value; }

        private static ContactAdminRepository instance = new ContactAdminRepository();

        private ContactAdminRepository()
        {
            _db = new FonNatureDbContext();
        }

        public static ContactAdminRepository getInstance()
        {
            return instance;
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
            contactEdit.LinkFaceBook = contact.LinkFaceBook;
            contactEdit.LinkInstagram = contact.LinkInstagram;
            contactEdit.LogoHeader = contact.LogoHeader;
            contactEdit.LogoFooter = contact.LogoFooter;
            _db.SaveChanges();
            return true;
        }
    }
}
