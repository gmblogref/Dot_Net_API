using GMB.NetAPI.Infrastructure.ErrorHandler;
using Newtonsoft.Json.Serialization;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.ExceptionHandling;

namespace GMB.NetAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API Enable Cors globally
            // https://enable-cors.org/server_aspnet.html
            config.EnableCors(new EnableCorsAttribute("*", "*", "*"));
            
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // Web API use Json and XML formatters
            // https://docs.microsoft.com/en-us/aspnet/web-api/overview/formats-and-model-binding/json-and-xml-serialization
            var jsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().First();
            jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            config.Formatters.XmlFormatter.UseXmlSerializer = true;

            // Replace default exception handler
            config.Services.Replace(typeof(IExceptionHandler), new OopsExceptionHandler());
        }
    }
}
