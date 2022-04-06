using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomMiddleware.mymiddlewares
{
  
    public static class MyMiddlewareExtensions
    {

        public static IApplicationBuilder UseMyMiddleware1(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MyMiddleware1>();
        }

        public static IApplicationBuilder UseMyMiddleware2(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MyMiddleware2>();
        }
    }
}
