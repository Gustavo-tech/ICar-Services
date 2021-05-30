using ICar.Data.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ICar.Infrastructure.Configurations
{
    public sealed class CarImageConfiguration : IEntityTypeConfiguration<CarImage>
    {
        public CarImageConfiguration()
        { }

        public void Configure(EntityTypeBuilder<CarImage> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("INT");

            builder.Property(x => x.ImageStream)
                .IsRequired()
                .HasColumnType("NVARCHAR");
        }
    }
}
