namespace Domain.Abstractions.Repositories
{
    public interface IRepositoryBase<TEntity, in T> where TEntity : class
    {
        /*        Task<TEntity> FindByIdAsync(T id,CancellationToken cancellationToken = default,params Expression<Func<TEntity, object>>[] inclu);
        */

        void Add(TEntity entity);
        void Update(TEntity entity);
        void Remove(TEntity entity);
        void RemoveMultiple(List<TEntity> entities);

    }
}
