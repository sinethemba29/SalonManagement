using SalonManagement.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace SalonManagement.Application.Interfaces
{
    public interface IUserService
    {
        Task<UserDto?> AuthenticateAsync(string email, string password);
        Task<UserDto?> AddNewUser(string name, string email, string password);
        Task<UserDto?> GetByIdAsync(int id);
    }
}
