using ICar.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ICar.Infrastructure.Configurations
{
    public sealed class CompanyLoginConfiguration : IEntityTypeConfiguration<CompanyLogin>
    {
        public CompanyLoginConfiguration()
        { }

        public void Configure(EntityTypeBuilder<CompanyLogin> builder)
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
