using TodoApp.Domain.Models;

namespace TodoApp.Persistence.Repositories;

public static class InMemoryDbContext
{
    public static List<User> Users { get; set; }
    public static List<Todo> Todos { get; set; }

    static InMemoryDbContext()
    {
        Users = new List<User>();
        Todos = new List<Todo>();

        Users.Add(new User(1, "John", "Doe", new DateTime(1990, 1, 1), "john.doe@example.com"));
        Users.Add(new User(2, "Jane", "Doe", new DateTime(1992, 2, 2), "jane.doe@example.com"));
        Users.Add(new User(3, "Jim", "Beam", new DateTime(1985, 3, 3), "jim.beam@example.com"));

        Todos.Add(new Todo(1, "Todo 1", "Description 1", DateTime.Now, DateTime.Now.AddDays(1), DateTime.Now, false, 1));
        Todos.Add(new Todo(2, "Todo 2", "Description 2", DateTime.Now, DateTime.Now.AddDays(2), DateTime.Now, false, 1));
        Todos.Add(new Todo(3, "Todo 3", "Description 3", DateTime.Now, DateTime.Now.AddDays(3), DateTime.Now, false, 2));
        Todos.Add(new Todo(4, "Todo 4", "Description 4", DateTime.Now, DateTime.Now.AddDays(4), DateTime.Now, false, 2));
        Todos.Add(new Todo(5, "Todo 5", "Description 5", DateTime.Now, DateTime.Now.AddDays(5), DateTime.Now, false, 3));
        Todos.Add(new Todo(6, "Todo 6", "Description 6", DateTime.Now, DateTime.Now.AddDays(6), DateTime.Now, false, 3));
    }
}
