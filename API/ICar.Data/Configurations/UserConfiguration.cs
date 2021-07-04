using ICar.Infrastructure.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ICar.Infrastructure.Database.Configurations
{
    public sealed class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public UserConfiguration()
        { }

        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Cpf);

            builder.Property(x => x.Cpf)
                .HasColumnType("NVARCHAR")
                .HasMaxLength(18);

            builder.Property(x => x.Email)
                .IsRequired()
                .HasColumnType("NVARCHAR")
                .HasMaxLength(320);

            builder.Property(x => x.AccountCreationDate)
                .IsRequired()
                .HasColumnType("DATETIME");

            builder.Property(x => x.Role)
                .IsRequired()
                .HasColumnType("NVARCHAR")
                .HasMaxLength(30);

            builder.HasMany(x => x.Cars)
                .WithOne();

            builder.HasMany(x => x.News)
                .WithOne();

            builder.HasMany(x => x.Logins)
                .WithOne();
        }
    }
}
