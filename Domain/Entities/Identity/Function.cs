using Domain.Abstractions;
using Domain.Abstractions.Entities;
using Domain.Enums;

namespace Domain.Entities.Identity
{
    public class Function : EntityBase<int>, IDateTracking
    {
        public string? Code { get; set; }
        public string Name { get; set; } = null!;
        public string Url { get; set; } = null!;
        public string? CssClass { get; set; }
        public int SortOrder { get; set; }
        public int ParentId { get; set; }
        public string Key { get; set; } = null!;
        public int ActionValue { get; set; }
        public FunctionStatus Status { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset ModifiedDate { get; set; }
    }
}
