using DotNetCleanArchitectureTemplate.Application.Abstractions.Persistence;
using DotNetCleanArchitectureTemplate.Application.Common;
using DotNetCleanArchitectureTemplate.Application.WorkItems.DTOs;
using MediatR;

namespace DotNetCleanArchitectureTemplate.Application.WorkItems.Queries.GetWorkItemById;

public class GetWorkItemByIdQueryHandler
    : IRequestHandler<GetWorkItemByIdQuery, Result<WorkItemDto>>
{
    private readonly IWorkItemRepository _repository;

    public GetWorkItemByIdQueryHandler(IWorkItemRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<WorkItemDto>> Handle(
        GetWorkItemByIdQuery request,
        CancellationToken cancellationToken)
    {
        var workItem = await _repository.GetByIdAsync(request.Id, cancellationToken);

        if (workItem is null)
            return Result<WorkItemDto>.Failure("WorkItem not found");

        var dto = new WorkItemDto(
            workItem.Id,
            workItem.Title,
            workItem.Description,
            workItem.Status.ToString());

        return Result<WorkItemDto>.Success(dto);
    }
}
