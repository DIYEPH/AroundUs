using Domain.Abstractions.Entities;
using Microsoft.AspNetCore.Identity;

namespace Domain.Entities.Identity
{

    public class AppUser : IdentityUser<Guid>, IAuditable
    {
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public string? Latitude { get; set; }
        public string? Longitude { get; set; }
        public bool? IsDiscoverable { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset ModifiedDate { get; set; }
        public Guid CreatedBy { get; set; }
        public Guid ModifiedBy { get; set; }
        public bool IsDelete { get; set; }
        public DateTimeOffset? DeleteAt { get; set; }
        public virtual ICollection<IdentityUserRole<Guid>>? UserRoles { get; set; }
        public virtual ICollection<IdentityUserClaim<Guid>>? Claims { get; set; }
        public virtual ICollection<IdentityUserToken<Guid>>? Tokens { get; set; }
        public virtual ICollection<IdentityUserLogin<Guid>>? Logins { get; set; }
    }
}
