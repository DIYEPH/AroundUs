using Domain.Abstractions.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class EFUnitOfWorkDbContext<TContext> : IUnitOfWorkDbContext<TContext> where TContext : DbContext
    {
        private readonly TContext _dbContext;
        public EFUnitOfWorkDbContext(TContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async ValueTask DisposeAsync()
                => await _dbContext.DisposeAsync();

        public DbContext GetDbContext()
       => _dbContext;

        public async Task SaveChangeAsync(CancellationToken cancellationToken = default)
       => await _dbContext.SaveChangesAsync();
    }
}
