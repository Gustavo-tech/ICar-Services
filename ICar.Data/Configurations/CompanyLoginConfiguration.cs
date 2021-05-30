using ICar.Data.Models.Entities.Accounts;
using ICar.Data.Models.Entities.Logins;
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

            builder.HasOne<Company>()
                .WithMany(x => x.CompanyLogins)
                .HasForeignKey(x => x.CompanyCnpj);
        }
    }
}
