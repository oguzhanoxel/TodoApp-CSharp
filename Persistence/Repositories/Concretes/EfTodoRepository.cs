using Core.Repository;
using Persistence.Contexts;
using Persistence.Repositories.Abstracts;
using TodoApp.Domain.Models;

namespace Persistence.Repositories.Concretes;

public class EfTodoRepository : EfRepositoryBase<EfCoreDbContext, Todo, int>, ITodoRepository
{
    public EfTodoRepository(EfCoreDbContext context) : base(context)
    {

    }
}