using ICar.Infrastructure.Models;
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
                .HasMaxLength(55);
        }
    }
}
