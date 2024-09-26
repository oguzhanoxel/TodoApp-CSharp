using TodoApp.Core.Data;
using TodoApp.Domain.Models;
using TodoApp.Persistence.Repositories.Abstracts;

namespace TodoApp.Persistence.Repositories;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    public UserRepository()
    {
        _items.AddRange(InMemoryDbContext.Users);
    }
}
