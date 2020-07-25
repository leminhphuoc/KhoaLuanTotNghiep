using Models.Entity;
using System.Collections.Generic;

namespace FonNature.Services.IServices
{
    public interface IAboutAdminServices
    {
        List<About> ListAllByName(string searchString);
        long AddAbout(About about);
        bool Delete(int id);
        About GetDetail(int id);
        bool Edit(About about);
        bool? ChangeStatus(int id);
    }
}