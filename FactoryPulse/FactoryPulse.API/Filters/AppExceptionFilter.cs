using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FactoryPulse.API.Filters
{
    public class AppExceptionFilter(ILogger<AppExceptionFilter> logger) : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            switch (context.Exception)
            {
                case KeyNotFoundException knf:
                    context.Result = new NotFoundObjectResult(new { knf.Message });
                    break;

                case InvalidOperationException ioe:
                    context.Result = new ConflictObjectResult(new { ioe.Message });
                    break;

                case BadHttpRequestException bre:
                    context.Result = new ObjectResult(new { bre.Message });
                    break;

                default:
                    logger.LogError(context.Exception, "Unhandled exception");
                    context.Result = new ObjectResult(new { Message = "Internal Server Error" })
                    {
                        StatusCode = 500
                    };
                    break;
            }

            context.ExceptionHandled = true;
        }
    }
}
