using SalonManagement.Application.Dtos;
using SalonManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace SalonManagement.Application.Interfaces
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetAll();
        Task<Category?> GetByIdAsync(int id);
        Task<Category> AddAsync(Category category);
        Task<Category> UpdateAsync(Category category);
    }
}
