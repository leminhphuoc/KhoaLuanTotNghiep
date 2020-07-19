using FonNature.Services.IServices;
using FonNature.Services.Services;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace FonNature
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers
            container.RegisterType<IAccountAdminServices, AccountAdminServices>();
            container.RegisterType<IProductAdminSerivces, ProductAdminSerivces>();
            container.RegisterType<IContentServices, ContentServices>();
            container.RegisterType<ICustomerAdminServices, CustomerAdminServices>();
            container.RegisterType<IMenuAdminServices, MenuAdminServices>();
            container.RegisterType<IFooterAdminServices, FooterAdminServices>();
            container.RegisterType<IContactClientServices, ContactClientServices>();
            container.RegisterType<ISlideAdminServices, SlideAdminServices>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}