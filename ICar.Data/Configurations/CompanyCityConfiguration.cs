using ICar.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ICar.Infrastructure.Configurations
{
    public class CompanyCityConfiguration : IEntityTypeConfiguration<CompanyCity>
    {
        public void Configure(EntityTypeBuilder<CompanyCity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.HasIndex(x => x.CompanyCnpj);
            builder.HasIndex(x => x.CityId);

            builder.HasOne(x => x.Company)
                .WithMany()
                .HasForeignKey(x => x.CompanyCnpj);

            builder.HasOne(x => x.City)
                .WithMany()
                .HasForeignKey(x => x.CityId);
        }
    }
}
