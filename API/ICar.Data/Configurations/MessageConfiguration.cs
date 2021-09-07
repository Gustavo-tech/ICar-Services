using ICar.Infrastructure.Models;
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
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Text)
                .IsRequired()
                .HasMaxLength(120);

            builder.HasOne(x => x.ToUser)
                .WithMany(x => x.MessagesReceived);

            builder.HasOne(x => x.FromUser)
                .WithMany(x => x.MessagesSent);

            builder.Property(x => x.SendAt)
                .IsRequired();
        }
    }
}
