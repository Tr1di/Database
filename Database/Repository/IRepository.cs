using Database.Models;

namespace Database.Repository;

public interface IRepository<TEntity> where TEntity : Entity
{
    public TEntity Get(Guid id);
    public IQueryable<TEntity> Query();
    public TEntity SaveOrUpdate(TEntity entity);
    public void Delete(TEntity entity);
}
