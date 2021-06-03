﻿using ICar.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ICar.Infrastructure.Configurations
{
    public sealed class UserNewsConfiguration : IEntityTypeConfiguration<UserNews>
    {
        public UserNewsConfiguration()
        { }

        public void Configure(EntityTypeBuilder<UserNews> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnType("INT")
                .ValueGeneratedOnAdd();

            builder.Property(x => x.LastUpdate)
                .HasColumnType("DATETIME")
                .IsRequired();

            builder.Property(x => x.CreatedOn)
                .HasColumnType("DATETIME")
                .IsRequired();

            builder.Property(x => x.Text)
                .HasColumnType("NVARCHAR")
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(x => x.Title)
                .HasColumnType("NVARCHAR")
                .IsRequired()
                .HasMaxLength(20);
        }
    }
}
