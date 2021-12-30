using ICar.Infrastructure.Database;
using ICar.Infrastructure.Database.Repositories;
using ICar.Infrastructure.Database.Repositories.Interfaces;
using ICar.Infrastructure.Repositories;
using ICar.Infrastructure.Repositories.Interfaces;
using ICar.Infrastructure.Storage;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Identity.Web;
using Microsoft.IdentityModel.Logging;
using System.Text;

namespace ICar.API
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
            IdentityModelEventSource.ShowPII = true;

            services.AddControllers()
                .AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            // Dependency injection
            services.AddTransient<INewsRepository, NewsRepository>();
            services.AddTransient<ICarRepository, CarRepository>();
            services.AddTransient<IMessageRepository, MessageRepository>();
            services.AddTransient<IBaseRepository, BaseRepository>();
            services.AddTransient<IContactRepository, ContactRepository>();
            services.AddTransient<IStorageService, AzureStorageService>();

            // Entity Framework
            services.AddDbContext<ICarContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("SqlServer"));
            });

            // JWT
            byte[] key = Encoding.ASCII.GetBytes(Configuration["JwtKey"]);
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddMicrosoftIdentityWebApi(Configuration, "AzureAdB2C");
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseCors(options =>
            {
                options.WithMethods("GET", "POST", "PUT", "DELETE");
                options.AllowAnyOrigin();
                options.AllowAnyHeader();
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
