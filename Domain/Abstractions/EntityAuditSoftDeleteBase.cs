using Domain.Abstractions.Entities;

namespace Domain.Abstractions
{
    public abstract class EntityAuditSoftDeleteBase<T> : EntityBase<T>, ISoftDelete
    {
        public bool IsDelete { get; set; }
        public DateTimeOffset? DeleteAt { get; set; }
    }
}
