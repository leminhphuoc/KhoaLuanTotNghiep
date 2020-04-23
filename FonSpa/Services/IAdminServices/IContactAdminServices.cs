using Models.Entity;

namespace FonNature.Services.IServices
{
    public interface IContactAdminServices
    {
        bool Edit(Contact contact);
        Contact GetContact();
    }
}