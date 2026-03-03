using DotNetCleanArchitectureTemplate.Application.Abstractions.Persistence;
using DotNetCleanArchitectureTemplate.Infrastructure.Persistence;
using DotNetCleanArchitectureTemplate.Infrastructure.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

namespace DotNetCleanArchitectureTemplate.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection")
            ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(connectionString));

        services.AddScoped<IWorkItemRepository, WorkItemRepository>();

        return services;
    }
}
