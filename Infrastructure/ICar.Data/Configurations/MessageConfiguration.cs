﻿using ICar.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ICar.Infrastructure.Configurations
{
    class MessageConfiguration : IEntityTypeConfiguration<Message>
    {
        public MessageConfiguration()
        {
        }

        public void Configure(EntityTypeBuilder<Message> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnType("VARCHAR");

            builder.Property(x => x.Text)
                .HasMaxLength(120)
                .IsRequired();

            builder.Property(x => x.SentAt)
                .IsRequired();

            builder.Property(x => x.ToUser)
                .HasColumnType("CHAR(36)")
                .IsRequired();

            builder.Property(x => x.FromUser)
                .HasColumnType("CHAR(36)")
                .IsRequired();
        }
    }
}
