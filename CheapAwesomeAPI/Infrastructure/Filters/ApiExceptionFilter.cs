using CheapAwesome.Domain.Models.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;

namespace CheapAwesome.API.Infrastructure.Filters
{
    public class ApiExceptionFilter : ExceptionFilterAttribute
    {
        private ILogger<ApiExceptionFilter> _Logger;

        /// <summary>
        /// Dependency to be injected and resolved
        /// </summary>
        /// <param name="logger"></param>
        public ApiExceptionFilter(ILogger<ApiExceptionFilter> logger)
        {
            _Logger = logger;
        }


        /// <summary>
        /// This method will be called on the exceptions which are unhandled from the code
        /// </summary>
        /// <param name="context"></param>
        public override void OnException(ExceptionContext context)
        {
            CommonResponse apiError = null;
          
                // Unhandled errors
                var msg = context.Exception.GetBaseException().Message;
                string stack = context.Exception.StackTrace;


                apiError = CommonResponse.CreateErrorResponse(msg,null,500);
                apiError.Details = stack;

                context.HttpContext.Response.StatusCode = 500;

                // handle logging here
                _Logger.LogError(new EventId(0), context.Exception, msg);
            

            // always return a JSON result
            context.Result = new JsonResult(apiError);

            base.OnException(context);
        }
    }
}
