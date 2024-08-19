using Microsoft.EntityFrameworkCore;

namespace Domain.Abstractions.Entities
{
    public interface IUnitOfWorkDbContext<TContext> : IAsyncDisposable where TContext : DbContext
    {
        Task SaveChangeAsync(CancellationToken cancellationToken = default);
        DbContext GetDbContext();
    }
}
