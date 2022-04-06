using ImageWatermark.DataLayer;
using ImageWatermark.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UdemyRabbitMQWeb.Watermark.BackgroundServices;

namespace ImageWatermark
{
    public class Startup
    {
    

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                
                options.UseMySql(
                    "server=localhost;port=3306;database=ImageDb;user=root;password=nyks6957!",
                    ServerVersion.AutoDetect("server=localhost;port=3306;database=ImageDb;user=root;password=nyks6957!")
                    );
            });

            services.AddSingleton(serviceProvider =>
            new ConnectionFactory()
            {
                Uri = new Uri("amqps://qyqyrpba:tXOh9cV7AEXOGxx_r4o5dteyLk-M0Wh5@fish.rmq.cloudamqp.com/qyqyrpba"),
                //asenkron method kullandığımızdan dolayı
                DispatchConsumersAsync = true
            }
            );
            services.AddSingleton<RabbitMQService>();
            services.AddSingleton<Producer>();
            services.AddHostedService<Consumer>();
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
