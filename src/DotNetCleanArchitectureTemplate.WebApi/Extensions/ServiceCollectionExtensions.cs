using DotNetCleanArchitectureTemplate.Application.Common.Behaviors;
using DotNetCleanArchitectureTemplate.Application.WorkItems.Commands.CreateWorkItem;
using FluentValidation;
using MediatR;

namespace DotNetCleanArchitectureTemplate.WebApi.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssemblyContaining<CreateWorkItemCommandHandler>();
        });

        services.AddValidatorsFromAssemblyContaining<CreateWorkItemCommandValidator>();

        services.AddTransient(
            typeof(IPipelineBehavior<,>),
            typeof(ValidationBehavior<,>));

        return services;
    }
}
