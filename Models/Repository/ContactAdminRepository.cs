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

        public Contact GetDetail(long id)
        {
            var contact = _db.Contacts.Find(id);
            return contact;
        }

        public List<Contact> GetListContact()
        {
            return _db.Contacts.ToList();
        }

        public long AddContact(Contact contact)
        {
            contact.status = false;
            var addContact = _db.Contacts.Add(contact);
            _db.SaveChanges();
            return addContact.id;
        }

        public bool EditContact(Contact contact)
        {
            var contactEdit = _db.Contacts.Where(x => x.id == contact.id).SingleOrDefault();
            contactEdit.content = contact.content;
            contactEdit.status = contact.status;
            _db.SaveChanges();
            return true;
        }

        public bool Delete(long id)
        {
            var contact = _db.Contacts.Find(id);
            if (contact != null)
            {
                _db.Contacts.Remove(contact);
                _db.SaveChanges();
            }
            return true;
        }

        public bool? ChangeStatus(long id)
        {
            if (id == 0) return false;
            var accountNeedChange = _db.Contacts.Find(id);
            accountNeedChange.status = !accountNeedChange.status;
            _db.SaveChanges();
            return accountNeedChange.status;
        }
    }
}
