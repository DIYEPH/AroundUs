using Domain.Abstractions;
using Domain.Abstractions.Repositories;

namespace Persistence.Repositories
{
    internal class RepositoryBase<TEntity, TKey> : IRepositoryBase<TEntity, TKey>, IDisposable where TEntity : EntityBase<TKey>
    {
        private readonly ApplicationDbContext _dbContext;
        public RepositoryBase(ApplicationDbContext dbContext) => _dbContext = dbContext;
        public void Add(TEntity entity)
       => _dbContext.Add(entity);

        public void Dispose()
       => _dbContext.Dispose();

        public void Remove(TEntity entity)
           => _dbContext.Remove(entity);

        public void RemoveMultiple(List<TEntity> entities)
        {

        }

        public void Update(TEntity entity)
            => _dbContext.Update(entity);
    }
}
