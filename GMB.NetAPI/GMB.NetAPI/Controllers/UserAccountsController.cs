using GMB.BusinessLogic.Utilities;
using GMB.NetAPI.Infrastructure.Presentation;
using GMB.NetAPI.Models;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;

namespace GMB.NetAPI.Controllers
{
    /// <summary>
    /// UserAccounts API Controller
    /// https://simpleinjector.readthedocs.io/en/latest/using.html#automatic-constructor-injection-auto-wiring
    /// </summary>
    [RoutePrefix("api/useraccounts")]
    public class UserAccountsController : BaseApiController
    {
        /// <summary>
        /// Submit a new User Account request
        /// Example Fiddler test string https://localhost:44394/api/useraccount/add
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("add")]
        public async Task<IHttpActionResult> AddToUserAccounts([FromBody] UserAccountsRequestModel request)
        {
            var response = await GetInstance<UserAccountsPassThrough>().AddUser(request);
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
        /// Delete user account
        /// Example Fiddler test string https://localhost:44394/api/useraccounts/delete/1
        /// </summary>
        /// <param name="userAccountsId"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("delete/{userAccountsId:int}")]
        public async Task<IHttpActionResult> DeleteUserAccount([FromUri] int userAccountsId)
        {
            var response = await GetInstance<UserAccountsPassThrough>().DeleteUserAccountById(userAccountsId);
            if (response == RequestResponse.Successful)
            {
                return Content(HttpStatusCode.OK, response);
            }
            else
            {
                return Content(HttpStatusCode.InternalServerError, response);
            }
        }

        /// <summary>
        /// Get all the user accounts that are saved
        /// Example Fiddler test string https://localhost:44394/api/useraccounts/getall
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("getall")]
        public async Task<IHttpActionResult> GetAllUserAccounts()
        {
            var response = await GetInstance<UserAccountsPassThrough>().GetAllUserAccounts();
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
        /// Get user account by id
        /// Example Fiddler test string https://localhost:44394/api/useraccounts/get/1
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("get/{userAccountId:int}")]
        public async Task<IHttpActionResult> GetUserAccount([FromUri] int userAccountId)
        {
            var response = await GetInstance<UserAccountsPassThrough>().GetUserAccountById(userAccountId);
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
        /// Update an user account
        /// Example Fiddler test string https://localhost:44394/api/useraccounts/update/1
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("update/{id:int}")]
        public async Task<IHttpActionResult> UpdateUserAccount(int id, [FromBody] UserAccountsRequestModel request)
        {
            var response = await GetInstance<UserAccountsPassThrough>().UpdateUserAccount(id, request);
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
