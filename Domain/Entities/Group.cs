using System.ComponentModel.DataAnnotations;

namespace AROUNDUS.Models
{
    public class Group
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string GroupName { get; set; } = null!;
        public DateTime CreateAt { get; set; }
        public ICollection<Message> Messages { get; set; } = new HashSet<Message>();
        public ICollection<GroupMember> Members { get; set; } = new HashSet<GroupMember>();

    }
}
