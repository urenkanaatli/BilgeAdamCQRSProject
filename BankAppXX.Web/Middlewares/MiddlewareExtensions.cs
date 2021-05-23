using BankAppXX.Web.Middlewares;
using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.AspNetCore.Builder
{
    public static class MiddlewareExtensions
    {

        public static IApplicationBuilder UsePerformanceMiddleWare(this IApplicationBuilder builder)
        {


            return builder.UseMiddleware<PerformanceMiddleware>();
        }

        public static IApplicationBuilder UseExceptionMiddleWare(this IApplicationBuilder builder)
        {


         return   builder.UseMiddleware<ExceptionMiddleWare>();
        }
    }
}
