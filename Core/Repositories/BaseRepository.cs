using TodoApp.Core.Models;

namespace TodoApp.Core.Data;

public class BaseRepository<TEntity> : IRepository<TEntity>
where TEntity : Entity, new()
{
    protected readonly List<TEntity> _items;

    public BaseRepository()
    {
        _items = new List<TEntity>();
    }

    public bool Create(TEntity item)
    {
        _items.Add(item);
        return true;
    }

    public bool Delete(int id)
    {
        var item = _items.FirstOrDefault(i => i.Id == id);
        if (item != null)
        {
            _items.Remove(item);
            return true;
        }
        return false;
    }

    public TEntity? Get(Func<TEntity, bool> predicate)
    {
        return _items.FirstOrDefault(predicate);
    }

    public List<TEntity> GetAll(Func<TEntity, bool>? predicate = null)
    {
        return predicate == null ? _items.ToList() : _items.Where(predicate).ToList();
    }

    public bool Update(TEntity item)
    {
        var index = _items.FindIndex(i => i.Id == item.Id);
        if (index != -1)
        {
            _items[index] = item;
            return true;
        }
        return false;
    }
}