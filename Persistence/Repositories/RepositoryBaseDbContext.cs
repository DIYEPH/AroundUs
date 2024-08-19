using Domain.Abstractions;
using Domain.Abstractions.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Persistence.Repositories
{
    internal class RepositoryBaseDbContext<TContext, TEntity, TKey> : IRepositoryBaseDbContext<TContext, TEntity, TKey>, IDisposable where TContext : DbContext where TEntity : EntityBase<TKey>
    {
        private readonly TContext _Dbcontext;
        public RepositoryBaseDbContext(TContext dbcontext) => _Dbcontext = dbcontext ?? throw new ArgumentNullException(nameof(dbcontext));
        public void Add(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
           => _Dbcontext.Dispose();
        public IQueryable<TEntity> FindAll(Expression<Func<TEntity, bool>>? predicate = null, params Expression<Func<TEntity, object>>[] includeProprties)
        {
            IQueryable<TEntity> items = _Dbcontext.Set<TEntity>().AsNoTracking();//Importance Always include AsNotracking for Query Side
            if (includeProprties != null)
                foreach (var includeProprtie in includeProprties)
                    items = items.Include(includeProprtie);
            if (predicate is not null)
                items = items.Where(predicate);
            return items;
        }

        public void Remove(TEntity entity)
        {

        }

        public void RemoveMultiple(List<TEntity> entities)
        {

        }

        public void Update(TEntity entity)
        {

        }
    }
}
