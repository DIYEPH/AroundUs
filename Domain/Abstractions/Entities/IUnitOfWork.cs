using Microsoft.EntityFrameworkCore;

namespace Domain.Abstractions.Entities
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        Task SaveChangeAsync(CancellationToken cancellationToken = default);
        DbContext GetDbContext();
    }
}
