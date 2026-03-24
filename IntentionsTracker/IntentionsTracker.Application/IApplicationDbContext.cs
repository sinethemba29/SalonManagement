using IntentionsTracker.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace IntentionsTracker.Application
{
    public interface IApplicationDbContext
    {
        DbSet<Intentions> Intentions { get; set; } // Changed from Products to Intentions
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}

