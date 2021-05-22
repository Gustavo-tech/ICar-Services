using ICar.Data.Models.Entities;
using ICar.Data.Models.Entities.Accounts;
using ICar.Data.Models.Entities.Logins;
using ICar.Data.Models.Entities.News;
using Microsoft.EntityFrameworkCore;

namespace ICar.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        { }

        public DbSet<Car> Cars { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<UserNews> UserNews { get; set; }
        public DbSet<CompanyNews> CompanyNews { get; set; }
        public DbSet<UserLogin> UserLogins { get; set; }
        public DbSet<CompanyLogin> CompanyLogins { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
