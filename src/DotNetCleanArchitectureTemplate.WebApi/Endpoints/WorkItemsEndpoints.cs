using DotNetCleanArchitectureTemplate.Application.WorkItems.Commands.CreateWorkItem;
using MediatR;

namespace DotNetCleanArchitectureTemplate.WebApi.Endpoints;

public static class WorkItemsEndpoints
{
    public static IEndpointRouteBuilder MapWorkItems(this IEndpointRouteBuilder app)
    {
        app.MapPost("/workitems", async (
            CreateWorkItemCommand command,
            IMediator mediator,
            CancellationToken cancellationToken) =>
        {
            var result = await mediator.Send(command, cancellationToken);

            if (!result.IsSuccess)
                return Results.BadRequest(result.Error);

            return Results.Ok(result.Value);
        });

        return app;
    }
}
