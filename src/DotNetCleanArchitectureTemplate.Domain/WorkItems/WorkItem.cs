using DotNetCleanArchitectureTemplate.Domain.Common;


namespace DotNetCleanArchitectureTemplate.Domain.WorkItems;

public class WorkItem : AggregateRoot<Guid>
{
    public string Title { get; private set; }
    public string Description { get; private set; }
    public WorkItemStatus Status { get; private set; }

    private WorkItem() { } // EF Core

    private WorkItem(Guid id, string title, string description)
    {
        Id = id;
        Title = title;
        Description = description;
        Status = WorkItemStatus.Todo;

        AddDomainEvent(new WorkItemCreatedEvent(Id));
    }

    public static WorkItem Create(string title, string description)
    {
        return new WorkItem(Guid.NewGuid(), title, description);
    }

    public void Start()
    {
        if (Status != WorkItemStatus.Todo)
            throw new InvalidOperationException("Work item cannot be started");

        Status = WorkItemStatus.InProgress;
    }

    public void Complete()
    {
        if (Status != WorkItemStatus.InProgress)
            throw new InvalidOperationException("Work item cannot be completed");

        Status = WorkItemStatus.Done;
    }
}
