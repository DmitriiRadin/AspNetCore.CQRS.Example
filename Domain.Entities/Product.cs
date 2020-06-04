using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Product
    {
        public Guid Id { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }

        public IEnumerable<OrderItem> OrderItems { get; set; }
        public IEnumerable<Comment> Comments { get; set; }
    }
}