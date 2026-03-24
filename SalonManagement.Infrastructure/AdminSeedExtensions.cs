//using Microsoft.Extensions.Configuration;
//using System;
//using System.Collections.Generic;
//using System.Security.Cryptography;
//using System.Text;
//using SalonManagement.

//namespace SalonManagement.Infrastructure
//{
//    public static class AdminSeedExtensions
//    {
//        public static async Task EnsureSeedDataAsync(this WebApplication app)
//        {
//            using var scope = app.Services.CreateScope();
//            var config = scope.ServiceProvider.GetRequiredService<IConfiguration>();
//            var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();

//            // If an admin already exists, nothing to do
//            if (await db.Users.AnyAsync(u => u.IsAdmin))
//                return;

//            // Read credentials from config or environment
//            var email = config["InitialAdmin:Email"] ?? Environment.GetEnvironmentVariable("INITIAL_ADMIN_EMAIL");
//            var password = config["InitialAdmin:Password"] ?? Environment.GetEnvironmentVariable("INITIAL_ADMIN_PASSWORD");
//            var name = config["InitialAdmin:Name"] ?? "Administrator";

//            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
//                throw new InvalidOperationException("Initial admin credentials not configured. Set InitialAdmin:Email and InitialAdmin:Password in configuration or environment variables.");

//            var hashed = HashPassword(password);

//            var admin = new Domain.User
//            {
//                Name = name,
//                Email = email,
//                Password = hashed,
//                IsAdmin = true,
//                CreatedAt = DateTime.UtcNow
//            };

//            db.Users.Add(admin);
//            await db.SaveChangesAsync();
//        }

//        // PBKDF2 password hashing (format: iterations.salt.hash)
//        private static string HashPassword(string password)
//        {
//            const int iterations = 100_000;
//            using var rng = RandomNumberGenerator.Create();
//            var salt = new byte[16];
//            rng.GetBytes(salt);

//            using var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations, HashAlgorithmName.SHA256);
//            var hash = pbkdf2.GetBytes(32);

//            return $"{iterations}.{Convert.ToBase64String(salt)}.{Convert.ToBase64String(hash)}";
//        }
//    }
//}
