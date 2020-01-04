using Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FonNature.Services.IClientServices
{
    public interface IHomeServices
    {
        List<Menu> ListMenu();
        List<Slide> ListSlide();
        List<ProductCategory> ListProductCategories();
        List<ContentCategory> ListContentCategory();
        List<Footer> ListFooter();
        List<FooterCategory> ListFooterCategory();
        List<About> ListAbout();
        List<Staff> GetStaffs();
    }
}
