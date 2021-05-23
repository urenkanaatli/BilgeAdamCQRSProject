using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankAppXX.Web.Middlewares
{
    public class ExceptionMiddleWare
    {
        private readonly RequestDelegate next;

        public ExceptionMiddleWare(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            //işlemlerim
            try
            {
                await next(httpContext);

            }
            catch (Exception ex)
            {

                //hatayı db ye yada bır dosyaya kaydedebilirlirim.
                await httpContext.Response.WriteAsync(ex.ToString());

            }

        }



    }
}
