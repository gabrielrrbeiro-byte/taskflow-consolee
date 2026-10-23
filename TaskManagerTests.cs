using TaskFlow.Domain;
using TaskFlow.Services;

namespace TaskFlow.Tests;

public class TaskManagerTests
{
    [Fact]
    public void AddTask_Should_Add_Task_When_Title_Is_Valid()
    {
        // Arrange
        var manager = new TaskManager();
        const string title = "Estudar C# e .NET 10";

        // Act
        var task = manager.AddTask(title);

        // Assert
        Assert.NotNull(task);
        Assert.Equal(title, task.Title);
        Assert.False(task.IsCompleted);
        Assert.Single(manager.Tasks);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public void AddTask_Should_Throw_Exception_When_Title_Is_Null_Or_Empty(string? title)
    {
        // Arrange
        var manager = new TaskManager();

        // Act & Assert
        Assert.Throws<ArgumentException>(() => manager.AddTask(title!));
        Assert.Empty(manager.Tasks);
    }

    [Fact]
    public void AddTask_Should_Trim_Title()
    {
        var manager = new TaskManager();

        var task = manager.AddTask("  Revisar PR  ");

        Assert.Equal("Revisar PR", task.Title);
    }

    [Fact]
    public void GetById_Should_Return_Task_When_Task_Exists()
    {
        var manager = new TaskManager();
        var added = manager.AddTask("Tarefa existente");

        var found = manager.GetById(added.Id);

        Assert.Same(added, found);
    }

    [Fact]
    public void GetById_Should_Return_Null_When_Task_Does_Not_Exist()
    {
        // Arrange
        var manager = new TaskManager();

        // Act
        var task = manager.GetById(Guid.NewGuid());

        // Assert
        Assert.Null(task);
    }

    [Fact]
    public void CompleteTask_Should_Mark_Task_As_Completed_And_Return_True()
    {
        var manager = new TaskManager();
        var task = manager.AddTask("Concluir lista");

        var result = manager.CompleteTask(task.Id);

        Assert.True(result);
        Assert.True(task.IsCompleted);
    }

    [Fact]
    public void CompleteTask_Should_Return_False_When_Task_Does_Not_Exist()
    {
        var manager = new TaskManager();

        var result = manager.CompleteTask(Guid.NewGuid());

        Assert.False(result);
    }
}
