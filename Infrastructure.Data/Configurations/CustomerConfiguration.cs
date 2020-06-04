using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.Property(p => p.FirstName).IsRequired();
            builder.Property(p => p.LastName).IsRequired();
            builder.Property(p => p.Email).IsRequired();

            builder.Property(p => p.RegistrationDate).IsRequired();

            builder.HasIndex(p => p.PhoneNumber).IsUnique();
            builder.HasIndex(p => p.Email).IsUnique();
        }
    }
}