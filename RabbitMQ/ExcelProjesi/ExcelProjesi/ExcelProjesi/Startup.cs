using ExcelProjesi.Data;
using ExcelProjesi.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UdemRabbitMQWeb.ExcelCreate.Services;

namespace ExcelProjesi
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
            services.AddControllersWithViews();

            services.AddDbContext<ApplicationContext>(opt => opt.UseMySql("server=localhost;port=3306;database=ExcelProjesiDB;user=root;password=nyks6957!",
                ServerVersion.AutoDetect("server=localhost;port=3306;database=ExcelProjesiDB;user=root;password=nyks6957!"))
            );

            services.AddIdentity<AppUser, IdentityRole<int>>(options =>
             {
                 options.SignIn.RequireConfirmedEmail = false;
                 options.SignIn.RequireConfirmedPhoneNumber = false;
             }
           ).AddEntityFrameworkStores<ApplicationContext>()
               .AddDefaultTokenProviders();

            services.AddAuthentication();
            services.AddAuthorization();
            /**----------------------------------**/

            services.AddSingleton(serviceProvider =>
           new ConnectionFactory()
           {
               Uri = new Uri("amqps://qyqyrpba:tXOh9cV7AEXOGxx_r4o5dteyLk-M0Wh5@fish.rmq.cloudamqp.com/qyqyrpba"),
               //asenkron method kullandığımızdan dolayı
               DispatchConsumersAsync = true
           });
            services.AddSingleton<RabbitMQClientService>();
           services.AddSingleton<Publisher>();
            // services.AddHostedService<Consumer>();
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

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
