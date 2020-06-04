using System;

namespace Domain.Entities
{
    public class Comment
    {
        public Guid Id { get; set; }

        public string Text { get; set; }

        public Product Product { get; set; }
        public Customer Customer { get; set; }
    }
}