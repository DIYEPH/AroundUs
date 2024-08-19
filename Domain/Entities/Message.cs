using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AROUNDUS.Models
{
    public class Message
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        [ForeignKey(nameof(Sender))]
        public string SenderId { get; set; } = null!;
        public User Sender { get; set; } = null!;
        [ForeignKey(nameof(Receiver))]
        public string ReceiverId { get; set; } = null!;
        public User Receiver { get; set; } = null!;
        public string? Content { get; set; } = null!;
        public DateTime CreateAt { get; set; }
        [ForeignKey(nameof(Group))]
        public string GroupId { get; set; } = null!;
        public Group Group { get; set; } = null!;
        public ICollection<MessageAttachment> MessageAttachments { get; set; } = new HashSet<MessageAttachment>();
    }
}
