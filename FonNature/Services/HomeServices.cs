using FonNature.Enum;
using Models.Entity;
using Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FonNature.Services
{
    public class HomeServices : IHomeServices
    {
        private readonly IMenuAdminRepository _menuAdminRepository;
        private readonly ISlideAdminRepository _slideAdminRepository;
        private readonly IProductCategoryAdminRepository _productCategoryAdminRepository;
        private readonly IStaffAdminRepository _staffAdminRepository;
        private readonly IContentCategoryAdminRepository _contentCategoryAdminRepository;
        private readonly IFooterCategoryAdminRepository _footerCategoryAdminRepository;
        private readonly IFooterAdminRepository _footerAdminRepository;
        private readonly IAboutAdminRepository _aboutAdminRepository;
        private readonly ISEORepository _seoRepository;
        private readonly IProductAdminRepository _productAdminRepository;
        private readonly IContentAdminRepository _contentAdminRepository;
        private readonly IBannerRepository _bannerRepository;
        private readonly IContactAdminRepository _contactAdminRepository;
        private readonly IBenefitRepository _benefitRepository;
        public HomeServices(IMenuAdminRepository menuAdminRepository, ISlideAdminRepository slideAdminRepository, IProductCategoryAdminRepository productCategoryAdminRepository, IContentCategoryAdminRepository contentCategoryAdminRepository, IFooterAdminRepository footerAdminRepository, IFooterCategoryAdminRepository footerCategoryAdminRepository, IAboutAdminRepository aboutAdminRepository, IStaffAdminRepository staffAdminRepository
            , ISEORepository seoRepository, IProductAdminRepository productAdminRepository, IContentAdminRepository contentAdminRepository, IBannerRepository bannerRepository,
             IContactAdminRepository contactAdminRepository, IBenefitRepository benefitRepository)
        {
            _menuAdminRepository = menuAdminRepository;
            _slideAdminRepository = slideAdminRepository;
            _productCategoryAdminRepository = productCategoryAdminRepository;
            _contentCategoryAdminRepository = contentCategoryAdminRepository;
            _staffAdminRepository = staffAdminRepository;
            _footerCategoryAdminRepository = footerCategoryAdminRepository;
            _footerAdminRepository = footerAdminRepository;
            _aboutAdminRepository = aboutAdminRepository;
            _seoRepository = seoRepository;
            _productAdminRepository = productAdminRepository;
            _contentAdminRepository = contentAdminRepository;
            _bannerRepository = bannerRepository;
            _contactAdminRepository = contactAdminRepository;
            _benefitRepository = benefitRepository;
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
            return _footerAdminRepository.GetListFooter().Where(x => x.status == true).OrderBy(x => x.displayOrder).ToList();
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
            return _productAdminRepository.GetListProduct().OrderByDescending(x => x.AmountSold).Take(8).ToList();
        }

        public List<Product> GetTopHot()
        {
            return _productAdminRepository.GetListProduct().Where(x => x.topHot >= DateTime.Now).OrderBy(x => x.topHot).ToList();
        }

        public Slide GetOtherSlide()
        {
            return _slideAdminRepository.GetListSlide().SingleOrDefault(x => x.SlideType == 2);
        }

        public List<Content> GetHomeContent()
        {
            return _contentAdminRepository.GetListContent().Where(x => x.IsDisplayInHomePage).OrderByDescending(x => x.createdDate).ToList();
        }

        public Banner GetBannerHome()
        {
            return _bannerRepository.GetList().FirstOrDefault(x => x.Location == (int)BannerLocation.Home);
        }

        public Contact GetContactHome()
        {
            return _contactAdminRepository.GetContact();
        }
        public About GetAboutUs()
        {
            return _aboutAdminRepository.GetListAbout().FirstOrDefault(x => x.Category.Equals(1));
        }

        public List<Benefit> GetBenefits()
        {
            return _benefitRepository.GetBenefits();
        }
    }
}