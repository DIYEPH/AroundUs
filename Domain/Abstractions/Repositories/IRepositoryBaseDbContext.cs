using Microsoft.EntityFrameworkCore;

namespace Domain.Abstractions.Repositories
{
    public interface IRepositoryBaseDbContext<TContext, TEntity, in TKey> where TContext : DbContext where TEntity : class
    {

        void Add(TEntity entity);
        void Update(TEntity entity);
        void Remove(TEntity entity);
        void RemoveMultiple(List<TEntity> entities);

    }
}
