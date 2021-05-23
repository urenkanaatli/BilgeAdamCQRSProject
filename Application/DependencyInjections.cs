using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using System.Reflection;
using FluentValidation;
using Application.Common;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DependencyInjections
    {

        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddMediatR(Assembly.GetExecutingAssembly());



            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(PeformancePipeline<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ApplicationAuthorizePipiline<,>));

          
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationPipleLine<,>));


            return services;
        }
    }
}
