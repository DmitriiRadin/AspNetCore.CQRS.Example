using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.Property(p => p.Text).IsRequired();

            builder
                .HasOne(p => p.Product)
                .WithMany(p => p.Comments)
                .IsRequired();

            builder
                .HasOne(p => p.Customer)
                .WithMany(p => p.Comments)
                .IsRequired();
        }
    }
}