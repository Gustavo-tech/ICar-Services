using ICar.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ICar.Infrastructure.Configurations
{
    public class CarConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnType("VARCHAR(60)");

            builder.Property(x => x.Plate)
                .HasColumnType("CHAR(8)");

            builder.Property(x => x.Maker)
                .HasColumnType("VARCHAR(60)")
                .HasMaxLength(60)
                .IsRequired();

            builder.Property(x => x.Model)
                .HasColumnType("VARCHAR(60)")
                .HasMaxLength(60)
                .IsRequired();

            builder.Property(x => x.MakeDate)
                .HasColumnType("INT")
                .IsRequired();

            builder.Property(x => x.MakedDate)
                .HasColumnType("INT")
                .IsRequired();

            builder.Property(x => x.Price)
                .HasColumnType("INT")
                .HasMaxLength(10000000)
                .IsRequired();

            builder.Property(x => x.Message)
                .HasColumnType("NVARCHAR")
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(x => x.Color)
                .HasColumnType("VARCHAR(60)")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.GasolineType)
                .HasColumnType("VARCHAR(60)")
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(x => x.NumberOfViews)
                .HasColumnType("INT")
                .IsRequired();

            builder.Property(x => x.OwnerId)
                .HasColumnType("CHAR(36)")
                .IsRequired();

            builder.HasOne(x => x.Address);

            builder.HasMany(x => x.Pictures);
        }
    }
}
