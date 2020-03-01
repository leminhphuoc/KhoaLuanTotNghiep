using Models.Entity;
using System.Collections.Generic;

namespace FonNature.Services.IClientServices
{
    public interface IAboutServices
    {
        About GetAbout(int id);
        List<About> GetAbouts();
        List<Staff> GetStaffs();
        SEO GetSeo();
    }
}
