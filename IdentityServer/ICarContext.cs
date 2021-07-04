using ICar.IdentityServer.Models;
using Microsoft.EntityFrameworkCore;

namespace IdentityServer
{
    public class ICarContext : DbContext
    {
        public ICarContext(DbContextOptions options) : base(options)
        { }

        public DbSet<User> Users { get; set; }
    }
}
