using ICar.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ICar.Infrastructure.Configurations
{
    public sealed class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public UserConfiguration()
        { }

        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Cpf);

            builder.Property(x => x.Cpf)
                .HasColumnType("CHAR")
                .HasMaxLength(14);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasColumnType("NVARCHAR")
                .HasMaxLength(60);

            builder.Property(x => x.Email)
                .IsRequired()
                .HasColumnType("NVARCHAR")
                .HasMaxLength(320);

            builder.Property(x => x.Password)
                .IsRequired()
                .HasColumnType("NVARCHAR")
                .HasMaxLength(60);

            builder.Property(x => x.AccountCreationDate)
                .IsRequired()
                .HasColumnType("DATETIME");

            builder.Property(x => x.Role)
                .IsRequired()
                .HasColumnType("NVARCHAR")
                .HasMaxLength(30);

            builder.HasMany(x => x.Cars)
                .WithOne()
                .HasForeignKey(x => x.Discriminator);

            builder.HasOne(x => x.City)
                .WithOne()
                .HasForeignKey<User>(x => x.CityId);

            builder.HasMany(x => x.News)
                .WithOne()
                .HasForeignKey(x => x.Discriminator);

            builder.HasMany(x => x.Logins)
                .WithOne()
                .HasForeignKey(x => x.Discriminator);
        }
    }
}
