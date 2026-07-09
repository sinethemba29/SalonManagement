using SalonManagement.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace SalonManagement.Application.Interfaces
{
    public interface ICategoryService
    {
        Task<List<CategoryDto?>> GetAll();
        Task<CategoryDto?> AddNewCategory(CategoryDto category);
        Task<CategoryDto?> UpdateCategory(CategoryDto category);
        Task<CategoryDto?> GetByIdAsync(int id);
    }
}
