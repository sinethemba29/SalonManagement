using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SalonManagement.Application.Interfaces;
using SalonManagement.Infrastructure.Repositories;
using SalonManagement.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace SalonManagement.Infrastructure
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Read connection string from the startup project's configuration
            var conn = configuration.GetConnectionString("DefaultConnection");
            if (string.IsNullOrEmpty(conn))
                throw new InvalidOperationException("DefaultConnection is not configured.");

            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(conn));

            // Repositories
            services.AddScoped<IUserRepository, UserRepository>();
            // Add other repositories...

            // Application-facing services
            services.AddScoped<IUserService, UserService>();
            // Add other services...

            return services;
        }
    }
}
