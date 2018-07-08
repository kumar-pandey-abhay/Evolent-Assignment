using Services;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace Abhay_EvolentAssignment
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            container.RegisterType<IUserService, UserService>();
            container.RegisterType<IContactService, ContactService>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}