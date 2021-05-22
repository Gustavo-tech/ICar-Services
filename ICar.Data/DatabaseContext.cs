using ICar.Data.Models.Entities;
using ICar.Data.Models.Entities.Accounts;
using ICar.Data.Models.Entities.Cars;
using ICar.Data.Models.Entities.Logins;
using ICar.Data.Models.Entities.News;
using Microsoft.EntityFrameworkCore;

namespace ICar.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        { }

        public DbSet<UserCar> UserCars { get; set; }
        public DbSet<CompanyCar> CompanyCars { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<UserNews> UserNews { get; set; }
        public DbSet<CompanyNews> CompanyNews { get; set; }
        public DbSet<IUserLoginRepository> UserLogins { get; set; }
        public DbSet<CompanyLogin> CompanyLogins { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
