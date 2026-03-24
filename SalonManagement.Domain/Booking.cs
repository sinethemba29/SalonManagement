using System;
using System.Collections.Generic;
using System.Text;

namespace SalonManagement.Domain
{
    public class Booking
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int ServiceId { get; set; }
        public Service Service { get; set; }
        public int SlotId { get; set; }
        public Slot Slot { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
