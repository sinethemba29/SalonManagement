using System;
using System.Collections.Generic;
using System.Text;

namespace SalonManagement.Domain
{
    public class Service
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Decimal Price { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;

        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    }
}
