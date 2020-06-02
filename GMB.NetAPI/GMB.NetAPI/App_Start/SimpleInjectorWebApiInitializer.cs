using GMB.BusinessLogic.AppsLogic;
using GMB.BusinessLogic.UserAccountsLogic;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using SimpleInjector.Lifestyles;
using System.Linq;
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

        /// <summary>
        /// Initialize the container and register it as Web API Dependency Resolver.
        /// </summary>
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

        /// <summary>
        /// Initializing the container by the auto registration option
        /// https://simpleinjector.readthedocs.io/en/latest/advanced.html#batch-registration-auto-registration
        /// </summary>
        private static void InitializeContainer(Container container)
        {
            var businessAssembly = typeof(AppsLogic).Assembly; // Get GMB.BusinessLogic Assembly

            // Get service and inplementation types 
            var registrations =
                from type in businessAssembly.GetExportedTypes()
                where !type.Namespace.Contains("Utilities")
                from service in type.GetInterfaces()
                select new { service, implementation = type };

            // Register items in container
            foreach (var reg in registrations)
            {
                container.Register(reg.service, reg.implementation, Lifestyle.Transient);
            }
        }

    }
}