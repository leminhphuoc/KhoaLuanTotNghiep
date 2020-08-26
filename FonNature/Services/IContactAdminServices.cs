using Models.Entity;

namespace FonNature.Services
{
    public interface IContactAdminServices
    {
        bool Edit(Contact contact);
        Contact GetContact();
    }
}