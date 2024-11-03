using Microsoft.AspNetCore.Identity;

namespace TodoApp.Domain.Models;

public class User : IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public List<Todo> Todos { get; set; }
}
