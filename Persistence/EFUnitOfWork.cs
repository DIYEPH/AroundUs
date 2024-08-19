using Domain.Abstractions.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public EFUnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }
        public async ValueTask DisposeAsync()
        => await _context.DisposeAsync();

        public DbContext GetDbContext() => _context;

        public async Task SaveChangeAsync(CancellationToken cancellationToken = default)
        => await _context.SaveChangesAsync();
    }
}
