using Models.Entity;
using System.Collections.Generic;


namespace FonNature.Services
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
        List<Product> GetBestSellerProducts();
        List<Product> GetTopHot();
        Slide GetOtherSlide();
        List<Content> GetHomeContent();
        Banner GetBannerHome();
        Contact GetContactHome();
        About GetAboutUs();
        List<Benefit> GetBenefits();
    }
}
