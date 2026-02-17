using DotNetCleanArchitectureTemplate.Domain.Common;

namespace DotNetCleanArchitectureTemplate.Domain.WorkItems;

public class WorkItemCreatedEvent : IDomainEvent
{
    public Guid WorkItemId { get; }
    public DateTime OccurredOn { get; }

    public WorkItemCreatedEvent(Guid workItemId)
    {
        WorkItemId = workItemId;
        OccurredOn = DateTime.UtcNow;
    }
}
