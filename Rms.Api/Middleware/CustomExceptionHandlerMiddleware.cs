using System;
using System.Net;
using System.Threading.Tasks;
using Rms.Api.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Rms.Api.Middleware
{
    public class CustomExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<CustomExceptionHandlerMiddleware> _logger;

        public CustomExceptionHandlerMiddleware(RequestDelegate next, ILogger<CustomExceptionHandlerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var code = HttpStatusCode.InternalServerError;

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;
            context.Response.AddApplicationError(exception.Message);
            _logger.LogError(exception.Message);
            _logger.LogError(exception.StackTrace);
            if (exception.InnerException != null) _logger.LogCritical(exception.InnerException.Message);

            var result = JsonConvert.SerializeObject(new { error = exception.Message });


            return context.Response.WriteAsync(result);
        }
    }
}
