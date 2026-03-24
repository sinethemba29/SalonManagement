using Microsoft.EntityFrameworkCore;
using SalonManagement.Domain;
using SalonManagement.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using SalonManagement.Application.Dtos;

namespace SalonManagement.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _db;
        public UserRepository(AppDbContext db) => _db = db;

        public async Task<UserDto> AddAsync(UserDto user)
        {
            var User = new User
            {
                Name = user.Name,
                Email = user.Email,
                Password = user.Password,
                CreatedAt = user.createdAt,
                IsAdmin= false
            };
            _db.Users.Add(User);
            await _db.SaveChangesAsync();
            return user;
        }

        public async Task<User?> GetByEmailAsync(string email)
            => await _db.Users.FirstOrDefaultAsync(u => u.Email == email);

        public async Task<User?> GetByIdAsync(int id)
            => await _db.Users.FindAsync(id);

        public async Task<bool> CheckCredentialsAsync(string email, string password)
        {
            var user = await _db.Users.FirstOrDefaultAsync(u => u.Email == email);
            if (user == null) return false;
            // Replace with a proper password hash check in production
            return user.Password == password;
        }
    }
}
