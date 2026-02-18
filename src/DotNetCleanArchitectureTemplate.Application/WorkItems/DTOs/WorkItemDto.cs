namespace DotNetCleanArchitectureTemplate.Application.WorkItems.DTOs;

public record WorkItemDto(Guid Id, string Title, string Description, string Status);
