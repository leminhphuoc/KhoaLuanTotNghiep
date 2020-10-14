using Models.Entity;
using System.Collections.Generic;

namespace Models.Repository
{
    public interface IAboutAdminRepository
    {
        About GetDetail(long id);
        List<About> GetListAbout();
        bool? ChangeStatus(long id);
        long AddAbout(About about);
        bool EditAbout(About about);
        bool Delete(long id);
        List<About> ListSearchAbout(string searchString);
        bool CheckExits(string name);
    }
}
