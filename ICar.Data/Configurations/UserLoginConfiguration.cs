using ICar.Data.Models.Entities.Logins;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ICar.Infrastructure.Configurations
{
    public sealed class UserLoginConfiguration : IEntityTypeConfiguration<UserLogin>
    {
        public UserLoginConfiguration()
        { }

        public void Configure(EntityTypeBuilder<UserLogin> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnType("INT")
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Time)
                .HasColumnType("DATETIME")
                .IsRequired();
        }
    }
}
