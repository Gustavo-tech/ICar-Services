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
            builder.HasKey(x => x.Email);

            builder.Ignore(x => x.Id);

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
                .WithOne(x => x.Owner);

            builder.HasMany(x => x.News)
                .WithOne(x => x.Owner);

            builder.HasMany(x => x.Logins)
                .WithOne(x => x.User);
        }
    }
}
