using ICar.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICar.Infrastructure.Configurations
{
    public class InteractionConfiguration : IEntityTypeConfiguration<Interaction>
    {
        public void Configure(EntityTypeBuilder<Interaction> builder)
        {
            builder.HasNoKey();

            builder.Property(x => x.UserId)
                .HasColumnType("CHAR(36)")
                .IsRequired();

            builder.Property(x => x.WithUserId)
                .HasColumnType("CHAR(36)")
                .IsRequired();

            builder.Property(x => x.UserNickname)
                .HasMaxLength(60)
                .IsRequired();

            builder.Property(x => x.SubjectId)
                .HasColumnType("CHAR(36)")
                .IsRequired();
        }
    }
}
