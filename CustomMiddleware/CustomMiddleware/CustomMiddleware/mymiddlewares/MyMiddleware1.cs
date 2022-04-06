using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomMiddleware.mymiddlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class MyMiddleware1
    {
        private readonly RequestDelegate next;

        public MyMiddleware1(RequestDelegate next)
        {
            this.next = next;

        }




        public async Task Invoke(HttpContext httpContext)
        {

            if (httpContext.Request.Path == "/topla")
            {
                var value1 = httpContext.Request.Query["sayi1"];
                var sayi1 = Convert.ToInt32(value1);
                var value2 = httpContext.Request.Query["sayi2"];
                var sayi2 = Convert.ToInt32(value2);


                await httpContext.Response.WriteAsync($"Toplam {sayi1 + sayi2} ");

            }
            else
            {
                await next(httpContext);
            }


        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
}
