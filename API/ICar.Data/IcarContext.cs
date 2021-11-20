using ICar.Infrastructure.Configurations;
using ICar.Infrastructure.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ICar.Infrastructure.Database
{
    public class ICarContext : IdentityDbContext<User>
    {
        public ICarContext(DbContextOptions<ICarContext> options) 
            : base(options)
        {
            
        }

        public DbSet<Login> Logins { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Address> Addresses { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new NewsConfiguration());
            builder.ApplyConfiguration(new MessageConfiguration());
            //builder.ApplyConfiguration(new CityConfiguration());
            builder.ApplyConfiguration(new CarConfiguration());
            builder.ApplyConfiguration(new LoginConfiguration());
        }
    }
}
