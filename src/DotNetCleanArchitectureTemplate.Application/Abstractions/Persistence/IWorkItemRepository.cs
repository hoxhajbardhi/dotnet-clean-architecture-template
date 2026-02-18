using DotNetCleanArchitectureTemplate.Domain.WorkItems;

namespace DotNetCleanArchitectureTemplate.Application.Abstractions.Persistence;

public interface IWorkItemRepository
{
    Task AddAsync(WorkItem workItem, CancellationToken cancellationToken);
    Task<WorkItem?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
}
