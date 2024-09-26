using TodoApp.Core.Data;
using TodoApp.Domain.Models;
using TodoApp.Persistence.Repositories.Abstracts;

namespace TodoApp.Persistence.Repositories;

public class TodoRepository : BaseRepository<Todo>, ITodoRepository
{
    public TodoRepository()
    {
        _items.AddRange(InMemoryDbContext.Todos);
    }
}

