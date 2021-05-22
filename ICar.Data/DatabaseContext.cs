using ICar.Data.Models.Entities;
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
        public DbSet<News> News { get; set; }
        public User User { get; set; }
    }
}
