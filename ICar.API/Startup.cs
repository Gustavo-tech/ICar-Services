using ICar.API.Auth;
using ICar.API.Auth.Contracts;
using ICar.Data;
using ICar.Data.Models.Entities.Cars;
using ICar.Data.Models.Entities.News;
using ICar.Data.Repositories.Accounts;
using ICar.Data.Repositories.Cars;
using ICar.Data.Repositories.Interfaces;
using ICar.Data.Repositories.Interfaces.Accounts;
using ICar.Data.Repositories.News;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
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
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ICar.API", Version = "v1" });
            });

            // Dependency injection
            services.AddScoped<IAuthService, JwtService>();
            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<INewsRepository<UserNews>, UserNewsRepository>();
            services.AddScoped<INewsRepository<CompanyNews>, CompanyNewsRepository>();

            services.AddScoped<ICarRepository<UserCar>, UserCarRepository>();
            services.AddScoped<ICarRepository<CompanyCar>, CompanyCarRepository>();

            // Entity Framework
            services.AddDbContext<DatabaseContext>(options =>
            {
                options.UseSqlServer(Configuration["DatabaseConnectionString"]);
            });

            // JWT
            byte[] key = Encoding.ASCII.GetBytes(Secret.key);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = ValidationParametersGenerator.GenerateTokenValidationParameters();
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
            app.UseAuthorization();
            app.UseAuthentication();

            app.UseCors(options =>
            {
                options.WithMethods("GET", "POST", "PUT", "DELETE");
                options.WithOrigins("https://localhost:3000");
                options.AllowAnyHeader();
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
