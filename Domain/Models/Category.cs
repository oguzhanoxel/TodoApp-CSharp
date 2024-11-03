using Core.Entities;

namespace TodoApp.Domain.Models;

public class Category : Entity<int>
{
    public string Name { get; set; }
    public List<Todo> Todos { get; set; }
}
