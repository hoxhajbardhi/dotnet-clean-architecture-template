using DotNetCleanArchitectureTemplate.Application.Abstractions.Persistence;
using DotNetCleanArchitectureTemplate.Domain.WorkItems;
using Microsoft.EntityFrameworkCore;

namespace DotNetCleanArchitectureTemplate.Infrastructure.Persistence.Repositories;

public class WorkItemRepository : IWorkItemRepository
{
    private readonly ApplicationDbContext _dbContext;

    public WorkItemRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddAsync(WorkItem workItem, CancellationToken cancellationToken)
    {
        await _dbContext.WorkItems.AddAsync(workItem, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<WorkItem?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _dbContext.WorkItems
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }
}
