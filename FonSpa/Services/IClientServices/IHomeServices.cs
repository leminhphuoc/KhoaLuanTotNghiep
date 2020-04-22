using Models.Entity;
using System.Collections.Generic;


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
        SEO GetHomeSeo();
        List<Product> GetFeaturedProducts();
        Product GetTopHot();
        List<Product> GetBestSellerProducts();
    }
}
