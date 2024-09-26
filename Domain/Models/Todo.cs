using TodoApp.Core.Models;

namespace TodoApp.Domain.Models;

public class Todo : Entity
{
    public string? Title { get; set; }
    public string? Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public DateTime CreatedAt { get; set; }
    public bool IsDone { get; set; }
    public int UserId { get; set; }
    public User? User { get; set; }

    public Todo(int id, string? title, string? description, DateTime startDate, DateTime endDate, DateTime createdAt, bool isDone, int userId) : base(id)
    {
        Title = title;
        Description = description;
        StartDate = startDate;
        EndDate = endDate;
        CreatedAt = createdAt;
        IsDone = isDone;
        UserId = userId;
    }

    public Todo()
    {

    }
}
