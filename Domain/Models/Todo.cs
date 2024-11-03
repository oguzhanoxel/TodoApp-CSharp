using Core.Entities;

namespace TodoApp.Domain.Models;

public enum Priority
{
    Low,
    Medium,
    High
}

public class Todo : Entity<int>
{
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public bool IsDone { get; set; } = false;
    public int CategoryId { get; set; }
    public string UserId { get; set; }
    public Category Category { get; set; }
    public User User { get; set; }
}
