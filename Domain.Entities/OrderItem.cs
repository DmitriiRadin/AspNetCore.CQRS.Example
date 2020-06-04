using System;

namespace Domain.Entities
{
    public class OrderItem
    {
        public Guid Id { get; set; }

        public Order Order { get; set; }
        public Product Product { get; set; }
    }
}