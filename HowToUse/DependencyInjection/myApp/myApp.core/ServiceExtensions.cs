using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myApp.core
{
    public static class ServiceExtensions
    {
        public static IServiceCollection RegisterServices(
           this IServiceCollection services)
        {
            services.AddTransient<ITopicAreaService, TopicAreaService>();
            // Add all other services here.
            return services;
        }
    }
}
