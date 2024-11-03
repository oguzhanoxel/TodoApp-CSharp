using Core.Repository;
using Persistence.Contexts;
using Persistence.Repositories.Abstracts;
using TodoApp.Domain.Models;

namespace Persistence.Repositories.Concretes;

public class EfCategoryRepository : EfRepositoryBase<EfCoreDbContext, Category, int>, ICategoryRepository
{
    public EfCategoryRepository(EfCoreDbContext context) : base(context)
    {
        
    }
}
