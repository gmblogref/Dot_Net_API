using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;

namespace GMB.NetAPI.Infrastructure
{
    /// <summary>
    /// Overall Exception handler to catch uncaught messages and give end user details
    /// https://docs.microsoft.com/en-us/aspnet/web-api/overview/error-handling/web-api-global-error-handling
    /// https://stack247.wordpress.com/2018/10/12/how-to-implement-iexceptionlogger-and-iexceptionhandler-in-web-api-net/
    /// </summary>
    public class OopsExceptionHandler : ExceptionHandler
    {
        public override Task HandleAsync(ExceptionHandlerContext context, CancellationToken cancellationToken)
        {
            // Code to handle exception...
            context.Result = new TextPlainErrorResult
            {
                Request = context.ExceptionContext.Request,
                Content = "Oops! Sorry! Something went wrong. It has been logged and staff has been notified."
            };

            return base.HandleAsync(context, cancellationToken);
        }

        private class TextPlainErrorResult : IHttpActionResult
        {
            public HttpRequestMessage Request { get; set; }

            public string Content { get; set; }

            public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
            {
                HttpResponseMessage response =
                                 new HttpResponseMessage(HttpStatusCode.InternalServerError);
                response.Content = new StringContent(Content);
                response.RequestMessage = Request;
                return Task.FromResult(response);
            }
        }
    }
}