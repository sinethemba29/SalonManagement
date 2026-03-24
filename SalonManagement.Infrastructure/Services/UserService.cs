using SalonManagement.Application.Dtos;
using SalonManagement.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SalonManagement.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repo;
        public UserService(IUserRepository repo) => _repo = repo;

        public async Task<UserDto?> AuthenticateAsync(string email, string password)
        {
            var ok = await _repo.CheckCredentialsAsync(email, password);
            if (!ok) return null;

            var user = await _repo.GetByEmailAsync(email);
            if (user == null) return null;

            return new UserDto
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                IsAdmin = user.IsAdmin
            };
        }

        public async Task<UserDto?> AddNewUser(string name, string email, string password)
        {
            // check if user already exists
            var existingUser = await _repo.GetByEmailAsync(email);
            if (existingUser != null)
            {
                // user already exists, return null or throw exception
                return null;
            }

            // create a new user object
            var newUser = new UserDto
            {
                Name = name,
                Email = email,
                Password = password, // consider hashing this before saving
                IsAdmin = false,
                createdAt = DateTime.Now
            };

            // add user to repository
            var createdUser = await _repo.AddAsync(newUser);

            // return the created user
            return createdUser;
        }

        public async Task<UserDto?> GetByIdAsync(int id)
        {
            var user = await _repo.GetByIdAsync(id);
            if (user == null) return null;

            return new UserDto
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                IsAdmin = user.IsAdmin
            };
        }
    }
}
