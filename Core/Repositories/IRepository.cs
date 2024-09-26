using TodoApp.Core.Models;

namespace TodoApp.Core.Data;

public interface IRepository<TEntity>
where TEntity : Entity, new()
{
    bool Create(TEntity item);
    bool Update(TEntity item);
    bool Delete(int id);
    TEntity? Get(Func<TEntity, bool> predicate);
    List<TEntity> GetAll(Func<TEntity, bool>? predicate = null);
}