using ICar.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ICar.Infrastructure.Configurations
{
    public sealed class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public CompanyConfiguration()
        { }

        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.HasKey(x => x.Cnpj);

            builder.Property(x => x.Cnpj)
                .HasColumnType("NVARCHAR")
                .HasMaxLength(18);

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

            builder.Ignore(x => x.Cities);

            builder.HasMany(x => x.Cars)
                .WithOne()
                .HasForeignKey(x => x.Discriminator);

            builder.HasMany(x => x.News)
                .WithOne()
                .HasForeignKey(x => x.Discriminator);

            builder.HasMany(x => x.Logins)
                .WithOne()
                .HasForeignKey(x => x.Discriminator);
        }
    }
}
