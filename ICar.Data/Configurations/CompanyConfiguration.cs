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
                .HasColumnType("CHAR(18)");

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

            builder.HasMany(x => x.CompanyCars)
                .WithOne(x => x.Company);

            builder.HasMany(x => x.CompanyNews)
                .WithOne(x => x.PublishedBy);

            builder.HasMany(x => x.CompanyLogins)
                .WithOne(x => x.Company);
        }
    }
}
