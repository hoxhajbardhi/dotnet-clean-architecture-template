using DotNetCleanArchitectureTemplate.Application.WorkItems.Commands.CreateWorkItem;
using DotNetCleanArchitectureTemplate.Application.WorkItems.Queries.GetWorkItemById;
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

        app.MapGet("/workitems/{id:guid}", async (
            Guid id,
            IMediator mediator,
            CancellationToken cancellationToken) =>
        {
            var result = await mediator.Send(
                new GetWorkItemByIdQuery(id),
                cancellationToken);

            if (!result.IsSuccess)
                return Results.NotFound(result.Error);

            return Results.Ok(result.Value);
        });


        return app;
    }
}
