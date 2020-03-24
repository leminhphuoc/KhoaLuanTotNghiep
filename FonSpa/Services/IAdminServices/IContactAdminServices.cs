using Models.Entity;
using System.Collections.Generic;

namespace FonNature.Services.IServices
{
    public interface IContactAdminServices
    {
        bool Edit(Contact contact);
        Contact GetContact();
    }
}