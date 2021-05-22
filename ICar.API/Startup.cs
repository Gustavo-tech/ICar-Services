using ICar.API.Auth;
using ICar.API.Auth.Contracts;
using ICar.Data;
using ICar.Data.Queries;
using ICar.Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
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
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ICar API", Version = "v1" });
            });

            // Interface implementations
            services.AddScoped<ICompanyRepository, CompanyQueries>();
            services.AddScoped<IUserRepository, UserQueries>();
            services.AddScoped<IAuthService, JwtService>();
            services.AddScoped<INewsRepository, NewsQueries>();
            services.AddScoped<ICarRepository, CarQuery>();

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
                DataInjector.InsertInitialData();
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
