namespace DotNetCleanArchitectureTemplate.Domain.Common;

public interface IDomainEvent
{
    DateTime OccurredOn { get; }
}
