using ICar.Data.Models.Entities;
using ICar.Data.Models.Entities.Accounts;
using ICar.Data.Models.Entities.Cars;
using ICar.Data.Models.Entities.Logins;
using ICar.Data.Models.Entities.News;
using ICar.Infrastructure.Models.Entities;
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

            builder.HasMany<City>()
                .WithOne()
                .HasForeignKey(x => x.CompanyCnpj);

            builder.HasMany<CompanyCar>()
                .WithOne(x => x.Company)
                .HasForeignKey(x => x.CompanyCnpj);

            builder.HasMany<CompanyNews>()
                .WithOne(x => x.PublishedBy)
                .HasForeignKey(x => x.CompanyCnpj);

            builder.HasMany<CompanyLogin>()
                .WithOne(x => x.Company)
                .HasForeignKey(x => x.CompanyCnpj);
        }
    }
}
