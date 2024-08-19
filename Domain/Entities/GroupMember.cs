using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AROUNDUS.Models
{
    public class GroupMember
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        [ForeignKey(nameof(Group))]
        public string GroupId { get; set; } = null!;
        public Group Group { get; set; } = null!;
        [ForeignKey(nameof(Member))]
        public string MemberId { get; set; } = null!;
        public User Member { get; set; } = null!;
        public int Role { get; set; }
    }
}
