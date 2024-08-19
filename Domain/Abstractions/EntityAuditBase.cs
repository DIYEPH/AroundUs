using Domain.Abstractions.Entities;

namespace Domain.Abstractions
{
    public abstract class EntityAuditBase<T> : EntityBase<T>, IEntityAuditBase<T>
    {
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset ModifiedDate { get; set; }
        public Guid CreatedBy { get; set; }
        public Guid ModifiedBy { get; set; }
        public bool IsDelete { get; set; }
        public DateTimeOffset? DeleteAt { get; set; }
    }
}
