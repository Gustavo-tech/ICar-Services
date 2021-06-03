using ICar.Infrastructure.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ICar.Infrastructure.Configurations
{
    public class CompanyCityConfiguration : IEntityTypeConfiguration<CompanyCity>
    {
        public void Configure(EntityTypeBuilder<CompanyCity> builder)
        {
            builder.HasKey(x => new { x.CompanyCnpj, x.CityId });
            builder.HasIndex(x => x.CompanyCnpj);
            builder.HasIndex(x => x.CityId);

            builder.HasOne(x => x.Company)
                .WithOne()
                .HasForeignKey<CompanyCity>(x => x.CompanyCnpj);

            builder.HasOne(x => x.City)
                .WithOne()
                .HasForeignKey<CompanyCity>(x => x.CityId);
        }
    }
}
