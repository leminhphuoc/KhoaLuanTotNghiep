using FonNature.Enum;
using FonNature.Services.IClientServices;
using Models.Entity;
using Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FonNature.Services.ClientServices
{
    public class HomeServices : IHomeServices
    {
        private readonly MenuAdminRepository _menuAdminRepository;
        private readonly SlideAdminRepository _slideAdminRepository;
        private readonly ProductCategoryAdminRepository _productCategoryAdminRepository;
        private readonly StaffAdminRepository _staffAdminRepository;
        private readonly ContentCategoryAdminRepository _contentCategoryAdminRepository;
        private readonly FooterCategoryAdminRepository _footerCategoryAdminRepository;
        private readonly FooterAdminRepository _footerAdminRepository;
        private readonly AboutAdminRepository _aboutAdminRepository;
        private readonly SEORepository _seoRepository;
        private readonly ProductAdminRepository _productAdminRepository;
        private readonly ContentAdminRepository _contentAdminRepository;
        private readonly BannerRepository _bannerRepository;
        private readonly ContactAdminRepository _contactAdminRepository;
        public HomeServices()
        {
            _menuAdminRepository = MenuAdminRepository.getInstance();
            _slideAdminRepository = SlideAdminRepository.getInstance();
            _productCategoryAdminRepository = ProductCategoryAdminRepository.getInstance();
            _contentCategoryAdminRepository = ContentCategoryAdminRepository.getInstance();
            _staffAdminRepository = StaffAdminRepository.getInstance();
            _footerCategoryAdminRepository = FooterCategoryAdminRepository.getInstance();
            _footerAdminRepository = FooterAdminRepository.getInstance();
            _aboutAdminRepository = AboutAdminRepository.getInstance();
            _seoRepository = SEORepository.getInstance();
            _productAdminRepository = ProductAdminRepository.getInstance();
            _contentAdminRepository = ContentAdminRepository.getInstance();
            _bannerRepository = BannerRepository.getInstance();
            _contactAdminRepository = ContactAdminRepository.getInstance();
        }

        public List<Menu> ListMenu()
        {
            return _menuAdminRepository.GetListMenu();
        }

        public SEO GetHomeSeo()
        {
            return _seoRepository.GetSEO(1);
        }

        public List<Slide> ListSlide()
        {
            return _slideAdminRepository.GetListTrue();
        }
       
        public List<About> ListAbout()
        {
            return _aboutAdminRepository.GetListAbout();
        }
  
        public List<ProductCategory> ListProductCategories()
        {
            return _productCategoryAdminRepository.GetListProductCategory();
        }

        public List<ContentCategory> ListContentCategory()
        {
            return _contentCategoryAdminRepository.GetListContentCategory();
        }

        public List<Footer> ListFooter()
        {
            return _footerAdminRepository.GetListFooter().Where(x=>x.status == true).OrderBy(x=>x.displayOrder).ToList(); 
        }

        public List<FooterCategory> ListFooterCategory()
        {
            return _footerAdminRepository.GetFooterCategories();
        }

        public List<Staff> GetStaffs()
        {
            return _staffAdminRepository.GetListStaff().Where(x => x.status == true && x.ShowOnHome == true).OrderBy(x => x.createdDate).Take(3).ToList();
        }

        public List<Product> GetFeaturedProducts()
        {
            return _productAdminRepository.GetListProduct().Where(x => x.isDisplayHomePage).ToList();
        }

        public List<Product> GetBestSellerProducts()
        {
            return _productAdminRepository.GetListProduct().OrderByDescending(x=>x.AmountSold).Take(8).ToList();
        }

        public List<Product> GetTopHot()
        {
            return _productAdminRepository.GetListProduct().Where(x=>x.topHot >= DateTime.Now).OrderBy(x=>x.topHot).ToList();
        }

        public Slide GetOtherSlide()
        {
            return _slideAdminRepository.GetListSlide().SingleOrDefault(x => x.SlideType == 2);
        }
        
        public List<Content> GetHomeContent()
        {
            return _contentAdminRepository.GetListContent().Where(x => x.IsDisplayInHomePage).OrderByDescending(x=>x.createdDate).ToList();
        }
        
        public Banner GetBannerHome()
        {
            return _bannerRepository.GetList().SingleOrDefault(x=>x.Location == (int)BannerLocation.Home);
        }

        public Contact GetContactHome()
        {
            return _contactAdminRepository.GetContact();
        }
    }
}