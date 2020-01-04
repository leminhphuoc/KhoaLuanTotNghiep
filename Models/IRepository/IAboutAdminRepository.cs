using Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.IRepository
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
