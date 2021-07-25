using ICar.Infrastructure.Database.Configurations;
using ICar.Infrastructure.Database.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ICar.Infrastructure.Database
{
    public class ICarContext : IdentityDbContext<User>
    {
        public ICarContext(DbContextOptions<ICarContext> options) : base(options)
        {
            
        }

        public DbSet<Login> Logins { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<City> Cities { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new NewsConfiguration());
            builder.ApplyConfiguration(new CityConfiguration());
            builder.ApplyConfiguration(new CarConfiguration());
            builder.ApplyConfiguration(new LoginConfiguration());
        }
    }
}
