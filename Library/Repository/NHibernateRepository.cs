using Database.Models;
using Database.Repository;
using NHibernate;

namespace Library.Repository;

internal class NHibernateRepository<TEntity>(ISession session) 
    : IRepository<TEntity> where TEntity : Entity
{
    public TEntity Get(Guid id)
    {
        return session.Get<TEntity>(id);
    }

    public IQueryable<TEntity> Query()
    {
        return session.Query<TEntity>();
    }

    public TEntity SaveOrUpdate(TEntity entity)
    {
        session.SaveOrUpdate(entity);
        return entity;
    }

    public void Delete(TEntity entity)
    {
        session.Delete(entity);
    }
}
