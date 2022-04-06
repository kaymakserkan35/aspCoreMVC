using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomMiddleware.mymiddlewares
{
    public class MyMiddleware2
    {
        private readonly RequestDelegate next;

        public MyMiddleware2(RequestDelegate next)
        {
            this.next = next;

        }


        public async Task Invoke(HttpContext httpContext)
        {
            if (httpContext.Request.Path == "/ekle")
            {
                var value1 = httpContext.Request.Query["word1"];
                var value2 = httpContext.Request.Query["word2"];

                await httpContext.Response.WriteAsync($"Toplam {value1 + value2} ");

            }

            else
            {
                await httpContext.Response.WriteAsync("hiçbir işlem girilmedi");
            }
        }
    }
}