using ICar.Infrastructure.Database;
using ICar.Infrastructure.Database.Models;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ICar.IdentityServer
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

            services.AddSingleton<ICorsPolicyService>((container) =>
            {
                var logger = container.GetRequiredService<ILogger<DefaultCorsPolicyService>>();
                return new DefaultCorsPolicyService(logger)
                {
                    AllowedOrigins = { "http://localhost:3000" }
                };
            });

            services.AddDbContext<ICarContext>(options =>
            {
                options.UseSqlServer(Configuration["DatabaseConnectionString"],
                    x => x.MigrationsAssembly("ICar.IdentityServer"));
            });

            services.AddIdentity<User, IdentityRole>(x =>
            {
                x.Password.RequireDigit = false;
                x.Password.RequireLowercase = false;
                x.Password.RequireUppercase = false;
                x.SignIn.RequireConfirmedEmail = false;
                x.SignIn.RequireConfirmedPhoneNumber = false;
                x.SignIn.RequireConfirmedAccount = false;
            })
                .AddEntityFrameworkStores<ICarContext>()
                .AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(config =>
            {
                config.Cookie.Name = "identity.cookie";
                config.Cookie.IsEssential = true;
                config.LoginPath = "/auth/login";
                config.LogoutPath = "/auth/logout";
            });

            services.AddIdentityServer()
            .AddAspNetIdentity<User>()
            .AddDeveloperSigningCredential()
            .AddInMemoryApiScopes(ServerConfiguration.ApiScopes)
            .AddInMemoryClients(ServerConfiguration.Clients)
            .AddInMemoryIdentityResources(ServerConfiguration.IdentityResources);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseIdentityServer();
            app.UseStaticFiles();
            app.UseCors(x =>
            {
                x.AllowAnyMethod();
                x.AllowAnyOrigin();
                x.AllowAnyHeader();
            });

            app.UseCookiePolicy();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
