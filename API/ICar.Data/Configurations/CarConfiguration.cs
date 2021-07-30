﻿using ICar.Infrastructure.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ICar.Infrastructure.Database.Configurations
{
    public class CarConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.HasKey(x => x.Plate);

            builder.Property(x => x.Plate)
                .HasColumnType("Char(8)");

            builder.Property(x => x.Maker)
                .HasColumnType("NVARCHAR")
                .IsRequired()
                .HasMaxLength(60);

            builder.Property(x => x.Model)
                .HasColumnType("NVARCHAR")
                .IsRequired()
                .HasMaxLength(60);

            builder.Property(x => x.MakeDate)
                .HasColumnType("INT")
                .IsRequired();

            builder.Property(x => x.MakedDate)
                .HasColumnType("INT")
                .IsRequired();

            builder.Property(x => x.Price)
                .HasColumnType("DECIMAL")
                .IsRequired()
                .HasMaxLength(10000000);

            builder.Property(x => x.AcceptsChange)
                .HasColumnType("BIT")
                .IsRequired();

            builder.Property(x => x.IpvaIsPaid)
                .HasColumnType("BIT")
                .IsRequired();

            builder.Property(x => x.IsLicensed)
                .HasColumnType("BIT")
                .IsRequired();

            builder.Property(x => x.IsArmored)
                .HasColumnType("BIT")
                .IsRequired();

            builder.Property(x => x.Message)
                .HasColumnType("NVARCHAR")
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(x => x.TypeOfExchange)
                .HasColumnType("CHAR(3)")
                .IsRequired();

            builder.Property(x => x.Color)
                .HasColumnType("NVARCHAR(50)")
                .IsRequired()
                .HasMaxLength(3);

            builder.Property(x => x.GasolineType)
                .HasColumnType("NVARCHAR")
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
