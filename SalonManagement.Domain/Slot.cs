using System;
using System.Collections.Generic;
using System.Text;

namespace SalonManagement.Domain
{
    public class Slot
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime SlotTime { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    }
}
