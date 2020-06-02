using GMB.BusinessLogic.AppsLogic;
using GMB.BusinessLogic.UserAccountsLogic;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using SimpleInjector.Lifestyles;
using System.Web.Http;

[assembly: WebActivator.PostApplicationStartMethod(typeof(GMB.NetAPI.App_Start.SimpleInjectorWebApiInitializer), "Initialize")]
namespace GMB.NetAPI.App_Start
{
    /// <summary>
    /// Initializer for Simple Injector IOC
    /// https://www.nuget.org/packages/SimpleInjector.Integration.WebApi.WebHost.QuickStart/
    /// </summary>
    public static class SimpleInjectorWebApiInitializer
    {
        public static Container Container;

        /// <summary>Initialize the container and register it as Web API Dependency Resolver.</summary>
        public static void Initialize()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();
            
            InitializeContainer(container);

            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);
       
            container.Verify();
            
            GlobalConfiguration.Configuration.DependencyResolver =
                new SimpleInjectorWebApiDependencyResolver(container);

            Container = container;
        }
     
        private static void InitializeContainer(Container container)
        {
            // For instance:
            // container.Register<IUserRepository, SqlUserRepository>(Lifestyle.Scoped);

            container.Register<IAppsLogic, AppsLogic>();
            container.Register<IUserAccountsLogic, UserAccountsLogic>();
        }
    }
}