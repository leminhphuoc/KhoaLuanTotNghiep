using System.Web.Mvc;
using Unity.Mvc5;
using Unity;
using Models.Repository;
using FonNature.Services.IServices;
using FonNature.Services.Services;
using FonNature.Services.IClientServices;
using FonNature.Services.ClientServices;
using FonNature.Services.IAdminServices;
using FonNature.Services.AdminServices;

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
            container.RegisterType<IAccountAdminServices, AccountAdminServices>();
            container.RegisterType<IProductAdminSerivces, ProductAdminSerivces>();
            container.RegisterType<IContentServices, ContentServices>();
            container.RegisterType<ICustomerAdminServices, CustomerAdminServices>();
            container.RegisterType<IMenuAdminServices, MenuAdminServices>();
            container.RegisterType<IFooterAdminServices, FooterAdminServices>();
            container.RegisterType<IContactAdminServices, ContactAdminServices>();
            container.RegisterType<ISlideAdminServices, SlideAdminServices>();
            container.RegisterType<IProductCategoryAdminServices, ProductCategoryAdminService>();
            container.RegisterType<IAboutAdminServices, AboutAdminServices>();
            container.RegisterType<IStaffAdminServices, StaffAdminServices>();
            container.RegisterType<IContentCategoryAdminServices, ContentCategoryAdminServices>();
            container.RegisterType<IMenuTypeSerivces, MenuTypeAdminServices>();
            container.RegisterType<IFooterCategoryAdminServices, FooterCategoryAdminServices>();
            // Client
            container.RegisterType<IContactClientServices, ContactClientServices>();
            container.RegisterType<IHomeServices, HomeServices>();
            container.RegisterType<IProductServices, ProductServices>();
            container.RegisterType<IBlogServices, BlogServices>();
            container.RegisterType<IAboutServices, AboutServices>();
            container.RegisterType<IOrderServices, OrderServicescs>();
            container.RegisterType<IOrderAdminServices, OrderAdminServices>();
            container.RegisterType<ISearchService, SearchService>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));

            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new { action = "Home{controller}", id = UrlParameter.Optional }
            );

            context.MapRoute(
                "Admin_default_home",
                "admin",
                new { controller = "HomeAdmin",action = "HomeAdmin", id = UrlParameter.Optional }
            );
        }
    }
}