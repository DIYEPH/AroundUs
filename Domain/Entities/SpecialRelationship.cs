using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AROUNDUS.Models
{
    public class SpecialRelationship
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        [ForeignKey(nameof(User))]
        public string UserId { get; set; } = null!;
        public User User { get; set; } = null!;
        [ForeignKey(nameof(RelateUser))]
        public string RelateUserId { get; set; } = null!;
        public User RelateUser { get; set; } = null!;
        public int RelationshipType { get; set; }
        public DateTime CreateAt { get; set; }
    }
}
