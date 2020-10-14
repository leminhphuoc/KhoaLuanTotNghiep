using Models.Entity;

namespace Models.Repository
{
    public interface IContactAdminRepository
    {
        Contact GetContact();
        bool EditContact(Contact contact);
    }
}
