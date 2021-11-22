using ICar.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ICar.Infrastructure.Configurations
{
    public sealed class LoginConfiguration : IEntityTypeConfiguration<Login>
    {
        public LoginConfiguration()
        { }

        public void Configure(EntityTypeBuilder<Login> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnType("VARCHAR");

            builder.Property(x => x.Time)
                .HasColumnType("DATETIME")
                .IsRequired();

            builder.Property(x => x.Success)
                .IsRequired();
        }
    }
}
