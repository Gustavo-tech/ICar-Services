using ICar.Data.Models.Entities;
using ICar.Data.Models.Entities.Accounts;
using ICar.Data.Models.Entities.Cars;
using ICar.Data.Models.Entities.Logins;
using ICar.Data.Models.Entities.News;
using ICar.Infrastructure.Configurations;
using ICar.Infrastructure.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace ICar.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        { }

        public DbSet<User> Users { get; set; }
        public DbSet<UserCar> UserCars { get; set; }
        public DbSet<UserLogin> UserLogins { get; set; }
        public DbSet<UserNews> UserNews { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<CompanyCar> CompanyCars { get; set; }
        public DbSet<CompanyLogin> CompanyLogins { get; set; }
        public DbSet<CompanyNews> CompanyNews { get; set; }
        public DbSet<CompanyCity> CompanyCities { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<CarImage> CarImages { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // company
            builder.ApplyConfiguration(new CompanyConfiguration());
            builder.ApplyConfiguration(new CompanyCarConfiguration());
            builder.ApplyConfiguration(new CompanyNewsConfiguration());
            builder.ApplyConfiguration(new CompanyLoginConfiguration());
            builder.ApplyConfiguration(new CompanyCityConfiguration());

            // user
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new UserCarConfiguration());
            builder.ApplyConfiguration(new UserNewsConfiguration());
            builder.ApplyConfiguration(new UserLoginConfiguration());


            builder.ApplyConfiguration(new CityConfiguration());
            builder.ApplyConfiguration(new CarImageConfiguration());
        }
    }
}
