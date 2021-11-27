using ICar.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ICar.Infrastructure.Configurations
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.ZipCode)
                .HasColumnType("VARCHAR(8)");

            builder.Property(x => x.Location)
                .HasColumnType("VARCHAR(60)");

            builder.Property(x => x.Street)
                .HasColumnType("VARCHAR(100)");

            builder.Property(x => x.District)
                .HasColumnType("VARCHAR(100)");
        }
    }
}
