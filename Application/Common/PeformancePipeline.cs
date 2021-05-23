using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System.Reflection;

namespace Application.Common
{
    public class PeformancePipeline<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly ILogger<PeformancePipeline<TRequest, TResponse>> logger;

        public PeformancePipeline(ILogger<PeformancePipeline<TRequest, TResponse>> logger)
        {
            this.logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {

            Performance performance = request.GetType().GetCustomAttribute<Performance>();

            int defaultDuration = 300;
            
            if(performance!=null)
            {
                defaultDuration = performance.Duration;

            }
                
           
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            var requestDelegate = await next();


            stopwatch.Stop();

            if (stopwatch.ElapsedMilliseconds > defaultDuration)
            {
                logger.LogInformation("ilgili islem 300 ms den cok surdu");
            }
            else
            {

                logger.LogInformation("ilgili islem 300 ms den az surdu");
            }

            return requestDelegate;

        }
    }
}
