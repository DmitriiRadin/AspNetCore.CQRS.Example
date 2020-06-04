using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Order
    {
        public Guid Id { get; set; }

        public IEnumerable<OrderItem> Items { get; set; }
        public OrderStatus Status { get; set; }

        public DateTime? InitialDate { get; set; }
        public DateTime? FinishedDate { get; set; }

        public Customer Customer { get; set; }
    }
}