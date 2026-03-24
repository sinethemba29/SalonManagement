using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntentionsTracker.Domain
{
    public class Intentions
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; } // Description can be optional
        public DateTime DateCreated { get; set; }
       // public bool IsCompleted { get; set; }
    }
}
