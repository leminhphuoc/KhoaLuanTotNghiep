using Models.Entity;
using System.Collections.Generic;

namespace FonNature.Services.IServices
{
    public interface IContactClientServices
    {
        List<Contact> GetContacts();
    }
}
