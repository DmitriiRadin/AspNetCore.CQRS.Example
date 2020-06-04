using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations
{
    public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.Property(p => p.CountOfProducts).IsRequired();

            builder
                .HasOne(p => p.Order)
                .WithMany(p => p.Items)
                .HasForeignKey(p => p.OrderId)
                .IsRequired();

            builder
                .HasOne(p => p.Product)
                .WithMany(p => p.OrderItems)
                .HasForeignKey(p => p.ProductId)
                .IsRequired();

            builder.HasIndex(p => new {p.OrderId, p.ProductId}).IsUnique();
        }
    }
}