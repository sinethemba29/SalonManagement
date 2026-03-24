using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using SalonManagement.Domain;

namespace SalonManagement.Infrastructure
{
    public class AppDbContext : DbContext
    {
            public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

            public DbSet<User> Users { get; set; }
            public DbSet<Booking> Bookings { get; set; }
            public DbSet<Service> Services { get; set; }
            public DbSet<Slot> Slots { get; set; }
            public DbSet<Category> Categories { get; set; }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
            modelBuilder.Entity<Category>().HasData(
               new Category { Id = 1, Name = "Ladies" },
               new Category { Id = 2, Name = "Gentlemen" }
           );
            modelBuilder.Entity<User>().HasData(
               new User { Id = 1, Name = "Admin", Email = "admin@gmail.com", Password = "adzi", IsAdmin = true, CreatedAt = new DateTime(2026, 3, 17) }
           );
            // Configure relationships and seed data here
        }
    }
}
