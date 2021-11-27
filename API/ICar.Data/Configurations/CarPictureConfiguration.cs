using ICar.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ICar.Infrastructure.Configurations
{
    public class CarPictureConfiguration : IEntityTypeConfiguration<CarPicture>
    {
        public void Configure(EntityTypeBuilder<CarPicture> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnType("VARCHAR");

            builder.Property(x => x.PictureUrl)
                .IsRequired();
        }
    }
}
