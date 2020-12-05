using FonNature.Services;
using FonNature.Services.AdminServices;
using FonNature.Services.IAdminServices;
using Models.Repository;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace FonNature.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration
    {

        public override string AreaName
        {
            get
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            var container = new UnityContainer();
            container.RegisterType<IAccountAdminRepository, AccountAdminRepository>();
            container.RegisterType<IAccountAdminServices, AccountAdminServices>();
            container.RegisterType<IProductAdminRepository, ProductAdminRepository>();
            container.RegisterType<IProductAdminSerivces, ProductAdminSerivces>();
            container.RegisterType<IContentAdminRepository, ContentAdminRepository>();
            container.RegisterType<IContentServices, ContentServices>();
            container.RegisterType<IMenuAdminRepository, MenuAdminRepository>();
            container.RegisterType<IMenuAdminServices, MenuAdminServices>();
            container.RegisterType<IFooterAdminServices, FooterAdminServices>();
            container.RegisterType<IFooterAdminRepository, FooterAdminRepository>();
            container.RegisterType<IContactAdminServices, ContactAdminServices>();
            container.RegisterType<IContactAdminRepository, ContactAdminRepository>();
            container.RegisterType<ISlideAdminServices, SlideAdminServices>();
            container.RegisterType<ISlideAdminRepository, SlideAdminRepository>();
            container.RegisterType<IProductCategoryAdminServices, ProductCategoryAdminService>();
            container.RegisterType<IProductCategoryAdminRepository, ProductCategoryAdminRepository>();
            container.RegisterType<IAboutAdminServices, AboutAdminServices>();
            container.RegisterType<IAboutAdminRepository, AboutAdminRepository>();
            container.RegisterType<IStaffAdminServices, StaffAdminServices>();
            container.RegisterType<IStaffAdminRepository, StaffAdminRepository>();
            container.RegisterType<IContentCategoryAdminServices, ContentCategoryAdminServices>();
            container.RegisterType<IContentCategoryAdminRepository, ContentCategoryAdminRepository>();
            container.RegisterType<IMenuTypeSerivces, MenuTypeAdminServices>();
            container.RegisterType<IMenuTypeAdminRepository, MenuTypeAdminRepository>();
            container.RegisterType<IFooterCategoryAdminServices, FooterCategoryAdminServices>();
            container.RegisterType<IFooterCategoryAdminRepository, FooterCategoryAdminRepository>();
            container.RegisterType<IIPAddressRepository, IPAddressRepository>();
            container.RegisterType<IBannerRepository, BannerRepository>();
            container.RegisterType<IDictionaryRepository, DictionaryRepository>();
            container.RegisterType<IPageRepository, PageRepository>();
            // Client
            container.RegisterType<IContactClientServices, ContactClientServices>();
            container.RegisterType<IHomeServices, HomeServices>();
            container.RegisterType<IProductServices, ProductServices>();
            container.RegisterType<IBlogServices, BlogServices>();
            container.RegisterType<IAboutServices, AboutServices>();
            container.RegisterType<IOrderRepository, OrdersRepository>();
            container.RegisterType<IOrderServices, OrderService>();
            container.RegisterType<IOrderAdminServices, OrderAdminServices>();
            container.RegisterType<ISEORepository, SEORepository>();
            container.RegisterType<ISearchService, SearchService>();
            container.RegisterType<IBenefitRepository, BenefitRepository>();
            container.RegisterType<IServiceRepository, ServiceRepository>();
            container.RegisterType<IServiceCategoryRepository, ServiceCategoryRepository>();
            container.RegisterType<IBookingService, BookingService>();
            container.RegisterType<IClientAccountRepository, ClientAccountRepository>();
            container.RegisterType<IMembershipService, MembershipService>();
            container.RegisterType<IBookingRepository, BookingRepository>();
            container.RegisterType<IHttpClientService, HttpClientService>();
            container.RegisterType<IFileHandlerService, FileHandlerService>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));

            context.MapRoute(
                "Admin_default_home",
                "admin",
                new { AreaName = "admin", controller = "HomeAdmin", action = "HomeAdmin", id = UrlParameter.Optional }
            );

            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new { controller = "{controller}", action = "Index", id = UrlParameter.Optional }
            );          
        }
    }
}