using GMB.BusinessLogic.AppsLogic;
using GMB.NetAPI.App_Start;
using GMB.NetAPI.Infrastructure.Presentation;
using GMB.NetAPI.Models;
using System.Collections.Generic;
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
            return Content(HttpStatusCode.OK, appsResponse);
        }


    }
}
