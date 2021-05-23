using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BankAppXX.Web.Middlewares
{
    public class PerformanceMiddleware
    {

        private readonly RequestDelegate next;
        private readonly ILogger<PerformanceMiddleware> logger;

        public PerformanceMiddleware(RequestDelegate next, ILogger<PerformanceMiddleware> logger)
        {
            this.next = next;
            this.logger = logger;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            await next(httpContext);
            stopwatch.Stop();

            if (stopwatch.ElapsedMilliseconds > 300)
            {
                logger.LogInformation(httpContext.Request.Path);
                logger.LogInformation("ilgili islem 300 ms den cok surdu");
            }
            else
            {
                logger.LogInformation(httpContext.Request.Path);
                logger.LogInformation("ilgili islem 300 ms den az surdu");
            }

        }
    }
}
