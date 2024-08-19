using Domain.Abstractions;

namespace Domain.Entities
{
    public abstract class Order : EntityAuditSoftDeleteBase<Guid>
    {
    }
}
