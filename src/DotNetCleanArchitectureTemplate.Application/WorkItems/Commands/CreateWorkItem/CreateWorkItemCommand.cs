using DotNetCleanArchitectureTemplate.Application.Common;
using MediatR;

namespace DotNetCleanArchitectureTemplate.Application.WorkItems.Commands.CreateWorkItem;

public record CreateWorkItemCommand(string Title, string Description) : IRequest<Result<Guid>>;
