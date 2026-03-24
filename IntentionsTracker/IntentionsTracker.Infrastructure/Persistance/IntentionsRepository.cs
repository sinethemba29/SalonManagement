using IntentionsTracker.Domain;
using Microsoft.EntityFrameworkCore;

namespace IntentionsTracker.Infrastructure.Persistance
{
    public class IntentionsRepository
    {
        private readonly ApplicationDbContext _context;

        public IntentionsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Intentions>> GetAllAsync()
        {
            return await _context.Intentions.ToListAsync();
        }

        public async Task<Intentions?> GetByIdAsync(int id)
        {
            return await _context.Intentions.FindAsync(id);
        }

        public async Task<Intentions> AddAsync(Intentions intention)
        {
            intention.DateCreated = DateTime.UtcNow;
            _context.Intentions.Add(intention);
            await _context.SaveChangesAsync();
            return intention;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var intention = await _context.Intentions.FindAsync(id);
            if (intention == null)
                return false;

            _context.Intentions.Remove(intention);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}