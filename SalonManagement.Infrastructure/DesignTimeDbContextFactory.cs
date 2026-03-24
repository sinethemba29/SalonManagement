using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace SalonManagement.Infrastructure;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
        // Replace with your real connection string or use an env var
        optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=SalonDb;Trusted_Connection=True;");
        return new AppDbContext(optionsBuilder.Options);
    }
}

