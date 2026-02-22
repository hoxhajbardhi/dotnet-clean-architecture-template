using DotNetCleanArchitectureTemplate.Domain.WorkItems;
using Microsoft.EntityFrameworkCore;

namespace DotNetCleanArchitectureTemplate.Infrastructure.Persistence;

public class ApplicationDbContext : DbContext
{
    public DbSet<WorkItem> WorkItems => Set<WorkItem>();

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
}
