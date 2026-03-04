using DotNetCleanArchitectureTemplate.Application.Abstractions.Persistence;
using DotNetCleanArchitectureTemplate.Application.WorkItems.Commands.CreateWorkItem;
using DotNetCleanArchitectureTemplate.Domain.WorkItems;
using FluentAssertions;
using Moq;

namespace DotNetCleanArchitectureTemplate.Application.Tests.WorkItems.Commands.CreateWorkItem;

public class CreateWorkItemCommandHandlerTests
{
    [Fact]
    public async Task Handle_Should_Create_WorkItem_And_Return_Id()
    {
        // Arrange
        var repositoryMock = new Mock<IWorkItemRepository>();

        repositoryMock
            .Setup(r => r.AddAsync(It.IsAny<WorkItem>(), It.IsAny<CancellationToken>()))
            .Returns(Task.CompletedTask);

        var handler = new CreateWorkItemCommandHandler(repositoryMock.Object);

        var command = new CreateWorkItemCommand(
            "Unit Test Title",
            "Unit Test Description");

        // Act
        var result = await handler.Handle(command, CancellationToken.None);

        // Assert
        result.IsSuccess.Should().BeTrue();
        result.Value.Should().NotBeEmpty();

        repositoryMock.Verify(r =>
            r.AddAsync(It.IsAny<WorkItem>(), It.IsAny<CancellationToken>()),
            Times.Once);
    }
}
