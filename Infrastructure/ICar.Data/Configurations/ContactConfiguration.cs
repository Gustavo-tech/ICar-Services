﻿using ICar.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ICar.Infrastructure.Configurations
{
    public class ContactConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.HasKey(x => x.UserObjectId);

            builder.Property(x => x.FirstName)
                .HasMaxLength(60)
                .IsRequired();
            
            builder.Property(x => x.LastName)
                .HasMaxLength(60)
                .IsRequired();

            builder.Property(x => x.PhoneNumber)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.UserObjectId)
                .HasColumnType("CHAR(36)")
                .IsRequired();
        }
    }
}
