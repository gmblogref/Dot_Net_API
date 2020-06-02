using GMB.BusinessLogic.Utilities;
using GMB.NetAPI.Infrastructure.Presentation;
using GMB.NetAPI.Models;
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
    public class AppsController : BaseApiController
    {
        /// <summary>
        /// Submit a new App request
        /// Example Fiddler test string https://localhost:44394/api/apps/add
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("add")]
        public async Task<IHttpActionResult> AddToApps([FromBody]AppsRequestModel request)
        {
            var response = await GetInstance<AppsPassThrough>().AddApp(request);
            if (response > 0)
            {
                return Content(HttpStatusCode.OK, response);
            }
            else
            {
                return Content(HttpStatusCode.InternalServerError, response);
            }
        }

        /// <summary>
        /// Get all the apps that are saved
        /// Example Fiddler test string https://localhost:44394/api/apps/getall
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("getall")]
        public async Task<IHttpActionResult> GetAllApps()
        {
            var response = await GetInstance<AppsPassThrough>().GetAllApps();
            if (response != null)
            {
                return Content(HttpStatusCode.OK, response);
            }
            else
            {
                return Content(HttpStatusCode.InternalServerError, response);
            }
        }

        /// <summary>
        /// Update an app
        /// Example Fiddler test string https://localhost:44394/api/apps/update/1
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("update/{id:int}")]
        public async Task<IHttpActionResult> UpdateApp(int id, [FromBody] AppsRequestModel request)
        {
            var response = await GetInstance<AppsPassThrough>().UpdateApp(id, request);
            if (response == RequestResponse.Successful)
            {
                return Content(HttpStatusCode.OK, response);
            }
            else
            {
                return Content(HttpStatusCode.InternalServerError, response);
            }
        }
    }
}
