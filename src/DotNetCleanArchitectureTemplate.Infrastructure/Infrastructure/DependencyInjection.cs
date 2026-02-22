using DotNetCleanArchitectureTemplate.Application.Abstractions.Persistence;
using DotNetCleanArchitectureTemplate.Infrastructure.Persistence;
using DotNetCleanArchitectureTemplate.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DotNetCleanArchitectureTemplate.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<IWorkItemRepository, WorkItemRepository>();

        return services;
    }
}
