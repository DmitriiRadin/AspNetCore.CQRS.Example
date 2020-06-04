using System;

namespace Domain.Entities
{
    public class OrderItem
    {
        public Guid Id { get; set; }

        public int CountOfProducts { get; set; }

        public Order Order { get; set; }
        public Product Product { get; set; }

        #region ForEF

        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }

        #endregion
    }
}