using Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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