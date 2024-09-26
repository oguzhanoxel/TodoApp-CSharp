using TodoApp.Core.Models;

namespace TodoApp.Domain.Models;

public class User : Entity
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public DateTime BirthDate { get; set; }
    public string? Email { get; set; }
    public List<Todo>? Todos { get; set; }

    public User(int id, string? firstName, string? lastName, DateTime birthDate, string? email) : base(id)
    {
        FirstName = firstName;
        LastName = lastName;
        BirthDate = birthDate;
        Email = email;
    }

    public User()
    {
        
    }
}
