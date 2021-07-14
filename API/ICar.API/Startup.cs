using ICar.Infrastructure.Database;
using ICar.Infrastructure.Database.Repositories;
using ICar.Infrastructure.Database.Repositories.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
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
            services.AddControllers()
                .AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ICar.API", Version = "v1" });
            });

            // Dependency injection
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<INewsRepository, NewsRepository>();
            services.AddScoped<ICarRepository, CarRepository>();
            services.AddScoped<ILoginRepository, LoginRepository>();
            services.AddScoped<ICityRepository, CityRepository>();
            services.AddScoped<IBaseRepository, BaseRepository>();

            // Entity Framework
            services.AddDbContext<ICarContext>(options =>
            {
                options.UseSqlServer(Configuration["DatabaseConnectionString"]);
            });

            // JWT
            byte[] key = Encoding.ASCII.GetBytes(Configuration["JwtKey"]);
            services.AddAuthentication("Bearer")
                .AddJwtBearer("Bearer", config =>
                {
                    config.Authority = "https://localhost:5002";
                    config.Audience = "Api";
                    config.RequireHttpsMetadata = false;
                    config.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateAudience = false
                    };
                });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ICar.API v1"));
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseCors(options =>
            {
                options.WithMethods("GET", "POST", "PUT", "DELETE");
                options.WithOrigins("http://localhost:3000");
                options.AllowAnyHeader();
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
