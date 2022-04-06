using libraryapp.dataaccess.Concrete.EfCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using myApp.business.Abstract;
using myApp.business.Concrete;
using myApp.dataaccess.context;
using myApp.dataaccess.Repository;
using myApp.entitiy.IdentityEntities;

namespace myApp.webuı
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
            services.AddSession();


            services.AddDbContext<IdentityContext>();
            services.AddIdentity<User, Role>().AddEntityFrameworkStores<IdentityContext>().AddDefaultTokenProviders();
            services.AddDbContext<LibraryContext>();


            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IBookRepository, EfCoreBookRepository>();



            services.AddRazorPages();
            services.AddControllersWithViews();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                SeedDatabase.SeedLibraryData();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseSession();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
                endpoints.MapControllerRoute(
                    name: "defaultA", pattern: "/session", defaults: new { controller = "Session", action = "index" }
                    );
                endpoints.MapControllerRoute(
                   name: "defaultB", pattern: "/cookie", defaults: new { controller = "cookie", action = "index" }
                   );
            });
        }
    }
}
