namespace Domain.Abstractions.Entities
{
    public interface IEntityAuditBase<T> : IEntityBase<T>, IAuditable, ISoftDelete
    {

    }
}
