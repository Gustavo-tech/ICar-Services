using ICar.IdentityServer.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace IdentityServer
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddDbContext<ICarContext>(options =>
            {
                options.UseSqlServer(Configuration["DatabaseConnectionString"]);
            });

            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<ICarContext>()
                .AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(config =>
            {
                config.Cookie.Name = "identity.cookie";
                config.LoginPath = "/Authentication/Login";
                config.LogoutPath = "/Authentication/Logout";
            });

            services.AddIdentityServer()
            .AddDeveloperSigningCredential()
            .AddInMemoryApiResources(ServerConfiguration.ApiResources)
            .AddInMemoryClients(ServerConfiguration.Clients);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseRouting();
            app.UseIdentityServer();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
