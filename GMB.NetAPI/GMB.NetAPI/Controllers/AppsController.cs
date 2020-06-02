using GMB.BusinessLogic.AppsLogic;
using GMB.NetAPI.App_Start;
using GMB.NetAPI.Infrastructure.Presentation;
using GMB.NetAPI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;

namespace GMB.NetAPI.Controllers
{
    /// <summary>
    /// Apps API Controller
    /// https://simpleinjector.readthedocs.io/en/latest/using.html#automatic-constructor-injection-auto-wiring
    /// </summary>
    [RoutePrefix("api/apps")]
    public class AppsController : ApiController
    {
        [HttpPost]
        [Route("add")]
        public async Task<IHttpActionResult> AddToApps([FromBody]AppsRequestModel request)
        {
            var appsResponse = await SimpleInjectorWebApiInitializer.Container.GetInstance<AppsPassThrough>().AddApp(request);
            if (appsResponse > 0)
            {
                return Content(HttpStatusCode.OK, appsResponse);
            }
            else
            {
                return Content(HttpStatusCode.InternalServerError, appsResponse);
            }
        }

        [HttpGet]
        [Route("getall")]
        public async Task<IHttpActionResult> GetAllApps()
        {
            var appsResponse = await SimpleInjectorWebApiInitializer.Container.GetInstance<AppsPassThrough>().GetAllApps();
            if (appsResponse != null)
            {
                return Content(HttpStatusCode.OK, appsResponse);
            }
            else
            {
                return Content(HttpStatusCode.InternalServerError, appsResponse);
            }
        }
    }
}
