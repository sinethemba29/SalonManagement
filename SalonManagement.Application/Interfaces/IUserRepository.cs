using System;
using System.Collections.Generic;
using System.Text;
using SalonManagement.Application.Dtos;
using SalonManagement.Domain;


namespace SalonManagement.Application.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetByEmailAsync(string email);
        Task<User?> GetByIdAsync(int id);
        Task<UserDto> AddAsync(UserDto user);
        Task<bool> CheckCredentialsAsync(string email, string password);
    }
}
