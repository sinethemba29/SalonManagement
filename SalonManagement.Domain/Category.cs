using System;
using System.Collections.Generic;
using System.Text;

namespace SalonManagement.Domain
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        // Navigation: services that belong to this category (e.g. "Ladies", "Gentlemen")
        public ICollection<Service> Services { get; set; } = new List<Service>();

    }
}
