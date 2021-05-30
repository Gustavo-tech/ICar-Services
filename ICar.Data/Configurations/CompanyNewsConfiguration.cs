using ICar.Data.Models.Entities.Accounts;
using ICar.Data.Models.Entities.News;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICar.Infrastructure.Configurations
{
    public sealed class CompanyNewsConfiguration : IEntityTypeConfiguration<CompanyNews>
    {
        public CompanyNewsConfiguration()
        { }

        public void Configure(EntityTypeBuilder<CompanyNews> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnType("INT")
                .ValueGeneratedOnAdd();

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
                .HasMaxLength(20);

            builder.HasOne<Company>()
                .WithMany(x => x.CompanyNews)
                .HasForeignKey(x => x.CompanyCnpj);
        }
    }
}
