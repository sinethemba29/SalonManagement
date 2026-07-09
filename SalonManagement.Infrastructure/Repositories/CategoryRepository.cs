using Microsoft.EntityFrameworkCore;
using SalonManagement.Application.Interfaces;
using SalonManagement.Domain;

namespace SalonManagement.Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _db;
        public CategoryRepository(AppDbContext db) => _db = db;

        public async Task<List<Category>> GetAll()
        {
            return await _db.Categories.AsQueryable().ToListAsync();
        }

        public async Task<Category?> GetByIdAsync(int id)
        {
            return await _db.Categories.FindAsync(id);
        }

        public async Task<Category> AddAsync(Category category)
        {
            _db.Categories.Add(category);
            await _db.SaveChangesAsync();
            return category;
        }

        public async Task<Category> UpdateAsync(Category category)
        {
            var existing = await _db.Categories.FindAsync(category.Id);
            if (existing == null)
                throw new InvalidOperationException($"Category with Id {category.Id} not found.");

            existing.Name = category.Name;
            existing.Description = category.Description;

            await _db.SaveChangesAsync();
            return existing;
        }
    }
}