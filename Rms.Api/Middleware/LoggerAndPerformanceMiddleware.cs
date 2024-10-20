using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;

namespace Rms.Api.Middleware
{
    public class LoggerAndPerformanceMiddleware
    {
        private readonly Stopwatch _timer;
        private readonly RequestDelegate _next;
        private readonly ILogger<LoggerAndPerformanceMiddleware> _logger;

        public LoggerAndPerformanceMiddleware(RequestDelegate next, ILogger<LoggerAndPerformanceMiddleware> logger)
        {
            _next = next;
            _logger = logger;
            _timer = new Stopwatch();
        }

        public async Task Invoke(HttpContext context)
        {
            var path = String.Empty;

            if (context.Request.Path.Value != null)
                path = context.Request.Path.Value;

            _timer.Start();

            _logger.LogInformation("Api Incoming Request: {path}", path);

            await _next(context);

            _timer.Stop();

            var elapsedMilliseconds = _timer.ElapsedMilliseconds;
            _timer.Reset();

            if (elapsedMilliseconds > 500)
            {
                _logger.LogWarning("Api Long Running Request: {path} - ({ElapsedMilliseconds} milliseconds)",
                    path, elapsedMilliseconds);
            }
            else
            {
                _logger.LogInformation("Api Running Request: {path} - ({ElapsedMilliseconds} milliseconds)",
                    path, elapsedMilliseconds);
            }
        }
    }
}
