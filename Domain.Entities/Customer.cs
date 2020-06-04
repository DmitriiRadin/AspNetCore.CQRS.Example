using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Customer
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public DateTime? BirthDay { get; set; }
        public DateTime RegistrationDate { get; set; }

        public IEnumerable<Comment> Comments { get; set; }
    }
}