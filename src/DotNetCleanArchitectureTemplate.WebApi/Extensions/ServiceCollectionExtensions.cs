using DotNetCleanArchitectureTemplate.Application.WorkItems.Commands.CreateWorkItem;
using MediatR;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssemblyContaining<CreateWorkItemCommandHandler>();
        });

        return services;
    }
}
