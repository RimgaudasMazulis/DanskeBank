using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;
using System.Web.Http.ModelBinding;

namespace CodeChallenge.Web.Exceptions.Filters
{
    public class GlobalExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            HttpRequestMessage request = context.ActionContext.Request;

            if (context.Exception is ModelStateException)
            {
                ModelStateDictionary modelState = context.ActionContext.ModelState;

                context.Response = request.CreateErrorResponse(HttpStatusCode.BadRequest, modelState);
            }
        }
    }
}