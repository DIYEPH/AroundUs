using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AROUNDUS.Models
{
    public class MessageAttachment
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        [ForeignKey(nameof(Message))]
        public string MessageId { get; set; } = null!;
        public Message Message { get; set; } = null!;
        public string FileUrl { get; set; } = null!;
        public DateTime CreateAt { get; set; }
    }
}
