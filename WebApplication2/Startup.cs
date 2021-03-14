using batuaShop.Data;
using batuaShop.Data.Interfaces;
using batuaShop.Data.Models;
using batuaShop.Data.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebApplication2.Data;
using WebApplication2.Data.Interfaces;

namespace WebApplication2
{
    public class Startup
    {

        private IConfigurationRoot confString;

        public Startup(IHostingEnvironment env)
        {
            confString = new ConfigurationBuilder().SetBasePath(env.ContentRootPath).AddJsonFile("dbsettings.json").Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContent>(options => options.UseSqlServer(confString.GetConnectionString("DefaultConnection")));

            services.AddTransient<IAllBooks, BookRepository>();
            services.AddTransient<IBookCategory, CategoryRepository>();
            services.AddTransient<IAllOrders, OrdersRepository>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped(sp => ShopCart.GetCart(sp));

            services.AddMvc();

            services.AddMemoryCache();
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePagesWithRedirects("/Error/{0}");
            app.UseStaticFiles();
            app.UseSession();
            //app.UseMvcWithDefaultRoute();
            app.UseMvc(routes =>
            {
                routes.MapRoute(name: "default", template:"{controller=Home}/{action=Index}/{id?}");
                routes.MapRoute(name: "categories", template:"Books/{action}/{category?}", defaults: new { Controllers = "Books", action= "List" });
            });

            AppDbContent content;
            using (var scope = app.ApplicationServices.CreateScope())
            {
                content = scope.ServiceProvider.GetRequiredService<AppDbContent>();
                DbObjects.Initial(content);        
            }
        }
    }
}
