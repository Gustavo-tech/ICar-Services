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
                .HasColumnType("VARCHAR");

            builder.Property(x => x.Plate)
                .HasColumnType("Char(8)");

            builder.Property(x => x.Maker)
                .HasColumnType("VARCHAR")
                .IsRequired()
                .HasMaxLength(60);

            builder.Property(x => x.Model)
                .HasColumnType("VARCHAR")
                .IsRequired()
                .HasMaxLength(60);

            builder.Property(x => x.MakeDate)
                .HasColumnType("INT")
                .IsRequired();

            builder.Property(x => x.MakedDate)
                .HasColumnType("INT")
                .IsRequired();

            builder.Property(x => x.Price)
                .HasColumnType("INT")
                .IsRequired()
                .HasMaxLength(10000000);

            builder.Property(x => x.Message)
                .HasColumnType("VARCHAR")
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(x => x.Color)
                .HasColumnType("VARCHAR")
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.GasolineType)
                .HasColumnType("VARCHAR")
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(x => x.NumberOfViews)
                .HasColumnType("INT")
                .IsRequired();

            builder.HasOne(x => x.City);

            builder.HasMany(x => x.Pictures)
                .WithOne(x => x.Car);
        }
    }
}
