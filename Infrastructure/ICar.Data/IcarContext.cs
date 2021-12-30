using ICar.Infrastructure.Configurations;
using ICar.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace ICar.Infrastructure.Database
{
    public class ICarContext : DbContext
    {
        public ICarContext(DbContextOptions<ICarContext> options)
            : base(options)
        {

        }

        public DbSet<Message> Messages { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Interaction> Interactions { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new NewsConfiguration());
            builder.ApplyConfiguration(new MessageConfiguration());
            builder.ApplyConfiguration(new AddressConfiguration());
            builder.ApplyConfiguration(new CarConfiguration());
            builder.ApplyConfiguration(new ContactConfiguration());
            builder.ApplyConfiguration(new InteractionConfiguration());
        }
    }
}
