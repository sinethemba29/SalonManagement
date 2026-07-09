using SalonManagement.Application.Interfaces;
using SalonManagement.Application.Dtos;
using SalonManagement.Domain;

namespace SalonManagement.Infrastructure.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repo;
        public CategoryService(ICategoryRepository repo) => _repo = repo;

        public async Task<CategoryDto?> AddNewCategory(CategoryDto category)
        {
            var newCategory = new Category
            {
                Name = category.Name,
                Description = category.Description
                // Id omitted: let the database generate it (identity column),
                // rather than computing Max(Id)+1 in app code.
            };

            var created = await _repo.AddAsync(newCategory);

            return new CategoryDto
            {
                Id = created.Id,
                Name = created.Name,
                Description = created.Description
            };
        }

        public async Task<List<CategoryDto>> GetAll()
        {
            var allCategories = await _repo.GetAll();
            return allCategories.Select(c => new CategoryDto
            {
                Id = c.Id,
                Name = c.Name,
                Description = c.Description
            }).ToList();
        }

        public async Task<CategoryDto?> GetByIdAsync(int id)
        {
            var category = await _repo.GetByIdAsync(id);
            if (category == null) return null;

            return new CategoryDto
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description
            };
        }

        public async Task<CategoryDto?> UpdateCategory(CategoryDto category)
        {
            var existing = await _repo.GetByIdAsync(category.Id);
            if (existing == null) return null; // nothing to update

            existing.Name = category.Name;
            existing.Description = category.Description;

            var updated = await _repo.UpdateAsync(existing);

            return new CategoryDto
            {
                Id = updated.Id,
                Name = updated.Name,
                Description = updated.Description
            };
        }
    }
}