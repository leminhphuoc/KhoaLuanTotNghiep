using Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FonNature.Services.IClientServices
{
    public interface IAboutServices
    {
        About GetAbout(int id);
        List<About> GetAbouts();
        List<Staff> GetStaffs();
    }
}
