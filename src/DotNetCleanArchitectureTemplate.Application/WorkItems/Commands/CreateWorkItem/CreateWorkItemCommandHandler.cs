using DotNetCleanArchitectureTemplate.Application.Abstractions.Persistence;
using DotNetCleanArchitectureTemplate.Application.Common;
using DotNetCleanArchitectureTemplate.Domain.WorkItems;
using MediatR;

namespace DotNetCleanArchitectureTemplate.Application.WorkItems.Commands.CreateWorkItem;

public class CreateWorkItemCommandHandler : IRequestHandler<CreateWorkItemCommand, Result<Guid>>
{
    private readonly IWorkItemRepository _repository;

    public CreateWorkItemCommandHandler(IWorkItemRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<Guid>> Handle(CreateWorkItemCommand request, CancellationToken cancellationToken)
    {
        // create domain entity
        var workItem = WorkItem.Create(request.Title, request.Description);

        // persist
        await _repository.AddAsync(workItem, cancellationToken);

        return Result<Guid>.Success(workItem.Id);
    }
}
