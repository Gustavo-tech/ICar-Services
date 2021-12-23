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
                .IsRequired()
                .HasMaxLength(120);

            builder.HasOne(x => x.ToUser)
                .WithMany();

            builder.HasOne(x => x.FromUser)
                .WithMany();

            builder.Property(x => x.SentAt)
                .IsRequired();
        }
    }
}