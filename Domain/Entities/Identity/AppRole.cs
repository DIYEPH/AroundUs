using Domain.Abstractions.Entities;
using Microsoft.AspNetCore.Identity;

namespace Domain.Entities.Identity
{
    public class AppRole : IdentityRole<Guid>, IAuditable
    {
        public string? Description { get; set; }
        public string? RoleCode { get; set; }
        public virtual ICollection<IdentityUserRole<Guid>>? UserRoles { get; set; }
        public virtual ICollection<IdentityRoleClaim<Guid>>? Claims { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset ModifiedDate { get; set; }
        public Guid CreatedBy { get; set; }
        public Guid ModifiedBy { get; set; }
        public bool IsDelete { get; set; }
        public DateTimeOffset? DeleteAt { get; set; }
    }
}
