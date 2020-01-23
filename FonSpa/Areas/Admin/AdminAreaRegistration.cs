using System.Web.Mvc;
using Unity.Mvc5;
using Unity;
using Models.IRepository;
using Models.Repository;
using FonNature.Services.IServices;
using FonNature.Services.Services;
using FonNature.Services.IClientServices;
using FonNature.Services.ClientServices;

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
            container.RegisterType<ICustomerAdminRepository, CustomerAdminRepository>();
            container.RegisterType<ICustomerAdminServices, CustomerAdminServices>();
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
            // Client
            container.RegisterType<IContactClientServices, ContactClientServices>();
            container.RegisterType<IHomeServices, HomeServices>();
            container.RegisterType<IProductServices, ProductServices>();
            container.RegisterType<IBlogServices, BlogServices>();
            container.RegisterType<IAboutServices, AboutServices>();
            container.RegisterType<IOrderRepository, OrdersRepository>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));

            //Admin Account

            context.MapRoute(
                "CreateAccount",
                "Admin/createaccount",
                new { action = "Create", Controller = "AccountAdmin" }
            );

            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}