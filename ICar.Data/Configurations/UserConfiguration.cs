using ICar.Data.Models.Entities.Accounts;
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

            builder.HasMany(x => x.UserCars)
                .WithOne(x => x.User);

            builder.HasOne(x => x.City)
                .WithOne()
                .HasForeignKey<User>(x => x.CityId);

            builder.HasMany(x => x.UserNews)
                .WithOne(x => x.PublishedBy);

            builder.HasMany(x => x.UserLogins)
                .WithOne(x => x.User);
        }
    }
}
