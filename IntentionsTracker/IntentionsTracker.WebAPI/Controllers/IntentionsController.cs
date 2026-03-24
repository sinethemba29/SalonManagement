using IntentionsTracker.Application;
using IntentionsTracker.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IntentionsTracker.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IntentionsController : ControllerBase
    {
        // You must declare the field here
        private readonly IApplicationDbContext _context;

        // And you must have a constructor that accepts the context and assigns it to the field
        public IntentionsController(IApplicationDbContext context)
        {
            _context = context;
        }
        // GET: api/Intentions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Domain.Intentions>>> GetIntentions()
        {
            return await _context.Intentions.ToListAsync();
        }

        // GET: api/Intentions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Domain.Intentions>> GetIntention(int id)
        {
            var intention = await _context.Intentions.FindAsync(id);

            if (intention == null)
            {
                return NotFound(); // Returns a 404 Not Found if the ID doesn't exist
            }

            return intention;
        }

        // POST: api/Intentions
        [HttpPost]
        public async Task<ActionResult<Domain.Intentions>> PostIntention(Domain.Intentions intention)
        {
            // We should set the creation date on the server-side
            intention.DateCreated = DateTime.UtcNow;

            _context.Intentions.Add(intention);
            await _context.SaveChangesAsync(CancellationToken.None);

            // Returns a 201 Created status with the new intention in the response body
            return CreatedAtAction(nameof(GetIntention), new { id = intention.Id }, intention);
        }

        // DELETE: api/Intentions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIntention(int id)
        {
            var intention = await _context.Intentions.FindAsync(id);
            if (intention == null)
            {
                return NotFound();
            }

            _context.Intentions.Remove(intention);
            await _context.SaveChangesAsync(CancellationToken.None);

            return NoContent(); // Returns a 204 No Content on successful deletion
        }

    }
}
