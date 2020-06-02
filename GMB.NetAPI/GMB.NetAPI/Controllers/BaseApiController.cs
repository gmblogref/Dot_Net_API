using GMB.NetAPI.App_Start;
using System.Web.Http;

namespace GMB.NetAPI.Controllers
{
    /// <summary>
    /// Base API controller for shared across all API Controllers
    /// </summary>
    public abstract class BaseApiController : ApiController
    {
        /// <summary>
        /// GetInstance of TYPE for the calling Controller
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        protected T GetInstance<T>() where T : class
        {
            return SimpleInjectorWebApiInitializer.Container.GetInstance<T>();
        }
    }
}