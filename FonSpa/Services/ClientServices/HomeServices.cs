using FonNature.Services.IClientServices;
using Models.Entity;
using Models.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FonNature.Services.ClientServices
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
        public HomeServices(IMenuAdminRepository menuAdminRepository, ISlideAdminRepository slideAdminRepository, IProductCategoryAdminRepository productCategoryAdminRepository ,IContentCategoryAdminRepository contentCategoryAdminRepository, IFooterAdminRepository footerAdminRepository, IFooterCategoryAdminRepository footerCategoryAdminRepository, IAboutAdminRepository aboutAdminRepository, IStaffAdminRepository staffAdminRepository
            , ISEORepository seoRepository, IProductAdminRepository productAdminRepository)
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

        public Product GetTopHot()
        {
            return _productAdminRepository.GetListProduct().SingleOrDefault(x=>x.topHot >= DateTime.Now);
        }
    }
}