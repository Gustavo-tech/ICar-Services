﻿using ICar.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ICar.Infrastructure.Configurations
{
    public sealed class NewsConfiguration : IEntityTypeConfiguration<News>
    {
        public NewsConfiguration()
        { }

        public void Configure(EntityTypeBuilder<News> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnType("VARCHAR")
                .HasMaxLength(50);

            builder.Property(x => x.UpdatedAt)
                .HasColumnType("DATETIME")
                .IsRequired();

            builder.Property(x => x.CreatedAt)
                .HasColumnType("DATETIME")
                .IsRequired();

            builder.Property(x => x.Text)
                .HasColumnType("NVARCHAR(MAX)")
                .IsRequired();

            builder.Property(x => x.Title)
                .HasColumnType("NVARCHAR")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.AuthorId)
                .HasColumnType("CHAR(36)")
                .IsRequired();
        }
    }
}
