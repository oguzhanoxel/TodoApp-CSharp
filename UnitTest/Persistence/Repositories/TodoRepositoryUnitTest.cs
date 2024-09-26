using TodoApp.Domain.Models;
using TodoApp.Persistence.Repositories;

namespace UnitTest.Persistence.Repositories;

public class TodoRepositoryUnitTest 
{
    private readonly TodoRepository _sut;

    public TodoRepositoryUnitTest()
    {
        _sut = new TodoRepository();
    }

    [Fact]
    public void GetAll_WhenCalled_ReturnsAllTodos()
    {
        // Given
        var todos = _sut.GetAll();

        // When
        var result = todos.Count;
    
        // Then
        Assert.Equal(6, result);
    }

    [Fact]
    public void GetAllByUserId_WhenCalled_ReturnsAllTodosByUserId()
    {
        // Given
        var userId = 1;

        // When
        var result = _sut.GetAll(t => t.UserId == userId);

        // Then
        Assert.Equal(2, result.Count);
    }

    [Fact]
    public void Get_WhenCalled_ReturnsTodo()
    {
        // Given
        var todoId = 1;

        // When
        var result = _sut.Get(t => t.Id == todoId);

        // Then
        Assert.NotNull(result);
        Assert.Equal(todoId, result.Id);
    }

    [Fact]
    public void GetByUserId_WhenCalled_ReturnsTodoByUserId()
    {
        // Given
        var userId = 1;

        // When
        var result = _sut.Get(t => t.UserId == userId);

        // Then
        Assert.NotNull(result);
        Assert.Equal(userId, result.UserId);
    }

    [Fact]
    public void CreateTodo_WhenCalled_AddsTodo()
    {
        // Given
        var todo = new Todo
        {
            Title = "Test Todo",
            Description = "Test Description",
            IsDone = false,
            UserId = 1
        };
    
        // When
        _sut.Create(todo);
        
        // Then
        Assert.Equal(7, _sut.GetAll().Count);
    }

    [Fact]
    public void UpdateTodo_WhenCalled_UpdatesTodo()
    {
        // Given
        var todo = new Todo
        {
            Id = 1,
            Title = "Test Todo",
            Description = "Test Description",
            IsDone = false,
            UserId = 1
        };
    

        // When
        _sut.Update(todo);
    
        // Then
        Assert.Equal(todo.Title, _sut.Get(t => t.Id == todo.Id).Title);
    }

    [Fact]
    public void DeleteTodo_WhenCalled_DeletesTodo()
    {
        // Given
        var todoId = 1;

        // When
        _sut.Delete(todoId);
        
        // Then
        Assert.Null(_sut.Get(t => t.Id == todoId));
    }
}