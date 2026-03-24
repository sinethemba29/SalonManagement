using System;
using System.Collections.Generic;
using System.Text;

namespace SalonManagement.Application.Dtos
{
    public class UserDto
    {
        public int Id { get; init; }
        public string Name { get; init; } = string.Empty;
        public string Email { get; init; } = string.Empty;
        public string Password { get; init; } = string.Empty;
        public bool IsAdmin { get; init; }
        public DateTime createdAt { get; init; } = DateTime.Now;
    }
}
