using Core.Repository;
using TodoApp.Domain.Models;

namespace Persistence.Repositories.Abstracts;

public interface ICategoryRepository : IRepository<Category, int>
{

}