using ICar.Infrastructure.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ICar.Infrastructure.Database.Configurations
{
    public sealed class LoginConfiguration : IEntityTypeConfiguration<Login>
    {
        public LoginConfiguration()
        { }

        public void Configure(EntityTypeBuilder<Login> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnType("INT")
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Time)
                .HasColumnType("DATETIME")
                .IsRequired();
        }
    }
}
