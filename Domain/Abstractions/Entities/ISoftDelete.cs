namespace Domain.Abstractions.Entities
{
    public interface ISoftDelete
    {
        public bool IsDelete { get; set; }
        public DateTimeOffset? DeleteAt { get; set; }
        public void Undo()
        {
            IsDelete = false;
            DeleteAt = null;
        }
    }
}
