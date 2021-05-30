using ICar.Infrastructure.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                .WithMany(x => x.Cities);

            builder.HasOne(x => x.City)
                .WithOne()
                .HasForeignKey<CompanyCity>(x => x.CityId);
        }
    }
}
