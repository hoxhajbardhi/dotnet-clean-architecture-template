using DotNetCleanArchitectureTemplate.Application.Common;
using DotNetCleanArchitectureTemplate.Application.WorkItems.DTOs;
using MediatR;

namespace DotNetCleanArchitectureTemplate.Application.WorkItems.Queries.GetWorkItemById;

public record GetWorkItemByIdQuery(Guid Id) : IRequest<Result<WorkItemDto>>;
