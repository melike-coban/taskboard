using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Abstractions;
using TaskBoard.Web.Data;
using TaskBoard.Web.Services;
using TaskBoard.Web.ViewModels;
using Xunit;

namespace TaskBoard.Tests;

public class UnitTest1
{
    private TaskService CreateService()
    {
        var options = new DbContextOptionsBuilder<TaskBoardDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

        var context = new TaskBoardDbContext(options);

        return new TaskService(
            context,
            NullLogger<TaskService>.Instance);
    }

    [Fact]
    public async Task CreateAsync_ShouldRejectEmptyTitle()
    {
        // Arrange
        var service = CreateService();

        var request = new CreateTaskViewModel
        {
            Title = "",
            Priority = "High"
        };

        // Act & Assert
        await Assert.ThrowsAsync<ArgumentException>(() =>
            service.CreateAsync(request));
    }
    [Fact]
public async Task CreateAsync_ShouldCreateTask()
{
    var service = CreateService();

    var request = new CreateTaskViewModel
    {
        Title = "Test Görevi",
        Priority = "High"
    };

    var result = await service.CreateAsync(request);

    Assert.NotNull(result);
    Assert.Equal("Test Görevi", result.Title);
    Assert.Equal("High", result.Priority);
    Assert.Equal("Open", result.Status);
}
[Fact]
public async Task DeleteAsync_ShouldReturnFalse_WhenTaskDoesNotExist()
{
    // Arrange
    var service = CreateService();

    // Act
    var result = await service.DeleteAsync(999);

    // Assert
    Assert.False(result);
}
[Fact]
public async Task GetAllAsync_ShouldReturnAllTasks()
{
    // Arrange
    var service = CreateService();

    await service.CreateAsync(new CreateTaskViewModel
    {
        Title = "Görev 1",
        Priority = "High"
    });

    await service.CreateAsync(new CreateTaskViewModel
    {
        Title = "Görev 2",
        Priority = "Low"
    });

    // Act
   var result = await service.GetAllAsync(new TaskQuery());

    // Assert
    Assert.Equal(2, result.Count);
}
[Fact]
public async Task MarkAsDone_ShouldReturnTrue_WhenTaskExists()
{
    // Arrange
    var service = CreateService();

    var createdTask = await service.CreateAsync(new CreateTaskViewModel
    {
        Title = "Test Görevi",
        Priority = "High"
    });

    // Act
    var result = await service.MarkAsDoneAsync(createdTask.Id);

    var updatedTask = await service.GetByIdAsync(createdTask.Id);

    // Assert
    Assert.True(result);
    Assert.NotNull(updatedTask);
    Assert.Equal("Done", updatedTask!.Status);
}
[Fact]
public async Task MarkAsDone_ShouldReturnFalse_WhenTaskDoesNotExist()
{
    // Arrange
    var service = CreateService();

    // Act
    var result = await service.MarkAsDoneAsync(999);

    // Assert
    Assert.False(result);
}
}
